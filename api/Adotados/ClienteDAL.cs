using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adotados;
using AdotadosDTO;

namespace AdotadosDAL
{
    public class ClienteDAL : Conexao
    {
        public void CadastrarCliente(ClienteDTO cliente)
        {
            try
            {
                Conectar();

                cmd = new SqlCommand("INSERT INTO Cliente (Nome, DtaNascimento, Cpf, Email, Senha, Telefone, Endereco, Nro, Bairro, Cidade, Estado, UrlImgCliente) VALUES (@nome, @dtaNascimento, @cpf, @email, @senha, @telefone, @endereco, @nro, @bairro, @cidade, @estado, @urlImgcliente)", conn);
                cmd.Parameters.AddWithValue("@nome", cliente.Nome);
                cmd.Parameters.AddWithValue("@dtaNascimento", cliente.DtaNascimento);
                cmd.Parameters.AddWithValue("@cpf", cliente.Cpf);
                cmd.Parameters.AddWithValue("@email", cliente.Email);
                cmd.Parameters.AddWithValue("@senha", cliente.Senha);
                cmd.Parameters.AddWithValue("@telefone", cliente.Telefone);
                cmd.Parameters.AddWithValue("@endereco", cliente.Endereco);
                cmd.Parameters.AddWithValue("@nro", cliente.Nro);
                cmd.Parameters.AddWithValue("@bairro", cliente.Bairro);
                cmd.Parameters.AddWithValue("@cidade", cliente.Cidade);
                cmd.Parameters.AddWithValue("@estado", cliente.Estado);
                cmd.Parameters.AddWithValue("@urlImgcliente", cliente.UrlImgCliente);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar Cliente");
            }

            finally
            {
                Desconectar();
            }
        }

        public void Editar(ClienteDTO cliente)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("UPDATE Cliente SET Nome=@nome, DtaNascimento=@dtaNascimento, Cpf=@cpf, Email=@email, Senha=@senha, Telefone=@telefone, Endereco=@endereco, Nro=@nro, Bairro=@bairro, Cidade=@cidade, Estado=@estado, UrlImgCliente=@urlImgCliente WHERE Id=@id", conn);
                cmd.Parameters.AddWithValue("@nome", cliente.Nome);
                cmd.Parameters.AddWithValue("@dtaNascimento", cliente.DtaNascimento);
                cmd.Parameters.AddWithValue("@cpf", cliente.Cpf);
                cmd.Parameters.AddWithValue("@email", cliente.Email);
                cmd.Parameters.AddWithValue("@senha", cliente.Senha);
                cmd.Parameters.AddWithValue("@telefone", cliente.Telefone);
                cmd.Parameters.AddWithValue("@endereco", cliente.Endereco);
                cmd.Parameters.AddWithValue("@nro", cliente.Nro);
                cmd.Parameters.AddWithValue("@bairro", cliente.Bairro);
                cmd.Parameters.AddWithValue("@cidade", cliente.Cidade);
                cmd.Parameters.AddWithValue("@estado", cliente.Estado);
                cmd.Parameters.AddWithValue("@urlImgcliente", cliente.UrlImgCliente);
                cmd.Parameters.AddWithValue("@id", cliente.IdCliente);

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar Cliente");

            }

            finally
            {
                Desconectar();
            }
        }

        public void Excluir(int id)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("DELETE Cliente WHERE Id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir Cliente");
            }
            finally
            {
                Desconectar();
            }
        }

        public ClienteDTO Selecionar(int id)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Cliente WHERE Id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);

                //Executa o comando e lê o resultado
                dr = cmd.ExecuteReader();

                //se o comando tiver resultado, preenche o dto
                if (dr.Read())
                {
                    //criar um novo objeto dto
                    ClienteDTO cliente = new ClienteDTO();

                    cliente.IdCliente = Convert.ToInt32(dr["Id"]);
                    cliente.Nome = Convert.ToString(dr["Nome"]);
                    cliente.DtaNascimento = Convert.ToDateTime(dr["DtaNascimento"]);
                    cliente.Cpf = Convert.ToString(dr["Cpf"]);
                    cliente.Email = Convert.ToString(dr["Email"]);
                    cliente.Senha = Convert.ToString(dr["Senha"]);
                    cliente.Telefone = Convert.ToString(dr["Telefone"]);
                    cliente.Endereco = Convert.ToString(dr["Endereco"]);
                    cliente.Nro = Convert.ToString(dr["Nro"]);
                    cliente.Bairro = Convert.ToString(dr["Bairro"]);
                    cliente.Estado = Convert.ToString(dr["Estado"]);
                    cliente.UrlImgCliente = Convert.ToString(dr["UrlImgCliente"]);

                    //retorna o resultado
                    return cliente;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw new Exception("Erro ao selecionar Cliente");
            }
            finally
            {
                Desconectar();
            }
        }

        public List<ClienteDTO> Listar()
        {
            try
            {
                //abre a conexão
                Conectar();
                //monta o comando
                cmd = new SqlCommand("SELECT * FROM Cliente", conn);
                //executa e pega o resultado
                dr = cmd.ExecuteReader();

                //montar uma lista vazia
                List<ClienteDTO> lista = new List<ClienteDTO>();

                //enquanto tiver linhas no dr (resultado, vai add na lista)
                while (dr.Read())
                {
                    //criar um novo objeto dto
                    ClienteDTO cliente = new ClienteDTO();

                    cliente.IdCliente = Convert.ToInt32(dr["Id"]);
                    cliente.Nome = Convert.ToString(dr["Nome"]);
                    cliente.DtaNascimento = Convert.ToDateTime(dr["DtaNascimento"]);
                    cliente.Cpf = Convert.ToString(dr["Cpf"]);
                    cliente.Email = Convert.ToString(dr["Email"]);
                    cliente.Senha = Convert.ToString(dr["Senha"]);
                    cliente.Telefone = Convert.ToString(dr["Telefone"]);
                    cliente.Endereco = Convert.ToString(dr["Endereco"]);
                    cliente.Nro = Convert.ToString(dr["Nro"]);
                    cliente.Bairro = Convert.ToString(dr["Bairro"]);
                    cliente.Estado = Convert.ToString(dr["Estado"]);
                    cliente.UrlImgCliente = Convert.ToString(dr["UrlImgCliente"]);

                    //adiciona o plano na lista
                    lista.Add(cliente);
                }
                return lista;

            }
            catch (Exception)
            {
                throw new Exception("Erro ao listar Cliente");
            }
            finally
            {
                Desconectar();
            }

        }
    }
}
