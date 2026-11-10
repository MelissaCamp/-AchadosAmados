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
    public class TipoAnimalDAL : Conexao
    {
        public void CadastrarTpAnimal(TipoAnimalDTO tipo)
        {
            try
            {
                Conectar();

                cmd = new SqlCommand("INSERT INTO TipoAnimal (Nome) VALUES (@nome)", conn);
                cmd.Parameters.AddWithValue("@nome", tipo.Nome);



                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar tipo do animal");
            }

            finally
            {
                Desconectar();
            }
        }

        public void Editar(TipoAnimalDTO tipo)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("UPDATE TipoAnimal SET Nome=@nome WHERE Id=@id", conn);
                cmd.Parameters.AddWithValue("@nome", tipo.Nome);
                cmd.Parameters.AddWithValue("@id", tipo.IdTpAnimal);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar tipo do animal");

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
                cmd = new SqlCommand("DELETE TipoAnimal WHERE Id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir tipo de animal");
            }
            finally
            {
                Desconectar();
            }
        }

        public TipoAnimalDTO Selecionar(int id)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM TipoAnimal WHERE Id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);

                //Executa o comando e lê o resultado
                dr = cmd.ExecuteReader();

                //se o comando tiver resultado, preenche o dto
                if (dr.Read())
                {
                    //criar um novo objeto dto
                    TipoAnimalDTO tipo = new TipoAnimalDTO();

                    tipo.IdTpAnimal = Convert.ToInt32(dr["Id"]);
                    tipo.Nome = Convert.ToString(dr["Nome"]);




                    //retorna o resultado
                    return tipo;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw new Exception("Erro ao selecionar tipo animal");
            }
            finally
            {
                Desconectar();
            }
        }

        public List<TipoAnimalDTO> Listar()
        {
            try
            {
                //abre a conexão
                Conectar();
                //monta o comando
                cmd = new SqlCommand("SELECT * FROM TipoAnimal", conn);
                //executa e pega o resultado
                dr = cmd.ExecuteReader();

                //montar uma lista vazia
                List<TipoAnimalDTO> lista = new List<TipoAnimalDTO>();

                //enquanto tiver linhas no dr (resultado, vai add na lista)
                while (dr.Read())
                {
                    //criar um novo objeto dto
                    TipoAnimalDTO tipo = new TipoAnimalDTO();

                    tipo.IdTpAnimal = Convert.ToInt32(dr["Id"]);
                    tipo.Nome = Convert.ToString(dr["Nome"]);


                    //adiciona o plano na lista
                    lista.Add(tipo);
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
