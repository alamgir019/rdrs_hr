<%@ Page Language="C#" MasterPageFile="~/MasterBTMS.master" AutoEventWireup="true"
    CodeFile="EmployeeNature.aspx.cs" Inherits="EIS_EmployeeNature" Title="Employee Nature" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript" src="../JScripts/Confirmation.js">
    </script>

    <div class="officeSetup">
        <div id="formhead1">
            <div style="width: 96%; float: left;">
                Employee Nature Setup</div>
            <div style="margin: 2px; float: left; padding-right: 3px;">
                <a href="../Default.aspx">
                    <img src="../Images/close_icon.gif" /></a></div>
        </div>
        <!--Div for group-->
        <div class="MsgBox">
            <!--Div for msg-->
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </div>
        <div class="officeSetupInner">
            <fieldset>
                <!--Div for Controls-->
                <asp:HiddenField ID="hfID" runat="server" />
                <asp:HiddenField ID="hfIsUpdate" runat="server" />
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" CssClass="textlevel" Text="Employee Nature :"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtEmpNature" runat="server" Width="300px"></asp:TextBox></td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmpNature"
                                ErrorMessage="*"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:CheckBox ID="chkInActive" runat="server" CssClass="textlevelleft" Text="Mark Inactive" /></td>
                        <td>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>
        <div class="GridFormat1">
            <!--Grid view Code starts-->
            <asp:GridView ID="grEmpTypeStatus" runat="server" DataKeyNames="EmpNatureID,IsActive"
                AutoGenerateColumns="False" EmptyDataText="No Record Found" Font-Size="9px" OnRowCommand="grEmpTypeStatus_RowCommand"
                Width="99%">
                <HeaderStyle BackColor="#B3CDE4" Font-Bold="True"></HeaderStyle>
                <SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" CssClass="ListHeader" Font-Bold="True">
                </SelectedRowStyle>
                <AlternatingRowStyle BackColor="#EFF3FB"></AlternatingRowStyle>
                <Columns>
                    <asp:ButtonField CommandName="DoubleClick" HeaderText="Edit" Text="Edit">
                        <ItemStyle CssClass="ItemStylecss" Width="10px" />
                    </asp:ButtonField>
                    <asp:BoundField DataField="NatureName" HeaderText="Employee Nature">
                        <ItemStyle CssClass="ItemStylecss" Width="80%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="IsActive" HeaderText="Is Active">
                        <ItemStyle CssClass="ItemStylecss" Width="10%"></ItemStyle>
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
            <!--Grid view Code Ends-->
        </div>
        <div class="DivCommand1">
            <div class="DivCommandL">
                <asp:Button ID="btnClear" runat="server" Text="Refresh" Width="70px" OnClick="btnClear_Click" CausesValidation="false"
                    UseSubmitBehavior="False" />
            </div>
            <div class="DivCommandR">
                <asp:Button ID="btnSave" runat="server" Text="Save" Width="70px" OnClick="btnSave_Click" />
                <asp:Button ID="btnDelete" runat="server" Text="Delete" Width="70px" OnClientClick="javascript:return DeleteConfirmation();"
                    OnClick="btnDelete_Click" />
            </div>
        </div>
    </div>
</asp:Content>
