using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Maiev.DTO
{
    public class UserRegisterDTO
    {
        public Nullable<int> ID_USUARIO { get; set; }
        
        [Required(ErrorMessage = "Nome é um campo obrigatório")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O Nome deve ter no mínimo 5 e no máximo 100 caracteres.")]
        public string DS_USUARIO { get; set; }

        [Required(ErrorMessage = "Login é um campo obrigatório")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O Login deve ter no mínimo 5 e no máximo 100 caracteres.")]

        public string DS_LOGIN { get; set; }
        [Required(ErrorMessage = "Password e campo obrigatorio")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "A senha deve ter no mínimo 5 e no máximo 100 caracteres.")]
        [DataType(DataType.Password)]
        public string DS_SENHA { get; set; }

        [Required(ErrorMessage = "Idade e campo obrigatorio")]
        [Range(18, 65, ErrorMessage = "Você deve ter mais de 18 Anos para efetuar Cadastro")]
        public int NR_IDADE { get; set; }

        public Boolean FL_ATIVO { get; set; }

    }
}
