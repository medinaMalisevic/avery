using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Service
{
    /// <summary>
    /// Abstraction representing all query services
    /// </summary>
    public interface ISalesQueryService
    {
        SaleDataDto GetSale(Guid id);

        int GetNumberOfSoldArticles(DateTime date);

        decimal GetTotalRevenue(DateTime date);

        public List<ArticleStatistic> GetRevenuesByArticles();
    }
}
