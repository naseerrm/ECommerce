using DomainLayer.Models;
using DomainLayer.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ServiceLayer.IServices;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EcommerceBackend.Controllers
{
    [Route("api/Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public IConfiguration Configuration { get; }
        private readonly IProductImageService _productImage;
        private readonly IProductCategoryService _productCategory;
        private readonly IProductService _product;
        public ProductController(IConfiguration configuration,IProductImageService productImage, IProductService product, IProductCategoryService productCategory)
        {
            Configuration = configuration;
            _product = product;
            _productImage = productImage;
            _productCategory = productCategory;
        }

        [HttpGet]
        [Route("GetAllProductCategoryList")]
        public IActionResult GetAllProductCategoryList()
        {
            return Ok(_productCategory.GetAllProductCategoryDetails());
        }

        [HttpGet]
        [Route("GetProductByProductCategoryId")]
        public IActionResult GetProductByProductCategoryId(int productCategoryId)
        {
            return Ok(_product.GetProductByProductCategoryId(productCategoryId));
        }

        [HttpPost, DisableRequestSizeLimit]
        [Route("AddProduct")]
        public IActionResult AddProduct(AddProductViewModel addProductViewModel)
        {
            try
            {
                var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
                var userId = "";
                if (identity != null)
                {
                    // Get the claims values
                    var name = identity.Claims.Where(c => c.Type == ClaimTypes.Name)
                                       .Select(c => c.Value).SingleOrDefault();
                    var email = identity.Claims.Where(c => c.Type == ClaimTypes.Email)
                                       .Select(c => c.Value).SingleOrDefault();
                    userId = identity.Claims.Where(c => c.Type == ClaimTypes.Sid)
                                       .Select(c => c.Value).SingleOrDefault();
                }
                Product product = new Product
                {
                    ProductCategoryId = addProductViewModel.ProductCategoryId,
                    ProductName = addProductViewModel.ProductName,
                    Description = addProductViewModel.Description,
                    StockCount = addProductViewModel.StockCount,
                    Price = addProductViewModel.Price,
                    DiscountPercentage = addProductViewModel.DiscountPercentage,
                    SupplierId = userId != "" ? Convert.ToInt32(userId) : 1
                };
                _product.InsertProduct(product);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message.ToString());
            }
        }

        [HttpPost, DisableRequestSizeLimit]
        [Route("UploadProductImage")]
        public IActionResult UploadProductImage()
        {
            try
            {
                var files = Request.Form.Files;
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (files.Any(f => f.Length == 0))
                {
                    return BadRequest();
                }
                foreach (var file in files)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName); //you can add this path to a list and then return all dbPaths to the client if require

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    ProductImage productImage = new ProductImage
                    {
                        ProductId = 1,
                        ProductLinkType = ProductViewType.Image,
                        ProductImageLink = dbPath
                    };
                    _productImage.InsertProductImage(productImage);

                }
                return Ok("Upload SuccessFully...!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }


        [HttpPost, DisableRequestSizeLimit]
        [Route("AddProductDetails")]
        public async Task<IActionResult> AddProductDetails([FromForm] AddProductViewModel addProductViewModel)
        {
            try
            {
                if (addProductViewModel == null)
                {
                    return BadRequest("object is null");
                }
                var reqFile = Request.Form.Files;
                var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
                var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                var user = HttpContext.User;
                int userId = attachUserToContext(token);
                return Ok();
            }
            catch (Exception ex)
            {

            }
            return Ok();
        }

        private int attachUserToContext(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(Configuration["JWT:Secret"]);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
               return int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);
            }
            catch(Exception ex)
            {
                // do nothing if jwt validation fails
                // user is not attached to context so request won't have access to secure routes
            }
            return 0;
        }
    }
}
