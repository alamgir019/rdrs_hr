<%@ Page Language="C#" MasterPageFile="~/MasterBTMS.master" AutoEventWireup="true"
    CodeFile="DonerSetup.aspx.cs" Inherits="SOF_DonerSetup" Title="Doner Setup" %>

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
    <div class="empTrainForm">
        <div id="formhead1">
            <div style="width: 97%; float: left;">
                Doner Setup</div>
            <div style="margin: 2px; float: left; padding-right: 3px;">
                <a href="../../Default.aspx">
                    <img src="../Images/close_icon.gif" /></a></div>
        </div>
        <div class="MsgBox">
            <asp:Label ID="lblMsg" runat="server" CssClass="msglabel"></asp:Label>
        </div>
        <div id="officeSetupInner">
            <fieldset>
                <table>
                    <tr>
                        <td class="textlevel">
                            Doner Name :
                        </td>
                        <td>
                            <asp:TextBox ID="txtName" runat="server" MaxLength="20" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="textlevel">
                            Doner Code :
                        </td>
                        <td>
                            <asp:TextBox ID="txtCode" runat="server" MaxLength="20" Width="200px"></asp:TextBox>
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
            <asp:HiddenField ID="hfID" runat="server" />
            <asp:HiddenField ID="hfIsUpdate" runat="server" />
            
            <div style="float: left; margin-top: 10px; width: 99%;">
                <fieldset>
                    <legend>Salary Source List</legend>
                    <div style="overflow: scroll; width: 100%; height: 250px">
                        <asp:GridView ID="grList" runat="server" Width="100%" Font-Size="9px" EmptyDataText="No Record Found"
                            AutoGenerateColumns="False" DataKeyNames="DonerId,DonerName,DonerCode,IsActive" OnRowCommand="grList_RowCommand">
                            <HeaderStyle BackColor="#B3CDE4" Font-Bold="True"></HeaderStyle>
                            <SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" CssClass="ListHeader" Font-Bold="True">
                            </SelectedRowStyle>
                            <AlternatingRowStyle BackColor="#EFF3FB"></AlternatingRowStyle>
                            <Columns>
                                <asp:ButtonField CommandName="DoubleClick" HeaderText="Edit" Text="Edit">
                                    <ItemStyle Width="5%" CssClass="ItemStylecss" />
                                </asp:ButtonField>
                                <asp:BoundField DataField="DonerName" HeaderText="Doner Name">
                                    <ItemStyle CssClass="ItemStylecss" Width="10%"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="DonerCode" HeaderText="Doner Code">
                                    <ItemStyle CssClass="ItemStylecss" Width="10%"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="IsActive" HeaderText="IsActive">
                                    <ItemStyle CssClass="ItemStylecss" Width="10%"></ItemStyle>
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </fieldset>
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
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" Width="70px" OnClientClick="javascript:return DeleteConfirmation();"
                                OnClick="btnDelete_Click" />
                    </div>
                </fieldset>
            </div>
        </div>
    </div>
</asp:Content>
