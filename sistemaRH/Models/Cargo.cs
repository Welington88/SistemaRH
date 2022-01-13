using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace sistemaRH.Models
{
    [Table("Cargo")]
    public class Cargo
    {
        public Cargo()
        {
        }
        [Key]
        public int IdCargo { get; set; }
        [Display(Name = "Cargo")]
        [Required(ErrorMessage = " O Campo {0} é Obrigatório!")]
        public String Descricao { get; set; }

        [ForeignKey("Setor")]
        [Display(Name = "Código Setor")]
        public int IdSetor { get; set; }
        public virtual Setor Setor { get; set; }

        [JsonIgnore]
        public virtual ICollection<Colaborador> Colaboradores { get; set; }
    }
}
