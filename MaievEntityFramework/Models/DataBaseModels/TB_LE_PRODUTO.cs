using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MaievEntityFramework.Models.DataBaseModels
{
    [Table("TB_LE_PRODUTO")]
    public partial class TB_LE_PRODUTO
    {
        public TB_LE_PRODUTO()
        {
            TB_LE_LANCEs = new HashSet<TB_LE_LANCE>();
        }

        [Key]
        public int ID_PRODUTO { get; set; }
        [Required]
        [StringLength(100)]
        public string DS_NOME { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal VL_PRODUTO { get; set; }

        [InverseProperty(nameof(TB_LE_LANCE.ID_PRODUTONavigation))]
        public virtual ICollection<TB_LE_LANCE> TB_LE_LANCEs { get; set; }
    }
}
