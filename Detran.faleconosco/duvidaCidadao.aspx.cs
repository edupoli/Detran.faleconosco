using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Web.UI;

namespace Detran.faleconosco
{
    public partial class duvidaCidadao : System.Web.UI.Page
    {
        string idfaleconosco;
        string historicoSupervisor;
        string historicoOperador;
        string historicoOperadorComCidadao;
        DateTime data = DateTime.Now;
        string usuario;
        string status;
        Conexao con = new Conexao();

        string Vmail; string numProtocolo;
        string VNome; string VRG; string VUF;
        string VCPF; string VdataNasc; string VCelular; string VTelefone;
        string VCnh; string VDtvalidade; string VUFcnh; string VCnhsn;
        string VRenavan; string VPlaca; string VNumeroi;
        string assunto; string VMensagem;

        protected void Page_Load(object sender, EventArgs e)
        {
            idfaleconosco = Request.QueryString["idfaleconosco"];
            ListarDados();
            numProtocolo = protocolo.Text;
            Vmail = email.Text;
            VNome = nome.Text;
            VRG = rg.Text;
            VUF = uf.Text;
            VCPF = cpf.Text;
            VdataNasc = datanasc.Text;
            VCelular = celular.Text;
            VTelefone = telefone.Text;
            VCnh = cnh.Text;
            VDtvalidade = dtvalidade.Text;
            VUFcnh = ufcnh.Text;
            VRenavan = renavan.Text;
            VPlaca = placa.Text;
            VNumeroi = numeroi.Text;
            VMensagem = mensagem.Value;
            if (Session["perfil"].ToString() == "supervisor")
            {
                RetornoSupervisor.Text = "Retornar ao Operador:";
                lbEncaminhar.Text = "Encaminhar para Operador";
            }
            if (Session["perfil"].ToString() != "supervisor")
            {
                RetornoSupervisor.Text = "Retorno do Supervisor:";
                lbEncaminhar.Text = "Encaminhar para Supervisor";
            }
            usuario = Session["nome"].ToString();
        }

        private void ListarDados()
        {
            string sql;
            MySqlCommand cmd;
            con.AbrirCon();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter();
            sql = "SELECT * FROM faleconosco WHERE idfaleconosco=@idfaleconosco";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@idfaleconosco", idfaleconosco);
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                protocolo.Text = dt.Rows[0][1].ToString();
                nome.Text = dt.Rows[0][2].ToString();
                rg.Text = dt.Rows[0][3].ToString();
                uf.Text = dt.Rows[0][4].ToString();
                email.Text = dt.Rows[0][5].ToString();
                cpf.Text = dt.Rows[0][6].ToString();
                datanasc.Text = Convert.ToString(dt.Rows[0][7].ToString());
                celular.Text = dt.Rows[0][8].ToString();
                telefone.Text = dt.Rows[0][9].ToString();
                VCnhsn = dt.Rows[0][10].ToString();
                cnh.Text = dt.Rows[0][11].ToString();
                dtvalidade.Text = dt.Rows[0][12].ToString();
                ufcnh.Text = dt.Rows[0][13].ToString();
                renavan.Text = dt.Rows[0][14].ToString();
                placa.Text = dt.Rows[0][15].ToString();
                numeroi.Text = dt.Rows[0][16].ToString();
                mensagem.Value = dt.Rows[0][17].ToString();
                status = dt.Rows[0][21].ToString();
                if (status=="retorno detran" && Session["perfil"].ToString() != "supervisor" && dt.Rows[0][18].ToString() != "")
                {
                    mensagem_do_supervisor.Value = dt.Rows[0][19].ToString();
                }
                if (status=="supervisao" && Session["perfil"].ToString() == "supervisor" && dt.Rows[0][18].ToString() != "" )
                {
                    mensagem_encaminhamento.Value = dt.Rows[0][18].ToString();
                }
                if (dt.Rows[0][18].ToString() != "")
                {
                    historicoOperador = dt.Rows[0][18].ToString();
                }
                if (status=="supervisor" && Session["perfil"].ToString() =="supervisor" && dt.Rows[0][19].ToString() != "" )
                {
                    mensagem_do_supervisor.Value = "";
                }
                if (dt.Rows[0][19].ToString() != "")
                {
                    historicoSupervisor = dt.Rows[0][19].ToString();
                }
                if (status == "Retorno Cidadao" && Session["perfil"].ToString() != "supervisor" && dt.Rows[0][20].ToString() != "")
                {
                   // mensagem_resposta.Value = "";
                }
                if (dt.Rows[0][20].ToString() != "")
                {
                    historicoOperadorComCidadao = dt.Rows[0][20].ToString();
                }
                
                dataAbertura.Text = dt.Rows[0][22].ToString();

                if (status== "supervisor" && dt.Rows[0][19].ToString() != "")
                {
                    mensagem_do_supervisor.Value = "";
                }
                if (status == "fechado")
                {
                    mensagem_resposta.Value = dt.Rows[0][20].ToString();
                    mensagem_encaminhamento.Value = dt.Rows[0][18].ToString();
                    mensagem_do_supervisor.Value = dt.Rows[0][19].ToString();
                }
                LabelCidadao.Text = dt.Rows[0][17].ToString();
                LabelOperadorSupervisor.Text = dt.Rows[0][18].ToString();
                LabelSupervisorOperador.Text = dt.Rows[0][19].ToString();
                LabelOperadorCidadao.Text = dt.Rows[0][20].ToString();

            }

