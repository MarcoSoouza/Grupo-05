using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;


namespace Grupo3
{
    public partial class Form2 : Form
    {
        private MySqlConnection con;
        public Form2()
        {
            InitializeComponent();

            string connectionString = "Server=localhost;Database=APP;Uid=root;Pwd=1234;";
            con = new MySqlConnection(connectionString);
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" )
            {
                MessageBox.Show("Preencha todos os campos!");
                return;
            }

            try
            {
                // Abrir conexão com o banco de dados
                con.Open();

                // Criar comando SQL para inserir novo produto
                string sql = "INSERT INTO usuario (cpf,nome) VALUES (@cpf, @nome)";
                MySqlCommand cmd = new MySqlCommand(sql, con);

                // Adicionar parâmetros para o comando SQL
                cmd.Parameters.AddWithValue("@cpf", textBox1.Text);
                cmd.Parameters.AddWithValue("@nome", textBox2.Text);

                // Executar comando SQL para inserir o novo produto
                cmd.ExecuteNonQuery();

                MessageBox.Show("Usuário cadastrado com sucesso!");

                // Limpar campos do formulário
                textBox1.Text = "";
                textBox2.Text = "";
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar Usuário: " + ex.Message);
            }
            finally
            {
                // Fechar conexão com o banco de dados
                con.Close();
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Preencha todos os campos!");
                return;
            }

            try
            {
                // Abrir conexão com o banco de dados
                con.Open();

                // Criar comando SQL para inserir novo produto
                string sql = "DELETE FROM usuario WHERE cpf = 'specific_cpf_value' AND nome = 'specific_nome_value'";
                MySqlCommand cmd = new MySqlCommand(sql, con);

                // Adicionar parâmetros para o comando SQL
                cmd.Parameters.AddWithValue("@cpf", textBox1.Text);
                cmd.Parameters.AddWithValue("@nome", textBox2.Text);

                // Executar comando SQL para inserir o novo produto
                cmd.ExecuteNonQuery();

                MessageBox.Show("Usuário Deletado com sucesso!");

                // Limpar campos do formulário
                textBox1.Text = "";
                textBox2.Text = "";
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Deletar Usuário: " + ex.Message);
            }
            finally
            {
                // Fechar conexão com o banco de dados
                con.Close();
            }
        }
    }
}
