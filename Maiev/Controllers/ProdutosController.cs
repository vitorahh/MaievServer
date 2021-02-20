using ExceptionMaiev;
using Maiev.DTO;
using Maiev.DTO.ResponsesDTO;
using Maiev.Models;
using Maiev.Swagger;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maiev.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProdutosController : Controller
    {


        [ProducesResponseType(typeof(List<ResponseProdutosDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RequestResponseErrors), 401)]
        [ProducesResponseType(typeof(RequestResponseErrors), 500)]
        [Authorize]
        [HttpGet("Listar")]
        public ActionResult<ProdutoDTO> Listar()
        {
            try
            {
                Produtos pr = new Produtos();
                return StatusCode(200, pr.Listar());
            }
            catch (HttpException ex)
            {
                return StatusCode((int)ex.CodeStatus,
                                        new { ID = ex.traceID, Error = ex.Message, Describe = ex.describe });
            }
        }


        [ProducesResponseType(typeof(SuccessInsertResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestResponseErrors), 400)]
        [ProducesResponseType(typeof(RequestResponseErrors), 401)]
        [ProducesResponseType(typeof(RequestResponseErrors), 500)]
        [Authorize]
        [HttpPost("Cadastrar")]
        public ActionResult<ProdutoDTO> Cadastrar([FromBody] ProdutoDTO Produto)
        {
            try
            {
                Produtos pr = new Produtos();
                pr.CadastrarProduto(Produto);
                return StatusCode(200, new { message = "Produto Cadastrado com Sucesso" });
            }
            catch (HttpException ex)
            {
                return StatusCode((int)ex.CodeStatus,
                                        new { ID = ex.traceID, Error = ex.Message, Describe = ex.describe });
            }
        }

        [ProducesResponseType(typeof(SuccessInsertResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestResponseErrors), 400)]
        [ProducesResponseType(typeof(RequestResponseErrors), 401)]
        [ProducesResponseType(typeof(RequestResponseErrors), 500)]
        [Authorize]
        [HttpPut("Atualizar")]
        public ActionResult<ProdutoDTO> Atualizar([FromBody] ProdutoDTO Produto)
        {
            try
            {
                Produtos pr = new Produtos();
                pr.AtualizarProduto(Produto);
                return StatusCode(200, new { message = "Produto Atualizado com Sucesso" });
            }
            catch (HttpException ex)
            {
                return StatusCode((int)ex.CodeStatus,
                                        new { ID = ex.traceID, Error = ex.Message, Describe = ex.describe });
            }
        }

        [ProducesResponseType(typeof(SuccessInsertResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RequestResponseErrors), 401)]
        [ProducesResponseType(typeof(RequestResponseErrors), 500)]
        [Authorize]
        [HttpDelete("Deletar")]
        public ActionResult<ProdutoDTO> Deletar([FromQuery] int IDProduto)
        {
            try
            {
                Produtos pr = new Produtos();
                pr.DeletarProduto(IDProduto);
                return StatusCode(200, new { message = "Produto Deletado com Sucesso" });
            }
            catch (HttpException ex)
            {
                return StatusCode((int)ex.CodeStatus,
                                        new { ID = ex.traceID, Error = ex.Message, Describe = ex.describe });
            }
        }
    }
}
