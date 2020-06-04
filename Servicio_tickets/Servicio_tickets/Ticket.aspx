<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ticket.aspx.cs" Inherits="Servicio_tickets.Ticket" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Mis Ticket</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="icon" href="favicon.ico" />
    <!-- Bootstrap -->
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" />
    <%--<script src="../../../JS/Registration.js" language="javascript" type="text/javascript"></script>--%>
    <script src="Scripts/jquery-3.4.1.min.js" type="text/javascript"></script>
    <script src="Scripts/popper.min.js" type="text/javascript"></script>
    <script src="Scripts/bootstrap.min.js"  type="text/javascript"></script>
    <script src="Scripts/jasny-bootstrap.min.js" type="text/javascript"></script>
    <!-- UASLP -->
    <link href="~/Content/UASLP.css" rel="stylesheet" />
    <style>
        /*body {
          margin: 0 auto;
          max-width: 800px;
          padding: 0 20px;
        }*/
        .historial{
            max-height: 400px;
            overflow-y: auto;
        }

        .chatCont {
          border: 2px solid #dedede;
          background-color: #f1f1f1;
          border-radius: 5px;
          padding: 10px;
          margin: 10px 0;
          width:50%;
        }

        .darker {
          border-color: #ccc;
          background-color: #ddd;
          margin-left:auto;
        }

        .chatCont::after {
          content: "";
          clear: both;
          display: table;
        }

        .chatCont img {
          float: left;
          max-width: 60px;
          width: 100%;
          margin-right: 20px;
          border-radius: 50%;
        }

        .chatCont img.right {
          float: right;
          margin-left: 20px;
          margin-right:0;
        }

        .time-right {
          float: right;
          color: #aaa;
        }

        .time-left {
          float: left;
          color: #999;
        }
    </style>
    
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
        <div class="row" style="margin-left: auto; text-align: right;">
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
        
        <%--Aqui empueza el contenido--%>
        <div style="background-color: #1B3257; color:white; text-align:center;">
            <h2>Historial del ticket</h2>
            <asp:Panel ID="divinfo" runat="server" CssClass="container" style="background-color: #1B3257;color: white;font-size: 15px;">
             </asp:Panel>
             <%--<div class="container" >
                <div class="row">
                        <div class="col-sm">
                            <p>Area: Comunicación</p>
                        </div>
                        <div class="col-sm">
                            <p>Servicio: Un servicio</p>
                        </div>
                        <div class="col-sm">
                            <p>Encargado: MALDONADO DIAZ FABIAN GIOVANY</p>
                        </div>
                </div>
              </div>--%>
         </div>
        <div style="background: lightcyan;">
            <asp:Panel ID="historial" runat="server" CssClass="historial">
             </asp:Panel>
            <div style="margin:40px 0;">
                <textarea runat="server"  id="Respuesta" maxlength="500" class="form-control darker" style="width:50%; height: 100px; text-align: justify;font-size: 16px;"></textarea>
                <div style="margin-left:auto; margin-top:10px; width:fit-content;">
                    <asp:Button ID="responde" runat="server" CssClass="btn btn-primary" Text="Responder" OnClick="responde_Click"/>
                </div>
            </div>            
        </div>
        <asp:Panel ID="divcerrar" runat="server" style="margin-bottom:50px;">      
                <div style="margin-left:auto; margin-right:auto; margin-top:10px; width:fit-content;">
                    <asp:Button ID="cerrar" runat="server" CssClass="btn btn-danger" Text="Cerrar Ticket" OnClick="cerrar_Click"/>
                </div>
          </asp:Panel>
        <asp:Panel ID="divabr" runat="server" style="margin-bottom:50px;">      
                <div style="margin-left:auto; margin-right:auto; margin-top:10px; width:fit-content;">
                    <asp:Button ID="abrir" runat="server" CssClass="btn btn-primary" Text="Abrir ticket" OnClick="open_tick"/>
                </div>
          </asp:Panel>
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
