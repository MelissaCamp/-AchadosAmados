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
    public class FuncionarioDAL : Conexao
    {
        public void CadastrarFuncionario(FuncionarioDTO funcionario)
        {
            try
            {
                Conectar();

                cmd = new SqlCommand("INSERT INTO Funcinario (Nome, Email, Senha, DtaNascimento, Cpf, Telefone, Sexo, UrlImgFuncionario, IdTpFuncionario) VALUES (@nome, @dtaNascimento, @cpf, @email, @senha, @telefone, @sexo, @urlImgFuncionario, @idTpFuncionario)", conn);
                cmd.Parameters.AddWithValue("@nome", funcionario.Nome);
                cmd.Parameters.AddWithValue("@email", funcionario.Email);
                cmd.Parameters.AddWithValue("@senha", funcionario.Senha);
                cmd.Parameters.AddWithValue("@dtaNascimento", funcionario.DtaNascimento);
                cmd.Parameters.AddWithValue("@cpf", funcionario.Cpf);
                cmd.Parameters.AddWithValue("@telefone", funcionario.Telefone);
                cmd.Parameters.AddWithValue("@sexo", funcionario.Sexo);
                cmd.Parameters.AddWithValue("@urlImgFuncionario", funcionario.UrlImgFuncionario);
                cmd.Parameters.AddWithValue("@idTpFuncionario", funcionario.IdTpFuncionario);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar Funcionario");
            }

            finally
            {
                Desconectar();
            }
        }

        public void Editar(FuncionarioDTO funcionario)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("UPDATE Funcionario SET Nome=@nome,  Email=@email, Senha=@senha,DtaNascimento=@dtaNascimento, Cpf=@cpf, Telefone=@telefone, Sexo@sexo, UrlImgFuncionario=@urlImgFuncionario, IdTpFuncionario@idTpFuncinario WHERE Id=@id", conn);
                cmd.Parameters.AddWithValue("@nome", funcionario.Nome);
                cmd.Parameters.AddWithValue("@email", funcionario.Email);
                cmd.Parameters.AddWithValue("@senha", funcionario.Senha);
                cmd.Parameters.AddWithValue("@dtaNascimento", funcionario.DtaNascimento);
                cmd.Parameters.AddWithValue("@cpf", funcionario.Cpf);
                cmd.Parameters.AddWithValue("@telefone", funcionario.Telefone);
                cmd.Parameters.AddWithValue("@sexo", funcionario.Sexo);
                cmd.Parameters.AddWithValue("@urlImgFuncionario", funcionario.UrlImgFuncionario);
                cmd.Parameters.AddWithValue("@idTpFuncionario", funcionario.IdTpFuncionario);
                cmd.Parameters.AddWithValue("@id", funcionario.IdFuncionario);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar Funcionario");

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
                cmd = new SqlCommand("DELETE Funcionario WHERE Id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir Funcionario");
            }
            finally
            {
                Desconectar();
            }
        }

        public FuncionarioDTO Selecionar(int id)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Funcionario WHERE Id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);

                //Executa o comando e lê o resultado
                dr = cmd.ExecuteReader();

                //se o comando tiver resultado, preenche o dto
                if (dr.Read())
                {
                    //criar um novo objeto dto
                    FuncionarioDTO funcionario = new FuncionarioDTO();

                    funcionario.IdFuncionario = Convert.ToInt32(dr["Id"]);
                    funcionario.Nome = Convert.ToString(dr["Nome"]);
                    funcionario.Email = Convert.ToString(dr["Email"]);
                    funcionario.Senha = Convert.ToString(dr["Senha"]);
                    funcionario.DtaNascimento = Convert.ToDateTime(dr["DtaNascimento"]);
                    funcionario.Cpf = Convert.ToString(dr["Cpf"]);
                    funcionario.Telefone = Convert.ToString(dr["Telefone"]);
                    funcionario.Sexo = Convert.ToString(dr["Sexo"]);
                    funcionario.UrlImgFuncionario = Convert.ToString(dr["UrlImgFuncionario"]);
                    funcionario.IdTpFuncionario = Convert.ToInt32(dr["IdTpFuncionario"]);


                    //retorna o resultado
                    return funcionario;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw new Exception("Erro ao selecionar Funcionario");
            }
            finally
            {
                Desconectar();
            }
        }

        public List<FuncionarioDTO> Listar()
        {
            try
            {
                //abre a conexão
                Conectar();
                //monta o comando
                cmd = new SqlCommand("SELECT * FROM Funcionario", conn);
                //executa e pega o resultado
                dr = cmd.ExecuteReader();

                //montar uma lista vazia
                List<FuncionarioDTO> lista = new List<FuncionarioDTO>();

                //enquanto tiver linhas no dr (resultado, vai add na lista)
                while (dr.Read())
                {
                    //criar um novo objeto dto
                    FuncionarioDTO funcionario = new FuncionarioDTO();

                    funcionario.IdFuncionario = Convert.ToInt32(dr["Id"]);
                    funcionario.Nome = Convert.ToString(dr["Nome"]);
                    funcionario.Email = Convert.ToString(dr["Email"]);
                    funcionario.Senha = Convert.ToString(dr["Senha"]);
                    funcionario.DtaNascimento = Convert.ToDateTime(dr["DtaNascimento"]);
                    funcionario.Cpf = Convert.ToString(dr["Cpf"]);
                    funcionario.Telefone = Convert.ToString(dr["Telefone"]);
                    funcionario.Sexo = Convert.ToString(dr["Sexo"]);
                    funcionario.UrlImgFuncionario = Convert.ToString(dr["UrlImgFuncionario"]);
                    funcionario.IdTpFuncionario = Convert.ToInt32(dr["IdTpFuncionario"]);

                    //adiciona o plano na lista
                    lista.Add(funcionario);
                }
                return lista;

            }
            catch (Exception)
            {
                throw new Exception("Erro ao listar Funcionario");
            }
            finally
            {
                Desconectar();
            }

        }
    }
}
