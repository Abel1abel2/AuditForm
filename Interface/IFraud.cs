using AuditForm.Model;

namespace AuditForm.Interface
{
    public interface IFraud
    {
        Task AddAsync(Fraud fraud);
    }
}
