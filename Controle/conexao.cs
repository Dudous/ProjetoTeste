using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Agreement.Srp;

namespace Controle
{
    //Classe de conexão com o BD
    public class conexao
    {
        //Atributos para conectar no banco
        static private string servidor = "localhost";
        static private string db = "testando";
        static private string usuario = "root";
        static private string senha = "";

        //String para para se connectar no MySQL.
        static private string StrConexao = "server=" + servidor + ";database=" + db + ";user=" + usuario + ";password=" + senha;

        public MySqlConnection GetConexao()
        {
            MySqlConnection conexao = new MySqlConnection(StrConexao);
            return conexao;
        }
    }


}
