<%@ Page Language="C#" MasterPageFile="~/MasterBTMS.master" AutoEventWireup="true"
    CodeFile="SOFEntry.aspx.cs" Inherits="SOF_SOFEntry" Title="SOF Entry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../../../JScripts/datetimepicker.js">
        //Date Time Picker script
    </script>
    <script language="javascript" type="text/javascript" src="../../JScripts/Confirmation.js">
    </script>
    <script language="javascript" type="text/javascript">
        function ToUpper(ctrl) {
            var t = ctrl.value;
            ctrl.value = t.toUpperCase();
        }
    </script>
    <div class="empTrainForm" style="height: 750px">
        <div id="formhead2">
            <div style="width: 97%; float: left;">
                Salary Source Entry</div>
            <div style="margin: 2px; float: left; padding-right: 3px;">
                <a href="../../Default.aspx">
                    <img src="../Images/close_icon.gif" /></a></div>
        </div>
        <div class="MsgBox">
            <asp:Label ID="lblMsg" runat="server" CssClass="msglabel"></asp:Label>
        </div>
        <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" Width="100%"
            Height="660px">
            <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel1" Width="100%">
                <HeaderTemplate>
                    Salary Source Entry
                </HeaderTemplate>
                <ContentTemplate>
                    <div id="PayrollConfigInner" style="height: 350px">
                        <fieldset>
                            <table>
                                <tr>
                                    <td class="textlevel">
                                        Source Type :
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="radGrant" runat="server" GroupName="Type" Text="Grant" class="textlevel" />
                                        <asp:RadioButton ID="radSponsorship" runat="server" GroupName="Type" class="textlevel"
                                            Text="Sponsorship" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="textlevel">
                                        Salary Source Name :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSalarySourceName" runat="server" MaxLength="20" Width="200px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="textlevel">
                                        Salary Source Code :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSalarySourceCode" runat="server" MaxLength="20" Width="200px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="textlevel">
                                        Project (T2) For T3 :
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlProject" runat="server" CssClass="textlevelleft" ToolTip="Select an Action from this list. You have to select an Action for storing records. "
                                            Width="205px" AutoPostBack="True" OnSelectedIndexChanged="ddlProject_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="textlevel">
                                        Source of Fund (T3) :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSalarySource" runat="server" MaxLength="20" Width="200px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td class="textlevelright">
                                        <asp:CheckBox ID="chkInActive" runat="server" CssClass="textlevelleft" Text="Mark Inactive" />
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                        <div style="margin: 5px 5px 10px 2px; width: 99%; height: 50%;">
                            <div style="width: 49%; height: 50%; float: left;">
                                <fieldset style="margin-bottom: 10px;">
                                    <legend>Salary DEA</legend>
                                    <table>
                                        <tr>
                                            <td class="textlevel">
                                                Salary :
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtSalary" runat="server" CssClass="TextBoxAmt60" OnTextChanged="txtSalary_TextChanged"></asp:TextBox>
                                                <asp:Button ID="btnSalaryCopy" runat="server" CausesValidation="False" Text="Copy"
                                                    Width="70px" OnClick="btnSalaryCopy_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="textlevel">
                                                Bonus :
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtBonus" runat="server" CssClass="TextBoxAmt60"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="textlevel">
                                                PF Contribution(Employee) :
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtPF" runat="server" CssClass="TextBoxAmt60"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="textlevel">
                                                Income Tax Cost Centre :
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtIT" runat="server" CssClass="TextBoxAmt60"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="textlevel">
                                                PF Loan :
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtPFLoan" runat="server" CssClass="TextBoxAmt60"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                    &nbsp;
                                </fieldset>
                            </div>
                            <div style="width: 49%; height: 50%; float: left; margin-left: 10px;">
                                <fieldset>
                                    <legend>Fringe Benefit DEA</legend>
                                    <table>
                                        <tr>
                                            <td class="textlevel">
                                                PF Contribution (Company) :
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtFringePF" runat="server" CssClass="TextBoxAmt60" OnTextChanged="txtFringePF_TextChanged"></asp:TextBox>
                                                <asp:Button ID="btnFringeCopy" runat="server" CausesValidation="False" Text="Copy"
                                                    Width="70px" OnClick="btnFringeCopy_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="textlevel">
                                                Medical :
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMedical" runat="server" CssClass="TextBoxAmt60"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="textlevel">
                                                Gratuity :
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtGratuity" runat="server" CssClass="TextBoxAmt60"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </fieldset>
                            </div>
                            <asp:HiddenField ID="hfID" runat="server" />
                            <asp:HiddenField ID="hfIsUpdate" runat="server" />
                        </div>
                        <div class="DivCommand1" style="width: 99%;">
                            <fieldset>
                                <div class="DivCommandL">
                                    <asp:Button ID="btnRefresh" runat="server" CausesValidation="False" Text="Refresh"
                                        Width="70px" OnClick="btnRefresh_Click" />
                                </div>
                                <div class="DivCommandR">
                                    <asp:Button ID="btnSave" runat="server" Text="Save" Width="70px" OnClick="btnSave_Click"
                                        ToolTip="Click on Save Button to store the employee data." />
                                </div>
                            </fieldset>
                        </div>
                        <div style="float: left; margin-top: 10px; width: 99%;">
                            <fieldset>
                                <legend>Salary Source List</legend>
                                <div style="overflow: scroll; width: 100%; height: 250px">
                                    <asp:GridView ID="grList" runat="server" Width="100%" Font-Size="9px" EmptyDataText="No Record Found"
                                        AutoGenerateColumns="False" DataKeyNames="SalarySourceId" OnRowCommand="grList_RowCommand">
                                        <HeaderStyle BackColor="#B3CDE4" Font-Bold="True"></HeaderStyle>
                                        <SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" CssClass="ListHeader" Font-Bold="True">
                                        </SelectedRowStyle>
                                        <AlternatingRowStyle BackColor="#EFF3FB"></AlternatingRowStyle>
                                        <Columns>
                                            <asp:ButtonField CommandName="DoubleClick" HeaderText="Edit" Text="Edit">
                                                <ItemStyle Width="5%" CssClass="ItemStylecss" />
                                            </asp:ButtonField>
                                            <asp:BoundField DataField="SourceType" HeaderText="Source Type">
                                                <ItemStyle CssClass="ItemStylecss" Width="10%"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SalSourceName" HeaderText="Salary Source Name">
                                                <ItemStyle CssClass="ItemStylecss" Width="10%"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SalSourceCode" HeaderText="Salary Source Code">
                                                <ItemStyle CssClass="ItemStylecss" Width="10%"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ProjectCode" HeaderText="Project Code">
                                                <ItemStyle CssClass="ItemStylecss" Width="10%"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Salary" HeaderText="Salary">
                                                <ItemStyle CssClass="ItemStylecss" Width="5%"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Bonus" HeaderText="Bonus">
                                                <ItemStyle CssClass="ItemStylecss" Width="5%"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="PF" HeaderText="PF">
                                                <ItemStyle CssClass="ItemStylecss" Width="5%"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="IT" HeaderText="IT">
                                                <ItemStyle CssClass="ItemStylecss" Width="5%"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="PFLoan" HeaderText="PF Loan">
                                                <ItemStyle CssClass="ItemStylecss" Width="5%"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="FringePF" HeaderText="Fringe PF">
                                                <ItemStyle CssClass="ItemStylecss" Width="5%"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Medical" HeaderText="Medical">
                                                <ItemStyle CssClass="ItemStylecss" Width="5%"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Gratuity" HeaderText="Gratuity">
                                                <ItemStyle CssClass="ItemStylecss" Width="5%"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="IsActive" HeaderText="IsActive">
                                                <ItemStyle CssClass="ItemStylecss" Width="10%"></ItemStyle>
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </fieldset>
                        </div>
                    </div>
                </ContentTemplate>
            </cc1:TabPanel>
            <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1" Width="100%">
                <HeaderTemplate>
                    Salary Source Upload
                </HeaderTemplate>
                <ContentTemplate>
                    <fieldset>
                        <table>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                </td>
                                <td>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                    <div style="width: 100%; height: 580px; overflow: scroll;">
                        <asp:GridView ID="grUpload" runat="server" Width="97%" EmptyDataText="No record found">
                            <HeaderStyle BackColor="#B3CDE4" Font-Bold="True" />
                            <SelectedRowStyle BackColor="#D1DDF1" CssClass="ListHeader" Font-Bold="True" ForeColor="#333333" />
                            <AlternatingRowStyle BackColor="#EFF3FB" />
                        </asp:GridView>
                    </div>
                    <div class="DivCommandR">
                        <asp:Button ID="btnSaveBatch" runat="server" Text="Save Batch" OnClick="btnSaveBatch_Click" />
                    </div>
                </ContentTemplate>
            </cc1:TabPanel>
        </cc1:TabContainer>
    </div>
</asp:Content>
