
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Maiev.DTO
{
    
    public class ProdutoDTO
    {
        public Nullable<int> ID_PRODUTO { get; set; }

        [Required(ErrorMessage = "DS_NOME e um campo obrigatorio")]
        public string DS_NOME { get; set; }

        [Required(ErrorMessage = "VL_PRODUTO e um campo obrigatorio")]
        public decimal VL_PRODUTO { get; set; }
    }
}
