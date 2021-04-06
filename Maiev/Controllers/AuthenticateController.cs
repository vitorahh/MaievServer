using ExceptionMaiev;
using Maiev.DTO;
using Maiev.DTO.ResponsesDTO;
using Maiev.Models;
using Maiev.Swagger;
using MaievEntityFramework.Models.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Maiev.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthenticateController : Controller
    {
        readonly maievdatabaseContext db = null;
        readonly Authenticate auth = null;
        public AuthenticateController(IConfiguration config, maievdatabaseContext _db)
        {
            auth = new Authenticate(config);
            db = _db;
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestResponseErrors), 400)]
        [ProducesResponseType(typeof(RequestResponseErrors), 401)]
        [ProducesResponseType(typeof(RequestResponseErrors), 500)]
        [HttpPost("Login")]
        public async Task<ActionResult<ResponseJWTDTO>> Login([FromBody] LoginDTO userInfo)
        {
            try
            {
                Users UserModels = new Users(db);

                int ID_USUARIO = UserModels.AuthLogin(userInfo);

                return Authenticate.BuildToken(ID_USUARIO);
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
        [HttpPost("Register")]
        public async Task<ActionResult<object>> Register([FromBody] UserRegisterDTO User)
        {
            try
            {
                Users us = new Users(db);


                us.RegisterUser(User);

                return StatusCode(200, new { message = "Usuário Cadastrado com Sucesso" });
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
        [HttpGet("GetUser")]
        [Authorize]
        public  ActionResult<object> GetUser()
        {
            try
            {
                Users UserModels = new Users(db);
                ClaimsIdentity identity = (ClaimsIdentity)HttpContext.User.Identity;
                object User = UserModels.getuser(identity);

                return User;
            }
            catch (HttpException ex)
            {
                return StatusCode((int)ex.CodeStatus,
                                        new { ID = ex.traceID, Error = ex.Message, Describe = ex.describe });
            }
        }

    }

}
