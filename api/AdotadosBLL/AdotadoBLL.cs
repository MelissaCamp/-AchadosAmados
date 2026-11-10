using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdotadosDAL;
using AdotadosDTO;

namespace AdotadosBLL
{
    public class AdotadoBLL
    {
        AdotadoDAL adotadoDAL = new AdotadoDAL();

        public void CadastrarAdocao(AdotadoDTO adotado)
        {
            adotadoDAL.CadastrarAdocao(adotado);
        }
        public void Editar(AdotadoDTO adotado)
        {
            adotadoDAL.CadastrarAdocao(adotado);
        }
        public void Excluir(int id)
        {
            adotadoDAL.Excluir(id);
        }
        public AdotadoDTO Selecionar(int id)
        {
            return adotadoDAL.Selecionar(id);
        }
        public List<AdotadoDTO> Listar()
        {
            return adotadoDAL.Listar();
        }
    }
}
