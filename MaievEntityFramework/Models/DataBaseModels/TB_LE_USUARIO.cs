using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MaievEntityFramework.Models.DataBaseModels
{
    [Table("TB_LE_USUARIO")]
    public partial class TB_LE_USUARIO
    {
        public TB_LE_USUARIO()
        {
            TB_LE_LANCEs = new HashSet<TB_LE_LANCE>();
        }

        [Key]
        public int ID_USUARIO { get; set; }
        [Required]
        [StringLength(100)]
        public string DS_USUARIO { get; set; }
        [Required]
        [StringLength(100)]
        public string DS_LOGIN { get; set; }
        [Required]
        [StringLength(100)]
        public string DS_SENHA { get; set; }
        public int NR_IDADE { get; set; }
        public bool FL_ATIVO { get; set; }
        public bool FL_ADMINISTRADOR { get; set; }

        [InverseProperty(nameof(TB_LE_LANCE.ID_USUARIONavigation))]
        public virtual ICollection<TB_LE_LANCE> TB_LE_LANCEs { get; set; }
    }
}
