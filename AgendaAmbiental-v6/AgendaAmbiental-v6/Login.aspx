<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AgendaAmbiental_v6.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <style type="text/css"> 
       .FailureDiv
       {
        width: 300px;        
        text-align:center;           
        color:#CC0000;
        background-color:#FFDCDC;
        border-color:#CC0000;
        border-style:solid;
        border-width:1px;             
	    font-size:12pt;	
	    padding:1em 0 1em 0;           
       }
    </style>
</head>
<body>
    <br />
    <br />
    <form id="form1" runat="server">
    <center>
        <div id="FailureDiv" runat="server" class="FailureDiv"  enableviewstate="false" visible="false">
            <asp:Literal ID="FailureText" runat="server" />
        </div>
    </center>
    </form>
</body>
</html>

