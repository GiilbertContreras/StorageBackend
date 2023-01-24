using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sql.Connection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;
using StorageBackend.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StorageBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // GET: api/<ProductController>
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            try
            {
                Connection resultado = new Connection();
                var listProducts = resultado.ejecutar("SELECT * FROM dbo.products where status_product = 'INPUT'");
                return Ok(listProducts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ProductController>/5
        [HttpGet("{id_product}")]
        public async Task<IActionResult> Get(string id_product)
        {
            try
            {
                Connection resultado = new Connection();
                var listProducts = resultado.ejecutar("SELECT * FROM dbo.products WHERE id_product = '"+ id_product +"'");
                return Ok(listProducts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            try
            {
                Connection resultado = new Connection();
                var listProducts = resultado.ejecutar("INSERT INTO products (name_product, status_product, defective_product) VALUES ('" + product.name_product + "', 'INPUT', '"+ product.defective_product + "');");
                return Ok("[\"Ok\"]");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id_product}")]
        public async Task<IActionResult> Put(int id_product, [FromBody] Product product)
        {
            try
            {
                Connection resultado = new Connection();
                var listProducts = resultado.ejecutar("UPDATE products SET name_product='"+ product.name_product + "', defective_product= '"+ product.defective_product + "' WHERE id_product='" + product.id_product + "'");
                return Ok("[\"Producto Marcado Como Defectusoso\"]");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id_product}")]
        public async Task<IActionResult> Delete(int id_product)
        {
            try
            {
                Connection resultado = new Connection();
                var listProducts = resultado.ejecutar("UPDATE products SET status_product='Salida' WHERE id_product='" + id_product + "'");
                return Ok("[\"Salida Exitosa de Producto\"]");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
