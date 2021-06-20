using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace siteProdutos
{
    public partial class EditarUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (capturarId()) carregarDetalhes();
            }
        }

        private void carregarDetalhes()
        {

            int IdUser = obterIdUser();
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Conexao.Connection;
                cmd.CommandText = @"select * from users where user_id = @IdUser";
                cmd.Parameters.AddWithValue("@IdUser", IdUser);

                Conexao.Conectar();

                var rd = cmd.ExecuteReader();
                rd.Read();

                string admin = GetAdmin(rd.GetString("user_nivel"));

                txtNome.Text = rd.GetString("user_nome");
                txtSobre.Text = rd.GetString("user_sobrenome");
                txtEmail.Text = rd.GetString("user_email");
                ddlSexo.Text = rd.GetString("user_sexo");
                txtCpf.Text = rd.GetString("user_cpf");
                txtTel.Text = rd.GetString("user_telefone");
                txtNivel.Text = admin;

            }
            catch (Exception ex)
            {
                lblMsg.Text = $"Error: {ex.Message}";
            }
            finally
            {
                Conexao.Desconectar();
            }
        }
        private string GetSex(string sex)
        {
            if (sex == "M") return "Masculino";
            return "Feminino";
        }
        private string GetAdmin(string admin)
        {
            if (admin == "A") return "Administrador";
            return "Operador";
        }
        private int obterIdUser()
        {
            int id = 0;
            var idUrl = Request.QueryString["id"];
            if (!int.TryParse(idUrl, out id)) throw new Exception("ID Inválido");
            if (id <= 0) throw new Exception("ID Inválido");
            return id;
        }
        private bool capturarId()
        {
            return Request.QueryString.AllKeys.Contains("id");
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand();
            
            int idUser = obterIdUser();
            try
            {
                cmd.Connection = Conexao.Connection;
                cmd.CommandText = @"update users
                                    set user_nome = @nome, 
                                        user_sobrenome = @sobre, 
                                        user_email = @email, 
                                        user_sexo = @sexo, 
                                        user_cpf = @cpf, 
                                        user_telefone = @telefone
                                    where user_id = @idUser";

                cmd.Parameters.AddWithValue("@idUser", idUser);
                cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@sobre", txtSobre.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@sexo", ddlSexo.SelectedValue);
                cmd.Parameters.AddWithValue("@cpf", txtCpf.Text);
                cmd.Parameters.AddWithValue("@telefone", txtTel.Text);

                Conexao.Conectar();
                cmd.ExecuteNonQuery();
                lblMsg.CssClass = "text text-success";
                lblMsg.Text = "Atualizado com Sucesso!";
            }
            catch(Exception ex)
            {
                lblMsg.Text = $"Error: {ex.Message}";
            }
            finally
            {
                Conexao.Desconectar();
            }
        }
    }
}