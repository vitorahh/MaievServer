using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MaievEntityFramework.Models.DataBaseModels
{
    [Table("TB_LE_LANCE")]
    public partial class TB_LE_LANCE
    {
        [Key]
        public int ID_LANCE { get; set; }
        public int ID_USUARIO { get; set; }
        public int ID_PRODUTO { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal VL_LANCE { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DT_LANCE { get; set; }

        [ForeignKey(nameof(ID_PRODUTO))]
        [InverseProperty(nameof(TB_LE_PRODUTO.TB_LE_LANCEs))]
        public virtual TB_LE_PRODUTO ID_PRODUTONavigation { get; set; }
        [ForeignKey(nameof(ID_USUARIO))]
        [InverseProperty(nameof(TB_LE_USUARIO.TB_LE_LANCEs))]
        public virtual TB_LE_USUARIO ID_USUARIONavigation { get; set; }
    }
}
