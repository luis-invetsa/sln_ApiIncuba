using ApiIncuba.Dao;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiIncuba.Controllers
{
    //[Route("api/[controller]/[action]")]
    //[Route("[controller]")]
    //[ApiController]
    //[ProducesResponseType(StatusCodes.Status400BadRequest)]
    //[ApiExplorerSettings(GroupName = "ApiUsuario")]
    //[Authorize(AuthenticationSchemes = "Bearer")]
    public class UsuarioController : Controller
    {
        DA_Usuario usuario = new DA_Usuario();

        //[HttpGet("{login}/{clave}", Name = "GetByClave")]
        [HttpGet("{login}", Name = "GetByClave")]
        //[ProducesResponseType(200)]
        //[ProducesResponseType(404)]
        //[ProducesDefaultResponseType]
        public async Task<IActionResult> GetByUsuario(string login)//string clave
        {
            var objectGetById = usuario.ValidarSessionUsuario(login);

            if (objectGetById == null)
            {
                return NotFound();
            }

            return Ok(objectGetById);
        }
    }
}
