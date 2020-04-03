using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Web.UI;

namespace Detran.faleconosco
{
    public partial class formulario : System.Web.UI.Page
    {
        string idfaleconosco;
        Conexao con = new Conexao();
        string valido = "sim";
        string status = "aberto";
        int numProtocolo;
        DateTime data = DateTime.Now;
        string historicoMensagemCidadao;
        Random rd = new Random();
        string Vmail;
        string VNome; string VRG; string VUF;
        string VCPF; string VdataNasc; string VCelular; string VTelefone;
        string VCnh; string VDtvalidade; string VUFcnh; string VCnhsn;
        string VRenavan; string VPlaca; string VNumeroi;
        string assunto; string VMensagem;

        protected void Page_Load(object sender, EventArgs e)
        {
            idfaleconosco = Request.QueryString["idfaleconosco"];
            Label1.Visible = false;
            numProtocolo = rd.Next(0, 9999999);
            Vmail = email.Text;
            VNome = nome.Text;
            VRG = rg.Text;
            VUF = uf.SelectedValue;
            VCPF = cpf.Text;
            VdataNasc = datanasc.Text;
            VCelular = celular.Text;
            VTelefone = telefone.Text;
            VCnh = cnh.Text;
            VDtvalidade = dtvalidade.Text;
            VUFcnh = ufcnh.Text;
            VCnhsn = cnhsn.SelectedValue;
            VRenavan = renavan.Text;
            VPlaca = placa.Text;
            VNumeroi = numeroi.Text;
            VMensagem = mensagem.Value;
            if (idfaleconosco != null)
            {
                ListarDados();
            }
            

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
                //mensagem.Value = dt.Rows[0][17].ToString();
                if (VCnhsn != "")
                {
                    rbHabilitacao.Checked = true;
                }
                if (VCnhsn == "SIM")
                {
                    cnhsn.SelectedIndex = 1;
                }
                if (VCnhsn == "NAO")
                {
                    cnhsn.SelectedIndex = 2;
                }
                if (numeroi.Text != "")
                {
                    rbInfracoes.Checked = true;
                }
                if (renavan.Text != "" && placa.Text != "" && numeroi.Text == "")
                {
                    rbVeiculos.Checked = true;
                }
                if (dt.Rows[0][17].ToString() != "")
                {
                    historicoMensagemCidadao = dt.Rows[0][17].ToString();
                }
                status = dt.Rows[0][20].ToString();
               

            }

            con.FecharCon();
        }

