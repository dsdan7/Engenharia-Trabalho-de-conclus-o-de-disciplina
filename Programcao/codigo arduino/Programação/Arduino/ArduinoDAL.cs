using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace Arduino
{
    class ArduinoDAL
    {
        private static String strConexao = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=TabArduino.mdb";
        private static OleDbConnection conn = new OleDbConnection(strConexao);
        private static OleDbCommand strSQL;
        private static OleDbDataReader result;

        public static void conecta()
        {
            try
            {
                conn.Open();

            }
            catch (Exception)
            {
                Erro.setMsg("Problema ao conectar ao banco de dado");
            }
        }

        public static void desconecta()
        {
            conn.Close();
        }

        public static void insiraUmArduino(Arduino umArduino)
        {
            String aux = "insert into TabArduino(codigo,dataHora,dispositivo,acao) values (@codigo,@dataHora,@dispositivo,@acao)";


            strSQL = new OleDbCommand(aux, conn);
            strSQL.Parameters.Add("@codigo", OleDbType.Integer).Value = int.Parse(umArduino.getCodigo());
            strSQL.Parameters.Add("@dataHora", OleDbType.Date).Value = umArduino.getDataHora();
            strSQL.Parameters.Add("@dispositivo", OleDbType.WChar).Value = umArduino.getDispositivo();
            strSQL.Parameters.Add("@acao", OleDbType.WChar).Value = (umArduino.getAcao());
            

            Erro.setErro(false);
            try
            {
                strSQL.ExecuteNonQuery();
            }
            catch (Exception)
            {
                Erro.setMsg("A inserção não foi possivel, chave duplicada");
            }

        }
       
    }
}
