<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmReportViewer.aspx.cs"
    Inherits="frmReportViewer" Title="Report Page" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Report Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <fieldset style="text-align: left; background-color: White">
                <CR:CrystalReportViewer ID="CRV" runat="server" EnableDatabaseLogonPrompt="False"
                    OnBeforeRender="CRV_BeforeRender" OnUnload="CRV_Unload" />
            </fieldset>
        </div>
    </form>
</body>
</html>
