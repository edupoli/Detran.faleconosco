using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Detran.faleconosco
{
    public partial class Finalizados : System.Web.UI.Page
    {
        int idfaleconosco;
        string login;
        Conexao con = new Conexao();
        protected void Page_Load(object sender, EventArgs e)
        {
            painelErroGrid.Visible = false;
            Listar();
        }
        private void Listar()
        {
            string sql;
            MySqlCommand cmd;
            con.AbrirCon();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter();
            sql = "SELECT * FROM faleconosco where status ='fechado' ORDER BY data_abertura ASC";
            cmd = new MySqlCommand(sql, con.con);
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                grid.Visible = true;
                grid.DataSource = dt;
                grid.DataBind();
            }
            else
            {
                grid.Visible = false;
                painelErroGrid.Visible = true;
                gridMensagemErro.Text = "Não existem Lançamentos Cadastrados!";
            }
            con.FecharCon();

        }
        protected void btnResponder_Click(object sender, EventArgs e)
        {
            idfaleconosco = Convert.ToInt32((sender as Button).CommandArgument);
            Response.Redirect("duvidaCidadao.aspx?idfaleconosco=" + idfaleconosco);

        }
        protected void grid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex >= 0)
            {
                string status = DataBinder.Eval(e.Row.DataItem, "status").ToString();
                if (status == "aberto")
                {
                    e.Row.Cells[2].BackColor = Color.Red;
                    e.Row.Cells[2].ForeColor = Color.White;
                }
                if (status == "fechado")
                {
                    e.Row.Cells[2].BackColor = Color.Green;
                    e.Row.Cells[2].ForeColor = Color.White;
                }
                if (status == "supervisao")
                {
                    e.Row.Cells[2].BackColor = Color.Blue;
                    e.Row.Cells[2].ForeColor = Color.White;
                }
            }


        }
    }
}