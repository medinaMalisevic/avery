using System;
using System.Collections.Generic;

namespace Sales.Service
{
    /// <summary>
    /// Sales query service
    /// </summary>
    public class SalesService : ISalesQueryService
    {
        readonly ISalesRepository salesRepository;

        public SalesService(ISalesRepository salesRepository)
        {
            this.salesRepository = salesRepository;
        }

        /// <summary>
        /// Gets number of sold articles per day
        /// </summary>
        /// <param name="date">Date parameter</param>
        /// <returns>Number of articles</returns>
        public int GetNumberOfSoldArticles(DateTime date)
        {
            return salesRepository.GetNumberOfSoldArticles(date);
        }

        /// <summary>
        /// Gets revnues per articles
        /// </summary>
        /// <returns>Articles' statistics</returns>
        public List<ArticleStatistic> GetRevenuesByArticles()
        {
            return salesRepository.GetRevenuesByArticles();
        }

        /// <summary>
        /// Gets sale data per ID
        /// </summary>
        /// <param name="id">ID parameter</param>
        /// <returns>SaleDataDTO</returns>
        public SaleDataDto GetSale(Guid id)
        {
            return salesRepository.GetSale(id);
        }

        /// <summary>
        /// Gets total revenue per day
        /// </summary>
        /// <param name="date">Date parameter</param>
        /// <returns>Total revenue</returns>
        public decimal GetTotalRevenue(DateTime date)
        {
            return salesRepository.GetTotalRevenue(date);
        }
    }
}
