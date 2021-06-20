using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace siteProdutos
{
    public partial class Deletar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (capturaId())
                {
                    DadosConsulta();
                }
            }
        }
        private void DadosConsulta()
        {
            int IdProduto = obterIdProduto();
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Conexao.Connection;

                cmd.CommandText = @"select * from product where pd_id = @IdProduto";
                cmd.Parameters.AddWithValue("@IdProduto", IdProduto);

                Conexao.Conectar();

                var reader = cmd.ExecuteReader();

                reader.Read();
                float price = reader.GetFloat("pd_price");
                string isprice = price.ToString();

                int id = reader.GetInt32("pd_id");
                string isid = id.ToString();

                string url = reader.GetString("pd_image");

                txtId.Text = isid;
                txtNome.Text = reader.GetString("pd_nome");
                txtDescription.Text = reader.GetString("pd_desc");
                txtPrice.Text = isprice;
                imgProduto.ImageUrl = $"img/imgProducts/{url}";
            }
            catch (Exception ex)
            {
                lblResult.Text = ex.Message;
            }
            finally
            {
                Conexao.Desconectar();
            }
        }
        private int obterIdProduto()
        {
            int id = 0;

            var idURL = Request.QueryString["id"];

            if (!int.TryParse(idURL, out id))
            {
                throw new Exception("ID inválido");
            }
            if (id <= 0)
            {
                throw new Exception("ID inválido");
            }
            return id;
        }

        private bool capturaId()
        {
            return Request.QueryString.AllKeys.Contains("id");
        }

        protected void btnDeletar_Click(object sender, EventArgs e)
        {
            int IdProduto = obterIdProduto();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Conexao.Connection;
                cmd.CommandText = @"delete from product where pd_id = @IdProduto";

                cmd.Parameters.AddWithValue("@IdProduto", IdProduto);

                Conexao.Conectar();
                cmd.ExecuteNonQuery();

                Response.Redirect("listar.aspx");
            }
            catch (Exception ex)
            {
                lblResult.Text = $"Error: {ex.Message}";
            }
            finally
            {
                Conexao.Desconectar();
            }
        }
    }
}