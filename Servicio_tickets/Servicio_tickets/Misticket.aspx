<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Misticket.aspx.cs" Inherits="Servicio_tickets.Misticket" %>

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
        
        <div id="accordion" style="margin-bottom:100px;">
           <%-- <div class="card" style="margin-bottom: 25px; margin-left: auto;">
                <div class="card-header" id="headingFour" style="background-color: #1B3257;">
                  <h5 class="mb-0">
                    <button class="btn btn-link" style="color:white;" data-toggle="collapse" data-target="#collapseFour" aria-expanded="true" aria-controls="collapseFour">
                      Recibidos
                    </button>
                  </h5>
                </div>

                <div id="collapseFour" class="collapse show" aria-labelledby="headingOne" data-parent="#accordion">
                  <div class="card-body">
                    Esta parte solo debe de salir si es un jefe de unidad.  
                  </div>
                </div>
              </div>--%>
          <div class="card" style="margin-bottom: 25px; margin-left: auto;">
            <div class="card-header" id="headingOne" style="background-color: #1B3257;">
              <h5 class="mb-0">
                <button type="button" class="btn btn-link" style="color:white;" data-toggle="collapse" data-target="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                  Activos
                </button>
              </h5>
            </div>

            <div id="collapseOne" class="collapse" aria-labelledby="headingOne" data-parent="#accordion">
                <asp:Panel class="card-body" ID="divact" runat="server">
                </asp:Panel>
            </div>
          </div>
          <div class="card" style="margin-bottom: 25px; margin-left: auto;">
            <div class="card-header" id="headingTwo" style="background-color: #1B3257;">
              <h5 class="mb-0">
                <button type="button" class="btn btn-link collapsed" style="color:white;" data-toggle="collapse" data-target="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">
                  En espera</button>
              </h5>
            </div>
            <div id="collapseTwo" class="collapse" aria-labelledby="headingTwo" data-parent="#accordion">
              <asp:Panel class="card-body" ID="divesp" runat="server">
                </asp:Panel>
            </div>
          </div>
          <div class="card" style="margin-bottom: 25px; margin-left: auto;">
            <div class="card-header" id="headingThree" style="background-color: #1B3257;">
              <h5 class="mb-0">
                <button type="button" style="color:white;" class="btn btn-link collapsed" data-toggle="collapse" data-target="#collapseThree" aria-expanded="false" aria-controls="collapseThree">
                  Cerrados
                </button>
              </h5>
            </div>
            <div id="collapseThree" class="collapse" aria-labelledby="headingThree" data-parent="#accordion">
              <asp:Panel class="card-body" ID="divcerr" runat="server">
                </asp:Panel>
            </div>
          </div>
        </div>

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
