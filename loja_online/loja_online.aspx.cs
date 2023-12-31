﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace loja_online
{
    public partial class loja_online : System.Web.UI.Page
    {
        string query = "";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cargo"] != null)
            {
                
                lbl_cargo.Visible = true;
                lbl_cargo.Text = (string)Session["cargo"];
                string username = (string)Session["username"];
                btn_sair.Visible = true;
                lb_minhaConta.Visible = false;
                lbl_nome.Visible = true;
                lbl_nome.Text = "Bem-vindo/a, " + username;
            }

            string cargo = (string)Session["cargo"];
           
            //Aqui agora para começar o código

            if (!IsPostBack)
            {
                decimal valorTotal = 0;

                if (Session["ValorAcumulado"] != null && Decimal.TryParse(Session["ValorAcumulado"].ToString(), out valorTotal))
                {
                    lbl_valor.Text = valorTotal > 0 ? valorTotal.ToString("C") : "0,00 €";
                }
                else
                {
                    lbl_valor.Text = "0,00 €";
                }
            }



            if (ddl_opcoes.SelectedItem.ToString() == "Nome Produto")
            {
                query = "SELECT id_produto,produto, designacao, preco, preco_revenda, foto, contenttype FROM produtos WHERE ativo = 'True' ORDER BY produto";
            }
            else if (ddl_opcoes.SelectedItem.ToString() == "Preço Ascendente")
            {
                query = "SELECT id_produto,produto, designacao, preco, preco_revenda, foto, contenttype FROM produtos WHERE ativo = 'True' ORDER BY preco ASC";
            }
            else if (ddl_opcoes.SelectedItem.ToString() == "Preço Descendente")
            {
                query = "SELECT id_produto,produto, designacao, preco, preco_revenda, foto, contenttype FROM produtos WHERE ativo = 'True' ORDER BY preco DESC";
            }
            else
            {
                query = "SELECT id_produto,produto, designacao, preco, preco_revenda, foto, contenttype FROM produtos Where ativo = 'True'";
            }

            SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["lojaOnline_aulaTesteConnectionString"].ConnectionString);

            SqlCommand mycomm = new SqlCommand(query, myconn);

            List<Produtos> lst_produtos = new List<Produtos>();

            myconn.Open();

            var reader = mycomm.ExecuteReader();

            while (reader.Read())
            {
                Produtos produto = new Produtos();

                produto.id_produto = reader.GetInt32(0);
                produto.produto = reader.GetString(1);
                produto.designacao = reader.GetString(2);
                produto.preco = reader.GetDecimal(3);

                if (cargo == "Revendedor")
                {
                    produto.preco_revenda = reader.GetDecimal(4);
                }

                byte[] imagemBytes = (byte[])reader["foto"];
                string contentType = reader.GetString(reader.GetOrdinal("ContentType"));

                // Convertendo os bytes da imagem em uma string base64
                string imagemBase64 = Convert.ToBase64String(imagemBytes);
                string imagemSrc = $"data:{contentType};base64,{imagemBase64}";

                produto.imagemSrc = imagemSrc;


                lst_produtos.Add(produto);
            }

            myconn.Close();
            rptProdutos.DataSource = lst_produtos;
            rptProdutos.DataBind();
        }

        protected void txt_pesquisar_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT id_produto,produto, designacao, preco, preco_revenda, foto, contenttype FROM produtos WHERE produto LIKE '%" + txt_pesquisar.Text + "%' And ativo = 'True'";


            SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["lojaOnline_aulaTesteConnectionString"].ConnectionString);

            SqlCommand mycomm = new SqlCommand(query, myconn);

            List<Produtos> lst_produtos = new List<Produtos>();

            myconn.Open();

            var reader = mycomm.ExecuteReader();
            string cargo = (string)Session["cargo"];
            while (reader.Read())
            {
                Produtos produto = new Produtos();

                produto.id_produto = reader.GetInt32(0);
                produto.produto = reader.GetString(1);
                produto.designacao = reader.GetString(2);
                produto.preco = reader.GetDecimal(3);
                if (cargo == "Revendedor")
                {
                    produto.preco_revenda = reader.GetDecimal(4);
                }

                byte[] imagemBytes = (byte[])reader["foto"];
                string contentType = reader.GetString(reader.GetOrdinal("ContentType"));

                // Convertendo os bytes da imagem em uma string base64
                string imagemBase64 = Convert.ToBase64String(imagemBytes);
                string imagemSrc = $"data:{contentType};base64,{imagemBase64}";

                produto.imagemSrc = imagemSrc;


                lst_produtos.Add(produto);
            }

            myconn.Close();
            rptProdutos.DataSource = lst_produtos;
            rptProdutos.DataBind();
        }

        protected void Lb_menos100_Click(object sender, EventArgs e)
        {
            string query = "SELECT id_produto,produto, designacao, preco, preco_revenda, foto, contenttype FROM produtos WHERE preco < 100 AND ativo = 'True'";


            SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["lojaOnline_aulaTesteConnectionString"].ConnectionString);

            SqlCommand mycomm = new SqlCommand(query, myconn);

            List<Produtos> lst_produtos = new List<Produtos>();

            myconn.Open();

            var reader = mycomm.ExecuteReader();
            string cargo = (string)Session["cargo"];
            while (reader.Read())
            {
                Produtos produto = new Produtos();

                produto.id_produto = reader.GetInt32(0);
                produto.produto = reader.GetString(1);
                produto.designacao = reader.GetString(2);
                produto.preco = reader.GetDecimal(3);
                if (cargo == "Revendedor")
                {
                    produto.preco_revenda = reader.GetDecimal(4);
                }

                byte[] imagemBytes = (byte[])reader["foto"];
                string contentType = reader.GetString(reader.GetOrdinal("ContentType"));

                // Convertendo os bytes da imagem em uma string base64
                string imagemBase64 = Convert.ToBase64String(imagemBytes);
                string imagemSrc = $"data:{contentType};base64,{imagemBase64}";

                produto.imagemSrc = imagemSrc;


                lst_produtos.Add(produto);
            }

            myconn.Close();
            rptProdutos.DataSource = lst_produtos;
            rptProdutos.DataBind();
        }

        protected void lb_entre100e300_Click(object sender, EventArgs e)
        {
            string query = "SELECT id_produto,produto, designacao, preco, preco_revenda, foto, contenttype FROM produtos WHERE preco >= 100 AND preco <= 300 AND ativo = 'True'";


            SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["lojaOnline_aulaTesteConnectionString"].ConnectionString);

            SqlCommand mycomm = new SqlCommand(query, myconn);

            List<Produtos> lst_produtos = new List<Produtos>();

            myconn.Open();

            var reader = mycomm.ExecuteReader();
            string cargo = (string)Session["cargo"];
            while (reader.Read())
            {
                Produtos produto = new Produtos();

                produto.id_produto = reader.GetInt32(0);
                produto.produto = reader.GetString(1);
                produto.designacao = reader.GetString(2);
                produto.preco = reader.GetDecimal(3);
                if (cargo == "Revendedor")
                {
                    produto.preco_revenda = reader.GetDecimal(4);
                }
                byte[] imagemBytes = (byte[])reader["foto"];
                string contentType = reader.GetString(reader.GetOrdinal("ContentType"));

                // Convertendo os bytes da imagem em uma string base64
                string imagemBase64 = Convert.ToBase64String(imagemBytes);
                string imagemSrc = $"data:{contentType};base64,{imagemBase64}";

                produto.imagemSrc = imagemSrc;


                lst_produtos.Add(produto);
            }

            myconn.Close();
            rptProdutos.DataSource = lst_produtos;
            rptProdutos.DataBind();
        }

        protected void lb_mais300_Click(object sender, EventArgs e)
        {
            string query = "SELECT id_produto,produto, designacao, preco,preco_revenda, foto, contenttype FROM produtos WHERE preco > 300 AND ativo = 'True'";


            SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["lojaOnline_aulaTesteConnectionString"].ConnectionString);

            SqlCommand mycomm = new SqlCommand(query, myconn);

            List<Produtos> lst_produtos = new List<Produtos>();

            myconn.Open();

            var reader = mycomm.ExecuteReader();
            string cargo = (string)Session["cargo"];
            while (reader.Read())
            {
                Produtos produto = new Produtos();

                produto.id_produto = reader.GetInt32(0);
                produto.produto = reader.GetString(1);
                produto.designacao = reader.GetString(2);
                produto.preco = reader.GetDecimal(3);
                if (cargo == "Revendedor")
                {
                    produto.preco_revenda = reader.GetDecimal(4);
                }
                byte[] imagemBytes = (byte[])reader["foto"];
                string contentType = reader.GetString(reader.GetOrdinal("ContentType"));

                // Convertendo os bytes da imagem em uma string base64
                string imagemBase64 = Convert.ToBase64String(imagemBytes);
                string imagemSrc = $"data:{contentType};base64,{imagemBase64}";

                produto.imagemSrc = imagemSrc;


                lst_produtos.Add(produto);
            }

            myconn.Close();
            rptProdutos.DataSource = lst_produtos;
            rptProdutos.DataBind();
        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
              Button btn = (Button)sender;
              string[] argumentos = btn.CommandArgument.ToString().Split('|');

              int produtoID = Convert.ToInt32(argumentos[0]);
              string nomeProduto = argumentos[1];
              decimal preco;

            if (Session["cargo"] != null && Session["cargo"].ToString().Equals("Revendedor", StringComparison.OrdinalIgnoreCase))
            {
                preco = Convert.ToDecimal(argumentos[4]); // Usa o preco_revenda
            }
            else
            {
                preco = Convert.ToDecimal(argumentos[2]); // Usa o preco normal
            }

              string imagemSrc = argumentos[3];
              

              // Obtém o valor acumulado da sessão (ou 0 se for a primeira vez)
              decimal valorAcumulado = (Session["ValorAcumulado"] != null) ? (decimal)Session["ValorAcumulado"] : 0;

              // Soma o novo preço ao valor acumulado
              valorAcumulado = valorAcumulado + preco;


              // Atualiza o valor na label
              lbl_valor.Text = valorAcumulado.ToString("C");

              // Atualiza o valor acumulado na sessão
              Session["ValorAcumulado"] = valorAcumulado;

             string produtoid = Convert.ToString(btn.CommandArgument);

              Produtos item = new Produtos
              {
                  imagemSrc=imagemSrc,
                  id_produto = produtoID,
                  produto = nomeProduto,
                  preco = preco,
                  Quantidade = 1 // Quantidade inicial
              };

              List<Produtos> carrinho;

              if (Session["Carrinho"] == null)
              {
                  carrinho = new List<Produtos>();
              }
              else
              {
                  carrinho = (List<Produtos>)Session["Carrinho"];
              }

              carrinho.Add(item);

              Session["Carrinho"] = carrinho;

        }

        protected void btn_sair_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("loja_online.aspx");
            lb_minhaConta.Visible = true;
            lbl_nome.Visible = false;
        }

        protected void lb_minhaConta_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }

        protected void lbl_nome_Click(object sender, EventArgs e)
        {
            Response.Redirect("conta.aspx");
        }
    }
}