using api_reto.Entitites;
using api_reto.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace api_reto.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : Controller
    {

        [HttpGet()]
        public IEnumerable<Cliente> Get()
        {
            cliente_repository repository = new cliente_repository();
            var clientes = repository.Search();
            return clientes;
        }

        [HttpGet("{id}")]
        public IEnumerable<Cliente> GetId(int id)
        {
            cliente_repository repository = new cliente_repository();
            var clientes = repository.SearchById(id);
            return clientes;
        }

        [HttpPost()]
        public IActionResult Post(Cliente cliente)
        {
            cliente_repository repository = new cliente_repository();
            var res = repository.Insert(cliente);
            return Accepted();
            //comentario
        }

    }
}
