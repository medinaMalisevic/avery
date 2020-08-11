using System;
using System.ComponentModel.DataAnnotations;

namespace Sales.Service
{
    /// <summary>
    /// Sale data DTO
    /// </summary>
    public class SaleDataDto
    {
        public SaleDataDto()
        {}

        public SaleDataDto(string articleNo, decimal price)
        {
            ArticleNumber = articleNo;
            Price = price;
        }

        /// <summary>
        /// Alphanumeric code for article
        /// </summary>
        [Required]
        [MaxLength(32)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string ArticleNumber { get; set; }

        /// <summary>
        /// Price of article in this sale
        /// </summary>
        [Range(0, (double)decimal.MaxValue)]
        public decimal Price { get; set; }
    }
}
