<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="duvidaCidadao.aspx.cs" Inherits="Detran.faleconosco.duvidaCidadao" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <meta http-equiv="refresh" content="120" />
    <div class="container" style="width:90%">
    
  <div class="form-row col-md-12" >
      <br />
      <div>
            <p class="lead">Este canal é exclusivo para assuntos relacionados a procedimentos do Detran-PR</p>
           
        </div>
    <div class="col-md-2 mb-2">
      <label for="protocolo">N° Protocolo</label>
      <asp:TextBox CssClass="form-control" id="protocolo"  runat="server" ReadOnly="true"  />
    </div>
    <div class="col-md-2 mb-2">
      <label for="dataAbertura">Data Abertura</label>
      <asp:TextBox CssClass="form-control" id="dataAbertura"  runat="server" ReadOnly="true" />
    </div>
    <div class="col-md-4 mb-2">
      <label for="nome">Nome</label>
      <asp:TextBox CssClass="form-control" id="nome"  runat="server" ReadOnly="true"  />
    </div>
    <div class="col-md-2 mb-2">
      <label for="rg">RG</label>
        
      <asp:TextBox CssClass="form-control" id="rg"  runat="server" ReadOnly="true" />
    </div>
    <div class="col-md-2 mb-2">
      <label for="uf">UF Emissor</label>
        <asp:TextBox CssClass="form-control" id="uf"  runat="server" ReadOnly="true" />
    </div>
      
   </div>
        
  <div class="form-row col-md-12">
     
    <div class="col-md-2 mb-2">
      <label for="datanasc">Data Nascimento</label>
      <asp:TextBox CssClass="form-control" id="datanasc"  runat="server" ReadOnly="true" />
    </div>
    <div class="col-md-2 mb-2">
      <label for="cpf">CPF</label>
      <asp:TextBox cssclass="form-control" id="cpf"  runat="server" ReadOnly="true" />
    </div>
    <div class="col-md-4 mb-3">
      <label for="email">E-mail</label>
      <asp:TextBox cssclass="form-control" id="email"  runat="server" ReadOnly="true" />
    </div>
    <div class="col-md-2 mb-2">
      <label for="celular">Celular</label>
      <asp:TextBox cssclass="form-control" id="celular"  runat="server" ReadOnly="true" />
    </div>
    <div class="col-md-2 mb-2">
      <label for="telefone">Telefone</label>
      <asp:TextBox cssclass="form-control" id="telefone"  runat="server" ReadOnly="true" />
    </div>
   </div>
  <div class="col-md-12">
    <div class="col-md-2 mb-2">
        <label for="cnh">N° CNH</label>
        <asp:TextBox CssClass="form-control" id="cnh"  runat="server" ReadOnly="true" />
    </div>
    <div class="col-md-2 mb-2">
        <label for="dtvalidade">Validade CNH</label>
        <asp:TextBox name="dtvalidade" id="dtvalidade" cssclass="form-control"  runat="server" ReadOnly="true" />
    </div>
    <div class="col-md-2 mb-2">
        <label for="ufcnh">UF Emissor CNH</label>
        <asp:TextBox CssClass="form-control" id="ufcnh"  runat="server" ReadOnly="true" />
        </div>
      <div class="col-md-2 mb-2">
          <label for="renavam">Renavam</label>
          <asp:TextBox cssclass="form-control" id="renavan" runat="server" ReadOnly="true" />
     </div>
    <div class="col-md-2 mb-2">
        <label for="placa">Placa</label>
        <asp:TextBox cssclass="form-control" id="placa"  runat="server" ReadOnly="true" />
    </div>
    <div class="col-md-2 mb-2">
        <label for="autoInfracao">N° Auto Infração</label>
        <asp:TextBox cssclass="form-control" id="numeroi"  runat="server" ReadOnly="true" />
    </div>
    </div>
        <div class="form-row col-md-12">
            <br />
            <div>
                <span style="text-align:left"><asp:Label Text="Mensagem do Cidadão:" runat="server" Font-Bold="true" /></span>
                <button type="button" id="btnCidadao" class="btn btn-primary" data-toggle="modal" data-target="#ModalCidadao">Histórico</button> 
            </div>
            <br />
                <textarea name="mensagem" id="mensagem" rows="5" cols="140" runat="server" readonly="readonly"></textarea>
        </div>
        <div class="form-row col-md-12">
            <br />
            <div>
                <span style="text-align:left"><asp:Label Text="Mensagem ao Supervisor:" runat="server" Font-Bold="true" /></span>    
                <button type="button" id="btnHistorico" class="btn btn-primary" data-toggle="modal" data-target="#ModalOperadorSupervisor">Histórico</button> 
            </div>
            <br />
                <textarea name="mensagem" id="mensagem_encaminhamento" rows="5" cols="140" runat="server" ></textarea>
        </div>
        <div class="form-row col-md-12">
            <br />
            <div>
                <span style="text-align:left"><asp:Label Text="" ID="RetornoSupervisor" runat="server" Font-Bold="true" /></span>
                <button type="button" id="btnSupervisor" class="btn btn-primary" data-toggle="modal" data-target="#ModalSupervisorOperador">Histórico</button> 
            </div>
            <br />
                <textarea name="mensagem" id="mensagem_do_supervisor" rows="5" cols="140" runat="server" ></textarea>
        </div>
        <div class="form-row col-md-12">
            <br />
            <div>
                <span style="text-align:left"><asp:Label Text="Resposta para o Cidadão:" runat="server" Font-Bold="true" /></span>
                <button type="button" id="btnResposta" class="btn btn-primary" data-toggle="modal" data-target="#ModalOperadorCidadao">Histórico</button> 
            </div>
            <br />
                <textarea name="mensagem" id="mensagem_resposta" rows="5" cols="140" runat="server" ></textarea>
            <br />
        </div>
        <h4>Responder</h4>
        <div class="form-row col-md-12">
            <div class="col-md-2 mb-2">
            <div class="form-check">
                <asp:RadioButton runat="server" class="form-check-input" type="radio" GroupName="rbTipoRel" ID="rbRespCidadao" value="opcao1" />
                <asp:Label runat="server" class="form-check-label" for="rbChamaEntrada" ID="lbCidadao" Text="Para o Cidadão">
                    
                </asp:Label>
            </div>
            </div>
            <div class="col-md-4 mb-2">
            <div class="form-check">
                <asp:RadioButton runat="server" class="form-check-input" type="radio" GroupName="rbTipoRel" ID="rbRespSupervisao" value="opcao2" />
                <asp:Label runat="server" class="form-check-label" for="rbChamadasAb" ID="lbEncaminhar">
                    
                </asp:Label>
            </div>
            </div>
            </div>
        <div class="form-row col-md-12">
            <br />
            <div class="col-md-2 mb-2">
            <asp:Button ID="btnEnvia" CssClass="btn btn-primary" runat="server" Text="Enviar" OnClick="btnEnvia_Click"  />
            </div>

        </div>
        <div class="form-row col-md-12">
            <br /><br />
        <asp:Label ID="Label1" runat="server" Text="" Font-Bold="true"  ForeColor="Red"></asp:Label>
        </div>
        </form>
        
  </div>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-sweetalert/1.0.1/sweetalert.js" integrity="sha256-ZvMf9li0M5GGriGUEKn1g6lLwnj5u+ENqCbLM5ItjQ0=" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-sweetalert/1.0.1/sweetalert.css" integrity="sha256-Z8TW+REiUm9zSQMGZH4bfZi52VJgMqETCbPFlGRB1P8=" crossorigin="anonymous" />
        <script type="text/javascript">
        function erroEncaminhar() {
            swal({
                title: 'Erro!',
                text: 'Por favor selecione o direcionamento da Resposta, se direto ao Cidadão ou Encaminhar para Supervisão',
                type: 'error'
            });
            }
            function erroTxtCidadao() {
            swal({
                title: 'Erro!',
                text: 'O campo onde deve conter o texto da resposta ao Cidadão esta vazio, favor preencher',
                type: 'error'
            });
            }
            function erroTxtSupervisao() {
            swal({
                title: 'Erro!',
                text: 'O campo onde deve conter o texto para a Supervisão esta vazio, favor preencher',
                type: 'error'
            });
            }
            function erroTxtOperador() {
            swal({
                title: 'Erro!',
                text: 'O campo onde deve conter o texto para a Operador esta vazio, favor preencher',
                type: 'error'
            });
            }
            function erroTxtEncSupervisao() {
            swal({
                title: 'Erro!',
                text: 'O Assunto já esta com a Supervisão! Deve-se Responder ao Cidadão',
                type: 'error'
            });
            }
            function erroEmail() {
            swal({
                title: 'Erro!',
                text: 'Erro ao enviar e-mail',
                type: 'error'
            });
            }
            function sucessEmail() {
            swal({
                title: 'Sucesso!',
                text: 'E-mail enviado, com sucesso!',
                type: 'success',
                timer: '2500'
            });
            }
            function sucessSupervisao() {
            swal({
                title: 'Sucesso!',
                text: 'Assunto enviado, com sucesso para a Supervisão!',
                type: 'success',
                timer: '2500'
            });
            }
            function sucessRetornoSupervisao() {
            swal({
                title: 'Sucesso!',
                text: 'Assunto enviado, com sucesso para o Operador!',
                type: 'success',
                timer: '2500'
            });
            }
    </script>
    <!-- Modal -->
