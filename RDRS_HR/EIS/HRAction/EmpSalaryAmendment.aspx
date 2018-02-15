﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterBTMS.master" AutoEventWireup="true" CodeFile="EmpSalaryAmendment.aspx.cs" Inherits="EIS_HRAction_EmpSalaryAmendment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript" src="../../JScripts/datetimepicker.js">
        //Date Time Picker script
    </script>

    <script language="javascript" type="text/javascript" src="../../JScripts/Confirmation.js">
    </script>

  
    <div class="empTrainForm">
        <div id="formhead1">
            <div style="width: 97%; float: left;">
                Salary Amendment</div>
            <div style="margin: 2px; float: left; padding-right: 3px;">
                <a href="../../Default.aspx">
                    <img src="../../Images/close_icon.gif" /></a></div>
    </div>
        <div class="MsgBox">
            <asp:Label ID="lblMsg" runat="server" CssClass="msglabel"></asp:Label>
        </div>
        <div id="PayrollConfigInner">
            <div style="background-color: #EFF3FB; margin-bottom: 10px">
                <fieldset>
                    <table>
                        <tr>
                            <td class="textlevel">
                                Emp Code :</td>
                            <td>
                                <asp:TextBox ID="txtEmpID" runat="server" MaxLength="20" onkeyup="ToUpper(this)"
                                    Width="80px" ToolTip="Enter the Emp. Code and click on Find Button. Details of the find employee will be shown in employee general information screen if information exists. In order to enter employee."></asp:TextBox>
                            </td>
                            <td>
                                <asp:ImageButton ID="imgBtnSearch" runat="server" Height="19px" ImageUrl="~/Images/Search_Icon.jpg"
                                    OnClick="imgBtnSearch_Click" ToolTip="Enter the Emp. Code and click on Find Button. Details of the find employee will be shown in employee general information screen if information exists. In order to enter employee." /></td>
                            <td>
                                <asp:RequiredFieldValidator ID="ReqFieldVal" runat="server" ErrorMessage="*" ControlToValidate="txtEmpID"></asp:RequiredFieldValidator></td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td class="textlevel">
                                Name :</td>
                            <td>
                                <asp:Label ID="lblName" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="textlevel">
                                Office :</td>
                            <td>
                                <asp:Label ID="lblOffice_Loc" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="textlevel">
                                Project/Designation :</td>
                            <td>
                                <asp:Label ID="lblDeg_Project" runat="server"></asp:Label></td>
                        </tr>    
                         <tr>
                            <td class="textlevel">
                                Basic Salary :</td>
                            <td>
                                <asp:Label ID="lblBasic" runat="server"></asp:Label></td>
                        </tr>                   
                        <tr>
                            <td class="textlevel">
                                Gross Salary :</td>
                            <td>
                                <asp:TextBox ID="lblGross" runat="server" Enabled="false" ClientIDMode="Static"></asp:TextBox></td>
                        </tr>
                        
                        <tr>
                            <td class="textlevel">
                                Salary Package :</td>
                            <td>
                                <asp:Label ID="lblSalPac" runat="server"></asp:Label></td>
                        </tr>
                    </table>
                </fieldset>
            </div>
            <fieldset style="margin-bottom: 10px;">
                <legend>Salary Amendment Details</legend>
                <table>
                    <tr>
                        <td class="textlevel">
                            Name of Action :</td>
                        <td>
                            <asp:DropDownList ID="ddlAction" runat="server" Width="300px" ToolTip="Select the name of action for confirmation from the list.">
                            </asp:DropDownList>
                            
                            </td>
                    </tr>
                   <tr>
                        <td class="textlevel">
                            Grade :</td>
                        <td>
                            <asp:DropDownList ID="ddlGrade" runat="server" Width="300px" ToolTip="." 
                                onselectedindexchanged="ddlGrade_SelectedIndexChanged" AutoPostBack="True">
                            </asp:DropDownList>
                            
                            </td>
                    </tr>
                     <tr>
                        <td class="textlevel">
                            Grade Step :</td>
                        <td>
                            <asp:DropDownList ID="ddlGradeLevel" runat="server" Width="300px" ToolTip="." 
                                AutoPostBack="True" onselectedindexchanged="ddlGradeLevel_SelectedIndexChanged">
                            </asp:DropDownList>
                            
                            </td>
                    </tr>
                     <tr>
                        <td class="textlevel">
                            New Basic Salary :
                        </td>
                        <td class="textlevelleft">
                            <asp:TextBox ID="txtBasicSalary" runat="server" CssClass="TextBoxAmt60" 
                                Width="80px"  ClientIDMode="Static" OnChange="CalculateGross();"></asp:TextBox>
                            BDT</td>
                    </tr>
                     <tr>
                        <td class="textlevel">
                            New House Rent :
                        </td>
                        <td class="textlevelleft">
                            <asp:TextBox ID="txtHouseRent" runat="server" CssClass="TextBoxAmt60" Width="80px" ClientIDMode="Static" OnChange="CalculateGross();"></asp:TextBox>
                            BDT</td>
                    </tr>
                     <tr>
                        <td class="textlevel">
                            New Medical :
                        </td>
                        <td class="textlevelleft">
                            <asp:TextBox ID="txtMedical" runat="server" CssClass="TextBoxAmt60" Width="80px" ClientIDMode="Static" OnChange="CalculateGross();" ></asp:TextBox>
                            BDT</td>
                    </tr>
                     <tr>
                        <td class="textlevel">
                            New Conveyance :
                        </td>
                        <td class="textlevelleft">
                            <asp:TextBox ID="txtConveyance" runat="server" CssClass="TextBoxAmt60" Width="80px" ClientIDMode="Static" OnChange="CalculateGross();" ></asp:TextBox>
                            BDT</td>
                    </tr>
                    <tr>
                        <td class="textlevel">
                            New Gross Salary :
                        </td>
                        <td class="textlevelleft">
                            <asp:TextBox ID="txtGrossSal" runat="server" CssClass="TextBoxAmt60" Width="80px" ClientIDMode="Static" Enabled="false" ></asp:TextBox>
                            BDT</td>
                    </tr>
                    
                    <tr>
                        <td class="textlevel">
                            Increment Percentage :</td>
                        <td class="textlevelleft">
                            <asp:TextBox ID="txtIncPercentage" runat="server" CssClass="TextBoxAmt60" ClientIDMode="Static"   Enabled="false"
                                ></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td class="textlevel">
                            Effective Date :</td>
                        <td>
                            <asp:TextBox ID="txtEffDate" runat="server" Width="80px" ToolTip="Input the Effective date."></asp:TextBox>
                            <a href="javascript:NewCal('<%= txtEffDate.ClientID %>','ddmmyyyy')">
                                <img style="border: 0px;" height="16" alt="Pick a date" src="../../images/cal.gif" width="16" /></a>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtEffDate"
                                CssClass="validator" ErrorMessage="Invalid Date" ValidationExpression="^(?=\d)(?:(?:31(?!.(?:0?[2469]|11))|(?:30|29)(?!.0?2)|29(?=.0?2.(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00)))(?:\x20|$))|(?:2[0-8]|1\d|0?[1-9]))([-./])(?:1[012]|0?[1-9])\1(?:1[6-9]|[2-9]\d)?\d\d(?:(?=\x20\d)\x20|$))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\x20[AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$"></asp:RegularExpressionValidator></td>
                    </tr>
                    <tr>
                        <td class="textlevel">
                            Remarks :</td>
                        <td class="textlevelleft">
                            <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" Width="415px"></asp:TextBox></td>
                    </tr>
                </table>
                <asp:HiddenField ID="hfIsUpdate" runat="server" />
                <asp:HiddenField ID="hfID" runat="server" />
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom,Numbers"
                    TargetControlID="txtBasicSalary" ValidChars="0123456789">
                </cc1:FilteredTextBoxExtender>
                 <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Custom,Numbers"
                    TargetControlID="txtHouseRent" ValidChars="0123456789">
                </cc1:FilteredTextBoxExtender>
                 <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterType="Custom,Numbers"
                    TargetControlID="txtMedical" ValidChars="0123456789">
                </cc1:FilteredTextBoxExtender>
                 <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" FilterType="Custom,Numbers"
                    TargetControlID="txtConveyance" ValidChars="0123456789">
                </cc1:FilteredTextBoxExtender>
                 <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" FilterType="Custom,Numbers"
                    TargetControlID="txtGrossSal" ValidChars="0123456789">
                </cc1:FilteredTextBoxExtender>
            </fieldset>
            <fieldset>
                <legend>Salary Amendment List</legend>
                <div style="overflow: scroll; width: 98%; height: 250px">
                    <asp:GridView ID="grConfirmation" runat="server" Width="100%" Font-Size="9px" EmptyDataText="No Record Found"
                        AutoGenerateColumns="False" DataKeyNames="LogId,ActionId,NewBasic,NewHouseRent,NewMedical,NewConveyance,NewGross,IncAmount,IncPercent,Remarks" OnRowCommand="grConfirmation_RowCommand"
                        ToolTip="8.&#9;You will find the entire existing advice list of the employee. Click on any confirmation Edit link from the list.">
                        <HeaderStyle BackColor="#B3CDE4" Font-Bold="True"></HeaderStyle>
                        <SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" CssClass="ListHeader" Font-Bold="True">
                        </SelectedRowStyle>
                        <AlternatingRowStyle BackColor="#EFF3FB"></AlternatingRowStyle>
                        <Columns>
                            <asp:ButtonField CommandName="DoubleClick" HeaderText="Edit" Text="Edit">
                                <ItemStyle Width="5%" CssClass="ItemStylecss" />
                            </asp:ButtonField>
                            <asp:BoundField DataField="ActionName" HeaderText="Action Name">
                                <ItemStyle CssClass="ItemStylecss" Width="15%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="ActionDate" HeaderText="Action Date">
                                <ItemStyle CssClass="ItemStylecss" Width="15%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="NewBasic" HeaderText="New Basic">
                                <ItemStyle CssClass="ItemStylecssRight" Width="10%"></ItemStyle>
                            </asp:BoundField>
                             <asp:BoundField DataField="NewGross" HeaderText="New Gross">
                                <ItemStyle CssClass="ItemStylecssRight" Width="10%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="IncAmount" HeaderText="Increment Amount">
                                <ItemStyle CssClass="ItemStylecssRight" Width="10%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="IncPercent" HeaderText="Increment %">
                                <ItemStyle CssClass="ItemStylecssRight" Width="10%"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Remarks" HeaderText="Remarks">
                                <ItemStyle CssClass="ItemStylecss" Width="25%"></ItemStyle>
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </div>
            </fieldset>
        </div>
        <div class="DivCommand1" style="width: 92%;">
            <div class="DivCommandL">
                <asp:Button ID="btnRefresh" runat="server" CausesValidation="False" Text="Refresh"
                    Width="70px" OnClick="btnRefresh_Click" ToolTip="Click on Save Button to store the employee data." />
            </div>
            <div class="DivCommandR">
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClientClick="javascript:return HistorySaveConfirmation();"
                    Width="70px" OnClick="btnSave_Click" ToolTip="Click on Save Button to store the employee data." />
                <%--<asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" OnClientClick="javascript:return DeleteConfirmation();"
                Text="Delete" Width="70px" />--%>
            </div>
        </div>
    </div>
     <script language="javascript" type="text/javascript">
         function ToUpper(ctrl) {
             var t = ctrl.value;
             ctrl.value = t.toUpperCase();
         }

         function CalculateGross() {
             var basic = document.getElementById('<%= txtBasicSalary.ClientID %>').value;
             var house = document.getElementById('<%= txtHouseRent.ClientID %>').value;
             var medical = document.getElementById('<%= txtMedical.ClientID %>').value;
             var convey = document.getElementById('<%= txtConveyance.ClientID %>').value;
             var prevgross = document.getElementById('<%= lblGross.ClientID %>').value;
             var newgross = (basic * 1) + (house * 1) + (medical * 1) + (convey * 1);
             document.getElementById('<%= txtGrossSal.ClientID %>').value = newgross;
             var percent = (((newgross * 1) - (prevgross * 1)) * 100) / (prevgross * 1);
             document.getElementById('<%= txtIncPercentage.ClientID %>').value = percent.toFixed(2) || 0;
         }
         CalculateGross();

    </script>
</asp:Content>

 
