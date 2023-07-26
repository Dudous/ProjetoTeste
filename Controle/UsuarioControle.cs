using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Modelo;



namespace Controle
{
    public class UsuarioControle
    {
        conexao con = new conexao();
        
        public bool cadastrar( UsuarioModelo usuario)
        {
            bool resultado = false;
            string sqlComando = "INSERT INTO usuario (nome, senha) VALUES ('" + usuario.nome + "','" + usuario.senha + "')";

            MySqlConnection sqlConexao = con.GetConexao();
            sqlConexao.Open();
            MySqlCommand cmd = new MySqlCommand(sqlComando, sqlConexao);
            
            //
            if (cmd.ExecuteNonQuery() >= 1)
                resultado =  true;
                     
            sqlConexao.Close();
            
            
            return resultado;
        }
    }
}
