using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EComm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EComm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private ECommDataContext _dataContext;

        public ProductsController(ECommDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            var products = _dataContext.Products.ToList();

            return products;
        }

        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var product = _dataContext.Products.SingleOrDefault(p => p.Id == id);

            if (product == null) return NotFound();

            return product;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            _dataContext.Attach(product);
            _dataContext.Entry(product).State = EntityState.Added;
            _dataContext.SaveChanges();

            return CreatedAtAction("Get", new { id = product.Id }, product);
        }

        // PUT api/products/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            if (product == null || product.Id != id)
            {
                return BadRequest();
            }
            var existing = _dataContext.Products
                .SingleOrDefault(p => p.Id == id);

            if (existing == null) return NotFound();

            existing.ProductName = product.ProductName;
            existing.UnitPrice = product.UnitPrice;
            existing.Package = product.Package;
            existing.IsDiscontinued = product.IsDiscontinued;
            existing.SupplierId = product.SupplierId;
            _dataContext.SaveChanges();

            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // delete from database
        }
    }
}