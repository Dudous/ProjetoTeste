using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Modelo;
using System.Data;

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
        public DataTable ObterDados(string sql)
        {
            //crio uma nova tabela de daos
            DataTable dt = new DataTable();
            //conn é a conexão com o banco de dados
            MySqlConnection conn = con.GetConexao();
            conn.Open();//abre o banco de dados
            //preparo o comando sql
            MySqlCommand sqlCon = new MySqlCommand(sql, conn);
            //tipo de instrução texto
            sqlCon.CommandType = System.Data.CommandType.Text;
            sqlCon.CommandText = sql;
            //irá montar as informações da consulta
            MySqlDataAdapter dados = new MySqlDataAdapter(sqlCon);
            dados.Fill(dt);
            conn.Close();
            return dt;
        }

        public bool Excluir(int codigo)
        {
            bool resultado = false;
            MySqlConnection sqlcon = con.GetConexao();
            string sql = "delete from usuario where id=" + codigo;
            sqlcon.Open();
            MySqlCommand Command = new MySqlCommand(sql, sqlcon);
            Command.CommandType = System.Data.CommandType.Text;
            Command.CommandText = sql;
            if(Command.ExecuteNonQuery() >= 1)
                resultado=true;
            return resultado;
        }
    }
}
