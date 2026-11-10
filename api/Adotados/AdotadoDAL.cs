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
    public class AdotadoDAL : Conexao
    {
        public void CadastrarAdocao(AdotadoDTO adotado)
        {
            try
            {
                Conectar();

                cmd = new SqlCommand("INSERT INTO Adotado (DtaAdocao, IdCliente, IdAnimal) VALUES (@dtaAdocao, @idCliente, @idAnimal)", conn);
                cmd.Parameters.AddWithValue("@dtaAdocao", adotado.DtaAdocao);
                cmd.Parameters.AddWithValue("@idCliente", adotado.IdCliente);
                cmd.Parameters.AddWithValue("@idAnimal", adotado.IdAnimal);


                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar Animal Adotado");
            }

            finally
            {
                Desconectar();
            }
        }

        public void Editar(AdotadoDTO adotado)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("UPDATE Adotado SET DtaAdocao=@dtaAdocao,  IdCliente=@idCliente, IdAnimal=@idAnimal WHERE Id=@id", conn);
                cmd.Parameters.AddWithValue("@dtaAdocao", adotado.DtaAdocao);
                cmd.Parameters.AddWithValue("@idCliente", adotado.IdCliente);
                cmd.Parameters.AddWithValue("@idAnimal", adotado.IdAnimal);
                cmd.Parameters.AddWithValue("@id", adotado.IdAdotado);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar Adoção");

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
                cmd = new SqlCommand("DELETE Adotado WHERE Id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir Adoção");
            }
            finally
            {
                Desconectar();
            }
        }

        public AdotadoDTO Selecionar(int id)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Adotado WHERE Id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);

                //Executa o comando e lê o resultado
                dr = cmd.ExecuteReader();

                //se o comando tiver resultado, preenche o dto
                if (dr.Read())
                {
                    //criar um novo objeto dto
                    AdotadoDTO adotado = new AdotadoDTO();

                    adotado.IdAdotado = Convert.ToInt32(dr["Id"]);
                    adotado.DtaAdocao = Convert.ToDateTime(dr["DtaAdocao"]);
                    adotado.IdCliente = Convert.ToInt32(dr["IdCliente"]);
                    adotado.IdAnimais = Convert.ToInt32(dr["IdAnimais"]);



                    //retorna o resultado
                    return adotado;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw new Exception("Erro ao selecionar Adoção");
            }
            finally
            {
                Desconectar();
            }
        }

        public List<AdotadoDTO> Listar()
        {
            try
            {
                //abre a conexão
                Conectar();
                //monta o comando
                cmd = new SqlCommand("SELECT * FROM Adotado", conn);
                //executa e pega o resultado
                dr = cmd.ExecuteReader();

                //montar uma lista vazia
                List<AdotadoDTO> lista = new List<AdotadoDTO>();

                //enquanto tiver linhas no dr (resultado, vai add na lista)
                while (dr.Read())
                {
                    //criar um novo objeto dto
                    AdotadoDTO adotado = new AdotadoDTO();

                    adotado.IdAdotado = Convert.ToInt32(dr["Id"]);
                    adotado.DtaAdocao = Convert.ToDateTime(dr["DtaAdocao"]);
                    adotado.IdCliente = Convert.ToInt32(dr["IdCliente"]);
                    adotado.IdAnimal = Convert.ToInt32(dr["IdAnimal"]);


                    //adiciona o plano na lista
                    lista.Add(adotado);
                }
                return lista;

            }
            catch (Exception)
            {
                throw new Exception("Erro ao listar Adoções");
            }
            finally
            {
                Desconectar();
            }

        }
    }
}
