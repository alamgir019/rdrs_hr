<%@ Page Language="C#" MasterPageFile="~/MasterBTMS.master" AutoEventWireup="true" CodeFile="TotalPF.aspx.cs" Inherits="Payroll_Loan_TotalPF" Title="Total PF" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="PayrollConfigForm">
    <div id="formhead1">
      <div style="width:92%;float:left;">Total PF By Month</div>
        <div style=" margin:2px; float:left;padding-left:3px;"><a href="../../File/Home.aspx">
                    <img src="../../Images/close_icon.gif" /></a></div>
    </div>
    <div class="MsgBox">
      <asp:Label ID="lblMsg" runat="server" CssClass="msglabel"></asp:Label>
    </div>
    <div id="PayrollConfigInner">
        <fieldset style="margin-top:10px;">
            <table>
                <tr>
                    <td class="textlevel">Fiscal Year</td>
                    <td><asp:DropDownList ID="ddlFiscalYear" runat="server" Width="105px"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td class="textlevel"></td>
                    <td style="text-align:right;"><asp:Button ID="btnPreview" runat="server" Text="Print Priview" OnClick="btnPreview_Click"/></td>
                </tr>
            </table>
        </fieldset>
    </div>
</div>
</asp:Content>

