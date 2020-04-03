<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="session.aspx.cs" Inherits="Detran.faleconosco.session" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="Scripts/jquery-3.3.1.js"></script>
    <title></title>
    <script type="text/javascript">

        var sessao_Intervalo = 6000;
        var sessao_expiracaoMinutos = 7;
        var sessao_avisoMinutos = 2;
        var sessao_intervaloID;
        var sessao_ultimaAtividade;

        function initSession() 
        {
            sessao_ultimaAtividade = new Date();
            sessao_SetIntervalo();
            $(document).bind('keypress.session', function (ed, e) {
                sessao_TeclaPressionada(ed, e);
            });
        }

        function sessao_SetIntervalo() 
        {
            sessao_intervaloID = setInterval('sessaoIntervalo()', sessao_Intervalo);
        }

        function sessao_LimpaIntervalo() {
            clearInterval(sessao_intervaloID);
        }

        function sessao_TeclaPressionada(ed, e) {
            sessao_ultimaAtividade = new Date();
        }

        function sessao_LogOut() {
            window.location.href = 'Logout.aspx';
        }

        function sessaoIntervalo() 
        {
            var now = new Date();
            //obtem a diferença de tempo em milisegundos
            var diferencaMilisegundos = now - sessao_ultimaAtividade;
            //obtem o tempo em minutos
            var diferencaMinutos = (diferencaMilisegundos / 1000 / 60);

            if (diferencaMinutos >= sessao_avisoMinutos) 
            {
                //emite o aviso de expiração
                //para o timer
                sessao_LimpaIntervalo();
                //mensagem de alerta
                var ativar = confirm('A sua sessão irá experir em ' + (sessao_expiracaoMinutos - sessao_avisoMinutos) +
                ' minutos (de ' + now.toTimeString() + '), pressione OK para permanecer logado ' +
                'ou pressione Cancel para fazer o log off. \nAo se desconetar seus dados da sessão serão perdidos.');
                if (ativar == true) {
                    now = new Date();
                    diferencaMilisegundos = now - sessao_ultimaAtividade;
                    diferencaMinutos = (diferencaMilisegundos / 1000 / 60);

                    if (diferencaMinutos > sessao_expiracaoMinutos) {
                        sessao_LogOut();
                    }
                    else {
                        initSession();
                        sessao_SetIntervalo();
                        sessao_ultimaAtividade = new Date();
                    }
                }
                else {
                    sessao_LogOut();
                }
            }
        }
</script>

</head>
<body onload="initSession()">
    <form id="form1" runat="server">
    <div>
    <h1>Macoratti .net - Quase tudo para VB .NET , C# e ASP .NET</h1>
    </div>
    </form>
</body>
</html>
