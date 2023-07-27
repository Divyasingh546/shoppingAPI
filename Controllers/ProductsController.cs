using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shoppingAPI_inMemoryCollection;
using shoppingAPI_inMemoryCollection.Models;
using System.Net;

namespace shoppingAPI_inMemoryCollection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        Products pObj = new Products();//should use dependency injection instead of creating new product

        [HttpGet]
        [Route("/products")]
        public IActionResult GetAllProduct()
        {
            return Ok(pObj.GetAllProducts);
        }

        [HttpGet]
        [Route("/products/category/{category}")]
        public IActionResult GetAllProductsByCategory(string category) {
            try
            {
                return Ok(pObj.GetProductsByCategory(category));
            }
            catch (Exception es) {
                return NotFound(es.Message);
            }

        }

        [HttpGet]
        [Route("/products/id/{id}")]
        public IActionResult GetProductById(int id)
        {
            try
            {
                return Ok(pObj.GetProductById(id));
            }
            catch(Exception es) {
                return NotFound(es.Message);
            }
        }

        [HttpGet]
        [Route("/products/count")]
        public IActionResult GettotalProducts()
        {
            return Ok(pObj.GetAllProducts());
        }

       [HttpGet]
        [Route("/products/avability/{yesorno}")]
        public IActionResult GetProductsInStock( bool yesorno)
        {
            try
            {
                return Ok(pObj.GetProductsIsInStock(yesorno));
            }
            catch (Exception es) 
            {
                return NotFound(es.Message);
            }
        }


        [HttpPost]
        [Route("/products/add")]
        public IActionResult AddnewProduct(Products newProduct)
        {
            string result = pObj.AddNewProduct(newProduct);
            return Created("", result);
        }

        [HttpDelete]
        [Route("/products/delete/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                string result = pObj.DeleteProduct(id);
                return Accepted(result);
            }
            catch (Exception es)
            {
                return NotFound(es.Message);
            }


        }


        [HttpPut]
        [Route("/products/update")]
        public IActionResult UpdateProduct(Products changes) {
            try
            {
                string result = pObj.UpdateProduct(changes);
                return Accepted(result);
            }
            catch(Exception es)
            {
                return NotFound(es.Message);
            }
        }

    }
}
