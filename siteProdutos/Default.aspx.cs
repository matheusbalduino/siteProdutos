using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace siteProdutos
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                string usuario = txtUser.Text;

                string senha = txtPsw.Text;

                // recuperar senha do banco

                cmd.Connection = Conexao.Connection;

                cmd.CommandText = @"select user_senha from users where user_email = @usuario";

                cmd.Parameters.AddWithValue("@usuario", usuario);

                Conexao.Conectar();

                string senhaEncriptada = Convert.ToString(cmd.ExecuteScalar()); // recebe um único dado do banco e passa para a variável

                if (string.IsNullOrEmpty(senhaEncriptada))
                {

                    throw new Exception("Usuário ou Senha Inválido");

                }

                if (BCrypt.Net.BCrypt.Verify(senha, senhaEncriptada))
                {

                    cmd.CommandText = @"select  user_nome, user_nivel, user_id from users where user_email = @email";

                    cmd.Parameters.AddWithValue("@email", usuario);

                    var reader = cmd.ExecuteReader();

                    reader.Read();

                    string nivel = reader.GetString("user_nivel");
                    string nome = reader.GetString("user_nome");
                    int id = reader.GetInt32("user_id");

                    FormsAuthentication.RedirectFromLoginPage(nivel, false);

                    Session["Perfil"] = nivel;
                    Session["Nome"] = nome;
                    Session["id"] = id;
                }
                else
                {
                    throw new Exception("Usuário ou Senha Inválido");
                }


            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
            }
            finally
            {
                Conexao.Desconectar();
            }
        }
    }
}