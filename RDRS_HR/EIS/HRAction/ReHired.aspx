<%@ Page Language="C#" MasterPageFile="~/MasterBTMS.master" AutoEventWireup="true"
    CodeFile="ReHired.aspx.cs" Inherits="EIS_ReHired" Title="Re-Hired" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%@ register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
    <%-- <script src="../JScripts/jquery-1.4.2.min.js" type="text/javascript"></script>
  <script type="text/javascript" src="../JScripts/ui.datepicker.js"></script>--%>
    <script language="javascript" type="text/javascript" src="../../JScripts/datetimepicker.js">
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
            <div style="width: 94%; float: left;">
                Re-Hired</div>
            <div style="margin: 2px; float: left; padding-right: 3px;">
                <a href="../../Default.aspx">
                    <img src="../../Images/close_icon.gif" /></a></div>
        </div>
        <div class="MsgBox">
            <asp:Label ID="lblMsg" runat="server" CssClass="msglabel"></asp:Label>
        </div>
        <div id="PayrollConfigInner">
            <div style="background-color: #EFF3FB; margin-bottom: 10px;">
                <fieldset>
                    <legend>Re-Hired </legend>
                    <table>
                        <tr>
                            <td class="textlevel">
                                Emp Code :
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmpID" runat="server" MaxLength="20" onkeyup="ToUpper(this)"
                                    Width="80px" ToolTip="Type an Emp code and press ‘Enter’ or click on Find Image."></asp:TextBox>
                            </td>
                            <td>
                                <asp:ImageButton ID="imgBtnSearch" runat="server" Height="19px" ImageUrl="~/Images/Search_Icon.jpg"
                                    OnClick="imgBtnSearch_Click" CausesValidation="False" ToolTip="Find Image" />
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="ReqFieldVal" runat="server" ErrorMessage="*" ControlToValidate="txtEmpID"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td class="textlevel">
                                Name :
                            </td>
                            <td>
                                <asp:Label ID="lblName" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="textlevel">
                                Designation :</td>
                            <td>
                                <asp:Label ID="lblDesignation" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="textlevel">
                                Sector :</td>
                            <td>
                                <asp:Label ID="lblSector" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="textlevel">
                                Department :</td>
                            <td>
                                <asp:Label ID="lblDept" runat="server"></asp:Label>
                            </td>
                        </tr>
                         <tr>
                            <td class="textlevel">
                                Seperate Date :</td>
                            <td>
                                <asp:Label ID="lblSeperateddate" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </div>
            <fieldset style="margin-bottom: 10px;">
                <legend>Re-Hired Details</legend>
                <table width="98%">
                    <tr>
                        <td class="textlevel">
                            Pay Emp Code :
                        </td>
                        <td>
                            <asp:TextBox ID="txtPayEmpId" runat="server" MaxLength="20" onkeyup="ToUpper(this)"
                                ToolTip="Type an Emp code and press ‘Enter’ or click on Find Image." Width="80px"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td class="textlevel">
                            Name of Action :
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlAction" runat="server" ToolTip="Select an ‘Action’ from this list box. You have to select an Action for storing records. ">
                            </asp:DropDownList>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td class="textlevel">
                            Effective Date :
                        </td>
                        <td>
                            <asp:TextBox ID="txtEffDate" runat="server" Width="25%" ToolTip="Select a date by clicking on the calendar image or type a date in this order ‘dd/mm/yyyy’. You must put a valid dalid date for storing record."></asp:TextBox>
                            <a href="javascript:NewCal('<%= txtEffDate.ClientID %>','ddmmyyyy')">
                                <img style="border: 0px;" height="16" alt="Pick a date" src="../../images/cal.gif" width="16" /></a>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtEffDate"
                                CssClass="validator" ErrorMessage="Invalid Date" ValidationExpression="^(?=\d)(?:(?:31(?!.(?:0?[2469]|11))|(?:30|29)(?!.0?2)|29(?=.0?2.(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00)))(?:\x20|$))|(?:2[0-8]|1\d|0?[1-9]))([-./])(?:1[012]|0?[1-9])\1(?:1[6-9]|[2-9]\d)?\d\d(?:(?=\x20\d)\x20|$))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\x20[AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$"></asp:RegularExpressionValidator><asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtEffDate"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
                <asp:HiddenField ID="hfIsUpdate" runat="server" />
                <asp:HiddenField ID="hfReHiredId" runat="server" />
                &nbsp;
            </fieldset>
            <fieldset>
                <legend>Re-Hired List</legend>
                <div style="overflow: scroll; width: 98%; height: 250px">
                    <asp:GridView ID="grReHired" runat="server" Width="97%" Font-Size="9px" EmptyDataText="No Record Found"
                        AutoGenerateColumns="False" DataKeyNames="ReHiredId,ActionId" OnRowCommand="grReHired_RowCommand"
                        ToolTip="Re-Hired List">
                        <HeaderStyle BackColor="#B3CDE4" Font-Bold="True"></HeaderStyle>
                        <SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" CssClass="ListHeader" Font-Bold="True">
                        </SelectedRowStyle>
                        <AlternatingRowStyle BackColor="#EFF3FB"></AlternatingRowStyle>
                        <Columns>
                            <asp:ButtonField CommandName="DoubleClick" HeaderText="Edit" Text="Edit">
                                <ItemStyle Width="5%" CssClass="ItemStylecss" />
                            </asp:ButtonField>
                            <asp:BoundField DataField="PayEmpId" HeaderText="Pay Emp Code">
                                <ItemStyle CssClass="ItemStylecss" Width="20%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="ActionName" HeaderText="Action Name">
                                <ItemStyle CssClass="ItemStylecss" Width="40%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="EffectiveDate" HeaderText="Effective Date">
                                <ItemStyle CssClass="ItemStylecss" Width="30%"></ItemStyle>
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </div>
            </fieldset>
        </div>
        <div class="DivCommand1">
            <div class="DivCommandL">
                <asp:Button ID="btnRefresh" runat="server" CausesValidation="False" Text="Refresh"
                    Width="70px" OnClick="btnRefresh_Click" ToolTip="To set the page as initial stage or set fields blank, click on Refresh button." />
            </div>
            <div class="DivCommandR">
                <asp:Button ID="btnSave" runat="server" Text="Save" UseSubmitBehavior="True" OnClientClick="javascript:return HistorySaveConfirmation();"
                    Width="70px" OnClick="btnSave_Click" ToolTip="Click on this button to store/update above informations" />
            </div>
        </div>
    </div>
</asp:Content>
