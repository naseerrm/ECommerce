using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.IServices;
using ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceBackend.ExtensionMethod
{
    public static class ExtenstionServices
    {
        public static void ExtenstionService(this IServiceCollection services)
        {
            services.AddTransient<ISupplierService, SupplierService>();
            services.AddTransient<IProductCategoryService, ProductCategoryService>();
            services.AddTransient<IProductImageService, ProductImageService>();
            services.AddTransient<IProductService, ProductService>();
        }
    }
}
