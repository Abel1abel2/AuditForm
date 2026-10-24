using AuditForm.Dtos;
using Microsoft.AspNetCore.Authentication;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.ActiveDirectory;
using System.Runtime.InteropServices;

namespace AuditForm.Repositary
{
    public class LDPServices 
    {
        private readonly IConfiguration _config;
        private readonly ILogger<LDPServices> _logger;

        private string LdpUsername = string.Empty;
        private string LdpPassword = string.Empty;
        private int LdpPort = -1;
        private string LdpServer;
        private string LdpPath;
        public LDPServices(IConfiguration config, ILogger<LDPServices> logger)
        {
            _logger = logger;
            _config = config;
        }

        private async Task GetConigInfo()
        {
            LdpUsername = _config["Ldap:Username"];
            LdpPassword = _config["Ldap:Password"];
            LdpPath = _config["Ldap:Server"] ?? $"LDAP://{Domain.GetCurrentDomain().Name}";
        }

        public async Task<List<DomainUser>> SearchUsersByFullName(string? fullName)
        {
            await GetConigInfo();
            var users = new List<DomainUser>();

            // Validate fullName
            if (string.IsNullOrWhiteSpace(fullName))
            {
                throw new ArgumentException("Full name cannot be null or empty", nameof(fullName));
            }

            string ldapPath = LdpServer;

            try
            {
                using (var entry = new System.DirectoryServices.DirectoryEntry(LdpServer, LdpUsername, LdpPassword))
                {
                    using (var searcher = new DirectorySearcher(entry))
                    {
                        // Corrected filter
                        searcher.Filter = $"(&(objectClass=user)(displayName=*{fullName}*))";
                        searcher.PropertiesToLoad.Add("displayName");
                        searcher.PropertiesToLoad.Add("sAMAccountName");

                        foreach (SearchResult result in searcher.FindAll())
                        {
                            var user = new DomainUser
                            {
                                DisplayName = result.Properties["displayName"].Count > 0 ? result.Properties["displayName"][0].ToString() : string.Empty,
                                Username = result.Properties["sAMAccountName"].Count > 0 ? result.Properties["sAMAccountName"][0].ToString() : string.Empty
                            };
                            users.Add(user);
                        }
                    }
                }
            }
            catch (COMException comEx)
            {
                Console.WriteLine($"COM Exception: {comEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Exception: {ex.Message}");
            }

            return users;
        }
        public async Task<DomainUser> SearchUserByUsername(string username)
        {
            await GetConigInfo();
            // Validate username
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("Username cannot be null or empty", nameof(username));
            }

            DomainUser user = null; //

            try
            {
                using (var entry = new DirectoryEntry(LdpServer, LdpUsername, LdpPassword))
                {
                    using (var searcher = new DirectorySearcher(entry))
                    {
                        // Use the correct filter for username
                        searcher.Filter = $"(&(objectClass=user)(sAMAccountName={username}))";
                        searcher.PropertiesToLoad.Add("displayName");
                        searcher.PropertiesToLoad.Add("sAMAccountName");

                        var result = searcher.FindOne(); // Find a single result

                        if (result != null)
                        {
                            user = new DomainUser
                            {
                                DisplayName = result.Properties["displayName"].Count > 0 ? result.Properties["displayName"][0].ToString() : string.Empty,
                                Username = result.Properties["sAMAccountName"].Count > 0 ? result.Properties["sAMAccountName"][0].ToString() : string.Empty
                            };
                        }
                    }
                }
            }
            catch (COMException comEx)
            {
                Console.WriteLine($"COM Exception: {comEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Exception: {ex.Message}");
            }

            return user; // Return the found user or null
        }

        public async Task<List<DomainUser>> SearchUsers(string searchTerm)
        {
            await GetConigInfo();
            var results = new List<DomainUser>();

            if (string.IsNullOrWhiteSpace(searchTerm) || searchTerm.Length < 2)
            {
                return results;
            }

            try
            {

                using var entry = new DirectoryEntry(LdpPath);
                using var searcher = new DirectorySearcher(entry)
                {
                    Filter = $"(|(sAMAccountName=*{searchTerm}*)(displayName=*{searchTerm}*))",
                    PropertiesToLoad = { "sAMAccountName", "displayName", "mail" },
                    PageSize = 100
                };

                using var searchResults = searcher.FindAll();

                foreach (SearchResult result in searchResults)
                {
                    results.Add(new DomainUser
                    {
                        Username = result.Properties["sAMAccountName"]?[0]?.ToString() ?? "",
                        DisplayName = result.Properties["displayName"]?[0]?.ToString() ?? ""
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "LDAP search failed");
            }

            return results;
        }

        public async Task<bool> ValidateUser(string username, string password)
        {
            await GetConigInfo();
            using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, "addisbanksc.local"))
            {
                bool isValid = pc.ValidateCredentials(username, password);
                return isValid;
            }

        }

        public async Task<DomainUser> GetUserInformation(string username)
        {
            await GetConigInfo();
            using (var context = new PrincipalContext(ContextType.Domain))
            {
                using (var user = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, username))
                {

                    if (user != null)
                    {
                        var userInformation = new DomainUser
                        {
                            Username = username,
                            DisplayName = user.DisplayName,
                        };

                        return userInformation;
                    }
                }
            }

            return null;
        }

    }
}
