<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="faleconosco.aspx.cs" Inherits="Detran.faleconosco.formulario" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.3.1.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    <script src="Scripts/jquery.maskedinput.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-sweetalert/1.0.1/sweetalert.js" integrity="sha256-ZvMf9li0M5GGriGUEKn1g6lLwnj5u+ENqCbLM5ItjQ0=" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-sweetalert/1.0.1/sweetalert.css" integrity="sha256-Z8TW+REiUm9zSQMGZH4bfZi52VJgMqETCbPFlGRB1P8=" crossorigin="anonymous" />
        <script type="text/javascript">
        function erroNome() {
            swal({
                title: 'Erro!',
                text: 'Por favor Preencha o campo Nome',
                type: 'error'
            });
            }
            function erroRG() {
            swal({
                title: 'Erro!',
                text: 'Por favor Preencha o campo RG',
                type: 'error'
            });
            }
            function erroDataNasc() {
            swal({
                title: 'Erro!',
                text: 'Por favor Preencha o campo Data de Nascimento',
                type: 'error'
            });
            }
            function erroUF() {
            swal({
                title: 'Erro!',
                text: 'Por favor Selecione a UF',
                type: 'error'
            });
            }
            function erroCPF() {
            swal({
                title: 'Erro!',
                text: 'Por favor Preencha o campo CPF',
                type: 'error'
            });
            }
            function erroCPFinv() {
            swal({
                title: 'Erro!',
                text: 'O CPF Informado é Inválido',
                type: 'error'
            });
            }
            function erroEmail() {
            swal({
                title: 'Erro!',
                text: 'Por favor Preencha o campo E-mail',
                type: 'error'
            });
            }
            function erroEmailinv() {
            swal({
                title: 'Erro!',
                text: 'O E-mail Informado é Inválido',
                type: 'error'
            });
            }
            function erroCelular() {
            swal({
                title: 'Erro!',
                text: 'Por favor Preencha o campo Celular',
                type: 'error'
            });
            }
            function erroMensagem() {
            swal({
                title: 'Erro!',
                text: 'Por favor Preencha o campo Celular',
                type: 'error'
            });
            }
            function erroCategoria() {
            swal({
                title: 'Erro!',
                text: 'Por favor Escollha a Categoria de atendimento desejado',
                type: 'error'
            });
            }
            function erroTemCNH() {
            swal({
                title: 'Erro!',
                text: 'Por favor responda  se TEM ou NÂO CNH',
                type: 'error'
            });
            }
            function erroCampos() {
            swal({
                title: 'Erro!',
                text: 'Por favor Preencha todos os campos Nº da CNH, Data Validade e UF da CNH',
                type: 'error'
            });
            }
            function erroRenavam() {
            swal({
                title: 'Erro!',
                text: 'Por favor Informe o Renavam do Veículo',
                type: 'error'
            });
            }
            function erroPlaca() {
            swal({
                title: 'Erro!',
                text: 'Por favor Informe a Placa do Veículo',
                type: 'error'
            });
            }
            function erroAutoI() {
            swal({
                title: 'Erro!',
                text: 'Por favor Informe o Numero do Auto de Infração',
                type: 'error'
            });
            }
            function sucesso() {
            swal({
                title: 'Sucesso!',
                text: 'Enviado com sucesso!',
                type: 'success',
                timer: '2500'
            });
            }

    </script>
    <title></title>
