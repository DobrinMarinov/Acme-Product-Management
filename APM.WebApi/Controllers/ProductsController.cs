using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Web.Http.OData;
using APM.WebApi.Models;
using APM.WebAPI.Models;

namespace APM.WebApi.Controllers
{
    //[EnableCors(origins: "http://localhost:51639", headers: "*", methods:"*")]
    public class ProductsController : ApiController
    {
        // GET: api/Product
        [EnableQuery]
        [ResponseType(typeof(Product))]
        public IHttpActionResult Get()
        {
            try
            {
                var productRepository = new ProductRepository();
                return Ok(productRepository.Retrieve().AsQueryable());
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            
        }

        // GET: api/Product/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                //throw new ArgumentNullException("TEST Error message");
                Product product;
                var productRepository = new ProductRepository();
                if (id > 0)
                {
                    var products = productRepository.Retrieve();
                    product = products.FirstOrDefault(p => p.ProductId == id);
                    if (product == null)
                    {
                        return NotFound();
                    }
                }
                else
                {
                    product = productRepository.Create();
                }

                return Ok(product);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            
        }

        // POST: api/Product
        public IHttpActionResult Post([FromBody]Product product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest("Product cannot be null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var productRepository = new ProductRepository();
                var newProduct = productRepository.Save(product);
                if (newProduct == null)
                {
                    return Conflict();
                }
                return Created<Product>(Request.RequestUri + newProduct.ProductId.ToString(), newProduct);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            
        }

        // PUT: api/Product/5
        public IHttpActionResult Put(int id, [FromBody]Product product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest("Product cannot be null");
                }
                var productRepository = new ProductRepository();
                var updateProduct = productRepository.Save(id, product);
                if (updateProduct == null)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
        }
    }
}