            con.FecharCon();
        }

        protected void btnEnvia_Click(object sender, EventArgs e)
        {
            if (rbRespCidadao.Checked == false && rbRespSupervisao.Checked == false)
            {
                ClientScript.RegisterStartupScript(GetType(), "Popup", "erroEncaminhar();", true);
            }

            if (rbRespCidadao.Checked == true && mensagem_resposta.Value == "" && status != "Retorno Cidadao")
            {
                ClientScript.RegisterStartupScript(GetType(), "Popup", "erroTxtCidadao();", true);
            }
            if (rbRespCidadao.Checked==true && mensagem_resposta.Value !="" )
            {
                SalvarCidadao();
                Email();
            }
            if (rbRespCidadao.Checked ==true && status == "Retorno Cidadao")
            {
                //SalvarCidadao();
                //Email();
            }
            if (rbRespSupervisao.Checked == true && status == "supervisao" && Session["perfil"].ToString() != "supervisor")
            {
                ClientScript.RegisterStartupScript(GetType(), "Popup", "erroTxtEncSupervisao();", true);
            }
           
            if (rbRespSupervisao.Checked==true && mensagem_encaminhamento.Value=="")
            {
                ClientScript.RegisterStartupScript(GetType(), "Popup", "erroTxtSupervisao();", true);
            }
            if (rbRespSupervisao.Checked==true && mensagem_encaminhamento.Value !="" && Session["perfil"].ToString() != "supervisor")
            {
                SalvarSupervisao();
            }
            if (rbRespSupervisao.Checked==true && mensagem_do_supervisor.Value=="")
            {
                ClientScript.RegisterStartupScript(GetType(), "Popup", "erroTxtOperador();", true);
            }
            if (rbRespSupervisao.Checked == true && mensagem_do_supervisor.Value !="" && Session["perfil"].ToString() == "supervisor")
            {
                SalvarRetornoSupervisao();
            }

        }
        
