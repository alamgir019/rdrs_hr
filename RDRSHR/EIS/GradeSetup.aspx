<%@ Page Language="C#" MasterPageFile="~/MasterBTMS.master" AutoEventWireup="true"
    CodeFile="GradeSetup.aspx.cs" Inherits="GradeSetup" Title="Grade" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../JScripts/Confirmation.js">
    </script>
    <div class="setup">
        <div id='formhead1'>
            <div style="width: 96%; float: left;">
                Grade Setup</div>
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
                <asp:HiddenField ID="hfIsUpadate" runat="server" />
                <asp:HiddenField ID="hfID" runat="server" />
                <table>
                    <tr>
                        <td class="textlevel">
                            Grade Name :
                        </td>
                        <td>
                            <asp:TextBox ID="txtGrade" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtGrade"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="textlevel">
                            Grade Type :</td>
                        <td>
                            <asp:DropDownList ID="ddlGradeType" runat="server" CssClass="textlevelleft"
                                Width="100px">
                                <asp:ListItem Value="S">Senior Level</asp:ListItem>
                                <asp:ListItem Value="M">Mid Level</asp:ListItem>
                                <asp:ListItem Value="J">Junior Level</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:CheckBox ID="chkIsActive" runat="server" CssClass="textlevelleft" Width="162px"
                                Text="Mark Inactive" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtBasicMax" runat="server" 
                                ToolTip="Input this grade level’s Basic maximum salary amount." 
                                Visible="False" Width="5px"></asp:TextBox>
                            <asp:TextBox ID="txtBasicMin" runat="server" 
                                ToolTip="Input this grade level’s Basic minimum salary amount." 
                                Visible="False" Width="5px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
              
            </fieldset>
        </div>
        <%--<cc1:filteredtextboxextender ID="FTB1" runat="server" FilterType="Custom,Numbers"
            TargetControlID="txtBasicMin" ValidChars="0123456789.">
        </cc1:filteredtextboxextender>
        <cc1:filteredtextboxextender ID="FTB2" runat="server" FilterType="Custom,Numbers"
            TargetControlID="txtBasicMax" ValidChars="0123456789.">
        </cc1:filteredtextboxextender>--%>
        <div class="GridFormat1">
             <asp:GridView ID="grGrade" runat="server" DataKeyNames="GradeID,IsActive" AutoGenerateColumns="False"
                EmptyDataText="No Record Found" Font-Size="9px" OnRowCommand="grGrade_RowCommand"
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
                        <ItemStyle CssClass="ItemStylecss" Width="40%"></ItemStyle>
                    </asp:BoundField>
                     <asp:BoundField DataField="GradeType" HeaderText="Grade Type">
                        <ItemStyle CssClass="ItemStylecss" Width="20%"></ItemStyle>
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
