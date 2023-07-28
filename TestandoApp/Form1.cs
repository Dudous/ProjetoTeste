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
using System.Security.Cryptography.X509Certificates;

namespace TestandoApp
{
    public partial class FormCliente : Form
    {
        public FormCliente() //Construtor
        {
            InitializeComponent(); //Constroi tudo que tem no formulario
        }
            int codigo = 0;

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
            //MessageBox.Show("Seja bem-vindo(a)");
            //instanciar meu controleUsuario
            UsuarioControle usControle = new UsuarioControle();
            dtUsuario.DataSource = usControle.ObterDados("select * from usuario");
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

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            UsuarioControle uscontroller = new UsuarioControle();
            //chamo o metodo excluir do usuario controle
            if(uscontroller.Excluir(codigo)== true)
            {
                MessageBox.Show("Usuário excluído");
            }
            else
            {
                MessageBox.Show("Erro ao excluir usuário");
            }
        }

        private void dtUsuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //convertendo a primeira célula em inteiro
            codigo = Convert.ToInt32(dtUsuario.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
            //converte o interiro para string
            MessageBox.Show("Usuário selecionado: " + codigo.ToString());
            txt_nome.Text = dtUsuario.Rows[e.RowIndex].Cells["nome"].Value.ToString();
            txt_senha.Text = dtUsuario.Rows[e.RowIndex].Cells["senha"].Value.ToString();


        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //instancio o objeto usuario controle
            UsuarioControle uscontroller = new UsuarioControle();
            UsuarioModelo usmodelo = new UsuarioModelo();
            //populando o objeto usuário modelo
            usmodelo.nome = txt_nome.Text;
            usmodelo.senha = txt_senha.Text;
            usmodelo.id = codigo;
            if (uscontroller.Editar(usmodelo))
                MessageBox.Show("Usuário atualizado com sucesso");
            else
                MessageBox.Show("Erro ao atualizar usuário");
        }

        private void btnListarUsuario_Click(object sender, EventArgs e)
        {
            //instancio o novo formulario
            FrmListarUsuario frmListar = new FrmListarUsuario();
            frmListar.ShowDialog();//mostro o formulario listar
        }
    }
}
