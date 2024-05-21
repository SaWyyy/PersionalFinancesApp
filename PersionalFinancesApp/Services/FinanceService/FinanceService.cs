using Microsoft.EntityFrameworkCore;
using PersionalFinancesApp.Data;
using PersionalFinancesApp.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace PersionalFinancesApp.Services.FinanceService
{
    public class FinanceService : IFinanceService
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _accesor;

        public FinanceService(AppDbContext context, IHttpContextAccessor accesor)
        {
            _context = context;
            _accesor = accesor;
        }

        public async Task<List<FinanceRecord>> AddFinanceRecord(FinanceRecord record)
        {
            var user = _accesor.HttpContext?.User;
            var userId = user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId is null)
            {
                return null;
            }
            var newRecord = new FinanceRecord
            {
                Name = record.Name,
                Description = record.Description,
                Category = record.Category,
                Price = record.Price,
                Date = DateTime.Now.ToString("dd-MM-yyyy"),
                UserId = userId
            };

            _context.Finances.Add(newRecord);

            await _context.SaveChangesAsync();

            var result = await _context.Finances.Where(x => x.UserId == userId).ToListAsync();

            return result;
        }

        public async Task<List<FinanceRecord>> GetAllFinances()
        {
            var user = _accesor.HttpContext?.User;
            var userId = user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId is null)
            {
                return null;
            }
            var result = await _context.Finances.Where(x => x.UserId == userId).ToListAsync();

            return result;
        }

        public async Task<FinanceRecord> GetSingleFinance(int id)
        {
            var user = _accesor.HttpContext?.User;
            var userId = user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId is null)
            {
                return null;
            }
            var result = await _context.Finances.Where(x => x.UserId == userId && x.Id == id).FirstOrDefaultAsync();

            return result;
        }

        public async Task<FinanceRecord> UpdateFinanceRecord(int id, FinanceRecord record)
        {
            var result = await _context.Finances.FindAsync(id);
            if (result is null)
            {
                return null;
            }

            result.Name = record.Name;
            result.Description = record.Description;
            result.Category = record.Category;
            result.Price = record.Price;

            await _context.SaveChangesAsync();

            return result;
        }

        public async Task<FinanceRecord> DeleteFinanceRecord(int id)
        {
            var result = await _context.Finances.FindAsync(id);
            if (result is null)
            {
                return null;
            }
            _context.Finances.Remove(result);

            await _context.SaveChangesAsync();

            return result;
        }
    }
}
