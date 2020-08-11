using System;

namespace Sales.Service
{
    /// <summary>
    /// Represents a create sale command
    /// </summary>
    public class CreateSale
    {
        public Guid? Id { get; set; }

        public SaleDataDto Sale { get; set; }
    }
}
