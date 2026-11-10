using System.Data.SqlClient;

namespace Adotados
{
    public class Conexao
    {
        protected SqlConnection conn;//representa conexao
        protected SqlCommand cmd;    //comando
        protected SqlDataReader dr;  //data reader (resultado)
        
        public void Conectar()
        {
            try
            {
                conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AchadoseAmados;Integrated Security=True;");
                conn.Open();
            }
            //se der erro, entra no catch e devolve a mensagem do erro
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Desconectar
        public void Desconectar()
        {
            try
            {
                conn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
