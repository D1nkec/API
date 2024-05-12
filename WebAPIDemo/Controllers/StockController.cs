using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIDemo.Data;
using WebAPIDemo.Dtos.Stock;
using WebAPIDemo.Helpers;
using WebAPIDemo.Mapping;
using WebAPIDemo.Services.Interfaces;

namespace WebAPIDemo.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;
        private readonly ApplicationDbContext _context;
        public StockController(ApplicationDbContext context, IStockService stockService)
        {
            _stockService = stockService;
            _context = context;
        }



        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stocks = await _stockService.GetAllAsync(query);
            var stockDto = stocks.Select(s => s.ToStockDto()).ToList();
            return Ok(stockDto);
        }



        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stock = await _stockService.GetByIdAsync(id);
            if(stock == null)
            {
                return NotFound();
            }
            return Ok(stock.ToStockDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stockModel = stockDto.ToStockFromCreateDTO();
           await _stockService.CreateAsync(stockModel);
            return CreatedAtAction(nameof(GetById), new {id = stockModel.Id}, stockModel.ToStockDto());
        }


        [HttpPut]
        [Route("{id:int}")]
        public async Task <IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stockModel = await _stockService.UpdateAsync(id, updateDto);
            if(stockModel == null)
            {
                return NotFound();
            }


            return Ok(stockModel.ToStockDto());
        }


        [HttpDelete]
        [Route("{id:int}")]

        public async Task <IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stockModel = await _stockService.DeleteAsync(id);
            if(stockModel == null)  
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
