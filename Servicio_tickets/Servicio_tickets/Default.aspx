<%@ Page Title="Registro" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Servicio_tickets._Default" %>
<%--  --%>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <table class="table table-condensed"  style="margin-left:auto; margin-right:auto; width:100%;">
        <tr>
            <td colspan="1" style="text-align:center;"><h2>Registro de usuario</h2></td>
        </tr>
    </table>
    
    <div class="jumbotron">
        <div class="row" style="margin-left:130px">
            <div class="col-md-6">
                <h4 style="margin-bottom:10px; margin-top:5px">Nombre</h4>
                <asp:TextBox ID="nombre" runat="server" placeholder="Nombre Completo" CssClass="form-control" ></asp:TextBox>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="El campo nombre es obligatorio" ControlToValidate="nombre" ForeColor="Red"></asp:RequiredFieldValidator>

                <div style="display:flex; margin-top:5px">
                    <h4>CURP</h4>
                    <p style="padding-top:5px;margin-left:3px; margin-top:5px">(Consulta tu CURP <asp:HyperLink runat="server" NavigateUrl="https://www.gob.mx/curp/" Target="_blank" Text="aquí."></asp:HyperLink>)</p>
                </div>
                <asp:TextBox ID="curp" runat="server" placeholder="CURP" CssClass="form-control" ></asp:TextBox>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="El campo CURP es obligatorio" ControlToValidate="curp" ForeColor="Red"></asp:RequiredFieldValidator>

                <h4 style="margin-bottom:10px; margin-top:5px">Correo</h4>
                <asp:TextBox ID="email" runat="server" placeholder="Correo electrónico" TextMode="Email" CssClass="form-control" ></asp:TextBox>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="El campo email es obligatorio" ControlToValidate="email" ForeColor="Red"></asp:RequiredFieldValidator>

                <h4 style="margin-bottom:10px; margin-top:5px">Telefono</h4>
                <asp:TextBox ID="tel" runat="server" datam-mask="9999999999" placeholder="Num. Telefono" MinLength="10" MaxLength="10" TextMode="Phone" CssClass="form-control" ></asp:TextBox>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="El campo telefono es obligatorio" ControlToValidate="tel" ForeColor="Red"></asp:RequiredFieldValidator>

            </div>
            <div class="col-md-6">
                <h4 style="margin-bottom: 10px; margin-top: 5px">Nivel Academico</h4>
                <asp:DropDownList ID="NA" runat="server" CssClass="form-control"></asp:DropDownList>
                <h4 style="margin-bottom: 10px; margin-top: 5px;">Trabajo</h4>
                <asp:DropDownList ID="Tr" runat="server" CssClass="form-control"></asp:DropDownList>
                <h4 style="margin-bottom:10px; margin-top:5px;">Contraseña</h4>
                <asp:TextBox ID="cont" runat="server" placeholder="Contraseña" TextMode="Password" CssClass="form-control" ></asp:TextBox>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="El campo contraseña es obligatorio" ControlToValidate="cont" ForeColor="Red"></asp:RequiredFieldValidator>

                <h4 style="margin-bottom:10px; margin-top:5px">Repetir Contraseña</h4>
                <asp:TextBox ID="cont2" runat="server" placeholder="Repite la contraseña" TextMode="Password" CssClass="form-control" ></asp:TextBox>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="El campo repetir contraseña es obligatorio" ControlToValidate="cont2" ForeColor="Red"></asp:RequiredFieldValidator>

            </div>
        </div>
        <br />
        <br />
        <div class="row">
            <div class="col-md-12" style="margin-left: 710px; margin-top:10px">
                <asp:Button ID="registra" runat="server" CssClass="btn btn-success" Text="Registrarse" OnClick="registra_Click1"/>
                <asp:Button runat="server" CssClass="btn btn-danger" Text="Cancelar" CausesValidation="false" OnClick="Unnamed2_Click" PostBackUrl="~/Index.aspx"/>				
            </div>
			<div>
			</div>
        </div>
    </div>


    <script src='<%= ResolveUrl("~/Scripts/jasny-bootstrap.min.js") %>'></script>
</asp:Content>
