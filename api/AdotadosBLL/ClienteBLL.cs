using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdotadosDAL;
using AdotadosDTO;

namespace AdotadosBLL
{
    public class ClienteBLL
    {
        ClienteDAL clienteDAL = new ClienteDAL();

        public void CadastrarCliente(ClienteDTO cliente)
        {
            clienteDAL.CadastrarCliente(cliente);
        }

        public void EditarCliente(ClienteDTO cliente)
        {
            clienteDAL.Editar(cliente);
        }

        public void ExcluirCliente(int id)
        {
            clienteDAL.Excluir(id);
        }

        public ClienteDTO SelecionarCliente(int id)
        {
            return clienteDAL.Selecionar(id);
        }

        public List<ClienteDTO> ListarAnimal()
        {
            return clienteDAL.Listar();
        }
    }
}
