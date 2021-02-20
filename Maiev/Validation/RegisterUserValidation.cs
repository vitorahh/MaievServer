using MaievEntityFramework.Models.Context;
using NETCore.Encrypt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maiev.Validation
{
    public class RegisterUserValidation
    {
        maievdatabaseContext db = new maievdatabaseContext();


        public bool ValidationUser(string DS_LOGIN)
        {

            int ID_USUARIO = db.TB_LE_USUARIOs.Where(x => x.DS_LOGIN == DS_LOGIN && x.FL_ATIVO).Select(x => x.ID_USUARIO).FirstOrDefault();
            if (ID_USUARIO == 0)
                return true;
            else
                return false;
        }
    }
}
