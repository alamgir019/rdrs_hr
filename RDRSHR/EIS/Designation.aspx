﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterBTMS.master" AutoEventWireup="true"
    CodeFile="Designation.aspx.cs" Inherits="EIS_Designation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="MaiContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../JScripts/Confirmation.js">
    </script>
    <div class="setup">
        <div id='formhead1'>
            <div style="width: 96%; float: left;">
                Designation Setup</div>
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
        <asp:HiddenField ID="hfIsUpadate" runat="server" />
        <asp:HiddenField ID="hfID" runat="server" />
        <div style="margin-left: 10px; margin-right: 10px;">
            <fieldset>
                <table>
                    <tr>
                        <td class="textlevel">
                            Designation Name :
                        </td>
                        <td>
                            <asp:TextBox ID="txtDesigation" runat="server" Width="309px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDesigation"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" CssClass="textlevel" Text="Short Name :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDesigShortName" runat="server" Width="100px"></asp:TextBox>
                        </td>
                       
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:CheckBox ID="ChkIsActive" Text="Mark Inactive" CssClass="textlevelleft" runat="server" />
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>
        <div style="margin-left: 10px; margin-right: 10px; margin-top: 10px;">
            <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" Width="100%"
                Height="250px">
                <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel1" Width="100%">
                    <HeaderTemplate>
                        Job Title List
                    </HeaderTemplate>
                    <ContentTemplate>
                        <div style="width: 100%; height: 240px; overflow: scroll;">
                            <asp:GridView ID="grJobTitle" runat="server" DataKeyNames="JobTitleId,DesigId" AutoGenerateColumns="False"
                                EmptyDataText="No Record Found" Font-Size="9px" OnRowCommand="grDesigation_RowCommand"
                                Width="99%">
                                <HeaderStyle BackColor="#B3CDE4" Font-Bold="True"></HeaderStyle>
                                <SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" CssClass="ListHeader" Font-Bold="True">
                                </SelectedRowStyle>
                                <AlternatingRowStyle BackColor="#EFF3FB"></AlternatingRowStyle>
                                <Columns>
                                    <asp:TemplateField HeaderText="Select">
                                        <ItemStyle CssClass="ItemStylecss" Width="5%" />
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkBox" runat="Server"></asp:CheckBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="JobTitleName" HeaderText="Job Title Name">
                                        <ItemStyle CssClass="ItemStylecss" Width="95%"></ItemStyle>
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </ContentTemplate>
                </cc1:TabPanel>
                <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1" Width="100%">
                    <HeaderTemplate>
                        Designation List
                    </HeaderTemplate>
                    <ContentTemplate>
                        <div style="width: 100%; height: 240px; overflow: scroll;">
                            <asp:GridView ID="grDesigation" runat="server" DataKeyNames="DesigId,IsActive" AutoGenerateColumns="False"
                                EmptyDataText="No Record Found" Font-Size="9px" OnRowCommand="grDesigation_RowCommand"
                                Width="99%">
                                <HeaderStyle BackColor="#B3CDE4" Font-Bold="True"></HeaderStyle>
                                <SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" CssClass="ListHeader" Font-Bold="True">
                                </SelectedRowStyle>
                                <AlternatingRowStyle BackColor="#EFF3FB"></AlternatingRowStyle>
                                <Columns>
                                    <asp:ButtonField CommandName="DoubleClick" HeaderText="Edit" Text="Edit">
                                        <ItemStyle CssClass="ItemStylecss" Width="10%" />
                                    </asp:ButtonField>
                                    <asp:BoundField DataField="DesigName" HeaderText="Desigation Name">
                                        <ItemStyle CssClass="ItemStylecss" Width="80%"></ItemStyle>
                                    </asp:BoundField>

                                     <asp:BoundField DataField="DesigShortName" HeaderText="Short Name">
                                        <ItemStyle CssClass="ItemStylecss" Width="80%"></ItemStyle>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="IsActive" HeaderText="Is Active">
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
                        CausesValidation="False" UseSubmitBehavior="False"/>
                </div>
                <div class="DivCommandR">
                    <asp:Button ID="btnSave" runat="server" Text="Save" Width="70px" OnClick="btnSave_Click" />
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" Width="70px" OnClientClick="javascript:return DeleteConfirmation();"
                        OnClick="btnDelete_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
