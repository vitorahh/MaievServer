using ExceptionMaiev;
using Maiev.DTO;
using Maiev.DTO.ResponsesDTO;
using Maiev.Models;
using Maiev.Swagger;
using MaievEntityFramework.Models.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Maiev.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LeilaoController : Controller
    {

        readonly maievdatabaseContext db = null;

        public LeilaoController(maievdatabaseContext _db)
        {
            db = _db;
        }

        [ProducesResponseType(typeof(SuccessInsertResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestResponseErrors), 400)]
        [ProducesResponseType(typeof(RequestResponseErrors), 401)]
        [ProducesResponseType(typeof(RequestResponseErrors), 500)]
        [Authorize]
        [HttpPost("CadastrarLance")]
        public ActionResult<ProdutoDTO> CadastrarLance([FromBody] LanceDTO DataLance)
        {
            try
            {
                ClaimsIdentity identity = (ClaimsIdentity)HttpContext.User.Identity;
                Leilao le = new Leilao(db);
                le.CadastrarLance(DataLance, identity);
                return StatusCode(200, new { message = "Lance Efetuado com Sucesso" });
            }
            catch (HttpException ex)
            {
                return StatusCode((int)ex.CodeStatus,
                                        new { ID = ex.traceID, Error = ex.Message, Describe = ex.describe });
            }
        }


        [ProducesResponseType(typeof(BadRequestResponseErrors), 400)]
        [ProducesResponseType(typeof(RequestResponseErrors), 401)]
        [ProducesResponseType(typeof(RequestResponseErrors), 500)]
        [Authorize]
        [HttpGet("ListarLances")]
        public ActionResult<ProdutoDTO> ListarLances([FromQuery] int ID_PRODUTO)
        {
            try
            {
                Leilao le = new Leilao(db);
                
                return StatusCode(200, new { lstLances = le.ListarLances(ID_PRODUTO)});
            }
            catch (HttpException ex)
            {
                return StatusCode((int)ex.CodeStatus,
                                        new { ID = ex.traceID, Error = ex.Message, Describe = ex.describe });
            }
        }


        //Listar Lances
    }
}
