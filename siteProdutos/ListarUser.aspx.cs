using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace siteProdutos
{
    public partial class ListarUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadUsers();
        }

        private void loadUsers()
        {
            string query = @"select * from users";
            DataTable dt = new DataTable();
            try
            {
                MySqlCommand cmd = new MySqlCommand();

                MySqlDataAdapter dados = new MySqlDataAdapter(query, cmd.Connection = Conexao.Connection);
                dados.Fill(dt);

                rptUsers.DataSource = dt;
                rptUsers.DataBind();
            }
            catch(Exception ex)
            {
                lblMsg.Text = $"Error: {ex.Message}";
            }
        }
    }
}