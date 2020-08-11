using Sales.Service;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sales.Repository
{
    /// <summary>
    /// Sale data entity representing Sales table
    /// </summary>
    [Table("Sales")]
    public class SaleData
    {
        public SaleData(string articleNumber, decimal price)
        {
            ArticleNumber = articleNumber;
            Price = price;
        }

        public Guid? Id { get; set; }

        [Required]
        [MaxLength(32)]
        public string ArticleNumber { get; set; }

        public decimal Price { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Converts SaleData entity to DTO
        /// </summary>
        /// <returns>SaleDataDTO</returns>
        public SaleDataDto ToDto()
        {
            return new SaleDataDto(ArticleNumber, Price);
        }
    }
}