<div class="modal fade .modal-xl" id="ModalCidadao" tabindex="-1" role="dialog" aria-labelledby="" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="">Histórico</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Fechar">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        <asp:Label ID="LabelCidadao" runat="server" Text=""></asp:Label>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Fechar</button>
      </div>
    </div>
  </div>
</div>
    <div class="modal fade .modal-xl" id="ModalOperadorSupervisor" tabindex="-1" role="dialog" aria-labelledby="" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="">Histórico</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Fechar">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        <asp:Label ID="LabelOperadorSupervisor" runat="server" Text=""></asp:Label>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Fechar</button>
      </div>
    </div>
  </div>
</div>
    <div class="modal fade .modal-xl" id="ModalSupervisorOperador" tabindex="-1" role="dialog" aria-labelledby="" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="">Histórico</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Fechar">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        <asp:Label ID="LabelSupervisorOperador" runat="server" Text=""></asp:Label>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Fechar</button>
      </div>
    </div>
  </div>
</div>
    <div class="modal fade .modal-xl" id="ModalOperadorCidadao" tabindex="-1" role="dialog" aria-labelledby="" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="">Histórico</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Fechar">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        <asp:Label ID="LabelOperadorCidadao" runat="server" Text=""></asp:Label>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Fechar</button>
        
      </div>
    </div>
  </div>
</div>
    <style>
        #btnHistorico{
            float:right
        }
        #btnCidadao{
            float:right
        }
        #btnSupervisor{
            float:right
        }
        #btnResposta{
            float:right
        }
    </style>
</asp:Content>
