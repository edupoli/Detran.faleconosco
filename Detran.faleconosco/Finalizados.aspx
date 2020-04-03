<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Finalizados.aspx.cs" Inherits="Detran.faleconosco.Finalizados" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
            <div class="jumbotron">
            <br />
        <p class="text-center" style="font-size:40px">Atendimento Fale Conosco Detran-PR</p>
            <br />
        </div>
    <!--<h2>Atendimento PABX Detran-PR</h2>-->
    <asp:Panel ID="painelErroGrid" runat="server">
       <div style="margin: auto; margin-bottom: 20px;" class="alert alert-danger" role="alert">
          <asp:Label runat="server" ID="gridMensagemErro"></asp:Label><br />
       </div>
    </asp:Panel>
    
    <br />
    <br />
    <br />
    <script src="~/Scripts/jquery-3.3.1.min.js"></script>
    
<link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.19/css/dataTables.bootstrap4.min.css" />
    <!-- jQuery CDN - Slim version (=without AJAX) -->
<script type="text/javascript" src="https://code.jquery.com/jquery-3.3.1.js"></script>
    <script src="Scripts/jquery-3.3.1.min.js"></script>
<!-- Popper.JS -->
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.0/umd/popper.min.js" integrity="sha384-cs/chFZiN24E4KMATLdqdvsezGxaGsi4hLGOzlXwp5UZB1LY//20VyM2taTB4QvJ" crossorigin="anonymous"></script>

<!-- Bootstrap JS -->
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.0/js/bootstrap.min.js" integrity="sha384-uefMccjFJAIv6A+rW+L4AHf99KvxDjWSu1z9VI8SKNVmz4sk7buKt/6v9KI65qnm" crossorigin="anonymous"></script>

<!-- jQuery Data Tables CDN -->
<script src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.js" type="text/javascript" charset="utf8"></script>

<!-- Bootstrap Data Tables JS -->
<script src="https://cdn.datatables.net/1.10.19/js/dataTables.bootstrap4.min.js" type="text/javascript" charset="utf8"></script>

    <div class="table-responsive">

    <asp:GridView ID="grid" class="table table-striped table-hover table-sm" runat="server" AutoGenerateColumns="False" OnRowDataBound="grid_RowDataBound" >
        <Columns>
            <asp:BoundField DataField="protocolo" HeaderText="Protocolo" />
            <asp:BoundField DataField="data_abertura" HeaderText="Data Abertura" />
            <asp:BoundField DataField="status" HeaderText="Status" />
            <asp:BoundField DataField="nome" HeaderText="Nome" />
            <asp:BoundField DataField="email" HeaderText="E-mail" />
            <asp:BoundField DataField="celular" HeaderText="Celular" />
            <asp:BoundField DataField="cpf" HeaderText="CPF" />
            <asp:TemplateField HeaderText="Ações">
                <ItemTemplate>
                    <asp:Button class="btn badge-info" Text="Ver" ID="btnResponder" runat="server" CommandArgument='<%# Eval("idfaleconosco") %>' OnClick="btnResponder_Click" />
                    
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    </div>
    <style>
        .jumbotron{
    position: relative;
    padding:0 !important;
    margin-top:40px !important;
    background: #eee;
    margin-top: 28px;
    text-align:center;
    margin-bottom: 0 !important;
}
        
   th, td {
    white-space: nowrap;
}
    </style>



    <script>
            $(document).ready(function () {
            $('#<%= grid.ClientID%>').prepend($("<thead></thead>").append($("#<%= grid.ClientID%>").find("tr:first"))).DataTable({
                "bJQueryUI": true,
                "autoWidth": true,
                 
                "oLanguage": {
                    "sProcessing":   "Processando...",
                    "sLengthMenu":   "Mostrar _MENU_ registros",
                    "sZeroRecords":  "Não foram encontrados resultados",
                    "sInfo":         "Mostrando de _START_ até _END_ de _TOTAL_ registros",
                    "sInfoEmpty":    "Mostrando de 0 até 0 de 0 registros",
                    "sInfoFiltered": "",
                    "sInfoPostFix":  "",
                    "sSearch":       "Pesquisar:",
                    "sUrl":          "",
                    "oPaginate": {
                        "sFirst":    "Primeiro",
                        "sPrevious": "Anterior",
                        "sNext":     "Seguinte",
                        "sLast":     "Último"
                    }
                }
            }) 
            });
    </script>
</asp:Content>
