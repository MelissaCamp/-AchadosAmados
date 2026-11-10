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
    public class TipoFuncionarioDAL : Conexao
    {
        public void CadastrarTpFuncionario(TipoFuncionarioDTO funcao)
        {
            try
            {
                Conectar();

                cmd = new SqlCommand("INSERT INTO TipoFuncionario (Nome) VALUES (@nome)", conn);
                cmd.Parameters.AddWithValue("@nome", funcao.Nome);



                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar nova função");
            }

            finally
            {
                Desconectar();
            }
        }

        public void Editar(TipoFuncionarioDTO funcao)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("UPDATE TipoFuncionario SET Nome=@nome WHERE Id=@id", conn);
                cmd.Parameters.AddWithValue("@nome", funcao.Nome);
                cmd.Parameters.AddWithValue("@id", funcao.IdTpFuncionario);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar função");

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
                cmd = new SqlCommand("DELETE TipoFuncionario WHERE Id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir função");
            }
            finally
            {
                Desconectar();
            }
        }

        public TipoFuncionarioDTO Selecionar(int id)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM TipoFuncionario WHERE Id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);

                //Executa o comando e lê o resultado
                dr = cmd.ExecuteReader();

                //se o comando tiver resultado, preenche o dto
                if (dr.Read())
                {
                    //criar um novo objeto dto
                    TipoFuncionarioDTO funcao = new TipoFuncionarioDTO();

                    funcao.IdTpFuncionario = Convert.ToInt32(dr["Id"]);
                    funcao.Nome = Convert.ToString(dr["Nome"]);




                    //retorna o resultado
                    return funcao;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw new Exception("Erro ao selecionar função");
            }
            finally
            {
                Desconectar();
            }
        }

        public List<TipoFuncionarioDTO> Listar()
        {
            try
            {
                //abre a conexão
                Conectar();
                //monta o comando
                cmd = new SqlCommand("SELECT * FROM TipoFuncionario", conn);
                //executa e pega o resultado
                dr = cmd.ExecuteReader();

                //montar uma lista vazia
                List<TipoFuncionarioDTO> lista = new List<TipoFuncionarioDTO>();

                //enquanto tiver linhas no dr (resultado, vai add na lista)
                while (dr.Read())
                {
                    //criar um novo objeto dto
                    TipoFuncionarioDTO funcao = new TipoFuncionarioDTO();

                    funcao.IdTpFuncionario = Convert.ToInt32(dr["Id"]);
                    funcao.Nome = Convert.ToString(dr["Nome"]);


                    //adiciona o plano na lista
                    lista.Add(funcao);
                }
                return lista;

            }
            catch (Exception)
            {
                throw new Exception("Erro ao listar funções");
            }
            finally
            {
                Desconectar();
            }

        }
    }
}
