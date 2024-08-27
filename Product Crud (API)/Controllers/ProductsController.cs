using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Product_Crud__API_.Models;

namespace Product_Crud__API_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        List<Product> products = new List<Product>
        {
            new Product { Id=1, Name = "Laptop", Description="This is Laptop" },
            new Product { Id=2, Name= "Mouse", Description="This is Mouse"},
            new Product { Id=3, Name= "Keyboard", Description="This is Keyboard"}
        };


        [HttpGet("GetAllProduct")]
        public IActionResult GetALL()
        {
            return Ok(products);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = products.Find(e => e.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }


        [HttpPost]
        public IActionResult AddProduct(Product request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            var NewProduct = new Product
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
            };

            products.Add(NewProduct);
            return Ok(NewProduct);
        }
        

        [HttpPut("{id}")]
        public IActionResult Update(int id, Product request)
        {
            var CurrentProduct = products.Find(e => e.Id == id);
            if (CurrentProduct == null)
            {
                return NotFound();
            }

            CurrentProduct.Name = request.Name;
            CurrentProduct.Description = request.Description;
            return Ok(CurrentProduct);
        }
         

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(e => e.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            products.Remove(product);
            return Ok();
        }
    }
}