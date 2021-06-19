using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace siteProdutos
{
    public partial class Inserir : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnImg_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand();

            try
            {
                //captura a file extension, mas não precisou ser usado.
                string fileExtension = System.IO.Path.GetExtension(uplImg.FileName);
                //salva a foto no caminho que é indicado.
                uplImg.SaveAs(Server.MapPath($"img/imgProducts/{uplImg.FileName}"));
                //captura o nome da imagem com extensão para colocar no banco
                string img = uplImg.FileName;
                //faz o tratamento da string para substituir , por . e salvar no banco.
                string price = txtPrice.Text.Replace(",", ".");
                cmd.Connection = Conexao.Connection;
                cmd.CommandText = @"insert into product (pd_nome, pd_image, pd_desc, pd_price) values (@nome, @image, @description, @price)";
                cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@image", img);
                cmd.Parameters.AddWithValue("@description", txtDescription.Text);
                cmd.Parameters.AddWithValue("@price", price);

                Conexao.Conectar();

                cmd.ExecuteNonQuery();

                lblResult.Text = "Enviado com Sucesso";
            }
            catch(Exception ex)
            {
                lblResult.Text = $"error:{ex.Message}";
            }
            finally
            {
                Conexao.Desconectar();
            }
        }
    }
}