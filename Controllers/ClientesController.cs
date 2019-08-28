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
    public class ClienteController : ControllerBase
    {
        public ClienteController(ProductoContext clienteContex)
        {
            Context = clienteContex; 
        }

        private ProductoContext Context;
        // GET api/values

        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> Get()
        {
            return Context.Clientes.ToList();
        }

        // GET api/values/5
        [HttpGet("{Username}")]
        public ActionResult<Cliente> Get(string Username)
        {
            return Context.Clientes.FirstOrDefault(b => b.Username == Username);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Cliente value)
        {
            Context.Clientes.Add(value);
            Context.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Cliente value)
        {
            var Clientes = Context.Clientes.Find(id);
            if(Clientes == null)
            {
             return NotFound();
            }
            else
            {
            Clientes.Username = value.Username;
            Clientes.Nombre = value.Nombre;
            Clientes.Apellido = value.Apellido;
            Clientes.Email = value.Email;
            Context.SaveChanges();
            return Ok();
            }

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {   

            var Clientes = Context.Clientes.Find(id);
            if(Clientes == null)
            {
               NotFound();
            }
            else 
            {
            Context.Clientes.Remove(Clientes);
            Context.SaveChanges();
            }
        }
    }
}