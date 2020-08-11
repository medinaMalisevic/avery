using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Sales.Api.Controllers;
using Sales.Repository;
using Sales.Service;
using System;

namespace Sales.Api
{
    /// <summary>
    /// DI container, pure DI
    /// </summary>
    public class SalesManagementControllerActivator : IControllerActivator
    {
        readonly CommerceConfiguration configuration;

        public SalesManagementControllerActivator(CommerceConfiguration configuration)
        {
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public object Create(ControllerContext context) =>
            Create(context.ActionDescriptor.ControllerTypeInfo.AsType());

        public void Release(ControllerContext context, object controller) =>
            (controller as IDisposable)?.Dispose();

        public ControllerBase Create(Type type)
        {
            // Create Scoped components
            var context = new SalesContext(configuration.ConnectionString);
            
            var salesRepo = CreateSalesRepository(context);

            // Create Transient components
            switch (type.Name)
            {
                case nameof(SalesController):
                    return new SalesController(
                        new ValidationCommandServiceDecorator<CreateSale>(
                            new CreateSaleService(
                                salesRepo)),
                        new SalesService(
                            salesRepo));

                case nameof(StatisticsController):
                    return new StatisticsController(
                        new SalesService(
                            salesRepo));

                case nameof(ErrorController):
                    return new ErrorController();

                default: throw new InvalidOperationException($"Unknown controller {type}.");
            }
        }

        private ISalesRepository CreateSalesRepository(SalesContext context) =>
            (ISalesRepository)Activator.CreateInstance(configuration.ProductRepositoryType, context);
    }
}
