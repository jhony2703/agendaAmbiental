<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Index.aspx.cs" Inherits="Servicio_tickets.Index" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<%--<!DOCTYPE html>--%>

<%--<html>
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Login Institucional</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" /> 
    <link rel="icon" href="favicon.ico" />
    <!-- Bootstrap -->
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" />
    <!-- UASLP -->
    <link href="~/Content/UASLP.css" rel="stylesheet" />
</head>
<body>  --%> 

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
        <div class="Idioma" style="display:block"></div>

        <div class="Lema">
            <div class="LemaAzul"><img id="LemaAz" runat="server" src="~/Imagenes/amarillo_azul.png" class="img-responsive"/>
            </div>
            <div class="LemaAmarillo">"Siempre autónoma. Por mi patria educaré."</div>
        </div>
        <div class="Idioma" style="display:block"></div>
        <div class="row">
            <div class="col-sm-6 col-lg-5">
                <div class="card" style="border-color: #337ab7">
                    <div class="card-header" style="background-color: #337ab7; color: white;">
                        Sistema Informático de Agenda Ambiental
                    </div>
                    <div class="card-body">
                        <form  method="post">
                            <div class="form-group">
                                <label for="input-usuario">CURP:</label>
                                <asp:TextBox ID="usuario" runat="server" placeholder="CURP" CssClass="form-control"></asp:TextBox>
                                <%--<input type="text" class="form-control" id="input-usuario"/>--%>
                            </div>
                            <div class="form-group">
                                <label for="input-password">Contraseña:</label>
                                <asp:TextBox ID="contra" TextMode="Password" runat="server" placeholder="Contraseña" CssClass="form-control"></asp:TextBox>
                               <%-- <input type="password" class="form-control" id="input-password" />--%>
                            </div>
                            <asp:Button ID="btnIS" runat="server" CssClass="btn btn-primary" Text="Iniciar sesión" OnClick="btnIS_Click"/>
                            <%--<a href="Genera_ticket" class="btn btn-primary">Iniciar sesión</a>--%>
                        </form>
                    </div>
                </div>
            </div>

            <div class="col-sm-6 col-lg-7">
                <div>
                    <%--<h3 style="margin-bottom: 2%; color: #2072B8; font-size: 1.15em;">
                        Para el uso del Servicio de autenticación, es indispensable contar con una cuenta institucional:
                    </h3>--%>
                    <div class="bs-callout bs-callout-primary">
                        <h4>Personas Externas a la UASLP </h4>
                        <p>
                            Si usted es una persona que no pertenece a la UASLP y ya está registrado inicie sesión con su CURP y su contraseña.
                        </p>
                         <p>
                            ¿No recuerdas tú CURP? Consultala en el siguiente <asp:HyperLink runat="server" Target="_blank" NavigateUrl="https://www.gob.mx/curp/" Text="enlace."></asp:HyperLink>
                        </p>
                        <p>
                            De lo contrario haga click en el siguiente botón y registre una cuenta:
                        </p>
                        <a href="/" class="btn btn-primary">Registro</a>
                       <%-- <h4>Alumnos</h4>
                        <p>
                            <strong>
                                Para asesoría:
                            </strong>
                            Acuda al Centro de Servicios Escolares de su Escuela o Facultad.
                        </p>
                        <p>
                            Si no recuerda su contraseña, la puede cambiar en el siguiente vínculo:
                            <a href="http://estudiantes.uaslp.mx/Administracion/ResetPass">
                                http://estudiantes.uaslp.mx/Administracion/ResetPass
                            </a>
                        </p>--%>
                    </div>
                   <%-- <div id="MsgEmpleados" class="bs-callout bs-callout-warning">
                        <h4>Administrativos / Docentes</h4>
                        <p>
                            Pueden ingresar con su cuenta de correo institucional ya que el usuario y contraseña son los mismos. Si no cuenta con su cuenta de correo, lo puede habilitar en el siguiente vínculo:
                            <a href="http://servicios.uaslp.mx/HabilitaCorreo/"> http://servicios.uaslp.mx/HabilitaCorreo/ </a>
                        </p>
                        <p>
                            Para más información, acuda con el Responsable de Tecnología de su Unidad (RTIC). Puede comunicarse a la División de Informática a la cuenta
                            <a href="mailto:servicios.internet@uaslp.mx">servicios.internet@uaslp.mx</a>
                        </p>
                        <p>
                            Si no recuerda su contraseña, la puede cambiar en el siguiente vínculo:
                            <a href="http://servicios2.uaslp.mx/cambiopassword/"> http://servicios.uaslp.mx/cambiopassword/ </a>
                        </p>
                    </div>--%>
                    <%--<div class="bs-callout bs-callout-info">
                        <h4>Personas Externas a la UASLP </h4>
                        <p>
                            Si usted es una persona que no pertenece a la UASLP y ya esta registrado inicie sesion con su CURP y su contraseña.
                        </p>
                        <p>
                            De lo contrario haga click en el siguiente botón y registre una cuenta:
                        </p>
                        <a href="/" class="btn btn-primary">Registro</a>
                    </div>--%>
                </div>
            </div>
        </div>
    </div>
  <%--</body>--%>
<%--</html>--%>
</asp:Content>
