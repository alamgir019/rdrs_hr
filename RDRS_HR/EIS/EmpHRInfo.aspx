<%@ Page Language="C#" MasterPageFile="~/MasterBTMS.master" AutoEventWireup="true"
    CodeFile="EmpHRInfo.aspx.cs" Inherits="EIS_EmpHRInfo" Title="Employee HR Information" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../JScripts/jquery-1.2.3.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../JScripts/ui.datepicker.js"></script>
    <script language="javascript" type="text/javascript" src="../JScripts/datetimepicker.js">
        //Date Time Picker script
    </script>
    <script language="javascript" type="text/javascript" src="../JScripts/Confirmation.js">
        //Delete Confirmation Message
    </script>
    <script language="javascript" type="text/javascript">
        function ToUpper(ctrl) {
            var t = ctrl.value;
            ctrl.value = t.toUpperCase();
        }
    </script>
    <script language="javascript" type="text/javascript">

    </script>
    <div class="formStyle">
        <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>--%>
        <div id="formhead2">
            <div style="width: 98%; float: left;">
                Employee HR Information</div>
            <div style="margin: 2px; float: left; padding-right: 3px;">
                <a href="../Default.aspx">
                    <img src="../Images/close_icon.gif" /></a></div>
        </div>
        <div class="MsgBox">
            <asp:Label ID="lblMsg" runat="server" Width="500px" Font-Bold="True" ForeColor="Green">
            </asp:Label>
        </div>
        <div class="Div950">
            <fieldset style="background-color: #C2D69B;">
                <div style="float: left; width: 50%;">
                    <table>
                        <tr>
                            <td class="textlevel" Width="100px">
                                Emp Id :
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmpID" runat="server" Width="80px">
                                </asp:TextBox>
                                <asp:Button ID="cmdFind" runat="server" OnClick="cmdFind_Click" Text="Find" Width="54px"
                                    CausesValidation="False" />
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td class="textlevel" Width="100px">
                                Full Name :
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmpFullName" runat="server" Width="295px" ReadOnly="True">
                                </asp:TextBox>
                            </td>
                            <td class="textlevel"  Width="100px">
                                PF ID:
                            </td>
                            <td class="textlevelleft" style="height: 16px">
                                <asp:TextBox ID="txtSeveranceId" runat="server" Width="295px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
            </fieldset>
            <fieldset>
                <legend>Placement</legend>
                <div style="background-color: #B8CCE4;">
                    <table>
                        <tbody>
                            <tr>
                                <td class="textlevel">
                                    Intervention :</td>
                                <td>
                                    <asp:DropDownList ID="ddlCompany" runat="server" Width="300px" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlCompany_SelectedIndexChanged" CssClass="textlevelleft">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:CompareValidator ID="CompareValidator16" runat="server" ErrorMessage="*" ControlToValidate="ddlCompany"
                                        Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                                </td>
                                <td class="textlevel">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td class="textlevel">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="textlevel">
                                    Office Type :</td>
                                <td>
                                    <asp:DropDownList runat="server" AutoPostBack="True" CssClass="textlevelleft" 
                                        Width="300px" ID="ddlOffType" 
                                        onselectedindexchanged=
                                        "ddlOffType_SelectedIndexChanged" ></asp:DropDownList>

                                </td>
                                <td>
                                    <asp:CompareValidator ID="CompareValidator19" runat="server" ErrorMessage="*" ControlToValidate="ddlCompany"
                                        Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                                </td>
                                <td class="textlevel">
                                    <asp:Label runat="server" ID="Label3" Text="Office :"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlOffice" runat="server" Width="300px" AutoPostBack="true"
                                        CssClass="textlevelleft" OnSelectedIndexChanged="ddlOffice_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:CompareValidator ID="CompareValidator17" runat="server" ErrorMessage="*" ControlToValidate="ddlOffice"
                                        Operator="NotEqual" ValueToCompare="99999"></asp:CompareValidator>
                                </td>
                                <td class="textlevel">
                                    <asp:Label runat="server" ID="Label1" Text="Project :"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlProject" runat="server" Width="300px" AutoPostBack="true"
                                        CssClass="textlevelleft">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="textlevel">
                                    Sector :
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlSector" runat="server" Width="300px" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlSector_SelectedIndexChanged" CssClass="textlevelleft">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:CompareValidator ID="CompareValidator7" runat="server" ErrorMessage="*" ControlToValidate="ddlSector"
                                        Operator="NotEqual" ValueToCompare="99999"></asp:CompareValidator>
                                </td>
                                <td class="textlevel">
                                    Department :
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlDept" CssClass="textlevelleft" runat="server" Width="300px"
                                        OnSelectedIndexChanged="ddlDept_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:CompareValidator ID="CompareValidator8" runat="server" ErrorMessage="*" ControlToValidate="ddlDept"
                                        Operator="NotEqual" ValueToCompare="99999"></asp:CompareValidator>
                                </td>
                                <td class="textlevel">
                                    Posting Date :
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPostingDate" runat="server" Width="89px">
                                    </asp:TextBox>
                                    <a href="javascript:NewCal('<%= txtPostingDate.ClientID %>','ddmmyyyy')">
                                        <img style="border-right: 0px; border-top: 0px; border-left: 0px; border-bottom: 0px"
                                            height="16" alt="Pick a date" src="../images/cal.gif" width="16" /></a>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtPostingDate"
                                        CssClass="validator" ErrorMessage="Invalid" ValidationExpression="^(?=\d)(?:(?:31(?!.(?:0?[2469]|11))|(?:30|29)(?!.0?2)|29(?=.0?2.(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00)))(?:\x20|$))|(?:2[0-8]|1\d|0?[1-9]))([-./])(?:1[012]|0?[1-9])\1(?:1[6-9]|[2-9]\d)?\d\d(?:(?=\x20\d)\x20|$))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\x20[AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$"></asp:RegularExpressionValidator>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="textlevel">
                                    Unit:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlUnit" CssClass="textlevelleft" runat="server" Width="300px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <%--<asp:CompareValidator ID="CompareValidator9" runat="server" ErrorMessage="*" ControlToValidate="ddlUnit"
                                        Operator="NotEqual" ValueToCompare="99999"></asp:CompareValidator>--%>
                                </td>
                                <td class="textlevel">
                                    Component:
                                </td>
                                <td>                                
                                 <asp:DropDownList ID="ddlComponent" CssClass="textlevelleft" runat="server" Width="300px"></asp:DropDownList>
                                </td>
                                <td>
                                </td>
                                <td class="textlevel">
                                    Function :
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPosByFunction" runat="server" Width="300px" CssClass="textlevelleft"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="textlevel">
                                    Date in Position :
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDateInPosition" runat="server" Width="89px"></asp:TextBox>
                                    <a href="javascript:NewCal('<%= txtDateInPosition.ClientID %>','ddmmyyyy')">
                                        <img style="border-right: 0px; border-top: 0px; border-left: 0px; border-bottom: 0px"
                                            height="16" alt="Pick a date" src="../images/cal.gif" width="16" /></a><asp:RegularExpressionValidator
                                                ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtDateInPosition"
                                                CssClass="validator" ErrorMessage="Invalid" ValidationExpression="^(?=\d)(?:(?:31(?!.(?:0?[2469]|11))|(?:30|29)(?!.0?2)|29(?=.0?2.(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00)))(?:\x20|$))|(?:2[0-8]|1\d|0?[1-9]))([-./])(?:1[012]|0?[1-9])\1(?:1[6-9]|[2-9]\d)?\d\d(?:(?=\x20\d)\x20|$))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\x20[AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$"></asp:RegularExpressionValidator>
                                </td>
                                <td></td>
                                <td class="textlevel">Grade :</td>
                                <td>
                                    <asp:DropDownList ID="ddlGrade" CssClass="textlevelleft" runat="server" Width="300px" AutoPostBack="true" 
                                    OnSelectedIndexChanged="ddlGrade_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="*" ControlToValidate="ddlGrade"
                                        Operator="NotEqual" ValueToCompare="99999"></asp:CompareValidator>
                                </td>
                                <td class="textlevel">Grade Step :</td>
                                <td>
                                    <asp:DropDownList ID="ddlGradeLevel" CssClass="textlevelleft" runat="server" Width="300px" AutoPostBack="true"
                                    OnSelectedIndexChanged="ddlGradeLevel_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="textlevel">Date in Grade :</td>
                                <td>
                                    <asp:TextBox ID="txtDateInGrade" runat="server" Width="89px"></asp:TextBox>
                                    <a href="javascript:NewCal('<%= txtDateInGrade.ClientID %>','ddmmyyyy')">
                                        <img style="border-right: 0px; border-top: 0px; border-left: 0px; border-bottom: 0px"
                                            height="16" alt="Pick a date" src="../images/cal.gif" width="16" /></a><asp:RegularExpressionValidator
                                                ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtDateInGrade"
                                                CssClass="validator" ErrorMessage="Invalid" ValidationExpression="^(?=\d)(?:(?:31(?!.(?:0?[2469]|11))|(?:30|29)(?!.0?2)|29(?=.0?2.(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00)))(?:\x20|$))|(?:2[0-8]|1\d|0?[1-9]))([-./])(?:1[012]|0?[1-9])\1(?:1[6-9]|[2-9]\d)?\d\d(?:(?=\x20\d)\x20|$))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\x20[AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$"></asp:RegularExpressionValidator>
                                </td>
                                <td>&nbsp;</td>
                                <td class="textlevel">HR Designation :</td>
                                <td>
                                    <asp:DropDownList ID="ddlDesignation" runat="server" Width="300px" CssClass="textlevelleft"
                                        OnSelectedIndexChanged="ddlDesignation_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:CompareValidator ID="CompareValidator4" runat="server" ErrorMessage="*" ControlToValidate="ddlDesignation"
                                        Operator="NotEqual" ValueToCompare="99999"></asp:CompareValidator>
                                </td>
                                <td class="textlevel">Functional Designation :</td>
                                <td>
                                    <asp:DropDownList ID="ddlJobTitle" runat="server" Width="300px" CssClass="textlevelleft"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="*" ControlToValidate="ddlJobTitle"
                                        Operator="NotEqual" ValueToCompare="99999"></asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="textlevel">
                                    <asp:Label ID="lblActionName" runat="server" CssClass="textlevel" Text="Name of Action :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtActionName" Text="" runat="server" Width="200px"></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                                <td class="textlevel">Posting Division :</td>
                                <td>
                                    <asp:DropDownList ID="ddlPostDivision" runat="server" Width="300px" CssClass="textlevelleft"
                                        OnSelectedIndexChanged="ddlPostDivision_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                </td>
                                <td><%--
                                    <asp:CompareValidator ID="CompareValidator10" runat="server" ErrorMessage="*" ControlToValidate="ddlPostDivision"
                                        Operator="NotEqual" ValueToCompare="99999"></asp:CompareValidator>
                                --%></td>
                                <td class="textlevel">Posting District :</td>
                                <td>
                                    <asp:DropDownList ID="ddlPostDistrict" runat="server" Width="300px" CssClass="textlevelleft"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="textlevel">
                                    <asp:Label ID="lblActionDate" runat="server" CssClass="textlevel" Text="Action Date :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtActionDate" runat="server" Width="89px"></asp:TextBox>
                                </td>
                                <td></td>
                                <td class="textlevel">Place Of Posting :</td>
                                <td>
                                    <asp:DropDownList ID="ddlPostingPlace" runat="server" Width="300px" CssClass="textlevelleft"></asp:DropDownList>
                                </td>
                              <td>  
                                   <%-- <asp:CompareValidator ID="CompareValidator13" runat="server" ErrorMessage="*" ControlToValidate="ddlPostingPlace"
                                        Operator="NotEqual" ValueToCompare="99999"></asp:CompareValidator>--%>
                                </td>
                                <td class="textlevel">Employee Type :</td>
                                <td>
                                    <asp:DropDownList ID="ddlEmpType" runat="server" Width="300px" CssClass="textlevelleft"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:CompareValidator ID="CompareValidator5" runat="server" ErrorMessage="*" ControlToValidate="ddlEmpType"
                                        Operator="NotEqual" ValueToCompare="99999"></asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="textlevel">Working Days :</td>
                                <td>
                                    <asp:TextBox ID="txtWorkingDays" Text="0" runat="server" Width="89px" CssClass="TextBoxAmt60"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:CompareValidator ID="CompareValidator15" runat="server" ErrorMessage="*" ControlToValidate="txtWorkingDays"
                                        Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                                </td>
                                <td class="textlevel">Salary Location :</td>
                                <td style="height: 15px">
                                    <asp:DropDownList ID="ddlSalaryLoc" runat="server" Width="300px" CssClass="textlevelleft"></asp:DropDownList>
                                </td>
                                <td></td>
                                <td class="textlevel">Emp Nature:</td>
                                <td>
                                    <asp:DropDownList ID="ddlEmpNature" runat="server" Width="150px" CssClass="textlevelleft"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="textlevel" style="height: 15px">Contract Purpose :</td>
                                <td style="height: 15px">
                                    <asp:TextBox ID="txtContractPurpose" runat="server" Width="295px"></asp:TextBox>
                                </td>
                                <td style="height: 15px"></td>
                                <td class="textlevel" style="height: 15px">Work Area :</td>
                                <td style="height: 15px">
                                    <asp:TextBox ID="txtWorkArea" runat="server" Width="295px"></asp:TextBox>
                                </td>
                                <td style="height: 15px"></td>
                                <td style="height: 15px" class="textlevel">Appointment Type:</td>
                                <td style="height: 15px">
                                    <asp:DropDownList ID="ddlAppointType" runat="server" CssClass="textlevelleft">
                                        <asp:ListItem Text="Core" Value="C"></asp:ListItem>
                                        <asp:ListItem Text="Project" Value="P"></asp:ListItem>
                                        <asp:ListItem Value="V">Voluntary</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="textlevel" style="height: 16px">Work Area Type :</td>
                                <td class="textlevelleft" style="height: 16px">
                                    <asp:CheckBox ID="chkWorkArea" runat="server" CssClass="textlevelleft" Text="Is Remote" Width="91px" />
                                </td>
                                <td style="height: 16px"></td>
                                <td class="textlevel" style="height: 16px"></td>
                                <td class="textlevelleft" style="height: 16px">
                                    <asp:CheckBox ID="chkIsSeveranceBenefit" runat="server" CssClass="textlevelleft"
                                        Text="Is PF Benefit" Width="255px" />
                                </td>
                                <td style="height: 16px"></td>
                                <td style="height: 16px"></td>
                                <td style="height: 16px">
                                   <%-- <asp:DropDownList ID="ddlSalarySubLoc" runat="server" Width="300px" 
                                        CssClass="textlevelleft" Visible="False">
                                    </asp:DropDownList>--%>
                                </td>
                            </tr>
                            <tr>
                                <%--<td class="textlevel" style="height: 16px">
                                    PF ID :
                                </td>
                                <td class="textlevelleft" style="height: 16px">
                                    <asp:TextBox ID="txtSeveranceId" runat="server" Width="295px"></asp:TextBox>
                                </td>--%>
                               <%-- <td style="height: 16px">
                                </td>--%>
                                <td class="textlevel" style="height: 16px">Reason (if not) :</td>
                                <td class="textlevelleft" style="height: 16px">
                                    <asp:TextBox ID="txtSeveranceReason" runat="server" Width="295px"></asp:TextBox>
                                </td>
                                <td style="height: 16px"></td>
                                <td style="height: 16px"></td>
                                <td style="height: 16px"></td>
                            </tr>
                            <tr>
                                <td class="textlevel">Supervisor Approver:</td>
                                <td class="textlevelleft">
                                     <asp:DropDownList ID="ddlSupervisor" runat="server" Width="300px" CssClass="textlevelleft"></asp:DropDownList>
                                </td>
                                <td></td>
                                <td class="textlevel">Supervisor Recommender :</td>
                                <td class="textlevelleft">
                                   <asp:TextBox ID="txtLeaveSupervisor" runat="server" Width="130px"></asp:TextBox>
                                </td>
                                <td></td>
                                <td class="textlevel">Notification Receivers</td>
                                <td>
                                   <asp:TextBox ID="txtNotifier" runat="server" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                 <td class="textlevel">Basic :</td>
                                <td class="textlevelleft">
                                    <asp:TextBox ID="txtBasicSalary" runat="server" CssClass="TextBoxAmt60" Width="89px"></asp:TextBox>&nbsp;&nbsp;BDT
                                    <asp:CompareValidator ID="CompareValidator14" runat="server" ErrorMessage="*" ControlToValidate="txtBasicSalary"
                                        Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                                </td>
                                <td></td>
                                <td class="textlevel">Gross :</td>
                                <td class="textlevelleft">
                                     <asp:TextBox ID="txtGross" runat="server" CssClass="TextBoxAmt60" Width="89px"></asp:TextBox>&nbsp;&nbsp;BDT
                                    <asp:CompareValidator ID="CompareValidator18" runat="server" ErrorMessage="*" ControlToValidate="txtGross"
                                        Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                                </td>
                                <td></td>
                                <td class="textlevel"></td>
                                <td></td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </fieldset>
            <fieldset>
                <legend>Payroll</legend>
                <div style="background-color: #C8C8C8;">
                    <table>
                        <tbody>
                            <tr>
                                <td class="textlevel">Salary Package :</td>
                                <td>
                                    <asp:DropDownList ID="ddlSalaryPak" runat="server" Width="300px" CssClass="textlevelleft"></asp:DropDownList>
                                </td>
                                <td></td>
                                <td class="textlevel">&nbsp;</td>
                                <td>
                                    <asp:CheckBox ID="chkIsPayrollStaff" runat="server" CssClass="textlevelleft" Text="Is Payroll Staff" Width="167px" />
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td class="textlevel">Payroll Cycle :</td>
                                <td>
                                    <asp:DropDownList ID="ddlMPC" runat="server" Width="300px" CssClass="textlevelleft"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:CompareValidator ID="CompareValidator6" runat="server" ErrorMessage="*" ControlToValidate="ddlMPC" Operator="NotEqual" ValueToCompare="99999"></asp:CompareValidator>
                                </td>
                                <td class="textlevel">Bank Account No :</td>
                                <td>
                                    <asp:TextBox ID="txtBankAccNo" runat="server" Width="130px"></asp:TextBox>&nbsp;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="textlevel">Bank Name :</td>
                                <td>
                                    <asp:DropDownList ID="ddlBankName" runat="server" Width="300px" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlBankName_SelectedIndexChanged" CssClass="textlevelleft">
                                    </asp:DropDownList>
                                </td>
                                <td></td>
                                <td class="textlevel">Branch Name :</td>
                                <td>
                                    <asp:DropDownList ID="ddlBranchCode" runat="server" Width="300px" CssClass="textlevelleft"></asp:DropDownList>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td class="textlevel">Routing No.:</td>
                                <td>
                                    <asp:Label ID="lblRoutingNo" runat="server" CssClass="textlevel" Text="Label"></asp:Label>
                                </td>
                                <td>&nbsp;</td>
                                <td class="textlevel">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </fieldset>
            <fieldset>
                <asp:Panel ID="pnlLeaveAttn" runat="server">
                    <legend>Leave &amp; Attendance</legend>
                    <div style="background-color: #C2D69B;">
                        <table>
                            <tbody>
                                <tr>
                                    <td class="textlevel">Leave Package :</td>
                                    <td>
                                        <asp:DropDownList ID="ddlLeavePackage" runat="server" Width="300px" CssClass="textlevelleft"></asp:DropDownList>
                                    </td>
                                    <td></td>
                                    <td class="textlevel">Weekend :</td>
                                    <td>
                                        <asp:DropDownList ID="ddlWeekend" runat="server" Width="300px" CssClass="textlevelleft" Visible="True"></asp:DropDownList>
                                    </td>
                                    <td></td>
                                    <td class="textlevel">Attnd Policy :</td>
                                    <td>
                                        <asp:DropDownList ID="ddlAttndPolicy" runat="server" Width="90px" CssClass="textlevelleft" Visible="True"></asp:DropDownList>
                                    </td>
                                    <td></td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </asp:Panel>
            </fieldset>
            <fieldset>
                <legend>Joining </legend>
                <div style="background-color: #F2DBDB;">
                    <table>
                        <tr>
                            <td class="textlevel">
                                Joining Date :
                            </td>
                            <td colspan="1">
                                <asp:TextBox ID="txtJoiningDate" runat="server" Width="89px">
                                </asp:TextBox>
                                <a href="javascript:NewCal('<%= txtJoiningDate.ClientID %>','ddmmyyyy')">
                                    <img style="border-right: 0px; border-top: 0px; border-left: 0px; border-bottom: 0px"
                                        height="16" alt="Pick a date" src="../images/cal.gif" width="16" /></a>
                            </td>
                            <td colspan="1">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                    ControlToValidate="txtJoiningDate">
                                </asp:RequiredFieldValidator>
                            </td>
                            <td colspan="1">
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Width="60px"
                                    ErrorMessage="Invalid" ControlToValidate="txtJoiningDate" CssClass="validator"
                                    ValidationExpression="^(?=\d)(?:(?:31(?!.(?:0?[2469]|11))|(?:30|29)(?!.0?2)|29(?=.0?2.(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00)))(?:\x20|$))|(?:2[0-8]|1\d|0?[1-9]))([-./])(?:1[012]|0?[1-9])\1(?:1[6-9]|[2-9]\d)?\d\d(?:(?=\x20\d)\x20|$))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\x20[AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$"></asp:RegularExpressionValidator>
                            </td>
                            <td colspan="1">
                            </td>
                            <td class="textlevel">
                                Job Status :
                            </td>
                            <td class="textlevelleft">
                                <asp:DropDownList ID="ddlStatus" runat="server" Width="127px" CssClass="textlevelleft">
                                    <asp:ListItem Value="A">Active</asp:ListItem>
                                    <asp:ListItem Value="I">In-Active</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td class="textlevel">
                            </td>
                            <td colspan="1">
                            </td>
                            <td colspan="1" style="width: 12px">
                            </td>
                            <td colspan="1" style="width: 12px">
                            </td>
                            <td colspan="1" style="width: 105px">
                            </td>
                            <td class="textlevel" style="width: 118px">
                            </td>
                            <td class="textlevelleft">
                            </td>
                            <td class="textlevel" style="width: 10px">
                            </td>
                        </tr>
                    </table>
                </div>
            </fieldset>
            <fieldset>
                <legend>Confirmation</legend>
                <div style="background-color: #C8C8C8;">
                    <table>
                        <tr>
                            <td class="textlevel">
                                Probation Period :
                            </td>
                            <td colspan="1" style="width: 128px" class="textlevelleft">
                                <asp:TextBox ID="txtProbationPeriod" runat="server" Width="50px" MaxLength="5" CssClass="TextBoxAmt60"
                                    AutoPostBack="True" OnTextChanged="txtProbationPeriod_TextChanged">0</asp:TextBox>
                                &nbsp;(Months)
                            </td>
                            <td style="width: 16px" colspan="1">
                                &nbsp;
                            </td>
                            <td style="width: 60px" colspan="1">
                            </td>
                            <td style="width: 103px" colspan="1">
                            </td>
                            <td class="textlevel">
                                Confirmation Date :
                            </td>
                            <td class="textlevelleft">
                                <asp:TextBox ID="txtConfirmDate" runat="server" Width="89px"></asp:TextBox>
                                <a href="javascript:NewCal('<%= txtConfirmDate.ClientID %>','ddmmyyyy')">
                                    <img style="border-right: 0px; border-top: 0px; border-left: 0px; border-bottom: 0px"
                                        height="16" alt="Pick a date" src="../images/cal.gif" width="16" /></a>
                            </td>
                            <td style="width: 10px" class="textlevel">
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtConfirmDate"
                                    CssClass="validator" ErrorMessage="Invalid" ValidationExpression="^(?=\d)(?:(?:31(?!.(?:0?[2469]|11))|(?:30|29)(?!.0?2)|29(?=.0?2.(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00)))(?:\x20|$))|(?:2[0-8]|1\d|0?[1-9]))([-./])(?:1[012]|0?[1-9])\1(?:1[6-9]|[2-9]\d)?\d\d(?:(?=\x20\d)\x20|$))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\x20[AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                    </table>
                </div>
            </fieldset>
            <fieldset>
                <legend>Contract</legend>
                <div style="background-color: #C2D69B;">
                    <table>
                        <tr>
                            <td class="textlevel">
                                Contract Interval :
                            </td>
                            <td colspan="1" style="width: 128px" class="textlevelleft">
                                <asp:TextBox ID="txtContractInterval" runat="server" Width="50px" MaxLength="5" CssClass="TextBoxAmt60"
                                    AutoPostBack="True" OnTextChanged="txtContractInterval_TextChanged">0</asp:TextBox>
                                &nbsp;(Months)
                            </td>
                            <td style="width: 16px" colspan="1">
                                &nbsp;
                            </td>
                            <td style="width: 60px" colspan="1">
                                &nbsp;
                            </td>
                            <td style="width: 103px" colspan="1">
                            </td>
                            <td class="textlevel">
                                Contract End Date :
                            </td>
                            <td class="textlevelleft">
                                <asp:TextBox ID="txtContractExpDate" runat="server" Width="89px">
                                </asp:TextBox>
                                <a href="javascript:NewCal('<%= txtContractExpDate.ClientID %>','ddmmyyyy')">
                                    <img style="border-right: 0px; border-top: 0px; border-left: 0px; border-bottom: 0px"
                                        height="16" alt="Pick a date" src="../images/cal.gif" width="16" /></a>
                            </td>
                            <td style="width: 10px" class="textlevel">
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txtContractExpDate"
                                    CssClass="validator" ErrorMessage="Invalid" ValidationExpression="^(?=\d)(?:(?:31(?!.(?:0?[2469]|11))|(?:30|29)(?!.0?2)|29(?=.0?2.(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00)))(?:\x20|$))|(?:2[0-8]|1\d|0?[1-9]))([-./])(?:1[012]|0?[1-9])\1(?:1[6-9]|[2-9]\d)?\d\d(?:(?=\x20\d)\x20|$))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\x20[AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                    </table>
                </div>
            </fieldset>
            <fieldset>
                <legend>Service Agreement</legend>
                <div style="background-color: #F2DBDB;">
                    <table>
                        <tr>
                            <td class="textlevel"></td>
                            <td class="textlevelleft" colspan="2">
                                <asp:CheckBox ID="chkIsServiceAgrmnt" runat="server" CssClass="textlevelleft" Text="Is Service Agreement" />
                            </td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td class="textlevel">
                                Start Date :
                            </td>
                            <td>
                                <asp:TextBox ID="txtTrainSerStartDt" runat="server" Width="89px"></asp:TextBox>
                                <a href="javascript:NewCal('<%= txtTrainSerStartDt.ClientID %>','ddmmyyyy')">
                                    <img style="border-right: 0px; border-top: 0px; border-left: 0px; border-bottom: 0px"
                                        height="16" alt="Pick a date" src="../images/cal.gif" width="16" /></a>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server"
                                    Width="60px" ErrorMessage="Invalid" ControlToValidate="txtTrainSerStartDt" CssClass="validator"
                                    ValidationExpression="^(?=\d)(?:(?:31(?!.(?:0?[2469]|11))|(?:30|29)(?!.0?2)|29(?=.0?2.(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00)))(?:\x20|$))|(?:2[0-8]|1\d|0?[1-9]))([-./])(?:1[012]|0?[1-9])\1(?:1[6-9]|[2-9]\d)?\d\d(?:(?=\x20\d)\x20|$))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\x20[AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$"></asp:RegularExpressionValidator>
                            </td>
                            <td class="textlevel">
                                End Date :
                            </td>
                            <td class="textlevelleft">
                                <asp:TextBox ID="txtTrainSerEndDt" runat="server" Width="89px"></asp:TextBox>
                                <a href="javascript:NewCal('<%= txtTrainSerEndDt.ClientID %>','ddmmyyyy')">
                                    <img style="border-right: 0px; border-top: 0px; border-left: 0px; border-bottom: 0px"
                                        height="16" alt="Pick a date" src="../images/cal.gif" width="16" /></a>
                            </td>
                            <td>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server"
                                    Width="60px" ErrorMessage="Invalid" ControlToValidate="txtTrainSerEndDt" CssClass="validator"
                                    ValidationExpression="^(?=\d)(?:(?:31(?!.(?:0?[2469]|11))|(?:30|29)(?!.0?2)|29(?=.0?2.(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00)))(?:\x20|$))|(?:2[0-8]|1\d|0?[1-9]))([-./])(?:1[012]|0?[1-9])\1(?:1[6-9]|[2-9]\d)?\d\d(?:(?=\x20\d)\x20|$))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\x20[AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$"></asp:RegularExpressionValidator>
                            </td>
                             <td class="textlevel">Security Money :</td>
                            <td class="textlevelleft">
                                <asp:TextBox ID="txtSecurityMoney" runat="server" Width="89px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
            </fieldset>
            <fieldset>
                <legend>Separation</legend>
                <div style="background-color: #C8C8C8;">
                    <table>
                        <tr>
                            <td class="textlevel">
                                Retirement Date :
                            </td>
                            <td>
                                <asp:TextBox ID="txtRetirementDate" runat="server" Enabled="false" Width="89px"></asp:TextBox>
                                <%--<a href="javascript:NewCal('<%= txtRetirementDate.ClientID %>','ddmmyyyy')">
                                    <img style="border-right: 0px; border-top: 0px; border-left: 0px; border-bottom: 0px"
                                        height="16" alt="Pick a date" src="../images/cal.gif" width="16" /></a>--%>
                            </td>
                            <td>
                               <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" Width="60px"
                                    ErrorMessage="Invalid" ControlToValidate="txtRetirementDate" CssClass="validator"
                                    ValidationExpression="^(?=\d)(?:(?:31(?!.(?:0?[2469]|11))|(?:30|29)(?!.0?2)|29(?=.0?2.(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00)))(?:\x20|$))|(?:2[0-8]|1\d|0?[1-9]))([-./])(?:1[012]|0?[1-9])\1(?:1[6-9]|[2-9]\d)?\d\d(?:(?=\x20\d)\x20|$))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\x20[AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$"></asp:RegularExpressionValidator>--%>
                            </td>
                            <td>
                            </td>
                            <td class="textlevel">
                                Separation Date :
                            </td>
                            <td>
                                <asp:TextBox ID="txtSeparationDate" runat="server" Width="89px" Enabled="false"></asp:TextBox>
                                <%--<a href="javascript:NewCal('<%= txtSeparationDate.ClientID %>','ddmmyyyy')">
                                    <img style="border-right: 0px; border-top: 0px; border-left: 0px; border-bottom: 0px"
                                        height="16" alt="Pick a date" src="../images/cal.gif" width="16" /></a>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server"
                                    ControlToValidate="txtSeparationDate" CssClass="validator" ErrorMessage="Invalid"
                                    ValidationExpression="^(?=\d)(?:(?:31(?!.(?:0?[2469]|11))|(?:30|29)(?!.0?2)|29(?=.0?2.(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00)))(?:\x20|$))|(?:2[0-8]|1\d|0?[1-9]))([-./])(?:1[012]|0?[1-9])\1(?:1[6-9]|[2-9]\d)?\d\d(?:(?=\x20\d)\x20|$))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\x20[AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$"></asp:RegularExpressionValidator>--%>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td class="textlevel" valign="top">
                                Separation Type :
                            </td>
                            <td valign="top">
                                <asp:DropDownList Enabled="false" ID="ddlSepType" runat="server" Width="250px" CssClass="textlevelleft">
                                </asp:DropDownList>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td class="textlevel" valign="top">
                                <asp:Label ID="lblSeparationReason" runat="server" CssClass="textlevel" Text="Separation Reason :"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSeparationReason" Enabled="false" runat="server" Width="295px" Font-Names="Arial"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td class="textlevel" valign="top">
                                &nbsp;
                            </td>
                            <td valign="top">
                                <asp:CheckBox Enabled="false" ID="chkIsNotRehire" runat="server" CssClass="textlevelleft" Text="Is Not Rehirable"
                                    Width="127px" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td class="textlevel" valign="top">
                                <asp:Label ID="lblNotRehireReason" runat="server" CssClass="textlevel" Text="Reason of Not Rehirable :"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtNotRehireReason" Enabled="false" runat="server" Width="295px" Font-Names="Arial"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </div>
            </fieldset>
            <fieldset>
                <legend>Other Information</legend>
                <div style="background-color: #F2DBDB;">
                    <table>
                        <tr>
                            <td class="textlevel">
                                Other Benefit :
                            </td>
                            <td>
                                <asp:TextBox ID="txtOtherBenefit" runat="server" Font-Names="Arial" Width="295px"></asp:TextBox>&nbsp;
                            </td>
                            <td class="textlevel">
                                Remarks :
                            </td>
                            <td>
                                <asp:TextBox ID="txtRemarks" runat="server" Font-Names="Arial" Width="295px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <%--<asp:CheckBox ID="chkIsMedicalEntitle" runat="server" CssClass="textlevelleft" Text="Is Medical Entitlement"
                                    Width="130px" Visible="false"/>--%>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkIsOTEntitle" runat="server" CssClass="textlevelleft" Text="Is OT Entitlement"
                                    Width="127px" />
                                <%--<asp:CheckBox ID="chkIsChildEdu" runat="server" CssClass="textlevelleft" Text="Child Care Allowance"
                                    Width="163px" Visible="false" />--%>
                            </td>
                        </tr>
                        <tr>
                            <td class="textlevel">
                                Asset :
                            </td>
                            <td>
                                <asp:TextBox ID="txtAsset" runat="server" Font-Names="Arial" Width="295px"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </div>
            </fieldset>
            <fieldset>
                <asp:Panel ID="pnlUploadDoc" runat="server">
                    <legend>Upload Document</legend>
                    <div style="background-color: #B8CCE4;">
                        <table>
                            <tr>
                                <td class="textlevel">
                                    Emp CV :
                                </td>
                                <td>
                                    <asp:FileUpload ID="fileEmpCV" runat="server" />
                                </td>
                                <td>
                                    <asp:LinkButton ID="lnkEmpCV" runat="server" OnClick="lnkEmpCV_Click"></asp:LinkButton>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td class="textlevel">
                                    Emp Signature :
                                </td>
                                <td>
                                    <asp:FileUpload ID="fileEmpSignature" runat="server" />
                                </td>
                                <td>
                                    <asp:LinkButton ID="lnkEmpSignature" runat="server" OnClick="lnkEmpSignature_Click"></asp:LinkButton>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td class="textlevel">
                                    Emp Document :
                                </td>
                                <td>
                                    <asp:FileUpload ID="fileEmpDocument" runat="server" />
                                </td>
                                <td>
                                    <asp:LinkButton ID="lnkEmpDocument" runat="server" OnClick="lnkEmpDocument_Click"></asp:LinkButton>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </div>
                </asp:Panel>
                <legend>Action List</legend>
            </fieldset>
            <asp:GridView ID="grEmpAction" runat="server" AutoGenerateColumns="False" EmptyDataText="No Record Found"
                Font-Size="9px" Width="30%">
                <HeaderStyle BackColor="#B3CDE4" Font-Bold="True" />
                <SelectedRowStyle BackColor="#D1DDF1" CssClass="ListHeader" Font-Bold="True" ForeColor="#333333" />
                <AlternatingRowStyle BackColor="#EFF3FB" />
                <Columns>
                    <asp:BoundField DataField="ActionName" HeaderText="Action Name">
                        <ItemStyle CssClass="ItemStylecss" Width="30%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ActionDate" HeaderText="Action Date">
                        <ItemStyle CssClass="ItemStylecss" Width="10%" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
            <%--<fieldset>
                <asp:Panel ID="PnlSalaryRange" runat="server" Width="600px" BackColor="White" Visible="false" >
                    <div style="background-image: url(../Images/back-bar-header.png); color: white; background-repeat: repeat-x;
                        height: 20px;">
                        Basic Salary Range</div>
                    <asp:Label ID="lblSalaryRange" runat="server" CssClass="msglabel" BackColor="White"></asp:Label>
                    <div style="margin-top: 5px; vertical-align: middle; height: 27px; background-color: gray;
                        text-align: center">
                        <asp:Button ID="btnOk" runat="server" Text="Ok" OnClick="btnOk_Click" Width="60px"
                            BackColor="#336699" Font-Bold="True" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="60px" BackColor="#336699"
                            Font-Bold="True" /></div>
                </asp:Panel>
            </fieldset>--%>
            <cc1:ModalPopupExtender ID="ModalPopupTree" runat="server" BackgroundCssClass="modalBackground"
                CancelControlID="btnCancel" DropShadow="True" DynamicServicePath="" Enabled="true" 
                PopupControlID="PnlSalaryRange" TargetControlID="btnShow">
            </cc1:ModalPopupExtender>
            <div class="DivCommand1" style="width: 100%;">
                <div class="DivCommandL" style="padding-left: 12px;">
                    <asp:Button ID="btnClear" runat="server" Text="Refresh" Width="70px" OnClick="btnClear_Click"
                        UseSubmitBehavior="False" CausesValidation="False" />
                </div>
                <div class="DivCommandR">
                    <asp:Button ID="btnShow" runat="server" Text="..." OnClick="btnDelete_Click" Enabled="False" />
                    <asp:CheckBox ID="chkIsNew" runat="server" CssClass="textlevelleft" Text="Is New"
                        Width="127px" />
                    <asp:Button ID="btnSave" runat="server" Text="Update" Width="70px" OnClick="btnSave_Click"
                        Style="height: 26px" />
                </div>
            </div>
            <asp:HiddenField ID="hfLPakId" runat="server" />
            <asp:HiddenField ID="hfIsUpadate" runat="server" />
            <asp:HiddenField ID="hfID" runat="server" />
            <asp:HiddenField ID="hfJoiningDate" runat="server" />
            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers"
                TargetControlID="txtProbationPeriod">
            </cc1:FilteredTextBoxExtender>
            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Custom,Numbers"
                TargetControlID="txtBasicSalary" ValidChars="0123456789.*">
            </cc1:FilteredTextBoxExtender>
            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterType="Numbers"
                TargetControlID="txtWorkingDays">
            </cc1:FilteredTextBoxExtender>
            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" FilterType="Numbers"
                TargetControlID="txtContractInterval">
            </cc1:FilteredTextBoxExtender>
            <%--</ContentTemplate>
        </asp:UpdatePanel>--%>
        </div>
</asp:Content>
