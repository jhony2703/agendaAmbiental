<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Genera_ticket.aspx.cs" Inherits="Servicio_tickets.Genera_ticket" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Genera Ticket</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="icon" href="favicon.ico" />
    <!-- Bootstrap -->
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" />
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" />
    <script src="~/Scripts/jquery-3.4.1.min.js"></script>
    <script src="~/Scripts/popper.min.js"></script>
    <script src="~/Scripts/bootstrap.min.js"></script>
    <script src="~/Scripts/jasny-bootstrap.min.js"></script>
    <!-- UASLP -->
    <link href="~/Content/UASLP.css" rel="stylesheet" />
</head>
<body>
    <form runat="server">
    <div class="container">
        <div class="Encabezado">
            <div class="escudos">
                <div class="escudo escudoUASLP">
                    <a href="http://www.uaslp.mx">
                        <img id="UASLPLogo" runat="server" src="~/Imagenes/UASLP.png" class="img-responsive"/>
                       <!-- <img id="UASLPLogo" src="~/Imagenes/UASLP.png" class="img-responsive" /> -->
                    </a>
                </div>
                <div class="lineaEscudo"></div>
                <div class="titulo">
                    <a href="/">
                        <span id="Titulo">Inicio de Sesión Institucional</span>
                        <span id="TituloMobile">Inicio de Sesión</span>
                    </a>
                </div>
            </div>
            <div class="foto"></div>
        </div>

        <div class="row" style="margin-left:auto; text-align:right;">
            <div class="row" style="margin-left:auto;margin-right:6px;">
                <a href="Genera_ticket.aspx" class="btn btn-primary" onclick="redirecciona(1)" style="margin-bottom:10px; margin-top:10px; margin-right:10px;">Crear ticket</a>
                <a href="Misticket.aspx" class="btn btn-primary" onclick="redirecciona(2)" style="margin-bottom:10px; margin-top:10px; margin-right:10px;">Mis tickets</a>
                <a href="CierraSesion.aspx" class="btn btn-danger"  onclick="redirecciona(3)" style="margin-bottom:10px; margin-top:10px; margin-right:10px;">Salir</a>
            </div>
        </div>
        <div class="row" style="margin-left:auto; text-align:right;">
            <div class="row" style="margin-left:auto;margin-right:6px;">
                <p  style="font-size:19px;margin-bottom :10px; margin-right:10px; color:blue;"><%: DateTime.Now.Date.ToString("dddd, dd \\de MMMM \\de yyyy") %></p> 
            </div>
        </div>
        <table class="table table-condensed table-borderless" style="margin-left:auto; margin-right:auto; width:550px; border-style:none">
            <tr>
                <td colspan="2" style="text-align:center; background-color:#1B3257"><h4 style="color:white">Información del contacto</h4></td>
            </tr>
            <tr>
                <td style="width:30%; text-align:right;"><label>CURP:</label></td>
                <td style="width:90%"><asp:Label runat="server" ID="usu"></asp:Label></td>
            </tr>
            <tr>
                <td style="width:30%; text-align:right;"><label>Nombre:</label></td>
                <td style="width:85%"><asp:Label runat="server" ID="nombC"></asp:Label></td>
            </tr>
            <tr>
                <td style="width:30%; text-align:right;"><label>Correo Electrónico:</label></td>
                <td style="width:90%"><asp:Label runat="server" ID="correo"></asp:Label></td>
            </tr>
            <tr>
                <td style="width:30%; text-align:right;"><label>Teléfono:</label></td>
                <td style="width:90%"><asp:Label runat="server" ID="tel"></asp:Label></td>
            </tr>
            <%--<tr>
                <td style="width:30%; text-align:right;"><label>Unidad:</label></td>
                <td style="width:90%"><label>División de Infomática</label></td>
            </tr>
            <tr>
                <td style="width:30%; text-align:right;"><label>Sub Unidad:</label></td>
                <td style="width:90%"><label>Redes</label></td>
            </tr>--%>
            <tr>
                <td colspan="2" style="text-align:center; background-color:#1B3257;"><h4 style="color:white">Detalle del servicio requerido</h4></td>
            </tr>
            <tr>
                <td style="width:30%; text-align:right;"><label>Proceso:</label></td>
                <td style=" width: 90% ">
                    <asp:DropDownList ID="Pro" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="Pro_SelectedIndexChanged" OnTextChanged="Pro_TextChanged"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 30%; text-align: right;"><label>Servicio:</label></td>
                <td style="width:90%">
                    <asp:DropDownList ID="Serv" runat="server" CssClass="form-control"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width:30%; text-align:right;"><label>Asunto:</label></td>
                <td style="width:90%"><input class="form-control" type="text" id="asunto" runat="server" placeholder="Asunto del ticket" maxlength="20"  /></td>
            </tr>
            <tr>
                <td style="width:30%; text-align:right;"><label>Detalle Solicitud:</label></td>
                <td style="width:90%"><textarea maxlength="500" id="detalle" runat="server" class="form-control"></textarea></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:right">
                    <asp:Button ID="envia" runat="server" CssClass="btn btn-success" Text="Enviar" OnClick="envia_Click" />
                </td>
            </tr>
        </table>

        <div id="info">
        </div>
        <div class="piedepagina">
            <div class="escudos">
                <div class="titulo">
                </div>
            </div>
            <div class="foto"></div>
        </div>

    </div>
   </form>
</body>
</html>
