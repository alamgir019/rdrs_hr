<%@ Page Language="C#" MasterPageFile="~/MasterBTMS.master" AutoEventWireup="true"
    CodeFile="GradeMatrixSetup.aspx.cs" Inherits="GradeMatrixSetup" Title="Grade Matrix" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../JScripts/Confirmation.js">
    </script>
    <div class="setup">
        <div id='formhead1'>
            <div style="width: 96%; float: left;">
                Grade Salary Matrix Setup</div>
            <div style="margin: 2px; float: left; padding-right: 3px;">
                <a href="../Default.aspx">
                    <img src="../Images/close_icon.gif" /></a></div>
        </div>
        <!--Div for group-->
        <div class="MsgBox">
            <!--Div for msg-->
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </div>
        <div class="setupInner">
            <fieldset>
                <!--Div for Controls-->
                <asp:HiddenField ID="hfIsUpdate" runat="server" />
                <asp:HiddenField ID="hfID" runat="server" />
                <table>
                    <tr>
                        <td class="textlevel">
                            Grade :
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlGrade" runat="server" CssClass="textlevelleft"
                                Width="100px">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlGrade"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                        <td class="textlevel">
                            Grade Level :
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlGradeLevel" runat="server" CssClass="textlevelleft"
                                Width="100px">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlGradeLevel"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="textlevel">
                            Basic :
                        </td>
                        <td>
                            <asp:TextBox ID="txtBasic" runat="server" CssClass="TextBoxAmt60" Width="89px" 
                                AutoPostBack="True" ontextchanged="txtBasic_TextChanged"></asp:TextBox>
                        </td>
                        <td class="textlevel">
                            Medical :
                        </td>
                        <td>
                            <asp:TextBox ID="txtMedical" runat="server" CssClass="TextBoxAmt60" Width="89px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="textlevel">
                            Housing :
                        </td>
                        <td>
                            <asp:TextBox ID="txtHousing" runat="server" CssClass="TextBoxAmt60" Width="89px"></asp:TextBox>
                        </td>
                        <td class="textlevel">
                            HO Housing :
                        </td>
                        <td>
                            <asp:TextBox ID="txtHOHousing" runat="server" CssClass="TextBoxAmt60" Width="89px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="textlevel">
                            Conveyance :
                        </td>
                        <td>
                            <asp:TextBox ID="txtConveyance" runat="server" CssClass="TextBoxAmt60" Width="89px"></asp:TextBox>
                        </td>
                        <td class="textlevel">
                            HO Conveyance:
                        </td>
                        <td>
                            <asp:TextBox ID="txtHOConveyance" runat="server" CssClass="TextBoxAmt60" Width="89px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:CheckBox ID="chkIsActive" runat="server" CssClass="textlevelleft" Width="162px"
                                Text="Mark Inactive" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>
        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Custom,Numbers"
            TargetControlID="txtBasic" ValidChars="0123456789.*">
        </cc1:FilteredTextBoxExtender>
        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom,Numbers"
            TargetControlID="txtMedical" ValidChars="0123456789.*">
        </cc1:FilteredTextBoxExtender>
         <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterType="Custom,Numbers"
            TargetControlID="txtHousing" ValidChars="0123456789.*">
        </cc1:FilteredTextBoxExtender>
         <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" FilterType="Custom,Numbers"
            TargetControlID="txtHOHousing" ValidChars="0123456789.*">
        </cc1:FilteredTextBoxExtender>
         <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" FilterType="Custom,Numbers"
            TargetControlID="txtConveyance" ValidChars="0123456789.*">
        </cc1:FilteredTextBoxExtender>
         <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" FilterType="Custom,Numbers"
            TargetControlID="txtHOConveyance" ValidChars="0123456789.*">
        </cc1:FilteredTextBoxExtender>
        <div class="GridFormat1">
            <asp:GridView ID="grGradeMatrix" runat="server" DataKeyNames="RecId,GradeId,GradeLevelId"
                AutoGenerateColumns="False" EmptyDataText="No Record Found" Font-Size="9px" OnRowCommand="grGradeMatrix_RowCommand"
                Width="99%">
                <HeaderStyle BackColor="#B3CDE4" Font-Bold="True"></HeaderStyle>
                <SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" CssClass="ListHeader" Font-Bold="True">
                </SelectedRowStyle>
                <AlternatingRowStyle BackColor="#EFF3FB"></AlternatingRowStyle>
                <Columns>
                    <asp:ButtonField CommandName="DoubleClick" HeaderText="Edit" Text="Edit">
                        <ItemStyle CssClass="ItemStylecss" Width="10%" />
                    </asp:ButtonField>
                    <asp:BoundField DataField="GradeName" HeaderText="Grade Name">
                        <ItemStyle CssClass="ItemStylecss" Width="10%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="GradeLevelName" HeaderText="Grade Level Name">
                        <ItemStyle CssClass="ItemStylecss" Width="10%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="BasicSal" HeaderText="Basic">
                        <ItemStyle CssClass="ItemStylecss" Width="10%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Housing" HeaderText="Housing">
                        <ItemStyle CssClass="ItemStylecss" Width="10%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="HOHousing" HeaderText="HO Housing">
                        <ItemStyle CssClass="ItemStylecss" Width="10%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Conveyance" HeaderText="Conveyance">
                        <ItemStyle CssClass="ItemStylecss" Width="10%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="HOConveyance" HeaderText="HO Conveyance">
                        <ItemStyle CssClass="ItemStylecss" Width="10%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Medical" HeaderText="Medical">
                        <ItemStyle CssClass="ItemStylecss" Width="10%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="IsActive" HeaderText="Is Active">
                        <ItemStyle CssClass="ItemStylecss" Width="10%"></ItemStyle>
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="DivCommand1">
            <div class="DivCommandL">
                <asp:Button ID="btnClear" runat="server" Text="Refresh" Width="70px" OnClick="btnClear_Click"
                    UseSubmitBehavior="False" CausesValidation="false" />
            </div>
            <div class="DivCommandR">
                <asp:Button ID="btnSave" runat="server" Text="Save" Width="70px" OnClick="btnSave_Click" />
                <asp:Button ID="btnDelete" runat="server" Text="Delete" Width="70px" OnClientClick="javascript:return DeleteConfirmation();"
                    OnClick="btnDelete_Click" />
            </div>
        </div>
    </div>
</asp:Content>
