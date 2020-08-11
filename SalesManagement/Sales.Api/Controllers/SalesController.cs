using System;
using Microsoft.AspNetCore.Mvc;
using Sales.Service;

namespace Sales.Api.Controllers
{
    /// <summary>
    /// Sales operating controller
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        readonly ICommandService<CreateSale> service;
        readonly ISalesQueryService queryService;

        public SalesController(ICommandService<CreateSale> service, ISalesQueryService queryService)
        {
            this.service = service;
            this.queryService = queryService;
        }

        /// <summary>
        /// Inserts sales data
        /// </summary>
        /// <param name="saleDataDto">Sales data DTO</param>
        /// <returns>Action result depending on execution</returns>
        [HttpPost]
        public IActionResult Post([FromBody]SaleDataDto saleDataDto)
        {
            CreateSale command = new CreateSale
            {
                Sale = saleDataDto
            };
            service.Execute(command);

            return CreatedAtAction(nameof(GetById), new { id = command.Id }, command.Sale);
        }

        /// <summary>
        /// Gets unique sale data
        /// </summary>
        /// <param name="id">Unique ID parameter</param>
        /// <returns>Action result depending on execution</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            SaleDataDto salesDataDto = queryService.GetSale(id);
            if (salesDataDto == null)
                return NotFound();

            return Ok(salesDataDto);
        }
    }
}