        protected void rbHabilitacao_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void btnEnvia_Click(object sender, EventArgs e)
        {


            if (nome.Text == "")
            {
                valido = "nao";
                //ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "erroNome();", true);
                ClientScript.RegisterStartupScript(GetType(), "Popup", "erroNome();", true);


            }
            else

                if (rg.Text == "")
            {
                valido = "nao";
                ClientScript.RegisterStartupScript(GetType(), "Popup", "erroRG();", true);
            }


            else

                if (datanasc.Text == "")
            {
                valido = "nao";
                ClientScript.RegisterStartupScript(GetType(), "Popup", "erroDataNasc();", true);
            }


            else

                if (uf.SelectedIndex == 0)
            {
                valido = "nao";
                ClientScript.RegisterStartupScript(GetType(), "Popup", "erroUF();", true);
            }

            else

                if (cpf.Text == "")
            {
                valido = "nao";
                ClientScript.RegisterStartupScript(GetType(), "Popup", "erroCPF();", true);
            }
            else

                if ((cpf.Text != "") && (ValidaCPF.IsCpf(cpf.Text) == false))
            {
                valido = "nao";
                ClientScript.RegisterStartupScript(GetType(), "Popup", "erroCPFinv();", true);
            }
            else

                if (email.Text == "")
            {
                valido = "nao";
                ClientScript.RegisterStartupScript(GetType(), "Popup", "erroEmail();", true);
            }
            else

                if ((email.Text != "") && (ValidaEmail.ValidarEmail(email.Text) == false))
            {
                valido = "nao";
                ClientScript.RegisterStartupScript(GetType(), "Popup", "erroEmailinv();", true);
            }
            else

                if (celular.Text == "")
            {
                valido = "nao";
                ClientScript.RegisterStartupScript(GetType(), "Popup", "erroCelular();", true);
            }
            else
                if (mensagem.Value == "")
                {
                    ClientScript.RegisterStartupScript(GetType(), "Popup", "erroMensagem();", true);
                }
            else

            if (rbHabilitacao.Checked == false && rbInfracoes.Checked == false && rbVeiculos.Checked == false)
            {
                valido = "nao";
                ClientScript.RegisterStartupScript(GetType(), "Popup", "erroCategoria();", true);
            }
            else

            if (rbHabilitacao.Checked == true)
            {
                if (cnhsn.SelectedIndex == 0)
                {
                    valido = "nao";
                    ClientScript.RegisterStartupScript(GetType(), "Popup", "erroTemCNH();", true);
                }
                else

                if ((cnhsn.SelectedValue == "SIM") && ((cnh.Text == "") || (dtvalidade.Text == "") || (ufcnh.Text == "")))
                {
                    valido = "nao";
                    ClientScript.RegisterStartupScript(GetType(), "Popup", "erroCampos();", true);
                }

                else

            if (rbInfracoes.Checked == true)
                {
                    if (renavan.Text == "")
                    {
                        valido = "nao";
                        ClientScript.RegisterStartupScript(GetType(), "Popup", "erroRenavam();", true);
                    }
                    else

                    if (placa.Text == "")
                    {
                        valido = "nao";
                        ClientScript.RegisterStartupScript(GetType(), "Popup", "erroPlaca();", true);
                    }
                    else

                    if (numeroi.Text == "")
                    {
                        valido = "nao";
                        ClientScript.RegisterStartupScript(GetType(), "Popup", "erroAutoI();", true);
                    }

                    else

                if (rbVeiculos.Checked == true)
                    {
                        if (renavan.Text == "")
                        {
                            valido = "nao";
                            ClientScript.RegisterStartupScript(GetType(), "Popup", "erroRenavam();", true);
                        }
                        else

                        if (placa.Text == "")
                        {
                            valido = "nao";
                            ClientScript.RegisterStartupScript(GetType(), "Popup", "erroPlaca();", true);
                        }
                    }
                }
                else
                {
                    valido = "sim";
                }
            }
            if (valido == "sim" && idfaleconosco == null)
            {
                Salvar();
                Email();
            }
            if (valido == "sim" && idfaleconosco != null)
            {
                SalvarRetornoCidadao();
                ListarMensagemRetornoEmail();
                Email();
            }
        }

