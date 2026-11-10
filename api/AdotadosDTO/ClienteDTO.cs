using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdotadosDTO
{
    [Table("Cliente")]
    public class ClienteDTO
    {
        [Key]
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public DateTime DtaNascimento { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Nro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string UrlImgCliente { get; set; }
    }
}
