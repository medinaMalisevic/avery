using Sales.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sales.Repository
{
    /// <summary>
    /// SQL repository managing Sales.DB
    /// </summary>
    public class SqlSalesRepository : ISalesRepository
    {
        readonly SalesContext context;

        public SqlSalesRepository(SalesContext context)
        {
            this.context = context ?? throw new ArgumentNullException("context");
        }

        /// <summary>
        /// Inserts sale data
        /// </summary>
        /// <param name="saleDataDto">SaleDataDTO parameter</param>
        /// <returns>Key-value pair of ID and DTO</returns>
        public KeyValuePair<Guid, SaleDataDto> CreateSale(SaleDataDto saleDataDto)
        {
            var saleData = context.SalesData.Add(new SaleData(saleDataDto.ArticleNumber, saleDataDto.Price));
            context.SaveChanges();

            return new KeyValuePair<Guid, SaleDataDto>((Guid)saleData.Entity.Id, saleData.Entity.ToDto());
        }

        /// <summary>
        /// Gets number of sold articles per day
        /// </summary>
        /// <param name="date">Date parameter</param>
        /// <returns>Number of sold articles</returns>
        public int GetNumberOfSoldArticles(DateTime date)
        {
            return context.SalesData.Where(w => w.DateCreated.Date == date.Date && w.DateCreated.Month == date.Month && w.DateCreated.Year == date.Year)
                                    .Count();
        }

        /// <summary>
        /// Gets sale data by ID
        /// </summary>
        /// <param name="id">ID parameter</param>
        /// <returns>SaleDataDTO</returns>
        public SaleDataDto GetSale(Guid id)
        {
            return context.SalesData.FirstOrDefault(f => f.Id == id).ToDto();
        }

        /// <summary>
        /// Gets total revenue per day
        /// </summary>
        /// <param name="date">Date parameter</param>
        /// <returns>Total revenue</returns>
        public decimal GetTotalRevenue(DateTime date)
        {
            return context.SalesData.Where(w => w.DateCreated.Date == date.Date && w.DateCreated.Month == date.Month && w.DateCreated.Year == date.Year)
                                    .Sum(s => s.Price);
        }

        /// <summary>
        /// Gets revenues per articles
        /// </summary>
        /// <returns>Articles' statistics</returns>
        public List<ArticleStatistic> GetRevenuesByArticles()
        {
            return context.SalesData.GroupBy(g => g.ArticleNumber)
                                    .Select(s => new ArticleStatistic { ArticleNumber = s.Key, Revenue = s.Sum(su => su.Price) })
                                    .ToList();
        }
    }
}
