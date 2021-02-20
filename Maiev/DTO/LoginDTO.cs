using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Maiev.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Login e um campo obrigatorio")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O Login deve ter no mínimo 5 e no máximo 100 caracteres.")]
        public string DS_LOGIN { get; set; }

        [Required(ErrorMessage = "Senha e campo obrigatorio")]
        [DataType(DataType.Password, ErrorMessage = "Senha e campo obrigatorio.")]
        public string DS_SENHA { get; set; }
    }
}
