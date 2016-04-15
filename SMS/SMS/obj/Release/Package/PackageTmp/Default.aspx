<%@ Page Title="" Language="C#" MasterPageFile="~/Padrao.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SMS.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <script language='JavaScript'>
            function SomenteNumero(e) {
                var tecla = (window.event) ? event.keyCode : e.which;
                if ((tecla > 47 && tecla < 59)) return true;
                else {
                    if (tecla == 8 || tecla == 0) return true;
                    else return false;
                }
            }
            function contanumero(input) {

                document.getElementById('lbtel').innerHTML = input.value.split(":").length;
            }
            function contagemCaracteres(inputText) {
                var texto = inputText.value.replace(/\n/g, "").replace(/\r/g, "");
                document.getElementById('lbltipAddedComment').innerHTML = 160 - texto.length;
                //document.form1.contar3.value = texto.length;
            }
            function limitTextarea(inputText, limit) {

                if (event.keyCode != '37' && event.keyCode != "38" && event.keyCode != '39' && event.keyCode != '40'
                    && event.keyCode != '8' && event.keyCode != '16' && event.keyCode != '17' && event.keyCode != '18') {
                    var texto = inputText.value.replace(/\n/g, "").replace(/\r/g, "");
                    var tamanho = texto.length;
                    var tex = inputText.value.replace(/\n/g, "").replace(/\r/g, "");
                    if (tamanho >= limit) {
                        inputText.value = tex.substring(0, limit);
                    }
                    return true;
                } else {
                    return false;
                }
            }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="jumbotron">
        <h1>Envio de SMS</h1>
        <asp:Label ID="Lb_erro" runat="server" Text="Label"></asp:Label>
        <p>Números:<label id="lbtel">0</label></p>
        <p><asp:TextBox ID="tx_numero" runat="server" onBlur="contanumero(this);" onkeydown="contanumero(this);" onkeyup="contanumero(this);"  onmouseout="contanumero(this);"  onkeypress='return SomenteNumero(event);contanumero(this);' CssClass="form-control" placeholder="Números"></asp:TextBox></p>
        <p>Mensagem:<label id="lbltipAddedComment">160 </label></p>
        <p><asp:TextBox ID="tx_mensagem" runat="server" CssClass="form-control" onkeydown="limitTextarea(this, 160);contagemCaracteres(this);" onkeyup="limitTextarea(this, 160);contagemCaracteres(this);" onmouseout="limitTextarea(this, 160);contagemCaracteres(this);" placeholder="Mensagem" Height="80px" TextMode="MultiLine"></asp:TextBox></p>
        <p><asp:Button CssClass="btn btn-primary btn-lg" ID="Button1" runat="server" Text="Enviar" OnClick="Button1_Click" /></p>
        <div class="table-responsive">
  <table class="table">
      <thead>
        <tr>
          <th>Número</th>
          <th>status</th>
        </tr>
      </thead>
      <tbody>
          <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        
      </tbody>
    </table>
</div>
        </div>
</asp:Content>
