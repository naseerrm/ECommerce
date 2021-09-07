using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModel
{
    public class AddProductViewModel
    {
        public string ProductName { get; set; }
        public int StockCount { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int ProductCategoryId { get; set; }
        public int DiscountPercentage { get; set; }
        public IFormFile PosterImg { get; set; }
    }
}
