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
    public partial class Listar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            carregarProducts();

        }

        private void carregarProducts()
        {
            int id = (int)Session["id"];

            DataTable dt = new DataTable();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                string query = $"select * from product where user_id = {id}";

                MySqlDataAdapter da = new MySqlDataAdapter(query, Conexao.Connection);
                da.Fill(dt);
                
                rptProducts.DataSource = dt;
                rptProducts.DataBind();
            }
            catch(Exception ex)
            {
                lblMsg.Text = $"Error: {ex.Message}";
            }
            
        }
    }
}