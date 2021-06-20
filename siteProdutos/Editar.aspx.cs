using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace siteProdutos
{
    public partial class Editar : System.Web.UI.Page
    {
        private static string imgName = "";

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
            int IdCliente = obterIdCliente();
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Conexao.Connection;

                cmd.CommandText = @"select * from product where pd_id = @IdCliente";
                cmd.Parameters.AddWithValue("@IdCliente", IdCliente);

                Conexao.Conectar();

                var reader = cmd.ExecuteReader();

                reader.Read();
                float price = reader.GetFloat("pd_price");
                string isprice = price.ToString();

                int id = reader.GetInt32("pd_id");
                string isid = id.ToString();

                string url = reader.GetString("pd_image");

                //variável para retornar o nome da imagem, caso nada seja substituido
                imgName = url;

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

        private int obterIdCliente()
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

        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                string img = "";

                if (uplImg.HasFile)
                {
                    //salva a foto no caminho que é indicado.
                    uplImg.SaveAs(Server.MapPath($"img/imgProducts/{uplImg.FileName}"));
                    //captura o nome da imagem com extensão para colocar no banco
                    img = uplImg.FileName;
                }
                else
                {
                    img = imgName;
                }


                cmd.Connection = Conexao.Connection;
                cmd.CommandText = @"update product set
                                        pd_nome = @nome,
                                        pd_desc = @description,
                                        pd_price = @price,
                                        pd_image = @image
                                   where pd_id = @id";

                //tratamento do float para string
                string price = txtPrice.Text.Replace(",", ".");

                cmd.Parameters.AddWithValue("@id", txtId.Text);
                cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@description", txtDescription.Text);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@image", img);


                Conexao.Conectar();
                cmd.ExecuteNonQuery();
                Response.Redirect("Listar.aspx");

            }
            catch(Exception ex)
            {
                lblResult.Text = ex.Message;
            }
            finally
            {
                Conexao.Desconectar();
            }
        }
    }
}