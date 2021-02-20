using Maiev.DTO;
using MaievEntityFramework.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NETCore.Encrypt;
using System.Net;
using ExceptionMaiev;
using MaievEntityFramework.Models.DataBaseModels;
using Maiev.Validation;
using System.Security.Claims;

namespace Maiev.Models
{
    public class Users
    {
        maievdatabaseContext db = new maievdatabaseContext();

        public int AuthLogin(LoginDTO UserBody)
        {
            try
            {
                int ID_USUARIO = db.TB_LE_USUARIOs.Where(x => x.DS_LOGIN == UserBody.DS_LOGIN
                                            && x.DS_SENHA == EncryptProvider.Sha1(UserBody.DS_SENHA) && x.FL_ATIVO).Select(x => x.ID_USUARIO).FirstOrDefault();

                if (ID_USUARIO == 0)
                    throw new HttpException("Erro de Autenticação", "Usuario ou senha invalidos", HttpStatusCode.Unauthorized);

                return ID_USUARIO;
            }
            catch (HttpException)
            {
                throw;
            }
            catch (Exception)
            {
                throw new HttpException("Erro Interno no Sistema", "Por favor entre em contato com o Administrador do Sistema", HttpStatusCode.InternalServerError);
            }
        }
        public void RegisterUser(UserRegisterDTO User)
        {
            try
            {

                RegisterUserValidation rv = new RegisterUserValidation();
                   
                if (!rv.ValidationUser(User.DS_LOGIN))
                    throw new HttpException("Erro no Usuario", "Este Usuario ja esta cadastrado", HttpStatusCode.Unauthorized);

                TB_LE_USUARIO us = new TB_LE_USUARIO();
                us.DS_USUARIO = User.DS_USUARIO;
                us.DS_LOGIN = User.DS_LOGIN;
                us.DS_SENHA = EncryptProvider.Sha1(User.DS_SENHA);
                us.FL_ADMINISTRADOR = User.FL_ADMINISTRADOR;
                us.FL_ATIVO = true;
                us.NR_IDADE = User.NR_IDADE;

                db.TB_LE_USUARIOs.Add(us);
                db.SaveChanges();
    
            }
            catch (HttpException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new HttpException("Erro Interno no Sistema", string.Format("Ocorrou um erro durante o cadastro. Contrate o administrador. {0}", ex.Message), HttpStatusCode.InternalServerError);

            }
        }
        
        public object getuser(ClaimsIdentity identity)
        {

            List<Claim> claim = identity.Claims.ToList();
            var User = db.TB_LE_USUARIOs.Where(x => x.ID_USUARIO == int.Parse(claim[0].Value) && x.FL_ATIVO).FirstOrDefault();

            return new
            {
                DS_NOME = User.DS_USUARIO,
                FL_ADMINISTRADOR = User.FL_ADMINISTRADOR
            };
        }
    }
}
