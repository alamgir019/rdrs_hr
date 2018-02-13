<%@ Page Language="C#" MasterPageFile="~/MasterBTMS.master" AutoEventWireup="true"
    CodeFile="Reports.aspx.cs" Inherits="Reports" Title="Reports" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../JScripts/datetimepicker.js">
        //Date Time Picker script
    </script>
    <script language="javascript">
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
                <a href="../Default.aspx">
                    <img src="../Images/close_icon.gif" /></a></div>
        </div>
        <div class="repotForm2">
            <fieldset>
                <div id="reportList">
                    <asp:TreeView ID="tvReports" runat="server" ImageSet="Arrows" OnSelectedNodeChanged="tvReports_SelectedNodeChanged">
                        <Nodes>
                            <asp:TreeNode Text="Report List" Value="RL">
                                <asp:TreeNode Text="Attendance Reports" Value="AttR">
                                    <asp:TreeNode Text="Attendance Report" Value="DA"></asp:TreeNode>
                                    <asp:TreeNode Text="Attendance Emp wise" Value="AE"></asp:TreeNode>
                                    <asp:TreeNode Text="Summary of Attendance" Value="SumAttnd"></asp:TreeNode>
                                    <asp:TreeNode Text="Late Report" Value="LR"></asp:TreeNode>
                                    <asp:TreeNode Text="Absent Report" Value="AR"></asp:TreeNode>
                                    <asp:TreeNode Text="Incomplete Report" Value="IR"></asp:TreeNode>
                                    <asp:TreeNode Text="Early Departure Report" Value="ED"></asp:TreeNode>
                                </asp:TreeNode>
                                <asp:TreeNode Text="Time Sheet" Value="TimeSheet">
                                    <asp:TreeNode Text="Time Sheet" Value="TS"></asp:TreeNode>
                                </asp:TreeNode>
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
                            <table style="width: 340px;">
                                <tbody>
                                    <tr>
                                        <td style="width: 431px">
                                            <asp:Panel ID="PSearchBy" runat="server" BorderStyle="Solid" BorderColor="DarkGray"
                                                BorderWidth="1px" Width="420px">
                                                <table>
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label7" runat="server" Text="Report By :" Width="80px" CssClass="textlevel"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlReportBy" runat="server" Width="127px" CssClass="textlevelleft"
                                                                    OnSelectedIndexChanged="ddlReportBy_SelectedIndexChanged" AutoPostBack="True">
                                                                    <asp:ListItem Value="D">Office</asp:ListItem>
                                                                    <asp:ListItem Value="E">Employee</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 431px">
                                            <asp:Panel ID="PBranch" runat="server" BorderStyle="Solid" BorderColor="DarkGray"
                                                BorderWidth="1px" Width="420px">
                                                <table>
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label1" runat="server" Text="Office :" Width="80px" CssClass="textlevel"></asp:Label>
                                                            </td>
                                                            <td colspan="2">
                                                                <asp:DropDownList ID="ddlDivision" runat="server" Width="250px" AutoPostBack="True"
                                                                    CssClass="textlevelleft">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 431px">
                                            <asp:Panel ID="PDiv" runat="server" BorderStyle="Solid" BorderColor="DarkGray" BorderWidth="1px"
                                                Width="420px">
                                                <table>
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblDiv" runat="server" Text="Team :" Width="80px" CssClass="textlevel"></asp:Label>
                                                            </td>
                                                            <td colspan="2">
                                                                <asp:DropDownList ID="ddlSUB" runat="server" Width="250px" AutoPostBack="True" CssClass="textlevelleft">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 431px">
                                            <asp:Panel ID="PDept" runat="server" BorderStyle="Solid" BorderColor="DarkGray" BorderWidth="1px"
                                                Width="420px" Visible="False">
                                                <table>
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblLoc" runat="server" Text="Department :" Width="80px" CssClass="textlevel"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlDept" runat="server" Width="250px" AutoPostBack="True" CssClass="textlevelleft">
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
                                            <asp:Panel ID="PShift" runat="server" BorderStyle="Solid" BorderColor="DarkGray"
                                                BorderWidth="1px" Width="420px">
                                                <table>
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblShift" runat="server" Text="Shift :" Width="80px" CssClass="textlevel"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlShift" runat="server" Width="127px" CssClass="textlevelleft">
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
                                            <asp:Panel ID="PClosed" runat="server" BorderStyle="Solid" BorderColor="DarkGray"
                                                BorderWidth="1px" Width="420px">
                                                <table>
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label9" runat="server" Text="Job Status :" Width="80px" CssClass="textlevel"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlIsClosed" runat="server" Width="127px" CssClass="textlevelleft">
                                                                    <asp:ListItem Value="-1">All</asp:ListItem>
                                                                    <asp:ListItem Selected="True" Value="Regular">Regular</asp:ListItem>
                                                                    <asp:ListItem Value="Contractual">Contractual</asp:ListItem>
                                                                    <asp:ListItem Value="Probation">Probation</asp:ListItem>
                                                                    <asp:ListItem Value="Released">Released</asp:ListItem>
                                                                    <asp:ListItem Value="Removed">Removed</asp:ListItem>
                                                                    <asp:ListItem Value="Resigned">Resigned</asp:ListItem>
                                                                    <asp:ListItem Value="Retired">Retired</asp:ListItem>
                                                                    <asp:ListItem Value="Suspended">Suspended</asp:ListItem>
                                                                    <asp:ListItem Value="Unauthorized Absent">Unauthorized Absent</asp:ListItem>
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
                                            <asp:Panel ID="pDate" runat="server" BorderStyle="Solid" BorderColor="DarkGray" BorderWidth="1px"
                                                Width="420px">
                                                <table>
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 20px">
                                                                <asp:Label ID="Label4" runat="server" Text="From :" Width="80px" CssClass="textlevel"></asp:Label>
                                                            </td>
                                                            <td style="width: 66px">
                                                                <asp:TextBox ID="txtFromDate" runat="server" Width="80px" MaxLength="10"></asp:TextBox>
                                                            </td>
                                                            <td style="width: 70px">
                                                                <a href="javascript:NewCal('<%= txtFromDate.ClientID %>','ddmmyyyy')">
                                                                    <img style="border-right: 0px; border-top: 0px; border-left: 0px; border-bottom: 0px"
                                                                        height="16" alt="Pick a date" src="../images/cal.gif" width="16" /></a>
                                                            </td>
                                                            <td style="width: 5px">
                                                                <asp:Label ID="Label5" runat="server" Text="To :" CssClass="textlevel" Width="80px"></asp:Label>
                                                            </td>
                                                            <td style="width: 62px">
                                                                <asp:TextBox ID="txtToDate" runat="server" Width="80px" MaxLength="10"></asp:TextBox>
                                                            </td>
                                                            <td style="width: 99px">
                                                                <a href="javascript:NewCal('<%= txtToDate.ClientID %>','ddmmyyyy')">
                                                                    <img style="border-right: 0px; border-top: 0px; border-left: 0px; border-bottom: 0px"
                                                                        height="16" alt="Pick a date" src="../images/cal.gif" width="16" /></a>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtFromDate"
                                                    ValidChars="/" FilterType="Custom,Numbers" Enabled="true">
                                                </cc1:FilteredTextBoxExtender>
                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtToDate"
                                                    ValidChars="/" FilterType="Custom,Numbers" Enabled="true">
                                                </cc1:FilteredTextBoxExtender>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Panel ID="PEmp" runat="server" BorderStyle="Solid" BorderColor="DarkGray" BorderWidth="1px"
                                                Width="420px" Visible="False">
                                                <table>
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label6" runat="server" Text="Emp Id :" Width="80px" CssClass="textlevel"></asp:Label>
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
                                </tbody>
                            </table>
                            <div style="padding-right: 15px; float: right; width: 228px">
                                <table>
                                    <tbody>
                                        <tr>
                                            <td style="width: 3px">
                                                <asp:Panel ID="PShow" runat="server" Visible="False">
                                                    <asp:Button ID="btnShow" OnClick="btnShow_Click" runat="server" Text="Show Report"
                                                        Font-Underline="False"></asp:Button>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </fieldset>
        </div>
    </div>
</asp:Content>
