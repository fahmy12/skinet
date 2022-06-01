using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _context;
        //@ 16 -> 1:20
        //when we inject something into our conroller, as in this way or any class, then it's given a lifetime
        //so when a request comes in, it hits our ProductsController, then a new instance of this ProductsController
        //is going to be created, and when this controller is created, it's going to see what its dependanceis are
        //and in this case, it's got a dependancy on the StoreContext, and this is going to create a new instance of 
        //the StoreContext that we can then work with
        public ProductsController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _context.Products.FindAsync(id);
        }
        
    }
}