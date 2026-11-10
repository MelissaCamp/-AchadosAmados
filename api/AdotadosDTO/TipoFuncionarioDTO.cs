using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdotadosDTO
{
    [Table("TipoFuncionario")]
    public class TipoFuncionarioDTO
    {
        [Key]
        public int IdTpFuncionario { get; set; }
        public string Nome { get; set; }
    }
}
