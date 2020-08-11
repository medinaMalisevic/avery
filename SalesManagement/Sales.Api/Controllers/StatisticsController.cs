using System;
using Microsoft.AspNetCore.Mvc;
using Sales.Service;

namespace Sales.Api.Controllers
{
    /// <summary>
    /// Statistics presenting controller
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        readonly ISalesQueryService salesService;

        public StatisticsController(ISalesQueryService salesService)
        {
            this.salesService = salesService;
        }

        /// <summary>
        /// Gets number of sold articles per day
        /// </summary>
        /// <param name="date">Date query parameter</param>
        /// <returns>Action result depending on execution</returns>
        [HttpGet("articles")]
        public IActionResult GetNumberOfSoldArticles(DateTime date)
        {
            return Ok(salesService.GetNumberOfSoldArticles(date));
        }

        /// <summary>
        /// Gets total revenue per day
        /// </summary>
        /// <param name="date">Date query parameter</param>
        /// <returns>Action result depending on execution</returns>
        [HttpGet("revenue")]
        public IActionResult GetTotalRevenue(DateTime date)
        {
            return Ok(salesService.GetTotalRevenue(date));
        }

        /// <summary>
        /// Gets total revenue per article
        /// </summary>
        /// <returns>Action result depending on execution</returns>
        [HttpGet("articles/revenue")]
        public IActionResult GetRevenuesByArticles()
        {
            return Ok(salesService.GetRevenuesByArticles());
        }
    }
}
