using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Dominio.Modelos;
using Supermarket.API.Dominio.Repositorios;
using System.Threading.Tasks;

namespace Supermarket.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        /// <summary>
        /// Variable privada de la clase/solo lectura
        /// </summary>
        private readonly ICategoriaRepo context;
        /// <summary>
        /// Metodo contructor de la clase
        /// </summary>
        /// <param name="CategoriaContexto"></param>
        public CategoriaController(ICategoriaRepo CategoriaContexto)
        {
            context = CategoriaContexto;
        }
         // GET api/values
        [HttpGet]

        //Secuencial
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            //return new string[] { "value1", "value2" };
            /// <summary>
            /// Retorna lista de categoria
            /// </summary>
            /// <returns></returns>
            return context.GetCategorias().ToList();
        }

        //Asincrona --> Usa paralelismo en el servidor
        public async Task<IEnumerable<Categoria>> GetAsync()
        {
            
            /// <summary>
            /// Retorna lista de categoria
            /// </summary>
            /// <returns></returns>
            return await context.GetCategoriasAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Categoria> HallarCategoriaById(int id)
        {
            Categoria resultado = await context.FindCategoriaById(id);
            return resultado;
        }

    }
}