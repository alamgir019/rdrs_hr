<%@ Page Title="" Language="C#" MasterPageFile="~/MasterBTMS.master" AutoEventWireup="true" CodeFile="FinalPaymentEntry.aspx.cs" Inherits="Payroll_Payroll_FinalPaymentEntry" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

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
            <div style="width: 97%; float: left;">
               Final Payment</div>
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
                    <table>
                        <tr>
                            <td class="textlevel">
                                Emp Id :</td>
                            <td>
                                <asp:TextBox ID="txtEmpID" runat="server" MaxLength="20" onkeyup="ToUpper(this)"
                                    Width="80px" ToolTip="Enter the Emp. Code"></asp:TextBox>
                            </td>
                            <td>
                                <asp:ImageButton ID="imgBtnSearch" runat="server" Height="19px" ImageUrl="~/Images/Search_Icon.jpg"
                                    OnClick="imgBtnSearch_Click" ToolTip="Click on find button to retrieve any existing employee information." />
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
                                Grade :</td>
                            <td>
                                <asp:Label ID="lblGrade" runat="server"></asp:Label>
                            </td>
                        </tr> 
                        <tr>
                            <td class="textlevel">
                                Joining Date :</td>
                            <td>
                                <asp:Label ID="lblJoindate" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="textlevel">
                                Separate Date :</td>
                            <td>
                                <asp:Label ID="lblSeprateDate" runat="server"></asp:Label>
                            </td>
                        </tr> 
                        <tr>
                            <td class="textlevel">
                                Separate Type :</td>
                            <td>
                                <asp:Label ID="lblSeparateType" runat="server"></asp:Label>
                            </td>
                        </tr> 
                                             
                    </table>
                </fieldset>
             </div>

             <fieldset style="margin-bottom: 10px;">
                <legend>Final Payment</legend>
                <table>

                      <tr>
                        <td class="textlevel">
                            Process Date :</td>
                        <td>
                            <asp:TextBox ID="txtProcessDate" runat="server" Width="80px" 
                                ToolTip="Input the from date of temporary duty."></asp:TextBox>
                            <a href="javascript:NewCal('<%= txtProcessDate.ClientID %>','ddmmyyyy')">
                                <img style="border: 0px;" height="16" alt="Pick a date" src="../../images/cal.gif" width="16" /></a>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtProcessDate"
                                CssClass="validator" ErrorMessage="Invalid Date" 
                                ValidationExpression="^(?=\d)(?:(?:31(?!.(?:0?[2469]|11))|(?:30|29)(?!.0?2)|29(?=.0?2.(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00)))(?:\x20|$))|(?:2[0-8]|1\d|0?[1-9]))([-./])(?:1[012]|0?[1-9])\1(?:1[6-9]|[2-9]\d)?\d\d(?:(?=\x20\d)\x20|$))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\x20[AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$"></asp:RegularExpressionValidator></td>
                        <td class="textlevel">
                            Due Date :</td>
                        <td>
                            <asp:TextBox ID="txtDueDate" runat="server" Width="80px" 
                                ToolTip="Input the to date of temporary duty."></asp:TextBox>
                            <a href="javascript:NewCal('<%= txtDueDate.ClientID %>','ddmmyyyy')">
                                <img style="border: 0px;" height="16" alt="Pick a date" src="../../images/cal.gif" width="16" /></a>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtDueDate"
                                CssClass="validator" ErrorMessage="Invalid Date" 
                                ValidationExpression="^(?=\d)(?:(?:31(?!.(?:0?[2469]|11))|(?:30|29)(?!.0?2)|29(?=.0?2.(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00)))(?:\x20|$))|(?:2[0-8]|1\d|0?[1-9]))([-./])(?:1[012]|0?[1-9])\1(?:1[6-9]|[2-9]\d)?\d\d(?:(?=\x20\d)\x20|$))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\x20[AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$"></asp:RegularExpressionValidator></td>
                    </tr>
                    <tr>
                        <td class="textlevel">
                            Payment Amount :</td>
                        <td>
                            <asp:TextBox ID="txtPaymentAmt" runat="server" MaxLength="20" 
                                ToolTip="Enter Payment Amount" Width="80px" CssClass="TextBoxAmt60"></asp:TextBox></td>
                        <td class="textlevel">
                            PF Amount :</td>
                        <td>
                            <asp:TextBox ID="txtPFAmount" runat="server" MaxLength="20" onkeyup="ToUpper(this)"
                                ToolTip="Enter the Emp. Code" Width="80px" CssClass="TextBoxAmt60"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="textlevel">
                            Remarks :</td>
                        <td colspan="3">
                            <asp:TextBox ID="txtRemarks" runat="server" MaxLength="200" onkeyup="ToUpper(this)"
                                ToolTip="Enter Remarks" Width="500px" TextMode="MultiLine" >
                                </asp:TextBox>
                        <td>
                          </td>
                    </tr>
                    
                  <%--  <cc1:FilteredTextBoxExtender ID="FTBPercentage" runat="server" FilterType="Custom,Numbers"
                        TargetControlID="txtPercentage" ValidChars="0123456789">
                    </cc1:FilteredTextBoxExtender>
                    <cc1:FilteredTextBoxExtender ID="FilteredAmount" runat="server" FilterType="Custom,Numbers"
                        TargetControlID="txtAmount" ValidChars="0123456789.">
                    </cc1:FilteredTextBoxExtender>--%>
                </table>

                <asp:HiddenField ID="hfIsUpdate" runat="server" />
                <asp:HiddenField ID="hfId" runat="server" />
            </fieldset>

            <fieldset style="margin-bottom: 10px;">
                <legend>Temporary Duty List</legend>
                <div style="overflow: scroll; width: 100%; height: 150px">
                    <asp:GridView ID="grTempDuty" runat="server" Width="100%" Font-Size="9px" EmptyDataText="No Record Found"
                        AutoGenerateColumns="False" OnRowCommand="grEmpTempDuty_RowCommand" DataKeyNames="DutyAssignID,ActionId,PostingDistId,PostingPlaceId,SectorId,UnitId,DeptId"
                        OnSelectedIndexChanged="grTempDuty_SelectedIndexChanged">
                        <HeaderStyle BackColor="#B3CDE4" Font-Bold="True"></HeaderStyle>
                        <SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" CssClass="ListHeader" Font-Bold="True">
                        </SelectedRowStyle>
                        <AlternatingRowStyle BackColor="#EFF3FB"></AlternatingRowStyle>
                        <Columns>
                            <asp:ButtonField CommandName="DoubleClick">
                                <ItemStyle Width="1%" CssClass="ItemStylecss" />
                            </asp:ButtonField>
                            <asp:BoundField DataField="ActionName" HeaderText="Name of Action">
                                <ItemStyle CssClass="ItemStylecss" Width="10%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="PostingDistName" HeaderText="District">
                                <ItemStyle CssClass="ItemStylecss" Width="10%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="PostingPlaceName" HeaderText="Location">
                                <ItemStyle CssClass="ItemStylecss" Width="10%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="SectorName" HeaderText="Sector">
                                <ItemStyle CssClass="ItemStylecss" Width="10%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="UnitName" HeaderText="Unit">
                                <ItemStyle CssClass="ItemStylecss" Width="10%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="DeptName" HeaderText="Department">
                                <ItemStyle CssClass="ItemStylecss" Width="10%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="StartDate" HeaderText="Start Date">
                                <ItemStyle CssClass="ItemStylecss" Width="5%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="EndDate" HeaderText="End Date">
                                <ItemStyle CssClass="ItemStylecss" Width="5%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Amount" HeaderText="Amount">
                                <ItemStyle CssClass="ItemStylecssCenter" Width="5%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Percentage" HeaderText="Percentage">
                                <ItemStyle CssClass="ItemStylecssCenter" Width="5%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="SupervisorId" HeaderText="Supervisor Id">
                                <ItemStyle CssClass="ItemStylecss" Width="10%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="SupervisorComment" HeaderText="Supervisor Comments">
                                <ItemStyle CssClass="ItemStylecss" Width="10%"></ItemStyle>
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </div>
            </fieldset>
            </div>
            <div class="DivCommand1" style="width: 98%;">
            <div class="DivCommandL">
                <asp:Button ID="btnRefresh" runat="server" CausesValidation="False" Text="Refresh"
                    Width="70px" OnClick="btnRefresh_Click"
                    ToolTip="Click this button to clear all fields." />
            </div>
            <div class="DivCommandR">

                <asp:Button ID="btnSave" runat="server" Text="Save" Width="70px" 
                       OnClick="btnSave_Click"
                     ToolTip="Click this button to store the information after providing all necessary fields." />
            </div>
            
        </div>

      </div>
    <br />
    <br />
</asp:Content>