        private void SalvarCidadao()
        {
            string sql;
            MySqlCommand cmd;
            con.AbrirCon();
            sql = "UPDATE faleconosco SET mensagem_resposta = @mensagem_resposta, status = @status WHERE idfaleconosco = @idfaleconosco";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@idfaleconosco", idfaleconosco);
            cmd.Parameters.AddWithValue("@mensagem_resposta", "[ Enviada em " + data + " Por " + usuario + " ]" + System.Environment.NewLine + mensagem_resposta.Value + System.Environment.NewLine + historicoOperadorComCidadao + System.Environment.NewLine);
            cmd.Parameters.AddWithValue("@status", "fechado");

            cmd.ExecuteNonQuery();
            Label1.Text = "Dados Inseridos com Sucesso!";
            return;
            //Response.Redirect("pabx.aspx");

        }
        private void SalvarSupervisao()
        {
            string sql;
            MySqlCommand cmd;
            con.AbrirCon();
            sql = "UPDATE faleconosco SET mensagem_encaminhamento=@mensagem_encaminhamento,status=@status where idfaleconosco=@idfaleconosco";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@idfaleconosco", idfaleconosco);
            cmd.Parameters.AddWithValue("@mensagem_encaminhamento", "[ Enviada em " + data + " Por " + usuario + " ]"+ System.Environment.NewLine + mensagem_encaminhamento.Value + System.Environment.NewLine + historicoOperador + System.Environment.NewLine);
            cmd.Parameters.AddWithValue("@status", "supervisao");

            cmd.ExecuteNonQuery();
            ClientScript.RegisterStartupScript(GetType(), "Popup", "sucessSupervisao();", true);
            Label1.Text = "Dados Inseridos com Sucesso!";
            return;
            //Response.Redirect("pabx.aspx");

        }
        private void SalvarRetornoSupervisao()
        {
            string sql;
            MySqlCommand cmd;
            con.AbrirCon();
            sql = "UPDATE faleconosco SET mensagem_do_supervisor=@mensagem_do_supervisor,status=@status where idfaleconosco=@idfaleconosco";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@idfaleconosco", idfaleconosco);
            cmd.Parameters.AddWithValue("@mensagem_do_supervisor", "[ Enviada em " + data + " Por " + usuario + " ]" + System.Environment.NewLine + mensagem_do_supervisor.Value + System.Environment.NewLine + historicoSupervisor + System.Environment.NewLine);
            cmd.Parameters.AddWithValue("@status", "retorno detran");

            cmd.ExecuteNonQuery();
            ClientScript.RegisterStartupScript(GetType(), "Popup", "sucessRetornoSupervisao();", true);
            Label1.Text = "Dados Inseridos com Sucesso!";
            return;
        }
        private void Email()
        {
            try
            {
                assunto = "Resposta Protocolo Nº " + numProtocolo + " Fale Conosco Detran-PR";
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(Vmail, "Fale Conosco Detran-PR");
                mailMessage.To.Add(Vmail.ToLower());
                mailMessage.Subject = assunto;
                mailMessage.IsBodyHtml = true;
                mailMessage.Body =
                mailMessage.Body = "<html><body><img src=/logo.png/><br><br>"+ "<b>Olá " + VNome + "</b><br><br>" + 
                            "Em Resposta a sua solicitação na qual foi registrada com protocolo Nº " + numProtocolo + "<br>" +
                           "<br>Sua Mensagem: <br>"+ VMensagem + "<br><br>" + 
                           "Segue abaixo Resposta:<br>" + mensagem_resposta.Value + "<br>"+ historicoOperadorComCidadao + "<br><br>" +
                           "Caso ainda tenha dúvidas referente a esse protocolo, por favor <b><a href='http://10.0.2.135/faleconosco/faleconosco?idfaleconosco=" + idfaleconosco + "'>CLIQUE AQUI</a></b> para nos perguntar<br>" +
                           "Obrigado por entrar em contato, estamos a disposição.<br>" +
                           "O DETRAN-PR está a sua disposição, você também pode conseguir informação e serviços em nosso site www.detran.pr.gov.br ou baixe nosso Aplicativo Detran INTELIGENTE (IOS ou Android).<br>" +
                           "Nosso horário de atendimento presencial é das 08h00min às 14h00min de segunda a sexta - feira.<br>" +
                           "Nosso horário de atendimento na central de informações é das 08h00min às 20h00min de segunda a sexta - feira.</body><html>";

                mailMessage.Priority = MailPriority.High;

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential("sercomtelcontatcenter@gmail.com", "gask8930");
                smtpClient.Send(mailMessage);
                //Response.Redirect("Default.aspx");
                ClientScript.RegisterStartupScript(GetType(), "Popup", "sucessEmail();", true);
                Label1.Text = "E-mail enviado, com sucesso!";
            }
            catch (Exception)
            {
                ClientScript.RegisterStartupScript(GetType(), "Popup", "erroEmail();", true);
                Label1.Text = "Erro ao enviar e-mail";
                throw;
            }
            
        }
    }
    
}