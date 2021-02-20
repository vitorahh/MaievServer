using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maiev.DTO.ResponsesDTO
{
    public class ResponseProdutosDTO
    {
        public int ID_PRODUTO { get; set; }

        public string DS_NOME { get; set; }

        public decimal VL_PRODUTO { get; set; }

        public int NR_LANCES { get; set; }

        public decimal VL_LANCE_ATUAL { get; set; }
    }
}
