<%@ Page Title="" Language="C#" MasterPageFile="~/MasterBTMS.master" AutoEventWireup="true"
    CodeFile="TrainingBudget.aspx.cs" Inherits="Training_TrainingBudget" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../JScripts/datetimepicker.js">
        //Date Time Picker script
    </script>
    <script language="javascript" type="text/javascript" src="../JScripts/Confirmation.js">
        //Delete Confirmation Message
    </script>
    <div class="officeSetup" style="width: 57% !important;">
        <div id="formhead1">
            <div style="width: 96%; float: left;">
                Training Budget</div>
            <div style="margin: 2px; float: left; padding-right: 3px;">
                <a href="../Default.aspx">
                    <img src="../Images/close_icon.gif" /></a></div>
        </div>
        <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Width="100%" Height="560px">
            <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1" Width="100%" Height="560px">
                <HeaderTemplate>
                    Budget Setup
                </HeaderTemplate>
                <ContentTemplate>
                    <!--Div for group-->
                    <div class="MsgBox">
                        <!--Div for msg-->
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                    </div>
                    <div class="officeSetupInner">
                        <fieldset>
                            <!--Div for Controls-->
                            <asp:HiddenField ID="hfId" runat="server" />
                            <asp:HiddenField ID="hfIsUpdate" runat="server" />
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label5" runat="server" CssClass="textlevel" Text="Training Name :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlTrainingName" runat="server" CssClass="textlevelleft" Width="180px"
                                            ToolTip="Select Training Nmae" OnSelectedIndexChanged="ddlTrainingName_SelectedIndexChanged"
                                            AutoPostBack="true">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" CssClass="textlevel" Text="Training Schedule :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlSchedule" runat="server" CssClass="textlevelleft" Width="180px"
                                            ToolTip="Select Training Location" OnSelectedIndexChanged="ddlSchedule_SelectedIndexChanged"
                                            AutoPostBack="true">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" CssClass="textlevel" Text="Start Date :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtStrDate" runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                            ControlToValidate="txtStrDate"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" CssClass="textlevel" Text="End Date :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtEndDate" runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                            ControlToValidate="txtEndDate"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" CssClass="textlevel" Text="Duration :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDuration" runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label6" runat="server" CssClass="textlevel" Text="No Of Person :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNoOfPerson" runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label8" runat="server" CssClass="textlevel" Text="Funded By :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFundedBy" runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label7" runat="server" CssClass="textlevel" Text="Course Co-ordinator :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCourseCoordinator" runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label9" runat="server" CssClass="textlevel" Text="Venue Type :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtResidential" runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkInActive" runat="server" CssClass="textlevelleft" Text="Make Inactive" />
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                        <br />
                        <fieldset>
                            <table>
                                <tr>
                                    <td valign="top">
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label10" runat="server" CssClass="textlevel" Text="Fee / Person :"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtFeePP" runat="server" Width="200px" onkeydown="return (!(event.keyCode>=65) && event.keyCode!=32);"
                                                        MaxLength="9"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*"
                                                        ControlToValidate="txtFeePP"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label13" runat="server" CssClass="textlevel" Text="Other Income :"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtOtherIncome" runat="server" Width="200px" onkeydown="return (!(event.keyCode>=65) && event.keyCode!=32);"
                                                        MaxLength="9"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*"
                                                        ControlToValidate="txtOtherIncome"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label11" runat="server" CssClass="textlevel" Text="Income / Person :"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtIncomePP" runat="server" Width="200px" onkeydown="return (!(event.keyCode>=65) && event.keyCode!=32);"
                                                        MaxLength="9"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*"
                                                        ControlToValidate="txtIncomePP"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td valign="top">
                                   
                                        <asp:GridView ID="grCostHead" runat="server" DataKeyNames="HeadID,HeadName,DefaultAmt"
                                            AutoGenerateColumns="False" EmptyDataText="No Record Found" Font-Size="9px" ShowFooter="True">
                                            <HeaderStyle BackColor="#B3CDE4" Font-Bold="True"></HeaderStyle>
                                            <SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" CssClass="ListHeader" Font-Bold="True">
                                            </SelectedRowStyle>
                                            <AlternatingRowStyle BackColor="#EFF3FB"></AlternatingRowStyle>
                                            <FooterStyle BackColor="#B3CDE4" Font-Bold="True"></FooterStyle>
                                            <Columns>
                                                <asp:BoundField DataField="HeadName" HeaderText="Cost Head">
                                                    <ItemStyle CssClass="ItemStylecss" Width="100%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtHeadAmt" runat="server" Width="80px" Text='<%# Eval("DefaultAmt") %>' OnTextChanged="txtHeadAmt_TextChanged"
                                                        AutoPostBack="true"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                      
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                        <div class="DivCommand1">
                            <div class="DivCommandL">
                                <asp:Button ID="btnClear" runat="server" Text="Refresh" Width="70px" OnClick="btnClear_Click"
                                    CausesValidation="False" />
                            </div>
                            <div class="DivCommandR">
                                <asp:Button ID="btnSave" runat="server" Text="Save" Width="70px" OnClick="btnSave_Click" />
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" Width="70px" OnClientClick="javascript:return DeleteConfirmation();"
                                    OnClick="btnDelete_Click" />
                            </div>
                        </div>
                        <br />
                        <br />
                    </div>
                </ContentTemplate>
            </cc1:TabPanel>
            <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel1" Width="760px" Height="560px">
                <HeaderTemplate>
                    Budget List
                </HeaderTemplate>
                <ContentTemplate>
                    <div class="GridFormat3" style="height: 500px !important;">
                        <!--Grid view Code starts-->
                        <asp:GridView ID="grList" runat="server" DataKeyNames="BudgetId,TrainId,TrainName,ScheduleID,StrDate,EndDate,Duration,NoofPerson,CoordinatorName,FundedBy,Residential,FeePerPerson,IncomePerPerson,OtherIncome,IsActive,CostPerPerson"
                            AutoGenerateColumns="False" EmptyDataText="No Record Found" Font-Size="9px" Width="99%" 
                            OnRowCommand="grList_RowCommand">
                            <HeaderStyle BackColor="#B3CDE4" Font-Bold="True"></HeaderStyle>
                            <SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" CssClass="ListHeader" Font-Bold="True">
                            </SelectedRowStyle>
                            <AlternatingRowStyle BackColor="#EFF3FB"></AlternatingRowStyle>
                            
                            <Columns>
                                <asp:ButtonField CommandName="DoubleClick" HeaderText="Edit" Text="Edit">
                                    <ItemStyle CssClass="ItemStylecss" Width="8%" />
                                </asp:ButtonField>
                                <asp:BoundField DataField="TrainName" HeaderText="Training Name">
                                    <ItemStyle CssClass="ItemStylecss" Width="20%"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="StrDate" HeaderText="Start Date" DataFormatString="{0:dd/MM/yyyy}">
                                    <ItemStyle CssClass="ItemStylecss"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="EndDate" HeaderText="End Date" DataFormatString="{0:dd/MM/yyyy}">
                                    <ItemStyle CssClass="ItemStylecss"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Duration" HeaderText="Duration">
                                    <ItemStyle CssClass="ItemStylecssCenter"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="NoofPerson" HeaderText="No Of Person">
                                    <ItemStyle CssClass="ItemStylecssCenter"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="CoordinatorName" HeaderText="Coordinator">
                                    <ItemStyle CssClass="ItemStylecss"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="FundedBy" HeaderText="Funded By">
                                    <ItemStyle CssClass="ItemStylecss"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Residential" HeaderText="Venue Type">
                                    <ItemStyle CssClass="ItemStylecss"></ItemStyle>
                                </asp:BoundField>
                               <asp:BoundField DataField="CostPerPerson" HeaderText="Cost/Person">
                                    <ItemStyle CssClass="ItemStylecss"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="IsActive" HeaderText="Is Active">
                                    <ItemStyle CssClass="ItemStylecssCenter" Width="10%"></ItemStyle>
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                        <!--Grid view Code Ends-->
                    </div>
                </ContentTemplate>
            </cc1:TabPanel>
        </cc1:TabContainer>
    </div>
</asp:Content>
