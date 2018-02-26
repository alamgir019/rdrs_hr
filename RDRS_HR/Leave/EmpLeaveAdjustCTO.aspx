<%@ Page Language="C#" MasterPageFile="~/MasterBTMS.master" AutoEventWireup="true"
    CodeFile="EmpLeaveAdjustCTO.aspx.cs" Inherits="EmpLeaveAdjustCTO" Title="Employee CTO Leave Adjust" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript" src="../JScripts/datetimepicker.js"></script>
    <script type="text/javascript" language="javascript">
        function ToUpper(ctrl) {
            var t = ctrl.value;
            ctrl.value = t.toUpperCase();
        }
    </script>
    <script language="javascript" type="text/javascript" src="../JScripts/Confirmation.js"></script>
    
    <div class="EmpMainDivStyle" style="text-align: left;">
        <div id='formhead4'>Leave Balance Entry For CTO</div>
        <div class="MsgBox">
            <asp:Label ID="lblMsg" runat="server" ForeColor="Navy" Font-Bold="True" CssClass="lblMsg"></asp:Label>
            &nbsp;
        </div>
        <table style="text-align: left; width: 100%">
            <tr style="border: solid 1px red;">
                <td style="width: 99%;">
                    <div class="Div950">
                        <fieldset>
                            <legend>CTO Balance Entry</legend>
                            <table>
                                <tbody>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text="Employee ID : " CssClass="textlevel"
                                                Width="80px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtEmpId" onkeyup="ToUpper(this)" Width="80px" runat="server" Height="16px"> </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" ></asp:Button>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Text="Name : " CssClass="textlevel" Width="80px"></asp:Label>
                                        </td>
                                        <td colspan="2">
                                            <asp:Label ID="lblName" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="color: #f00" colspan="3">
                                            <asp:Label ID="lblMsg2" runat="server" CssClass="lblMsg" Width="100%"></asp:Label>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <fieldset>
                                <legend>CTO Entry</legend>
                                <table id="tblCTOEntry">
                                    <tr>
                                        <td class="textlevelleft" style="height: 16px">Leave Type</td>
                                        <td class="textlevelleft" style="height: 16px; width: 61px;">Entitled</td>
                                        <td class="textlevelleft" style="height: 16px; width: 100px;">Entitlement Date</td>
                                        <td></td>
                                        <td class="textlevelleft" style="height: 16px; width: 96px;">Expire Date</td>
                                        <td></td>
                                        <td class="textlevelleft" style="height: 16px; width: 114px;">Year</td>
                                        <td class="textlevelleft">Remarks</td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlLType" runat="server" Width="150px">
                                            </asp:DropDownList></td>
                                        <td style="width: 61px">
                                            <asp:TextBox ID="txtEntitle" runat="server" CssClass="TextBoxAmt60" MaxLength="4"></asp:TextBox>
                                        </td>
                                        <td class="textlevelleft" style="width: 107px">
                                            <asp:TextBox ID="txtStartDate" runat="server" MaxLength="10" Width="70px" OnTextChanged="txtStartDate_TextChanged"></asp:TextBox>
                                            <a href="javascript:NewCal('<%= txtStartDate.ClientID %>','ddmmyyyy')">
                                                <img alt="Pick a date" height="16" src="../images/cal.gif" style="border-right: 0px;
                                                    border-top: 0px; border-left: 0px; border-bottom: 0px" width="16" /></a>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtStartDate"
                                                        ErrorMessage="*" Font-Bold="True"></asp:RequiredFieldValidator>
                                        </td>                                        
                                        <td style="width: 3px">
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtStartDate"
                                                CssClass="validator" ErrorMessage="*" ValidationExpression="^(?=\d)(?:(?:31(?!.(?:0?[2469]|11))|(?:30|29)(?!.0?2)|29(?=.0?2.(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00)))(?:\x20|$))|(?:2[0-8]|1\d|0?[1-9]))([-./])(?:1[012]|0?[1-9])\1(?:1[6-9]|[2-9]\d)?\d\d(?:(?=\x20\d)\x20|$))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\x20[AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$"
                                                Width="3px"></asp:RegularExpressionValidator>
                                        </td>
                                        <td class="textlevelleft" style="width: 70px">
                                            <asp:TextBox ID="txtEndDate" runat="server" MaxLength="10" Width="70px"></asp:TextBox>                                         
                                           </td>                                                                                
                                        <td style="width: 3px">
                                        </td>
                                        <td class="textlevelRight" style="width: 80px">
                                            <asp:DropDownList ID="ddlYear" runat="server" Width="80px">
                                            </asp:DropDownList></td>
                                        <td>
                                            <asp:TextBox ID="txtRemarks" runat="server" CssClass="TextBoxAmt60" Height="36px"></asp:TextBox>
                                        </td>
                                        <td style="width: 82px">
                                            <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" Text="Save" Width="80px" />
                                        </td>
                                    </tr>
                                </table>
                                <div class="divWithGridFrame">
                                    <asp:GridView ID="grCTOLeaveHistory" runat="server" Width="100%" PageSize="7" EmptyDataText="No Record Found"
                                        DataKeyNames="LogId,LTypeID" AutoGenerateColumns="False" Font-Size="9px"
                                        OnRowCommand="grCTOLeaveHistory_RowCommand" >
                                        <Columns>
                                            <asp:ButtonField CommandName="DoubleClick" HeaderText="Edit" Text="Edit" CausesValidation="true">
                                                <ItemStyle CssClass="ItemStylecss" Width="5%" />
                                            </asp:ButtonField>
                                            <asp:BoundField DataField="LTypeTitle" HeaderText="Leave Title">
                                                <ItemStyle Width="20%" CssClass="ItemStylecss"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="LEntitled" HeaderText="Leave Entitled">
                                                <ItemStyle Width="5%" CssClass="ItemStylecssRight" HorizontalAlign="Right"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="StartDate" HeaderText="Entitlement Date">
                                                <ItemStyle Width="20%" CssClass="ItemStylecss" HorizontalAlign="Right"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="EndDate" HeaderText="Expire Date">
                                                <ItemStyle Width="20%" CssClass="ItemStylecss" HorizontalAlign="Right"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="LYear" HeaderText="Entitled Year">
                                                <ItemStyle Width="10%" CssClass="ItemStylecss" HorizontalAlign="Center"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Remarks" HeaderText="Remarks">
                                                <ItemStyle Width="20%" CssClass="ItemStylecss" HorizontalAlign="Center"></ItemStyle>
                                            </asp:BoundField>
                                        </Columns>
                                        <HeaderStyle BackColor="#3366CC" ForeColor="WhiteSmoke" HorizontalAlign="Center"
                                            Font-Size="10px" Font-Bold="True"></HeaderStyle>
                                        <AlternatingRowStyle BackColor="#EFF3FB"></AlternatingRowStyle>
                                    </asp:GridView>
                                </div>
                                
                    <asp:HiddenField ID="hfIsUpdate" runat="server" />
                    <asp:HiddenField ID="hfID" runat="server" />
                    <asp:HiddenField ID="hfPrevsValue" runat="server" />
                            </fieldset>
                        </fieldset>
                        <div class="DivCommand1" style="padding-left: 15px; padding-top: 3px; float: left;">
                            <asp:Button ID="btnClear" runat="server" Text="Refresh" Width="70px"
                                UseSubmitBehavior="False" />
                        </div>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