        private void Email()
        {
            try
            {
                assunto = "Protocolo Nº " + numProtocolo + " Fale Conosco Detran-PR";
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(Vmail,"Fale Conosco Detran-PR");
                mailMessage.To.Add(Vmail.ToLower());
                mailMessage.Subject = assunto;
                mailMessage.IsBodyHtml = true;

                if (rbHabilitacao.Checked==true)
                {
                    if (VCnhsn=="SIM")
                    {
                        mailMessage.Body = "RECEBEMOS A SUA SOLICITAÇÃO E EM BREVE SERÁ RESPONDIDA." + "<br>" +
                       "Protocolo: " + numProtocolo + "<br>" + "Nome: " + VNome + "<br>" + " RG: " + VRG + "<br>" +
                       " CPF: " + VCPF + "<br>" +
                       " Número do Celeular: " + VCelular + "<br>" +
                       " Número do Telefone: " + VTelefone + "<br>" + " CNH: " + VCnh + "<br>" +
                       " Data Validade CNH: " + VDtvalidade + "<br>" +
                       " UF CNH: " + VUFcnh + "<br>" +
                       " Mensagem:<br> " + VMensagem + "<br><br>" +
                       "O DETRAN-PR está a sua disposição, você também pode conseguir informação e serviços em nosso site www.detran.pr.gov.br ou Aplicativo DETRAN INTELIGENTE (IOS ou Android)" +
                       "<br>" +
                       "*** E-mail automático, não há necessidade de respondê-lo. ***";

                    }
                    else
                    {
                        mailMessage.Body = "RECEBEMOS A SUA SOLICITAÇÃO E EM BREVE SERÁ RESPONDIDA." + "<br>" +
                    "Protocolo: " + numProtocolo + "<br>" + "Nome: " + VNome + "<br>" + " RG: " + VRG + "<br>" +
                    " CPF: " + VCPF + "<br>" +
                    " Número do Celeular: " + VCelular + "<br>" +
                    " Número do Telefone: " + VTelefone + "<br>" + 
                    "Possui Habilitação ? : "+ VCnhsn + "<br>" +
                     " Mensagem:<br> " + VMensagem + "<br><br>" +
                       "O DETRAN-PR está a sua disposição, você também pode conseguir informação e serviços em nosso site www.detran.pr.gov.br ou Aplicativo DETRAN INTELIGENTE (IOS ou Android)" +
                       "<br>" +
                       "*** E-mail automático, não há necessidade de respondê-lo. ***";
                    }
                    
                }else
                    if (rbInfracoes.Checked==true)
                {
                    mailMessage.Body = "RECEBEMOS A SUA SOLICITAÇÃO E EM BREVE SERÁ RESPONDIDA." + "<br>" + 
                    "Protocolo: " + numProtocolo + "<br>" + "Nome: " + VNome + "<br>" + " RG: " + VRG + "<br>" +
                    " CPF: " + VCPF + "<br>" +
                    " Número do Celeular: " + VCelular + "<br>" +
                    " Número do Telefone: " + VTelefone + "<br>" + 
                    " Renavam: " + VRenavan + "<br>" +
                    " Placa: " + VPlaca + "<br>" +
                    " Nº do Auto de Infração: " + VNumeroi + "<br>" +
                     " Mensagem:<br> " + VMensagem + "<br><br>" +
                       "O DETRAN-PR está a sua disposição, você também pode conseguir informação e serviços em nosso site www.detran.pr.gov.br ou Aplicativo DETRAN INTELIGENTE (IOS ou Android)" +
                       "<br>" +
                       "*** E-mail automático, não há necessidade de respondê-lo. ***";
                }
                else
                {
                    mailMessage.Body = "RECEBEMOS A SUA SOLICITAÇÃO E EM BREVE SERÁ RESPONDIDA." + "<br>" + 
                    "Protocolo: " + numProtocolo + "<br>" + "Nome: " + VNome + "<br>" + " RG: " + VRG + "<br>" +
                    " CPF: " + VCPF + "<br>" +
                    " Número do Celeular: " + VCelular + "<br>" +
                    " Número do Telefone: " + VTelefone + "<br>" + 
                    " Renavam: " + VRenavan + "<br>" +
                    " Placa: " + VPlaca + "<br>" +
                     " Mensagem:<br> " + VMensagem + "<br><br>" +
                       "O DETRAN-PR está a sua disposição, você também pode conseguir informação e serviços em nosso site www.detran.pr.gov.br ou Aplicativo DETRAN INTELIGENTE (IOS ou Android)" +
                       "<br>" +
                       "*** E-mail automático, não há necessidade de respondê-lo. ***";
                }
                

                mailMessage.Priority = MailPriority.High;

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential("sercomtelcontatcenter@gmail.com", "gask8930");
                smtpClient.Send(mailMessage);
                ClientScript.RegisterStartupScript(GetType(), "Popup", "sucesso();", true);
            }
            catch (Exception)
            {
                Label1.Text = "Erro ao enviar e-mail";
                throw;
            }
            
        }

