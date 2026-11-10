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
    public class AnimalDAL : Conexao
    {
        public void CadastrarAnimal(AnimalDTO animal)
        {
            try
            {
                Conectar();

                cmd = new SqlCommand("INSERT INTO Animal (Nome, Idade, EhVacinado, UrlImgAnimal, Descricao, DtaCadastro, IdTpFuncionario, IdTpAnimal, Sexo, Raca, EhCastrado) VALUES (@nome, @idade, @ehVacindado, @urlImgAnimal, @descricao, @dtaCadastro, @idTpFuncionario, @idTpAnimal, @sexo, @raca, @ehCastrado)", conn);
                cmd.Parameters.AddWithValue("@nome", animal.Nome);
                cmd.Parameters.AddWithValue("@idade", animal.Idade);
                cmd.Parameters.AddWithValue("@ehVacinado", animal.EhVacinado);
                cmd.Parameters.AddWithValue("@urlImgAnimal", animal.UrlImgAnimal);
                cmd.Parameters.AddWithValue("@descricao", animal.Descricao);
                cmd.Parameters.AddWithValue("@dtaCadastro", animal.DtaCadastro);
                cmd.Parameters.AddWithValue("@idTpFuncionario", animal.IdTpFuncionario);
                cmd.Parameters.AddWithValue("@idTpAnimal", animal.IdTpAnimal);
                cmd.Parameters.AddWithValue("@sexo", animal.Sexo);
                cmd.Parameters.AddWithValue("@raca", animal.Raca);
                cmd.Parameters.AddWithValue("@ehCastrado", animal.EhCastrado);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar Animal");
            }

            finally
            {
                Desconectar();
            }
        }

        public void Editar(AnimalDTO animal)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("UPDATE Animal SET Nome=@nome, Idade=@idade, EhVacinado=@ehVacinado, UrlImgAnimal=@urlImgAnimal, Descricao=@descricao, DtaCadastro=@dtaCadastro, IdTpFuncionario=@idTpFuncionario, IdTpAnimal=@idTpAnimal, Sexo=@sexo, Raca=@raca, EhCastrado=@ehCastrado WHERE Id=@id", conn);
                cmd.Parameters.AddWithValue("@nome", animal.Nome);
                cmd.Parameters.AddWithValue("@idade", animal.Idade);
                cmd.Parameters.AddWithValue("@ehVacinado", animal.EhVacinado);
                cmd.Parameters.AddWithValue("@urlImgAnimal", animal.UrlImgAnimal);
                cmd.Parameters.AddWithValue("@descricao", animal.Descricao);
                cmd.Parameters.AddWithValue("@dtaCadastro", animal.DtaCadastro);
                cmd.Parameters.AddWithValue("@idTpFuncionario", animal.IdTpFuncionario);
                cmd.Parameters.AddWithValue("@idTpAnimal", animal.IdTpAnimal);
                cmd.Parameters.AddWithValue("@sexo", animal.Sexo);
                cmd.Parameters.AddWithValue("@raca", animal.Raca);
                cmd.Parameters.AddWithValue("@ehCastrado", animal.EhCastrado);
                cmd.Parameters.AddWithValue("@id", animal.IdAnimal);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar Animal");

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
                cmd = new SqlCommand("DELETE Animal WHERE Id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir Animal");
            }
            finally
            {
                Desconectar();
            }
        }

        public AnimalDTO Selecionar(int id)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Animal WHERE Id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);

                //Executa o comando e lê o resultado
                dr = cmd.ExecuteReader();

                //se o comando tiver resultado, preenche o dto
                if (dr.Read())
                {
                    //criar um novo objeto dto
                    AnimalDTO animal = new AnimalDTO();

                    animal.IdAnimal = Convert.ToInt32(dr["Id"]);
                    animal.Nome = Convert.ToString(dr["Nome"]);
                    animal.Idade = Convert.ToString(dr["Idade"]);
                    animal.EhVacinado = Convert.ToBoolean(dr["EhVacinado"]);
                    animal.Descricao = Convert.ToString(dr["Descricao"]);
                    animal.DtaCadastro = Convert.ToDateTime(dr["DtaCadastro"]);
                    animal.IdTpFuncionario = Convert.ToInt32(dr["IdTpFuncionario"]);
                    animal.IdTpAnimal = Convert.ToInt32(dr["IdTpAnimal"]);
                    animal.Sexo = Convert.ToString(dr["Sexo"]);
                    animal.Raca = Convert.ToString(dr["Raca"]);
                    animal.EhCastrado = Convert.ToBoolean(dr["EhCastrado"]);

                    //retorna o resultado
                    return animal;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw new Exception("Erro ao selecionar Animal");
            }
            finally
            {
                Desconectar();
            }
        }

        public List<AnimalDTO> Listar()
        {
            try
            {
                //abre a conexão
                Conectar();
                //monta o comando
                cmd = new SqlCommand("SELECT * FROM Animal", conn);
                //executa e pega o resultado
                dr = cmd.ExecuteReader();

                //montar uma lista vazia
                List<AnimalDTO> lista = new List<AnimalDTO>();

                //enquanto tiver linhas no dr (resultado, vai add na lista)
                while (dr.Read())
                {
                    //criar um novo objeto dto
                    AnimalDTO animal = new AnimalDTO();


                    animal.IdAnimal = Convert.ToInt32(dr["Id"]);
                    animal.Nome = Convert.ToString(dr["Nome"]);
                    animal.Idade = Convert.ToString(dr["Idade"]);
                    animal.EhVacinado = Convert.ToBoolean(dr["EhVacinado"]);
                    animal.Descricao = Convert.ToString(dr["Descricao"]);
                    animal.DtaCadastro = Convert.ToDateTime(dr["DtaCadastro"]);
                    animal.IdTpFuncionario = Convert.ToInt32(dr["IdTpFuncionario"]);
                    animal.IdTpAnimal = Convert.ToInt32(dr["IdTpAnimal"]);
                    animal.Sexo = Convert.ToString(dr["Sexo"]);
                    animal.Raca = Convert.ToString(dr["Raca"]);
                    animal.EhCastrado = Convert.ToBoolean(dr["EhCastrado"]); ;

                    //adiciona o plano na lista
                    lista.Add(animal);
                }
                return lista;

            }
            catch (Exception)
            {
                throw new Exception("Erro ao listar Animal");
            }
            finally
            {
                Desconectar();
            }

        }



    }

}