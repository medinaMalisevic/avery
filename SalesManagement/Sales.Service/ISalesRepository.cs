using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Service
{
    /// <summary>
    /// Abstraction representing sales repository
    /// </summary>
    public interface ISalesRepository
    {
        KeyValuePair<Guid, SaleDataDto> CreateSale(SaleDataDto saleDataDto);

        SaleDataDto GetSale(Guid id);

        int GetNumberOfSoldArticles(DateTime date);

        decimal GetTotalRevenue(DateTime date);

        List<ArticleStatistic> GetRevenuesByArticles();
    }
}
