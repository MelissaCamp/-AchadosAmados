using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdotadosDTO
{
    [Table("TipoAnimal")]
    public class TipoAnimalDTO
    {
        [Key]
        public int IdTpAnimal { get; set; }
        public string Nome { get; set; }
    }
}