        private void Salvar()
        {
            string sql;
            MySqlCommand cmd;
            con.AbrirCon();
            sql = "INSERT INTO faleconosco(protocolo,nome,rg,uf,email,cpf,dataNasc,celular,telefone,possui_habilitacao,numero_cnh,data_validade_cnh,uf_cnh,renavam,placa,num_auto_infracao,mensagem_cidadao,status,data_abertura) VALUES(@protocolo,@nome,@rg,@uf,@email,@cpf,@dataNasc,@celular,@telefone,@possui_habilitacao,@numero_cnh,@data_validade_cnh,@uf_cnh,@renavam,@placa,@num_auto_infracao,@mensagem_cidadao,@status,now())";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@protocolo", numProtocolo);
            cmd.Parameters.AddWithValue("@nome", nome.Text);
            cmd.Parameters.AddWithValue("@rg", rg.Text);
            cmd.Parameters.AddWithValue("@uf", uf.SelectedValue);
            cmd.Parameters.AddWithValue("@email", email.Text);
            cmd.Parameters.AddWithValue("@cpf", cpf.Text);
            cmd.Parameters.AddWithValue("@dataNasc", Convert.ToDateTime(datanasc.Text));
            cmd.Parameters.AddWithValue("@celular", celular.Text);
            cmd.Parameters.AddWithValue("@telefone", telefone.Text);
            cmd.Parameters.AddWithValue("@possui_habilitacao", cnhsn.SelectedValue);
            cmd.Parameters.AddWithValue("@numero_cnh", cnh.Text);
            if (cnhsn.SelectedValue == "SIM")
            {
                cmd.Parameters.AddWithValue("@data_validade_cnh", Convert.ToDateTime(dtvalidade.Text));
            }
            else
            {
                cmd.Parameters.AddWithValue("@data_validade_cnh", null);
            }

            cmd.Parameters.AddWithValue("@uf_cnh", ufcnh.SelectedValue);
            cmd.Parameters.AddWithValue("@renavam", renavan.Text);
            cmd.Parameters.AddWithValue("@placa", placa.Text);
            cmd.Parameters.AddWithValue("@num_auto_infracao", numeroi.Text);
            if (idfaleconosco == null)
            {

            }
            cmd.Parameters.AddWithValue("@mensagem_cidadao", "[ Enviado em " +data+ " ]"+ System.Environment.NewLine + mensagem.Value + System.Environment.NewLine);
            cmd.Parameters.AddWithValue("@status", status);


            cmd.ExecuteNonQuery();
            Label1.Text = "Dados Inseridos com Sucesso!";


            con.FecharCon();
            nome.Text = string.Empty;
            rg.Text = string.Empty;
            uf.SelectedIndex = 0;
            email.Text = string.Empty;
            cpf.Text = string.Empty;
            datanasc.Text = string.Empty;
            celular.Text = string.Empty;
            telefone.Text = string.Empty;
            cnhsn.SelectedIndex = 0;
            cnh.Text = string.Empty;
            dtvalidade.Text = string.Empty;
            ufcnh.SelectedIndex = 0;
            renavan.Text = string.Empty;
            placa.Text = string.Empty;
            numeroi.Text = string.Empty;
            mensagem.Value = string.Empty;
            return;
            Response.Redirect("pabx.aspx");

        }
        private void SalvarRetornoCidadao()
        {
            string sql;
            MySqlCommand cmd;
            con.AbrirCon();
            sql = "UPDATE faleconosco SET mensagem_cidadao=@mensagem_cidadao,status=@status where idfaleconosco=@idfaleconosco";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@idfaleconosco", idfaleconosco);
            cmd.Parameters.AddWithValue("@mensagem_cidadao", "[ Enviada em " + data +  " ]" + System.Environment.NewLine + mensagem.Value + System.Environment.NewLine + historicoMensagemCidadao + System.Environment.NewLine);
            cmd.Parameters.AddWithValue("@status", "Retorno Cidadao");


            cmd.ExecuteNonQuery();
            ClientScript.RegisterStartupScript(GetType(), "Popup", "sucesso();", true);
            Label1.Text = "Dados Inseridos com Sucesso!";


            con.FecharCon();
            nome.Text = string.Empty;
            rg.Text = string.Empty;
            uf.SelectedIndex = 0;
            email.Text = string.Empty;
            cpf.Text = string.Empty;
            datanasc.Text = string.Empty;
            celular.Text = string.Empty;
            telefone.Text = string.Empty;
            cnhsn.SelectedIndex = 0;
            cnh.Text = string.Empty;
            dtvalidade.Text = string.Empty;
            ufcnh.SelectedIndex = 0;
            renavan.Text = string.Empty;
            placa.Text = string.Empty;
            numeroi.Text = string.Empty;
            mensagem.Value = string.Empty;
            return;
            Response.Redirect("pabx.aspx");

        }
        public static class ValidaCPF
        {
            public static bool IsCpf(string cpf)
            {
                int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                string tempCpf;
                string digito;
                int soma;
                int resto;
                cpf = cpf.Trim();
                cpf = cpf.Replace(".", "").Replace("-", "");
                if (cpf.Length != 11)
                    return false;
                tempCpf = cpf.Substring(0, 9);
                soma = 0;

                for (int i = 0; i < 9; i++)
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
                resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;
                digito = resto.ToString();
                tempCpf = tempCpf + digito;
                soma = 0;
                for (int i = 0; i < 10; i++)
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
                resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;
                digito = digito + resto.ToString();
                return cpf.EndsWith(digito);
            }


        }
        public static class ValidaEmail
        {
            public static bool ValidarEmail(string email)
            {
                bool validEmail = false;
                int indexArr = email.IndexOf('@');
                if (indexArr > 0)
                {
                    int indexDot = email.IndexOf('.', indexArr);
                    if (indexDot - 1 > indexArr)
                    {
                        if (indexDot + 1 < email.Length)
                        {
                            string indexDot2 = email.Substring(indexDot + 1, 1);
                            if (indexDot2 != ".")
                            {
                                validEmail = true;
                            }
                        }
                    }
                }
                return validEmail;
            }
        }
        private void ListarMensagemRetornoEmail()
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
                VMensagem = dt.Rows[0][17].ToString();
            }

            con.FecharCon();
        }
    }
}