using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;

namespace CustomSwagger.Controllers
{
    /// <summary>
    /// Descrição do objeto `CustomSwagger`
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(int), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(int), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public class CustomSwaggerController : ControllerBase
    {
        /// <summary>
        /// Cadastrar item
        /// </summary>
        [HttpPost]
        public ActionResult Post([FromBody] CustomSwagger request)
        {
            return new OkResult();
        }

        /// <summary>
        /// Alterar item
        /// </summary>
        [HttpPut("{id:int:range(1,99999999)}")]
        public ActionResult Update(int id, [FromBody] CustomSwagger request)
        {
            return new OkResult();
        }

        /// <summary>
        /// Retornar item
        /// </summary>
        [HttpGet("{id:int:range(1,99999999)}")]
        [ProducesResponseType(typeof(CustomSwagger), StatusCodes.Status200OK)]
        public ActionResult Get(int id)
        {
            return new OkResult();
        }

        /// <summary>
        /// Retornar itens
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CustomSwagger>), StatusCodes.Status200OK)]
        public ActionResult Get()
        {
            return new OkResult();
        }

        /// <summary>
        /// Alterar item
        /// </summary>
        [HttpDelete("{id:int:range(1,99999999)}")]
        public ActionResult Delete(int id)
        {
            return new OkResult();
        }
    }

    /// <summary>
    /// ## Item
    /// ---
    /// Descrição do objeto `CustomSwagger`
    /// </summary>
    public class CustomSwagger
    {
        /// <summary>
        /// Id
        /// </summary>        
        /// <example>1</example>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Nome
        /// </summary>
        /// <example>Nome</example>
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public required string Nome { get; set; }
    }

    public class CustomSwaggerEx : IExamplesProvider<CustomSwagger>
    {
        public CustomSwagger GetExamples() =>
            new()
            {
                Id = 1,
                Nome = "Nome"
            };
    }
}
