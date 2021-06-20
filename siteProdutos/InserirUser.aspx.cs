using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace siteProdutos
{
    public partial class InserirUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand();

            var senha = BCrypt.Net.BCrypt.HashPassword(txtSenha.Text);
            try
            {
                cmd.Connection = Conexao.Connection;
                cmd.CommandText = $@"insert into users 
                                        (user_nome, user_sobrenome, user_email, user_senha, user_telefone, user_cpf, user_sexo, user_nivel)
                                    values 
                                        (@nome, @sobrenome, @email, @senha, @telefone, @cpf, @sexo, @nivel)";

                cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@sobrenome", txtSobre.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@telefone", txtTel.Text);
                cmd.Parameters.AddWithValue("@cpf", txtCpf.Text);
                cmd.Parameters.AddWithValue("@sexo", ddlSexo.SelectedValue);
                cmd.Parameters.AddWithValue("@nivel", ddlNivel.SelectedValue);
                cmd.Parameters.AddWithValue("@senha", senha);


                Conexao.Conectar();
                
                cmd.ExecuteNonQuery();

                lblResult.CssClass = "text text-success";
                lblResult.Text = "enviado com sucesso";

            }
            catch (Exception ex)
            {
                lblResult.CssClass = "text text-danger";
                lblResult.Text = $"Error: {ex.Message}";
            }
            finally
            {
                Conexao.Desconectar();
            }

        }

    }
}