using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdotadosDTO
{
    [Table("Adotado")]
    public class AdotadoDTO
    {
        [Key]
        public int IdAdotado { get; set; }
        public DateTime DtaAdocao { get; set; }
        [ForeignKey("Animal")]
        public int IdAnimal { get; set; }
        [ForeignKey("Cliente")]
        public int IdCliente { get; set; }

        //public ClienteDTO? idCliente { get; set; }
        //public AnimalDTO? idAnimal { get; set; }
    }
}
