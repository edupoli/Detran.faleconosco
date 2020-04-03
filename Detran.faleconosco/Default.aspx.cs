using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Detran.faleconosco
{
    public partial class _Default : Page
    {
        int idfaleconosco;
        string login;
        Conexao con = new Conexao();
        protected void Page_Load(object sender, EventArgs e)
        {
            login = Session["usuario"].ToString();
            grid.Visible = false;
            painelErroGrid.Visible = false;
            if (Session["perfil"].ToString() != "supervisor")
            {
                ListarOperador();
            }
            else
            {
                ListarSupervisor();
            }
        }
        private void ListarOperador()
        {
            string sql;
            MySqlCommand cmd;
            con.AbrirCon();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter();
            sql = "SELECT * FROM faleconosco where status <> 'fechado' ORDER BY data_abertura ASC";
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

        private void ListarSupervisor()
        {
            string sql;
            MySqlCommand cmd;
            con.AbrirCon();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter();
            sql = "SELECT * FROM faleconosco where status='supervisao' order by data_abertura ASC";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@login", login);
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
                if (status == "retorno detran")
                {
                    e.Row.Cells[2].BackColor = Color.DarkOrchid;
                    e.Row.Cells[2].ForeColor = Color.White;
                }
                if (status == "Retorno Cidadao")
                {
                    e.Row.Cells[2].BackColor = Color.Yellow;
                    e.Row.Cells[2].ForeColor = Color.Black;
                }
            }


        }

        protected void grid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnResponder_Click(object sender, EventArgs e)
        {
                idfaleconosco = Convert.ToInt32((sender as Button).CommandArgument);
                Response.Redirect("duvidaCidadao.aspx?idfaleconosco=" + idfaleconosco);

        }
    }
}