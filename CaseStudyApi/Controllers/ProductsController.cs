using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CaseStudyApi.Data;
using CaseStudyApi.Models;
using Microsoft.AspNetCore.Cors;

namespace CaseStudyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class ProductsController : ControllerBase
    {
        private readonly CaseStudyApiContext _context;

        public ProductsController(CaseStudyApiContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            return await _context.Product.ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }
        //GET : api/{category}/product/Snackss..
        [HttpGet]
        [Route("/api/{category}/products")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByCategory(string category)
        {
            var productsList = await _context.Product.ToListAsync();
            var products = productsList.Where(p=>p.Category.ToLower().Equals(category.ToLower())).ToList();
            if(products.Count==0)
            {
                return NotFound();
            }
            return products;
        }
        //GET : api/{id}/seller/1....
        [HttpGet]
        [Route("api/{id}/seller")]
        public async Task<ActionResult<Seller>> GetSellerInfo(int id)
        {
            Product? Product = await _context.Product.FindAsync(id);
            int? sellerId = Product.SId;
            Seller? seller = await _context.Seller.FindAsync(sellerId);
            if(seller == null)
            {
                return NotFound();
            }
            return seller;
        }
        //GET : api/{id}/products/SId==1
        [HttpGet]
        [Route("api/{id}/product")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductBySeller(int id)
        {
            var productsList = await _context.Product.ToListAsync();
            var products = productsList.Where(p => p.SId == id).ToList();
            if(products.Count == 0)
            {
                return NotFound();
            }
            return products;
        }
        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.PId)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Product.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.PId }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.PId == id);
        }

        [HttpPost]
        [Route("/api/Order")]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            _context.Order.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = order.Id }, order);
        }
        [HttpGet]
        [Route("/api/{id}/customerdetails")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomerBypid(int id)
        {
            var orders = await _context.Order.Where(o=>o.PId==id).ToListAsync();
            var customers = new List<Customer>();
            foreach(var order in orders)
            {
                customers.Add(await _context.Customer.FindAsync(order.CId));
            }
            
            if (customers.Count == 0)
            {
                return NotFound();
            }
            return customers;
        }
    }
}