</head>
<body>
    <div class="container" style="width:90%">
    <form runat="server">
  <div class="form-row col-md-12" >
      <br />
      <br />
      <div>
            <p class="lead">Este canal é exclusivo para assuntos relacionados a procedimentos do Detran-PR</p>
            <p>Para outros assuntos como Reclamações, Sugestões, Elogios ou Denúncias entre em contato com a <asp:HyperLink NavigateUrl="http://www.sigo.pr.gov.br/pcontroller.php/cfaleouvidor/create&amp;codorgao=71&amp;iframe=true&amp;nohead=true" Text="OUVIDORIA" runat="server" /> do Detran-PR</p>
        </div>
      <br />
      <br />
    <div class="col-md-4 mb-2">
      <label for="nome">Nome</label>
      <asp:TextBox CssClass="form-control" id="nome" placeholder="Nome Completo" runat="server"  />
    </div>
    <div class="col-md-2 mb-2">
      <label for="rg">RG</label>
      <asp:TextBox CssClass="form-control" id="rg" placeholder="RG"  runat="server" />
    </div>
    <div class="col-md-2 mb-2">
      <label for="uf">UF Emissor</label>
      <asp:DropDownList id="uf" name="uf" class="form-control"  runat="server">
            <asp:ListItem value="" selected="true">UF Emissor do RG</asp:ListItem>
            <asp:ListItem value="AC">Acre</asp:ListItem>
            <asp:ListItem value="AL">Alagoas</asp:ListItem>
            <asp:ListItem value="AP">Amapá</asp:ListItem>
            <asp:ListItem value="AM">Amazonas</asp:ListItem>
            <asp:ListItem value="BA">Bahia</asp:ListItem>
            <asp:ListItem value="CE">Ceará</asp:ListItem>
            <asp:ListItem value="DF">Distrito Federal</asp:ListItem>
            <asp:ListItem value="ES">Espírito Santo</asp:ListItem>
            <asp:ListItem value="GO">Goiás</asp:ListItem>
            <asp:ListItem value="MA">Maranhão</asp:ListItem>
            <asp:ListItem value="MT">Mato Grosso</asp:ListItem>
            <asp:ListItem value="MS">Mato Grosso do Sul</asp:ListItem>
            <asp:ListItem value="MG">Minas Gerais</asp:ListItem>
            <asp:ListItem value="PA">Pará</asp:ListItem>
            <asp:ListItem value="PB">Paraíba</asp:ListItem>
            <asp:ListItem value="PR">Paraná</asp:ListItem>
            <asp:ListItem value="PE">Pernambuco</asp:ListItem>
            <asp:ListItem value="PI">Piauí</asp:ListItem>
            <asp:ListItem value="RJ">Rio de Janeiro</asp:ListItem>
            <asp:ListItem value="RN">Rio Grande do Norte</asp:ListItem>
            <asp:ListItem value="RS">Rio Grande do Sul</asp:ListItem>
            <asp:ListItem value="RO">Rondônia</asp:ListItem>
            <asp:ListItem value="RR">Roraima</asp:ListItem>
            <asp:ListItem value="SC">Santa Catarina</asp:ListItem>
            <asp:ListItem value="SP">São Paulo</asp:ListItem>
            <asp:ListItem value="SE">Sergipe</asp:ListItem>
            <asp:ListItem value="TO">Tocantins</asp:ListItem>
        </asp:DropDownList>
    </div>
      <div class="col-md-2 mb-2">
      <label for="datanasc">Data Nascimento</label>
      <asp:TextBox CssClass="form-control" id="datanasc" placeholder="Data Nascimento"  runat="server" />
    </div>
   </div>
        
  <div class="form-row col-md-12">
     
    
    <div class="col-md-2 mb-2">
      <label for="cpf">CPF</label>
      <asp:TextBox cssclass="form-control" id="cpf" placeholder="CPF"  runat="server" />
    </div>
    <div class="col-md-4 mb-3">
      <label for="email">E-mail</label>
      <asp:TextBox cssclass="form-control" id="email" placeholder="E-mail"  runat="server" />
    </div>
    <div class="col-md-2 mb-2">
      <label for="celular">Celular</label>
      <asp:TextBox cssclass="form-control" id="celular" placeholder="Celular"  runat="server" />
    </div>
    <div class="col-md-2 mb-2">
      <label for="telefone">Telefone</label>
      <asp:TextBox cssclass="form-control" id="telefone" placeholder="Telefone"  runat="server" />
    </div>
   </div>
        <div class="form-row col-md-12">
            <br />
            <h4>Categoria de Atendimento</h4>
            <div class="form-check">
                <asp:RadioButton runat="server" class="form-check-input" type="radio" GroupName="rbTipoRel" ID="rbHabilitacao" onclick="javascript:Habilitacao();" value="opcao1" />
                <asp:Label runat="server" class="form-check-label" for="rbHabilitacao">
                    Habilitações
                </asp:Label>
            </div>
            <div class="form-check">
                <asp:RadioButton runat="server" class="form-check-input" type="radio" GroupName="rbTipoRel" ID="rbInfracoes" onclick="javascript:Infracoes();" value="opcao2" />
                <asp:Label runat="server" class="form-check-label" for="rbInfracoes">
                    Infrações
                </asp:Label>
            </div>
            <div class="form-check">
                <asp:RadioButton runat="server" class="form-check-input" type="radio" GroupName="rbTipoRel" ID="rbVeiculos" onclick="javascript:Veiculo();" value="option3" />
                <asp:Label runat="server" class="form-check-label" for="rbVeiculo">
                    Veiculos
                </asp:Label>
            </div>
        </div>
       <div class="col-md-12">
            <div class="col-md-2 mb-2">
            <asp:TextBox id="possui" CssClass="form-control" value="Você possui CNH?" readonly="true" runat="server" />
            </div>
           <div class="col-md-2 mb-2">
            <asp:DropDownList id="cnhsn" name="cnhsn" onchange="SN()" class="form-control" runat="server">
                <asp:ListItem value="" selected="true">Sim ou Não</asp:ListItem>
                <asp:ListItem value="SIM">Sim</asp:ListItem>
                <asp:ListItem value="NAO">Não</asp:ListItem>
            </asp:DropDownList>
            </div>
            <div class="col-md-2 mb-2">
            <asp:TextBox CssClass="form-control" id="cnh" placeholder="N° da CNH" runat="server" />
            </div>
           <div class="col-md-2 mb-2">
                <asp:TextBox name="dtvalidade" id="dtvalidade" cssclass="form-control" placeholder="Data de Validade" runat="server" />
            </div>
            <div class="col-md-2 mb-2">
              <asp:DropDownList id="ufcnh" name="ufcnh" class="form-control"  runat="server">
                    <asp:ListItem value="" selected="true">UF Emissor</asp:ListItem>
                    <asp:ListItem value="AC">Acre</asp:ListItem>
                    <asp:ListItem value="AL">Alagoas</asp:ListItem>
                    <asp:ListItem value="AP">Amapá</asp:ListItem>
                    <asp:ListItem value="AM">Amazonas</asp:ListItem>
                    <asp:ListItem value="BA">Bahia</asp:ListItem>
                    <asp:ListItem value="CE">Ceará</asp:ListItem>
                    <asp:ListItem value="DF">Distrito Federal</asp:ListItem>
                    <asp:ListItem value="ES">Espírito Santo</asp:ListItem>
                    <asp:ListItem value="GO">Goiás</asp:ListItem>
                    <asp:ListItem value="MA">Maranhão</asp:ListItem>
                    <asp:ListItem value="MT">Mato Grosso</asp:ListItem>
                    <asp:ListItem value="MS">Mato Grosso do Sul</asp:ListItem>
                    <asp:ListItem value="MG">Minas Gerais</asp:ListItem>
                    <asp:ListItem value="PA">Pará</asp:ListItem>
                    <asp:ListItem value="PB">Paraíba</asp:ListItem>
                    <asp:ListItem value="PR">Paraná</asp:ListItem>
                    <asp:ListItem value="PE">Pernambuco</asp:ListItem>
                    <asp:ListItem value="PI">Piauí</asp:ListItem>
                    <asp:ListItem value="RJ">Rio de Janeiro</asp:ListItem>
                    <asp:ListItem value="RN">Rio Grande do Norte</asp:ListItem>
                    <asp:ListItem value="RS">Rio Grande do Sul</asp:ListItem>
                    <asp:ListItem value="RO">Rondônia</asp:ListItem>
                    <asp:ListItem value="RR">Roraima</asp:ListItem>
                    <asp:ListItem value="SC">Santa Catarina</asp:ListItem>
                    <asp:ListItem value="SP">São Paulo</asp:ListItem>
                    <asp:ListItem value="SE">Sergipe</asp:ListItem>
                    <asp:ListItem value="TO">Tocantins</asp:ListItem>
                </asp:DropDownList>
        </div>
    </div>
        <div class="form-row col-md-12">
        <div class="col-md-2 mb-2">
            <asp:TextBox cssclass="form-control" id="renavan" placeholder="Renavam" runat="server"  />
        </div>
           <div class="col-md-2 mb-2">
            <asp:TextBox cssclass="form-control" id="placa" placeholder="Placa" runat="server" />
            </div>
           <div class="col-md-2 mb-2">
            <asp:TextBox cssclass="form-control" id="numeroi" placeholder="N° do Auto de Infração" runat="server" />
            </div>
        </div>
        <label>
        Mensagem:
        <br />
        Descreva da forma mais completa possível:
        
        
    </label>
        <br />
        <textarea name="mensagem" id="mensagem" rows="10" cols="100" runat="server"></textarea>

        
    
        <div class="form-row col-md-12">
            <br />
            <div class="col-md-2 mb-2">
            <asp:Button ID="btnEnvia" CssClass="btn" runat="server"  Text="&nbsp;  Enviar &nbsp; " OnClick="btnEnvia_Click" />
            </div>

        </div>
        <div class="form-row col-md-12">
            <br /><br />
        <asp:Label ID="Label1" runat="server" Text="" Font-Bold="true"  ForeColor="Red"></asp:Label>
        </div>
        </form>

  </div>
    <style>
        .btn{
            color:#ffffff;
            Background:#00984b;
        }
    </style>
    <script>
        $(document).ready(function () {
            limpaTela();
            $('#datanasc').mask('99/99/9999');
            $('#dtvalidade').mask('99/99/9999');
            $('#celular').mask('(99) 99999-9999');
            $('#telefone').mask('(99) 9999-9999');
           // $('#cpf').mask('999.999.999-99');
        });
    </script>
