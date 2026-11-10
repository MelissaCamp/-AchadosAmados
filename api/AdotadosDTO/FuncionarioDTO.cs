using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdotadosDTO
{
    [Table("Funcionario")]
    public class FuncionarioDTO
    {
        [Key]
        public int IdFuncionario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DtaNascimento { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Sexo { get; set; }
        public string UrlImgFuncionario { get; set; }
        [ForeignKey("TipoFuncionario")]
        public int IdTpFuncionario { get; set; }

        //public TipoFuncionarioDTO? tipoFuncionario { get; set; }
    }
}
