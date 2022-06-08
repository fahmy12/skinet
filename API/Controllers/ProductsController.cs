using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
         private readonly IProductRepository _repo;

        //@ 16 -> 1:20
        //when we inject something into our conroller, as in this way or any class, then it's given a lifetime
        //so when a request comes in, it hits our ProductsController, then a new instance of this ProductsController
        //is going to be created, and when this controller is created, it's going to see what its dependanceis are
        //and in this case, it's got a dependancy on the StoreContext, and this is going to create a new instance of 
        //the StoreContext that we can then work with
       
        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
 
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _repo.GetProductsAsync();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _repo.GetProductByIdAsync(id);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _repo.GetProductBrandsAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _repo.GetProductTypesAsync());
        }
        
    }
}