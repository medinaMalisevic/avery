using System;
using System.Collections.Generic;

namespace Sales.Service
{
    /// <summary>
    /// Command service for inserting sale data
    /// </summary>
    public class CreateSaleService : ICommandService<CreateSale>
    {
        readonly ISalesRepository salesRepository;

        public CreateSaleService(ISalesRepository salesRepository)
        {
            this.salesRepository = salesRepository;
        }

        /// <summary>
        /// Inserts sale data
        /// </summary>
        /// <param name="command">Create sale parameter object</param>
        public void Execute(CreateSale command)
        {
            KeyValuePair<Guid, SaleDataDto> result = salesRepository.CreateSale(command.Sale);
            command.Id = result.Key;
            command.Sale = result.Value;
        }
    }
}
