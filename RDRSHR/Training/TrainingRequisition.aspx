<%@ Page Title="" Language="C#" MasterPageFile="~/MasterBTMS.master" AutoEventWireup="true" CodeFile="TrainingRequisition.aspx.cs" Inherits="Training_TrainingRequisition" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../JScripts/Confirmation.js">
    </script>
    <div class="officeSetup">
        <div id="formhead1">
            <div style="width: 96%; float: left;">
                Training Requsition</div>
            <div style="margin: 2px; float: left; padding-right: 3px;">
                <a href="../Default.aspx">
                    <img src="../Images/close_icon.gif" /></a></div>
        </div>
   <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Width="100%"
                    Height="520px">
   <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1" Width="860px"
                        Height="500px">                                                                                                                                                                                                                            
    <HeaderTemplate>
            Add Requisition
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
               <asp:HiddenField ID="hfTrainingId" runat="server" />
                <table>

                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" CssClass="textlevel" Text="Schedule ID:"></asp:Label>
                        </td>
                        <td>
                        <asp:DropDownList ID="ddlSchedule" runat="server" CssClass="textlevelleft" Width="200px" OnSelectedIndexChanged="ddlSchedule_SelectedIndexChanged"
                                 AutoPostBack="True" ToolTip="Select Training Schedule">
                            </asp:DropDownList>
                            
                        </td>
                        <td></td>
                        <td >
                            <asp:CheckBox ID="chkInActive" runat="server" CssClass="textlevel" Text="Make Inactive" />
                        </td>
                    </tr>
                    <tr>                                               
                        <td> <asp:Label ID="Label4" runat="server" CssClass="textlevel" Text="Training Name :"></asp:Label></td>
                        <td><asp:TextBox ID="txtTrainingName" CssClass="textlevelleft" runat="server" Width="200px" ReadOnly="true" ></asp:TextBox></td>
                         <td><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="txtTrainingName"></asp:RequiredFieldValidator></td>
                         
                        <td> <asp:Label ID="Label10" runat="server" CssClass="textlevel" Text="Training Location :"></asp:Label></td>
                        <td><asp:TextBox ID="txtTrainingLocation" CssClass="textlevelleft" runat="server" Width="200px" ReadOnly="true" ></asp:TextBox></td>
                        <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtTrainingLocation"></asp:RequiredFieldValidator></td>
                    </tr>
                       </table>
            </fieldset>
            <br />
            <fieldset>
               <table>
            
                    <tr>
                        <td> <asp:Label ID="Label1" runat="server" CssClass="textlevel" Text="Employee Name :"></asp:Label></td>
                        <td> <asp:DropDownList ID="ddlTraineeName" CssClass="textlevelleft" runat="server" Width="200px"
                                ToolTip="Select Trainee Name">
                            </asp:DropDownList></td>
                            <td></td>
                         <td><asp:Label ID="Label12" runat="server" CssClass="textlevel" Text="Funded Type :"></asp:Label></td>
                     <td> <asp:DropDownList ID="ddlFundType" runat="server" AutoPostBack="true" CssClass="textlevelleft" Width="200px" OnSelectedIndexChanged="ddlFundType_SelectedIndexChanged"
                                  ToolTip="Select Funded By">
                                  <asp:ListItem Value="0">Nil</asp:ListItem>
                                  <asp:ListItem Value="D">Donar</asp:ListItem>
                                  <asp:ListItem Value="P">Project</asp:ListItem>
                                  </asp:DropDownList></td>
                        
                    </tr>
                    <tr>
                        <td> <asp:Label ID="Label11" runat="server" CssClass="textlevel" Text="project Name :"></asp:Label></td>
                         <td> <asp:DropDownList ID="ddlProject" CssClass="textlevelleft" runat="server" Width="200px"
                                ToolTip="Select Project Name">
                                <asp:ListItem Value="-1">Nil</asp:ListItem>
                            </asp:DropDownList></td>
                        
                        <td>
                           
                         <td> <asp:Label ID="Label13" runat="server" CssClass="textlevel" Text="Donar Name :"></asp:Label></td>
                         <td> <asp:DropDownList ID="ddlProjectDonar" CssClass="textlevelleft" runat="server" Width="200px"
                                ToolTip="Select Project Name">
                                 <asp:ListItem Value="-1">Nil</asp:ListItem>
                            </asp:DropDownList></td>
                         <td>
                        <asp:Button ID="btnAdd" runat="server" Text="Add" Width="60px" 
                                CausesValidation="False" onclick="btnAdd_Click" />
                       </td>
                    </tr>

                </table>
            </fieldset>
        </div>
        <div class="GridFormat1">
            <!--Grid view Code starts-->

            <asp:GridView ID="grList" runat="server" DataKeyNames="EmpID,EmpName,ProjectId,ProjectName,FundType" AutoGenerateColumns="False"
                EmptyDataText="No Record Found" Font-Size="9px" Width="99%" 
                onrowcommand="grList_RowCommand" OnRowDeleting="grList_RowDeleting">
                <HeaderStyle BackColor="#B3CDE4" Font-Bold="True"></HeaderStyle>
                <SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" CssClass="ListHeader" Font-Bold="True">
                </SelectedRowStyle>
                <AlternatingRowStyle BackColor="#EFF3FB"></AlternatingRowStyle>
                <Columns>
                    <asp:ButtonField CommandName="DoubleClick" HeaderText="Edit" Text="Edit">
                        <ItemStyle CssClass="ItemStylecss" Width="10%" />
                    </asp:ButtonField>
                    <asp:ButtonField CommandName="Delete" HeaderText="Delete" Text="Delete">
                        <ItemStyle CssClass="ItemStylecss" Width="10%" />
                    </asp:ButtonField>
                    <asp:BoundField DataField="EmpName" HeaderText="Employee Name">
                        <ItemStyle CssClass="ItemStylecss" Width="30%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="FundType" HeaderText="Fund Type">
                        <ItemStyle CssClass="ItemStylecss" Width="30%"></ItemStyle>
                    </asp:BoundField> 
                      <asp:BoundField DataField="ProjectName" HeaderText="Project Name">
                        <ItemStyle CssClass="ItemStylecss" Width="30%"></ItemStyle>
                    </asp:BoundField>                   
                </Columns>
            </asp:GridView>
            <!--Grid view Code Ends-->
        </div> 
       
         <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" CssClass="textlevel" Text="Sigen By1 :"></asp:Label>
                        </td>
                        <td> <asp:DropDownList ID="ddlSigenBy1" CssClass="textlevelleft" runat="server" Width="200px"
                                ToolTip="Select Trainee Name"></asp:DropDownList></td>
                        
                        <td>
                            <asp:Label ID="Label5" runat="server" CssClass="textlevel" Text="Sigen By2 :"></asp:Label>
                        </td>
                        <td> <asp:DropDownList ID="ddlSigenBy2" CssClass="textlevelleft" runat="server" Width="200px"
                                ToolTip="Select Trainee Name"></asp:DropDownList>
                        </td>                       
                    </tr>
                     <tr>
                        <td>
                            <asp:Label ID="Label7" runat="server" CssClass="textlevel" Text="Seen By :"></asp:Label>
                        </td>
                       
                       <td> <asp:DropDownList ID="ddlSeenBy" CssClass="textlevelleft" runat="server" Width="200px"
                                ToolTip="Select Trainee Name">
                            </asp:DropDownList>
                       </td>
                       
                        <td>
                            <asp:Label ID="Label6" runat="server" CssClass="textlevel" Text="Review By :"></asp:Label>
                        </td>
                        <td> <asp:DropDownList ID="ddlReviewBy" CssClass="textlevelleft" runat="server" Width="200px"
                                ToolTip="Select Trainee Name">
                            </asp:DropDownList>
                        </td>                       
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="Label8" runat="server" CssClass="textlevel" Text="Recomanded By :"></asp:Label>
                        </td>
                        <td> <asp:DropDownList ID="ddlRecomandedBy" CssClass="textlevelleft" runat="server" Width="200px"
                                ToolTip="Select Trainee Name">
                            </asp:DropDownList>
                       </td>
                     
                        
                        <td>
                            <asp:Label ID="Label9" runat="server" CssClass="textlevel" Text="Approve By :"></asp:Label>
                        </td>
                        <td> <asp:DropDownList ID="ddlApproveBy" CssClass="textlevelleft" runat="server" Width="200px"
                                ToolTip="Select Trainee Name">
                            </asp:DropDownList>
                        </td>
                   
                        
                    </tr>
          </table>
        
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
    </ContentTemplate>
   </cc1:TabPanel>
 <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel1" Width="860px"
                        Height="500px">                                                                                                                                                                                                                            
    <HeaderTemplate>
     Requisition List
    </HeaderTemplate>
    <ContentTemplate>
    <div class="GridFormat3">
            <!--Grid view Code starts-->

            <asp:GridView ID="grRequisition" runat="server" DataKeyNames="ReqID,ScheduleID,ScheduleName,TrainId,TrainName,TrainLocation,SignDesig1,SignDesig2,SeenBy,ReviewBy,RecommendBy,ApprovBy,IsActive" AutoGenerateColumns="False"
                EmptyDataText="No Record Found" Font-Size="9px" Width="99%" 
                onrowcommand="grRequisition_RowCommand" >
                <HeaderStyle BackColor="#B3CDE4" Font-Bold="True"></HeaderStyle>
                <SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" CssClass="ListHeader" Font-Bold="True">
                </SelectedRowStyle>
                <AlternatingRowStyle BackColor="#EFF3FB"></AlternatingRowStyle>
                <Columns>
                    <asp:ButtonField CommandName="DoubleClick" HeaderText="Edit" Text="Edit">
                        <ItemStyle CssClass="ItemStylecss" Width="10%" />
                    </asp:ButtonField>
                    <asp:BoundField DataField="ScheduleName" HeaderText="Schedule Name">
                        <ItemStyle CssClass="ItemStylecss" Width="30%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="TrainName" HeaderText="Training Name">
                        <ItemStyle CssClass="ItemStylecss" Width="30%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="TrainLocation" HeaderText="Training Location">
                        <ItemStyle CssClass="ItemStylecss" Width="30%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="SignDesig1Name" HeaderText="Signed By1">
                        <ItemStyle CssClass="ItemStylecss" Width="30%"></ItemStyle>
                    </asp:BoundField>  
                    <asp:BoundField DataField="SignDesig2Name" HeaderText="Signed By2">
                        <ItemStyle CssClass="ItemStylecss" Width="30%"></ItemStyle>
                    </asp:BoundField>  
                    <asp:BoundField DataField="SeenByName" HeaderText="Seen By">
                        <ItemStyle CssClass="ItemStylecss" Width="30%"></ItemStyle>
                    </asp:BoundField>    
                    <asp:BoundField DataField="ReviewByName" HeaderText="Review By">
                        <ItemStyle CssClass="ItemStylecss" Width="30%"></ItemStyle>
                    </asp:BoundField>   
                    <asp:BoundField DataField="RecommendByName" HeaderText="Recommend By">
                        <ItemStyle CssClass="ItemStylecss" Width="30%"></ItemStyle>
                    </asp:BoundField>    
                    <asp:BoundField DataField="ApprovByName" HeaderText="Approve By">
                        <ItemStyle CssClass="ItemStylecss" Width="30%"></ItemStyle>
                    </asp:BoundField>  
                    <asp:BoundField DataField="IsActive" HeaderText="Is Active">
                        <ItemStyle CssClass="ItemStylecssCenter" Width="30%"></ItemStyle>
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




