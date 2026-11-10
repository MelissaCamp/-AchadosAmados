using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdotadosDAL;
using AdotadosDTO;

namespace AdotadosBLL
{
    public class FuncionarioBLL
    {
        FuncionarioDAL funcionarioDAL = new FuncionarioDAL();

        public void CadastrarFuncionario(FuncionarioDTO funcionario)
        {
            funcionarioDAL.CadastrarFuncionario(funcionario);
        }
        public void Editar(FuncionarioDTO funcionario)
        {
            funcionarioDAL.Editar(funcionario);
        }
        public void Excluir(int id)
        {
            funcionarioDAL.Excluir(id);
        }
        public FuncionarioDTO Selecionar(int id)
        {
            return funcionarioDAL.Selecionar(id);
        }
        public List<FuncionarioDTO> Listar()
        {
            return funcionarioDAL.Listar();
        }
    }
}
