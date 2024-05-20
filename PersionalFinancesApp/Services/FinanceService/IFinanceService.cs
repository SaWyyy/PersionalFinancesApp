using PersionalFinancesApp.Models;

namespace PersionalFinancesApp.Services.FinanceService
{
    public interface IFinanceService
    {
        Task<FinanceRecord> GetSingleFinance(int id);
        Task<List<FinanceRecord>> GetAllFinances();
        Task<List<FinanceRecord>> AddFinanceRecord(FinanceRecord record);
        Task<FinanceRecord> UpdateFinanceRecord(int id, FinanceRecord record);
        Task<FinanceRecord> DeleteFinanceRecord(int id);
    }
}
