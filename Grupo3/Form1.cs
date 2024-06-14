using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Grupo3
{
    public partial class Form1 : Form
    {
        private MySqlConnection con;
        private MySqlDataAdapter da;
        private DataTable usuario;
        public Form1()
        {
            InitializeComponent();

            string connectionString = "Server=localhost;Database=APP;Uid=root;Pwd=1234;";
            con = new MySqlConnection(connectionString);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // Abrir conexão com o banco de dados
                con.Open();

                // Criar comando SQL para selecionar produtos
                string sql = "SELECT CPF,Nome FROM usuario";
                MySqlCommand cmd = new MySqlCommand(sql, con);

                // Executar comando e obter dados em um DataTable
                da = new MySqlDataAdapter(cmd);
                usuario = new DataTable();
                da.Fill(usuario);

                // Atualizar DataGridView com os dados da tabela
                dgvApp.DataSource = usuario;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar produtos: " + ex.Message);
            }
            finally
            {
                // Fechar conexão com o banco de dados
                con.Close();
            }
        }

        private void btnNovoCadastro_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                // Abrir conexão com o banco de dados
                con.Open();

                // Criar comando SQL para selecionar produtos
                string sql = "SELECT cpf,nome FROM usuario";
                MySqlCommand cmd = new MySqlCommand(sql, con);

                // Executar comando e obter dados em um DataTable
                da = new MySqlDataAdapter(cmd);
                usuario = new DataTable();
                da.Fill(usuario);

                // Atualizar DataGridView com os dados da tabela
                dgvApp.DataSource = usuario;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar usuario: " + ex.Message);
            }
            finally
            {
                // Fechar conexão com o banco de dados
                con.Close();
            }
        }
    }
}