<script type="text/javascript">
    function limpaTela() {
       var cnhsn = document.getElementById("<%= cnhsn.ClientID %>");
        cnhsn.style.display = "none";
        var possui = document.getElementById("<%= possui.ClientID %>");
        possui.style.display = "none";
        var cnh = document.getElementById("<%= cnh.ClientID %>");
        cnh.style.display = "none";
        var dtvalidade = document.getElementById('<%= dtvalidade.ClientID %>');
        dtvalidade.style.display = "none";
        var ufcnh = document.getElementById("<%= ufcnh.ClientID %>");
        ufcnh.style.display = "none";
        document.getElementById("<%= renavan.ClientID %>").style.display = "none";
        document.getElementById("<%= placa.ClientID %>").style.display = "none";
        document.getElementById("<%= numeroi.ClientID %>").style.display = "none";
    }

    function Habilitacao() {
        limpaTela();
        var cnhsn = document.getElementById("<%= cnhsn.ClientID %>");
        cnhsn.style.display = "inline";
        var possui = document.getElementById("<%= possui.ClientID %>");
        possui.style.display = "inline";
    }


    function Infracoes() {
        limpaTela();
        document.getElementById("<%= renavan.ClientID %>").style.display = "inline";
        document.getElementById("<%= placa.ClientID %>").style.display = "inline";
        document.getElementById("<%= numeroi.ClientID %>").style.display = "inline";
    }

    function Veiculo() {
        limpaTela();
        document.getElementById("<%= renavan.ClientID %>").style.display = "inline";
        document.getElementById("<%= placa.ClientID %>").style.display = "inline";
    }


    function HabilitacaoS() {
        var cnh = document.getElementById("<%= cnh.ClientID %>");
        cnh.style.display = "inline";
        var dtvalidade = document.getElementById("<%= dtvalidade.ClientID %>");
        dtvalidade.style.display = "inline";
        var ufcnh = document.getElementById("<%= ufcnh.ClientID %>");
        ufcnh.style.display = "inline";
    }

    function HabilitacaoN() {
        var cnh = document.getElementById("<%= cnh.ClientID %>");
        cnh.style.display = "none";
        var dtvalidade = document.getElementById("<%= dtvalidade.ClientID %>");
        dtvalidade.style.display = "none";
        var ufcnh = document.getElementById("<%= ufcnh.ClientID %>");
        ufcnh.style.display = "none";
    }

    function SN() {
        if (document.getElementById("<%= cnhsn.ClientID %>").value == "SIM") {
            HabilitacaoS();
        }
        if (document.getElementById("<%= cnhsn.ClientID %>").value == "NAO") {
            HabilitacaoN();
        }
    }

</script>    


</body>
    
</html>


