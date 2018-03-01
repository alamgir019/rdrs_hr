<%@ Page Language="C#" MasterPageFile="~/MasterBTMS.master" AutoEventWireup="true"
    CodeFile="ComponentSetup.aspx.cs" Inherits="ComponentSetup" Title="Component Setup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="setup">
        <div id='formhead1'>
            <div style="width: 96%; float: left;">
                Component Setup</div>
            <div style="margin: 2px; float: left; padding-right: 3px;">
                <a href="../Default.aspx">
                    <img src="../Images/close_icon.gif" /></a></div>
        </div>
        <!--Div for group-->
        <div class="MsgBox">
            <!--Div for msg-->
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </div>
        <!--Div for Controls-->
        <asp:HiddenField ID="hfIsUpdate" runat="server" />
        <asp:HiddenField ID="hfID" runat="server" />
        <div style="margin-left: 10px; margin-right: 10px;">
            <fieldset>
                <table>
                    <tr>
                        <td class="textlevel">
                            Component Name :
                        </td>
                        <td>
                            <asp:TextBox ID="txtCompName" runat="server" Width="309px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtCompName" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:CheckBox ID="chkInActive" runat="server" Text="Mark Inactive" CssClass="textlevelleft" />
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>
        <div style="margin-left: 10px; margin-right: 10px; margin-top: 10px;">
            <cc1:TabContainer ID="TabContainer1" runat="server" Width="100%" Height="250px">
                <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1" Width="100%">
                    <HeaderTemplate>Component List</HeaderTemplate>
                    <ContentTemplate>
                    <div style="width: 100%; height: 240px; overflow: scroll;">
                        <asp:GridView ID="grCmpList" runat="server" DataKeyNames="ComponentId,IsActive" 
                            AutoGenerateColumns="False" EmptyDataText="No Record Found" Font-Size="9px" 
                            OnRowCommand="grCmpList_RowCommand" Width="99%">
                            <HeaderStyle BackColor="#B3CDE4" Font-Bold="True"></HeaderStyle>
                            <SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" CssClass="ListHeader" 
                                Font-Bold="True"></SelectedRowStyle>
                            <AlternatingRowStyle BackColor="#EFF3FB"></AlternatingRowStyle>
                            <Columns>
                                <asp:ButtonField CommandName="DoubleClick" HeaderText="Edit" Text="Edit">
                                    <ItemStyle CssClass="ItemStylecss" Width="10%" />
                                </asp:ButtonField>
                                <asp:BoundField DataField="ComponentName" HeaderText="Component Name">
                                    <ItemStyle CssClass="ItemStylecss" Width="60%"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="IsActive" HeaderText="Is Active">
                                    <ItemStyle CssClass="ItemStylecss" Width="10%"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="IsDeleted" HeaderText="Is Deleted">
                                    <ItemStyle CssClass="ItemStylecss" Width="10%"></ItemStyle>
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </div>
                       
                    </ContentTemplate>
                </cc1:TabPanel>
            </cc1:TabContainer>
            <div style="margin-top: 10px;">
                <div class="DivCommandL">
                    <asp:Button ID="btnClear" runat="server" Text="Refresh" Width="70px" OnClick="btnClear_Click"
                        CausesValidation="False" UseSubmitBehavior="False" />
                </div>
                <div class="DivCommandR">
                    <asp:Button ID="btnSave" runat="server" Text="Save" Width="70px" OnClick="btnSave_Click" />
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" Width="70px" 
                        OnClientClick="javascript:return DeleteConfirmation();" OnClick="btnDelete_Click" />
                </div>
            </div>
        </div>
    </div>
   
</asp:Content>
