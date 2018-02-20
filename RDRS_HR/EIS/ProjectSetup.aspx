<%@ Page Title="" Language="C#" MasterPageFile="~/MasterBTMS.master" AutoEventWireup="true" CodeFile="ProjectSetup.aspx.cs" Inherits="EIS_ProjectSetup" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <%@ register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
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
     
    <div class="setup">
        <div id='formhead1'>
            <div style="width: 96%; float: left;">
                Project Setup</div>
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
                        <td>
                            <asp:Label ID="Label2" runat="server" Width="100px" CssClass="textlevel" Text="Name :"></asp:Label>
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="txtProject" runat="server" Width="320px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtProject"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                     <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Width="100px" CssClass="textlevel" Text="Short Name :"></asp:Label>
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="txtSName" runat="server" Width="320px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSName"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server"  Width="100px" CssClass="textlevel" Text="Code :"></asp:Label>
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="txtProjectCode" runat="server" Width="100px"></asp:TextBox>
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
                                            ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtStartDate"
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
                                            ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtEndDate"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                        &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEndDate"
                                            CssClass="validator" ErrorMessage="Invalid" ValidationExpression="^(?=\d)(?:(?:31(?!.(?:0?[2469]|11))|(?:30|29)(?!.0?2)|29(?=.0?2.(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00)))(?:\x20|$))|(?:2[0-8]|1\d|0?[1-9]))([-./])(?:1[012]|0?[1-9])\1(?:1[6-9]|[2-9]\d)?\d\d(?:(?=\x20\d)\x20|$))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\x20[AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$"></asp:RegularExpressionValidator>
                                        &nbsp;
                                    </td>
                                </tr>
                             </table> 
                            </td>
                     </tr>
                                         
                      <tr>
                        <td style="text-align:right; vertical-align:top;">
                        <asp:Label ID="Label10" runat="server" Width="100px" CssClass="textlevel" 
                                Text="Benefits :"></asp:Label>
                        </td>
                      <td colspan="3">
                       <fieldset>
                      <table>
                        <tr>
                            
                            <td> <asp:CheckBox ID="chkPF" runat="server" Text="PF" /> </td>
                            <td><asp:CheckBox ID="chkGratuity" runat="server" Text="Gratuity"/></td>
                            <%--<td> <asp:CheckBox ID="chkEL" runat="server" Text="Earn Leave Encash" 
                                    Visible="False" /></td>--%>
                        </tr>
                        <%--<tr>
                            
                            <td> <asp:CheckBox ID="chkInsurance" runat="server" Text="Insurance" 
                                    Visible="False" /> </td>
                            <td><asp:CheckBox ID="chkGrossSalary" runat="server" Text="Gross Salary" 
                                    Visible="False"/></td>
                            <td><asp:CheckBox ID="chkBasicSalary" runat="server" Text="Basic Salary" 
                                    Visible="False" /></td>
                        </tr>--%>
                        </table>
                        </fieldset>
                      </td>
                      </tr>
                      
                     <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:CheckBox ID="ChkIsActive" Text="Make Inactive" CssClass="textlevelleft" runat="server" />
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>

                    </tr>

                     
                     <%--<tr>
                        <td>
                            <asp:Label ID="Label5" runat="server" Width="100px" CssClass="textlevel" 
                                Text="Weekend :" Visible="False"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlWeekend" CssClass="textlevelleft" runat="server" 
                                Width="127px" Visible="False">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="Label6" runat="server" Width="90px" CssClass="textlevel" 
                                Text="Increment Type :" Visible="False"></asp:Label>
                        </td>
                        <td>
                           <asp:DropDownList ID="ddlIncrement" runat="server" Width="127px" 
                                CssClass="textlevelleft" Visible="False">
                                    <asp:ListItem Value="1">General</asp:ListItem>
                                    <asp:ListItem Value="2">Conditional</asp:ListItem>
                                </asp:DropDownList>
                        </td>

                    </tr>--%>

                     
                     <%--<tr>
                        <td>
                            <asp:Label ID="Label7" runat="server" Width="100px" CssClass="textlevel" 
                                Text="Increment Month :" Visible="False"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlIncrMonth" runat="server" Width="127px" 
                                CssClass="textlevelleft" Visible="False">
                                    <asp:ListItem Value="1">January</asp:ListItem>
                                    <asp:ListItem Value="2">February</asp:ListItem>
                                    <asp:ListItem Value="3">March</asp:ListItem>
                                    <asp:ListItem Value="4">April</asp:ListItem>
                                    <asp:ListItem Value="5">May</asp:ListItem>
                                    <asp:ListItem Value="6">June</asp:ListItem>
                                    <asp:ListItem Value="7">July</asp:ListItem>
                                    <asp:ListItem Value="8">August</asp:ListItem>
                                    <asp:ListItem Value="9">September</asp:ListItem>
                                    <asp:ListItem Value="10">October</asp:ListItem>
                                    <asp:ListItem Value="11">November</asp:ListItem>
                                    <asp:ListItem Value="12">Ddecember</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="Label8" runat="server" Width="90px" CssClass="textlevel" 
                                Text="Increment After :" Visible="False"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtIncrementYear" runat="server" Width="100px" Visible="False"></asp:TextBox> &nbsp;</td>
                    </tr>
                   
                    <tr>
                        <td>
                            <asp:CheckBox ID="chkEOC" runat="server" Text="End of Contract (EOC)" 
                                Visible="False" />
                        </td>
                        <td>
                            <asp:CheckBox ID="chkCore" runat="server" Text="Core" Visible="False"/>
                        </td>
                        <td>
                            <asp:CheckBox ID="chkProject" runat="server" Text="Project" Visible="False" />
                        </td>
                    </tr>--%>
                </table>
                <%--<cc1:filteredtextboxextender ID="FTBIncrementYear" runat="server" FilterType="Numbers"
                        TargetControlID="txtIncrementYear" ValidChars="0123456789">
                    </cc1:filteredtextboxextender>--%>
            </fieldset>
        </div>
        <div class="GridFormat1">
            <!--Grid view Code starts-->
            <asp:GridView ID="grProject" runat="server" 
            DataKeyNames="ProjectId, ProjectName, ProjectCode, StartDate, EndDate, IsPF, IsGratuity,ShortName"
                AutoGenerateColumns="False" EmptyDataText="No Record Found" Font-Size="9px" Width="100%"
                OnRowCommand="grProject_RowCommand">
                <HeaderStyle BackColor="#B3CDE4" Font-Bold="True"></HeaderStyle>
                <SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" CssClass="ListHeader" Font-Bold="True">
                </SelectedRowStyle>
                <AlternatingRowStyle BackColor="#EFF3FB"></AlternatingRowStyle>
                <Columns>
                    <asp:ButtonField CommandName="DoubleClick" HeaderText="Edit" Text="Edit">
                        <ItemStyle CssClass="ItemStylecss" Width="8%" />
                    </asp:ButtonField>
                    <asp:BoundField DataField="ProjectName" HeaderText="Name">
                        <ItemStyle CssClass="ItemStylecss" Width="20%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="ProjectCode" HeaderText="Code">
                        <ItemStyle CssClass="ItemStylecss" Width="8%"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="StartDate" HeaderText="Start Date" DataFormatString="{0:dd/MM/yyyy}">
                        <ItemStyle CssClass="ItemStylecss" Width="12%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="EndDate" HeaderText="End Date" DataFormatString="{0:dd/MM/yyyy}">
                        <ItemStyle CssClass="ItemStylecss" Width="12%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="IsActive" HeaderText="Is Active">
                        <ItemStyle CssClass="ItemStylecss" Width="8%"></ItemStyle>
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
            <!--Grid view Code Ends-->
        </div>
        <div class="DivCommand1">
            <div class="DivCommandL">
                <asp:Button ID="btnClear" runat="server" Text="Refresh" Width="70px" OnClick="btnClear_Click"
                    CausesValidation="false" UseSubmitBehavior="False" />
            </div>
            <div class="DivCommandR">
                <asp:Button ID="btnSave" runat="server" Text="Save" Width="70px" OnClick="btnSave_Click" />
                <asp:Button ID="btnDelete" runat="server" Text="Delete" Width="70px" OnClientClick="javascript:return DeleteConfirmation();"
                    OnClick="btnDelete_Click" />
            </div>
            <br/>
        </div>
    </div>
    
</asp:Content>





