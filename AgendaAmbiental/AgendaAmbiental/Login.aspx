<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AgendaAmbiental.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Login Institucional</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />   
    <link rel="icon" href="favicon.ico"/>
    <!-- Bootstrap -->
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <!-- UASLP -->
    <link href="Content/UASLP.css" rel="stylesheet" />
</head>
<body>
    <div class="container">
        <div class="Encabezado">
            <div class="escudos">
                <div class="escudo escudoUASLP">
                    <a href="http://www.uaslp.mx">
                        <img id="UASLPLogo" src="Imagenes/UASLP.png" class="img-responsive" />
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
            <div class="LemaAzul"><img src="Imagenes/amarillo_azul.png"/></div>
            <div class="LemaAmarillo">"Siempre autónoma. Por mi patria educaré."</div>
        </div>
        <div class="Idioma" style="display:block"></div>
        <div class="row">
            <div class="col-sm-6 col-lg-5">
                <div class="card" style="border-color: #337ab7">
                    <div class="card-header" style="background-color: #337ab7; color: white;">
                        Sistema Informatico de Agenda Ambiental
                    </div>
                    <div class="card-body">
                        <form action="/" method="post">
                            <div class="form-group">
                                <label for="input-usuario">Usuario:</label>
                                <input type="text" class="form-control" id="input-usuario"/>
                            </div>
                            <div class="form-group">
                                <label for="input-password">Contraseña:</label>
                                <input type="password" class="form-control" id="input-password" />
                            </div>
                            <button type="submit" class="btn btn-primary">Iniciar sesión</button>
                        </form>
                    </div>
                </div>
            </div>

            <div class="col-sm-6 col-lg-7">
                <div>
                    <h3 style="margin-bottom: 2%; color: #2072B8; font-size: 1.15em;">
                        Para el uso del Servicio de autenticación, es indispensable contar con una cuenta institucional:
                    </h3>
                    <div class="bs-callout bs-callout-primary">
                        <h4>Alumnos</h4>
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
                        </p>
                    </div>
                    <div id="MsgEmpleados" class="bs-callout bs-callout-warning">
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
                    </div>
                    <div class="bs-callout bs-callout-info">
                        <h4>Personas Externas a la UASLP </h4>
                        <p>
                            Si usted es una persona que no pertenece a la UASLP haga click en el siguiente boton:

                        </p>
                        <button class="btn btn-primary">Registro</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>

