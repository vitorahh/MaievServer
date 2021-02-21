using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maiev.DTO.ResponsesDTO
{
    public class LeilaoProdutoDTO
    {
        public int ID_LANCE { get; set; }

        public DateTime DT_LANCE { get; set; }

        public string DS_PRODUTO { get; set; }

        public string DS_USUARIO { get; set; }

        public decimal VL_LANCE { get; set; }
    }
}
