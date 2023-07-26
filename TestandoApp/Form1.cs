using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelo;
using Controle;

namespace TestandoApp
{
    public partial class FormCliente : Form
    {
        public FormCliente() //Construtor
        {
            InitializeComponent(); //Constroi tudo que tem no formulario
        }

        private void btn_Cadastrar_Click(object sender, EventArgs e)
        {
            UsuarioModelo novoUsuario = new UsuarioModelo();
            novoUsuario.nome = txt_nome.Text;
            novoUsuario.senha = txt_senha.Text;

            UsuarioControle cadastrarNovoUsuario = new UsuarioControle();
            if (novoUsuario.nome != "" && novoUsuario.senha != "")
            {

                if (cadastrarNovoUsuario.cadastrar(novoUsuario))
                    MessageBox.Show("Sucesso!\nO usuário " + txt_nome.Text + " foi adicionado ao banco");
                else
                    MessageBox.Show("Erro!\nFalha ao cadastrar o usuário.");
            }
            else
                MessageBox.Show("Preencha os campos obrigatórios");
        }

        private void FormCliente_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Seja bem-vindo(a)");
        }

        private void btn_Conectar_Click(object sender, EventArgs e)
        {
            //Chamando a instancia do objeto
            conexao conectar = new conexao();
            if (conectar.GetConexao() == null)
            {
                MessageBox.Show("Erro na conexão!");
            }
            else
            {
                MessageBox.Show("Teste com o BD realizado com sucesso!!!");
            }
        }
    }
}
