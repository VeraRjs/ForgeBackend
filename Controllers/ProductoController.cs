using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiaD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace DiaD.Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        public ProductoController(ProductoContext productoContex)
        {
            Context = productoContex; 
        }

        public ProductoContext Context;
        // GET api/values

        [HttpGet]
        public ActionResult<IEnumerable<Producto>> Get()
        {
            return Context.Productos.Include(x => x.Categoria).ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Producto> Get(int id)
        {
            var Productos = Context.Productos.Find(id);
            if( Productos != null){
                return Productos;
            }

            return NotFound();

            
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Producto value)
        {

            Context.Productos.Add(value);
            Context.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Producto value)
        {
            var Productos = Context.Productos.Find(id);
            if(Productos == null)
            {
                return NotFound();
            }
            else
            {
            Productos.Precio = value.Precio;
            Productos.Titulo = value.Titulo;
            Productos.Descripcion = value.Descripcion;
            Productos.CategoriaId = value.CategoriaId;
            Context.SaveChanges();
            return Ok();
            }

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {   

            var Productos = Context.Productos.Find(id);
            if(Productos == null)
            {
               NotFound();
            }
            else 
            {
            Context.Productos.Remove(Productos);
            Context.SaveChanges();
            }
        }
    }
}