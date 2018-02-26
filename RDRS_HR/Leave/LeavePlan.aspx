<%@ Page Title="" Language="C#" MasterPageFile="~/MasterBTMS.master" AutoEventWireup="true" CodeFile="LeavePlan.aspx.cs" Inherits="Leave_LeavePlan" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../JScripts/Confirmation.js"></script>
    <script language="javascript" type="text/javascript" src="../JScripts/datetimepicker.js"></script>
    
    <div class="EmpMainDivStyle" style="text-align: left;">
        <div id='formhead4'>Employee Leave Plan</div>
        <div class="MsgBox">
            <asp:Label ID="lblMsg" runat="server" ForeColor="Navy" Font-Bold="True" CssClass="lblMsg"></asp:Label>
            &nbsp;
        </div>
        
        <div class="FormInner2">
            <fieldset>
                <asp:HiddenField ID="hfID" runat="server"></asp:HiddenField>
                <asp:HiddenField ID="hfIsUpdate" runat="server"></asp:HiddenField>
                <table>
                    <tr>
                        <td> 
                            <asp:Label ID="Label2" runat="server" Width="100px" CssClass="textlevel" Text="Employee Id :"></asp:Label>
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="txtEmpId" runat="server" Width="100px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmpId"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                     <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Width="100px" CssClass="textlevel" Text="Leave Type :"></asp:Label>
                        </td>
                        <td colspan="3">
                            <asp:DropDownList ID="ddlLeaveType" runat="server"></asp:DropDownList>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlLeaveType"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server"  Width="100px" CssClass="textlevel" Text="Start Date :"></asp:Label>
                        </td>
                        <td colspan="3" style="padding-left:0px;">
                            <table style="padding-left:0px;">
                                <tr>
                                    <td style="padding-left:0px;"><asp:TextBox ID="txtStartDate" runat="server" Width="90px"></asp:TextBox>
                                        <a href="javascript:NewCal('<%= txtStartDate.ClientID %>','ddmmyyyy')">
                                            <img style="border-right: 0px; border-top: 0px; border-left: 0px; border-bottom: 0px"
                                                height="16" alt="Pick a date" src="../images/cal.gif" width="16" /></a><asp:RequiredFieldValidator 
                                            ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtStartDate"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                        &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtStartDate"
                                            CssClass="validator" ErrorMessage="Invalid" ValidationExpression="^(?=\d)(?:(?:31(?!.(?:0?[2469]|11))|(?:30|29)(?!.0?2)|29(?=.0?2.(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00)))(?:\x20|$))|(?:2[0-8]|1\d|0?[1-9]))([-./])(?:1[012]|0?[1-9])\1(?:1[6-9]|[2-9]\d)?\d\d(?:(?=\x20\d)\x20|$))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\x20[AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$"></asp:RegularExpressionValidator>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:Label ID="Label9" runat="server" Width="55px" CssClass="textlevel" Text="End Date :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtEndDate" runat="server" Width="90px">
                                        </asp:TextBox>
                                        <a href="javascript:NewCal('<%= txtEndDate.ClientID %>','ddmmyyyy')">
                                            <img style="border-right: 0px; border-top: 0px; border-left: 0px; border-bottom: 0px"
                                                height="16" alt="Pick a date" src="../images/cal.gif" width="16" /></a><asp:RequiredFieldValidator 
                                            ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtEndDate"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                        &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtEndDate"
                                            CssClass="validator" ErrorMessage="Invalid" ValidationExpression="^(?=\d)(?:(?:31(?!.(?:0?[2469]|11))|(?:30|29)(?!.0?2)|29(?=.0?2.(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00)))(?:\x20|$))|(?:2[0-8]|1\d|0?[1-9]))([-./])(?:1[012]|0?[1-9])\1(?:1[6-9]|[2-9]\d)?\d\d(?:(?=\x20\d)\x20|$))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\x20[AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$"></asp:RegularExpressionValidator>
                                        &nbsp;
                                    </td>
                                </tr>
                             </table> 
                        </td>
                     </tr>                     
                      <tr>
                        <td style="text-align:right; vertical-align:top;">
                            <asp:Label ID="Label10" runat="server" Width="100px" CssClass="textlevel" Text="Remarks :"></asp:Label>
                        </td>
                          <td colspan="3">
                              <asp:TextBox ID="txtRemarks" runat="server" Width="250px"></asp:TextBox>
                          </td>
                      </tr>                      
                     <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:CheckBox ID="ChkIsActive" Text="Make Inactive" CssClass="textlevelleft" runat="server" />
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>                         
                </table>
            </fieldset>            
            <div class="GridFormat1">
                <fieldset>
                    <table>
                        <tr>
                            <td class="textlevel">
                                Employee Id
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmployeeId" runat="server" Width="200px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="btnSearch" runat="server" Text="Search" Width="70px" UseSubmitBehavior="False"
                                    OnClick="btnSearch_Click" CausesValidation="False" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
                <!--Grid view Code starts-->
                <asp:GridView ID="grLeavePlan" runat="server"  OnRowCommand="grLeavePlan_RowCommand" OnSelectedIndexChanged="grLeavePlan_SelectedIndexChanged"
                DataKeyNames="ID ,EmpId,LTypeId,LTypeName,StartDate,EndDate,Remarks,IsActive"
                    AutoGenerateColumns="False" EmptyDataText="No Record Found" Font-Size="9px" Width="100%">
                    <HeaderStyle BackColor="#B3CDE4" Font-Bold="True"></HeaderStyle>
                    <SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" CssClass="ListHeader" Font-Bold="True">
                    </SelectedRowStyle>
                    <AlternatingRowStyle BackColor="#EFF3FB"></AlternatingRowStyle>
                    <Columns>
                        <asp:ButtonField CommandName="DoubleClick" HeaderText="Edit" Text="Edit">
                            <ItemStyle CssClass="ItemStylecss" Width="8%" />
                        </asp:ButtonField>
                        <asp:BoundField DataField="EmpId" HeaderText="Employee Id">
                            <ItemStyle CssClass="ItemStylecss" Width="10%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="LTypeName" HeaderText="Leave Type">
                            <ItemStyle CssClass="ItemStylecss" Width="15%"></ItemStyle>
                        </asp:BoundField>

                        <asp:BoundField DataField="StartDate" HeaderText="Start Date" DataFormatString="{0:dd/MM/yyyy}">
                            <ItemStyle CssClass="ItemStylecss" Width="15%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="EndDate" HeaderText="End Date" DataFormatString="{0:dd/MM/yyyy}">
                            <ItemStyle CssClass="ItemStylecss" Width="15%"></ItemStyle>
                        </asp:BoundField>                        
                        <asp:BoundField DataField="Remarks" HeaderText="Remarks">
                            <ItemStyle CssClass="ItemStylecss" Width="20%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="IsActive" HeaderText="Is Active">
                            <ItemStyle CssClass="ItemStylecss" Width="8%"></ItemStyle>
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
                <!--Grid view Code Ends-->
            </div>
            <div id="DivCommand1" style="padding-top: 3px;">
                <div style="text-align: left; float: left">
                    <asp:Button ID="btnRefresh" runat="server" Text="Refresh" Width="70px" CausesValidation="False"/>
                </div>
                <div style="text-align: right;">
                    <asp:Button ID="btnSave" runat="server" Text="Save" Width="70px" OnClick="btnSave_Click" UseSubmitBehavior="False"/>
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" Width="70px" OnClientClick="javascript:return DeleteConfirmation();"/>
                </div>
            </div>
        </div>
    </div>
</asp:Content>