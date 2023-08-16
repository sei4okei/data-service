using DataService.Interfaces;
using DataService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace DataService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealController : ControllerBase
    {
        private readonly IDealService dealService;
        private readonly HttpClient httpClient;

        public DealController(IDealService _dealService)
        {
            httpClient = new HttpClient();
            dealService = _dealService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var deals = await dealService.GetAll();

            if (deals == null) return BadRequest();
            
            return Ok(deals);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var deal = await dealService.GetById(id);

            if (deal == null) return BadRequest();

            return Ok(deal);
        }

        [HttpGet("NoTrack/{id}")]
        public async Task<IActionResult> GetByIdNoTracking(int id)
        {
            var deal = await dealService.GetByIdNoTracking(id);

            if (deal == null) return BadRequest();

            return Ok(deal);
        }

        [HttpPost]
        public IActionResult Post(Deal deal)
        {
            var isCreated = dealService.Add(deal);

            if (!isCreated) return BadRequest(isCreated);

            return Ok(isCreated);
        }

        [HttpPut]
        public IActionResult Update(Deal deal)
        {
            var isUpdated = dealService.Update(deal);

            if (!isUpdated) return BadRequest(isUpdated);

            return Ok(isUpdated);
        }

        [HttpPut("Delete")]
        public IActionResult Delete(Deal deal)
        {
            var isDeleted = dealService.Delete(deal);

            if (!isDeleted) return BadRequest(isDeleted);

            return Ok(isDeleted);
        }
    }
}
