using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersionalFinancesApp.Models;
using PersionalFinancesApp.Services.FinanceService;

namespace PersionalFinancesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FinancesController : ControllerBase
    {
        private readonly IFinanceService _service;

        public FinancesController(IFinanceService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<FinanceRecord>>> GetAllFinances()
        {
            return await _service.GetAllFinances();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FinanceRecord>> GetSingleFinance(int id)
        {
            return await _service.GetSingleFinance(id);
        }

        [HttpPost]
        public async Task<ActionResult<List<FinanceRecord>>> AddFinanceResult(FinanceRecord record)
        {
            return await _service.AddFinanceRecord(record);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<FinanceRecord>> UpdateFinanceRecord(int id, FinanceRecord record)
        {
            return await _service.UpdateFinanceRecord(id, record);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<FinanceRecord>> DeleteFinanceRecord(int id)
        {
            return await _service.DeleteFinanceRecord(id);
        }
    }
}
