<%@ Page Language="C#" MasterPageFile="~/MasterBTMS.master" AutoEventWireup="true"
    CodeFile="TrainingReports.aspx.cs" Inherits="CrystalReports_Training_TrainingReports" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../../JScripts/datetimepicker.js">
        //Date Time Picker script
    </script>
    <script language="javascript" type="text/javascript">
        function ToUpper(ctrl) {
            var t = ctrl.value;
            ctrl.value = t.toUpperCase();
        }
    </script>
    <div class="formStyle">
        <div id='formhead6'>
            <div style="width: 98%; float: left;">
                Report List</div>
            <div style="margin: 2px; float: left; padding-right: 3px;">
                <a href="../../Default.aspx">
                    <img src="../../Images/close_icon.gif" alt="Close" /></a></div>
        </div>
        <div class="repotForm2">
            <fieldset>
                <div id="reportList">
                    <asp:TreeView ID="tvReports" runat="server" ImageSet="Arrows" OnSelectedNodeChanged="tvReports_SelectedNodeChanged">
                        <Nodes>
                            <asp:TreeNode Text="Report List" Value="RL">
                                <asp:TreeNode Text="Training Report" Value="ETD"></asp:TreeNode>
                                <asp:TreeNode Text="Schedule Report" Value="TSI"></asp:TreeNode>
                                <asp:TreeNode Text="Dept. Wise Training Report" Value="DTR"></asp:TreeNode>
                                <asp:TreeNode Text="Employee Eligible Training Report" Value="EER"></asp:TreeNode>
                            </asp:TreeNode>
                        </Nodes>
                        <ParentNodeStyle Font-Bold="False" />
                        <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                        <SelectedNodeStyle BackColor="#E0E0E0" Font-Underline="True" ForeColor="#5555DD"
                            HorizontalPadding="0px" VerticalPadding="0px" />
                        <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" HorizontalPadding="5px"
                            NodeSpacing="0px" VerticalPadding="0px" />
                    </asp:TreeView>
                </div>
                <div id="reportListFild">
                    <asp:HiddenField ID="hfId" runat="server" />
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div style="width: 475px">
                                <div style="float: left; width: 100%">
                                    <table>
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="PEmp" runat="server" BorderStyle="Solid" BorderColor="DarkGray" BorderWidth="1px"
                                                        Width="400px" Visible="False">
                                                        <table>
                                                            <tbody>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="Label2" runat="server" Text="Employee Id :" Width="150px" CssClass="textlevel"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtEmpCode" runat="server" Width="80px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="PrbtnLArea" runat="server" BorderStyle="Solid" BorderColor="DarkGray"
                                                        BorderWidth="1px" Width="400px">
                                                        <table>
                                                            <tbody>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="rbtnWithLearningArea" Text="With Learning Area" runat="server" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:RadioButton ID="rbtnWithoutLearningArea" Text="Without Learning Area" runat="server" />
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="PFiscalYr" runat="server" BorderStyle="Solid" BorderColor="DarkGray"
                                                        BorderWidth="1px" Width="400px">
                                                        <table>
                                                            <tbody>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="Label9" runat="server" Text="Fiscal Year :" Width="150px" CssClass="textlevel"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlFiscalYr" runat="server" Width="150px" CssClass="textlevelleft"
                                                                           AutoPostBack="true">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                             <td>
                                                    <asp:Panel ID="pSalaryLocation" runat="server" BorderStyle="Solid" BorderColor="DarkGray"
                                                        BorderWidth="1px" Width="400px">
                                                        <table>
                                                            <tbody>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="Label6" runat="server" Text="Location :" Width="150px" CssClass="textlevel"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlSalLoc" runat="server" Width="150px" CssClass="textlevelleft"
                                                                            AutoPostBack="true">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                              </tr>
                                              <tr>
                                               <tr>
                                             <td>
                                                    <asp:Panel ID="pEmployeeName" runat="server" BorderStyle="Solid" BorderColor="DarkGray"
                                                        BorderWidth="1px" Width="400px">
                                                        <table>
                                                            <tbody>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="Label13" runat="server" Text="Employee Name :" Width="150px" CssClass="textlevel"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlEmployeeName" runat="server" Width="150px" CssClass="textlevelleft"
                                                                            AutoPostBack="true">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                              </tr>
                                              <tr>
                                                <td>
                                                    <asp:Panel ID="PTrainingName" runat="server" BorderStyle="Solid" BorderColor="DarkGray"
                                                        BorderWidth="1px" Width="400px">
                                                        <table>
                                                            <tbody>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="Label3" runat="server" Text="Training Name :" Width="150px" CssClass="textlevel"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlTrainingName" runat="server" Width="150px" CssClass="textlevelleft"
                                                                            AutoPostBack="true">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                                <td>
                                                    <asp:Panel ID="PTrainingScheduleDates" runat="server" BorderStyle="Solid" BorderColor="DarkGray"
                                                        BorderWidth="1px" Width="400px" Visible="false">
                                                        <table>
                                                            <tbody>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="Label5" runat="server" Text="Dates :" Width="150px" CssClass="textlevel"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlScheduleDates" runat="server" Width="150px" CssClass="textlevelleft"
                                                                            AutoPostBack="true">
                                                                            <asp:ListItem Text="Yesterday" Value="1" />
                                                                            <asp:ListItem Text="Last Week" Value="2" />
                                                                            <asp:ListItem Text="Last Month" Value="3" />
                                                                            <asp:ListItem Text="Last Year" Value="4" />
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="PTraingType" runat="server" BorderStyle="Solid" BorderColor="DarkGray"
                                                        BorderWidth="1px" Width="400px">
                                                        <table>
                                                            <tbody>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="Label4" runat="server" Text="Traning Type:" Width="150px" CssClass="textlevel"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlTrainType" runat="server" Width="150px" CssClass="textlevelleft" >
                                                                            <asp:ListItem Text="All" Value="M"></asp:ListItem>
                                                                            <asp:ListItem Text="Overseas" Value="O"></asp:ListItem>
                                                                            <asp:ListItem Text="In Country" Value="C"></asp:ListItem>
                                                                            <asp:ListItem Text="In House" Value="I"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="PTraningState" runat="server" BorderStyle="Solid" BorderColor="DarkGray"
                                                        BorderWidth="1px" Width="400px">
                                                        <table>
                                                            <tbody>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="Label1" runat="server" Text="Training State :" Width="150px" CssClass="textlevel"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlTriningState" runat="server" Width="150px" CssClass="textlevelleft">
                                                                            <asp:ListItem Value="-1">All</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="PLearningArea" runat="server" BorderStyle="Solid" BorderColor="DarkGray"
                                                        BorderWidth="1px" Width="400px">
                                                        <table>
                                                            <tbody>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="Label7" runat="server" Text="Learning Area :" Width="150px" CssClass="textlevel"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlLearningArea" runat="server" Width="150px" CssClass="textlevelleft"
                                                                            AutoPostBack="true">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="PProgramDept" runat="server" BorderStyle="Solid" BorderColor="DarkGray"
                                                        BorderWidth="1px" Width="400px">
                                                        <table>
                                                            <tbody>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="Label8" runat="server" Text="Department :" Width="150px" CssClass="textlevel"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlProgDept" runat="server" Width="150px" CssClass="textlevelleft"
                                                                           AutoPostBack="true">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="PrbtnCost" runat="server" BorderStyle="Solid" BorderColor="DarkGray"
                                                        BorderWidth="1px" Width="400px">
                                                        <table>
                                                            <tbody>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="rbtnWithCost" Text="With Cost" runat="server" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:RadioButton ID="rbtnWithoutCost" Text="Without Cost" runat="server" />
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="PQuarter" runat="server" BorderStyle="Solid" BorderColor="DarkGray"
                                                        BorderWidth="1px" Width="400px">
                                                        <table>
                                                            <tbody>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="Label10" runat="server" Text="Quarter :" Width="150px" CssClass="textlevel"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlQuarter" runat="server" Width="150px" CssClass="textlevelleft">
                                                                            <asp:ListItem Value="-1">All</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="PrbtnAcive" runat="server" BorderStyle="Solid" BorderColor="DarkGray"
                                                        BorderWidth="1px" Width="400px">
                                                        <table>
                                                            <tbody>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="rbtnActive" Text="Active" runat="server" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:RadioButton ID="rbtnInactive" Text="Inactive" runat="server" />
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="PMonth" runat="server" BorderStyle="Solid" BorderColor="DarkGray"
                                                        BorderWidth="1px" Width="400px">
                                                        <table>
                                                            <tbody>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="Label11" runat="server" Text="Month :" Width="150px" CssClass="textlevel"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlMonth" runat="server" Width="150px" CssClass="textlevelleft">
                                                                            <asp:ListItem Value="-1">All</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="PYear" runat="server" BorderStyle="Solid" BorderColor="DarkGray" BorderWidth="1px"
                                                        Width="400px">
                                                        <table>
                                                            <tbody>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="Label12" runat="server" Text="Year :" Width="150px" CssClass="textlevel"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlYear" runat="server" Width="150px" CssClass="textlevelleft">
                                                                            <asp:ListItem Value="-1">All</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="PActveInAcBasic" runat="server" BorderColor="DarkGray" BorderStyle="Solid"
                                                        BorderWidth="1px" Width="400px">
                                                        <table>
                                                            <tbody>
                                                                <tr>
                                                                    <%--OnSelectedIndexChanged="radBtnListEmp_SelectedIndexChanged" AutoPostBack="True"--%>
                                                                    <td>
                                                                        <asp:RadioButtonList ID="radBtnListEmp" runat="server" Font-Names="Tahoma" Font-Size="11px"
                                                                            ForeColor="Blue" RepeatDirection="Horizontal">
                                                                            <asp:ListItem Value="M">All</asp:ListItem>
                                                                            <asp:ListItem Selected="True" Value="A">Active</asp:ListItem>
                                                                            <asp:ListItem Value="I">Inactive</asp:ListItem>
                                                                        </asp:RadioButtonList>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="pnlOTType" runat="server" BorderColor="DarkGray" BorderStyle="Solid"
                                                        BorderWidth="1px" Width="400px">
                                                        <table>
                                                            <tbody>
                                                                <tr>                                                                    
                                                                    <td>
                                                                        <asp:RadioButtonList ID="radBtnOTType" runat="server" Font-Names="Tahoma" Font-Size="11px"
                                                                            ForeColor="Blue" RepeatDirection="Horizontal">
                                                                           <%-- <asp:ListItem Selected="True" Value="A">All</asp:ListItem>--%>
                                                                            <asp:ListItem Selected="True" Value="O">OT, Agency & CSP</asp:ListItem>
                                                                            <asp:ListItem Value="T">Orientation Training</asp:ListItem>                                                                            
                                                                        </asp:RadioButtonList>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="pIntervention" runat="server" BorderStyle="Solid" BorderColor="DarkGray"
                                                        BorderWidth="1px" Width="400px">
                                                        <table>
                                                            <tbody>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="Label14" runat="server" Text="Intervention :" Width="150px" CssClass="textlevel"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlIntervention" runat="server" Width="150px" CssClass="textlevelleft"
                                                                           AutoPostBack="true"  OnSelectedIndexChanged="ddlIntervention_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td>
                                                    <asp:Panel ID="pOfficeType" runat="server" BorderStyle="Solid" BorderColor="DarkGray"
                                                        BorderWidth="1px" Width="400px">
                                                        <table>
                                                            <tbody>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="Label16" runat="server" Text="Office Type :" Width="150px" CssClass="textlevel"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlOfficeType" runat="server" Width="150px" CssClass="textlevelleft"
                                                                           AutoPostBack="true" OnSelectedIndexChanged="ddlOfficeType_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="pOffice" runat="server" BorderStyle="Solid" BorderColor="DarkGray"
                                                        BorderWidth="1px" Width="400px">
                                                        <table>
                                                            <tbody>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="Label15" runat="server" Text="Office :" Width="150px" CssClass="textlevel"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlOffice" runat="server" Width="150px" CssClass="textlevelleft"
                                                                           AutoPostBack="false">
                                                                           <asp:ListItem Value="-1">All</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="PDateRange" runat="server" BorderColor="DarkGray" BorderStyle="Solid"
                                                        BorderWidth="1px" Width="450px">
                                                        <table>
                                                            <tbody>
                                                                <tr>
                                                                    <td style="width: 20px">
                                                                        <asp:Label ID="LabelFromDate" runat="server" CssClass="textlevel" Text="From Date :"
                                                                            Width="80px"></asp:Label>
                                                                    </td>
                                                                    <td style="width: 66px">
                                                                        <asp:TextBox ID="txtFromDate" runat="server" MaxLength="10" Width="70px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="width: 70px">
                                                                        <a href="javascript:NewCal('<%= txtFromDate.ClientID %>','ddmmyyyy')">
                                                                            <img style="border-right: 0px; border-top: 0px; border-left: 0px; border-bottom: 0px"
                                                                                height="16" alt="Pick a date" src="../../images/cal.gif" width="16" />
                                                                        </a>
                                                                    </td>
                                                                    <td colspan="1">
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtFromDate"
                                                                            CssClass="validator" ErrorMessage="Invalid" ValidationExpression="^(?=\d)(?:(?:31(?!.(?:0?[2469]|11))|(?:30|29)(?!.0?2)|29(?=.0?2.(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00)))(?:\x20|$))|(?:2[0-8]|1\d|0?[1-9]))([-./])(?:1[012]|0?[1-9])\1(?:1[6-9]|[2-9]\d)?\d\d(?:(?=\x20\d)\x20|$))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\x20[AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$"
                                                                            Width="40px"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                    <td style="width: 5px">
                                                                        <asp:Label ID="LabelToDate" runat="server" CssClass="textlevel" Text="To Date :"
                                                                            Width="50px"></asp:Label>
                                                                    </td>
                                                                    <td style="width: 62px">
                                                                        <asp:TextBox ID="txtToDate" runat="server" MaxLength="10" Width="70px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="width: 99px">
                                                                        <a href="javascript:NewCal('<%= txtToDate.ClientID %>','ddmmyyyy')">
                                                                            <img style="border-right: 0px; border-top: 0px; border-left: 0px; border-bottom: 0px"
                                                                                height="16" alt="Pick a date" src="../../images/cal.gif" width="16" />
                                                                        </a>
                                                                    </td>
                                                                    <td colspan="1">
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtToDate"
                                                                            CssClass="validator" ErrorMessage="Invalid" ValidationExpression="^(?=\d)(?:(?:31(?!.(?:0?[2469]|11))|(?:30|29)(?!.0?2)|29(?=.0?2.(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00)))(?:\x20|$))|(?:2[0-8]|1\d|0?[1-9]))([-./])(?:1[012]|0?[1-9])\1(?:1[6-9]|[2-9]\d)?\d\d(?:(?=\x20\d)\x20|$))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\x20[AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$"
                                                                            Width="40px"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                                <div style="float: left; width: 50%">
                                    <div style="padding-right: 15px; float: right;">
                                        <table>
                                            <tbody>
                                                <tr>
                                                    <td style="width: 30px">
                                                        <asp:Panel ID="PShow" runat="server" Visible="False">
                                                            <asp:Button ID="btnShow" OnClick="btnShow_Click" runat="server" Text="Show Report"
                                                                Font-Underline="False"></asp:Button>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </fieldset>
        </div>
    </div>
</asp:Content>
