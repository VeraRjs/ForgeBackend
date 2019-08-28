using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiaD.Models;
using Microsoft.AspNetCore.Mvc;

namespace DiaD.Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        public CategoriasController(ProductoContext categoriaContex)
        {
            Context = categoriaContex; 
        }

        private ProductoContext Context;
        // GET api/values

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            return Context.Categorias.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Categoria> Get(int id)
        {   
            
            var Categoria = Context.Categorias.Find(id);
            if( Categoria != null){
                return Categoria;
            }

            return NotFound();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Categoria value)
        {
            Context.Categorias.Add(value);
            Context.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Producto value)
        {
            var Categoria = Context.Categorias.Find(id);
            Categoria.Titulo = value.Titulo;
            Context.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {   
            var Categoria = Context.Categorias.Find(id);
            if(Categoria == null){
                NotFound();
            }
            else
            {
            Context.Categorias.Remove(Categoria);
            Context.SaveChanges();
            }

        }
    }
}