using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdotadosDTO
{
    [Table("Animal")]
    public class AnimalDTO
    {
        [Key]
        public int IdAnimal { get; set; }
        public string Nome { get; set; }
        public string Idade { get; set; }
        public bool EhVacinado { get; set; }
        public string UrlImgAnimal { get; set; }
        public string Descricao { get; set; }
        public DateTime DtaCadastro { get; set; }
        [ForeignKey("TipoFuncionario")]
        public int IdTpFuncionario { get; set; }
        [ForeignKey("TipoAnimal")]
        public int IdTpAnimal { get; set; }
        public string Sexo { get; set; }
        public string Raca { get; set; }
        public bool EhCastrado { get; set; }

        //public TipoAnimalDTO? tipoAnimal { get; set; }
        //public TipoFuncionarioDTO? tipoFuncionario { get; set; }

    }
}
