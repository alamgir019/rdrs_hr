﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterBTMS.master" AutoEventWireup="true" CodeFile="TrainingPlan.aspx.cs" Inherits="Training_TrainingPlan" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../JScripts/Confirmation.js">
    </script>
    <script language="javascript" type="text/javascript" src="../JScripts/datetimepicker.js">
        //Date Time Picker script
    </script>

    <div class="officeSetup">
        <div id="formhead1">
            <div style="width: 96%; float: left;">
                Training Plan </div>
            <div style="margin: 2px; float: left; padding-right: 3px;">
                <a href="../Default.aspx">
                    <img src="../Images/close_icon.gif" /></a></div>
        </div>
        <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Width="100%"
                    Height="480px">
   <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1" Width="860px"
                        Height="400px">                                                                                                                                                                                                                            
    <HeaderTemplate>
            Training Plan Setup
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
                         <td><asp:Label ID="Label1" runat="server" CssClass="textlevel" Text="Training Name :"></asp:Label></td>                                 
                        <td>
                            <asp:DropDownList ID="ddlTrainingName" runat="server" CssClass="textlevelleft" Width="200px"
                                ToolTip="Select Training Nmae">
                            </asp:DropDownList>
                        </td>
                         <td><asp:Label ID="Label3" runat="server" CssClass="textlevel" Text="Tentative Date :"></asp:Label></td> 
                     <td>
                            <asp:TextBox ID="txtTentativeDate" runat="server" Width="89px" ></asp:TextBox>
                            <a href="javascript:NewCal('<%= txtTentativeDate.ClientID %>','ddmmyyyy')">
                               <img style="border-right: 0px; border-top: 0px; border-left: 0px; border-bottom: 0px"
                                    height="16" alt="Pick a date" src="../images/cal.gif" width="16" /></a>
                              <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtTentativeDate"
                                    CssClass="validator" ErrorMessage="Invalid" ValidationExpression="^(?=\d)(?:(?:31(?!.(?:0?[2469]|11))|(?:30|29)(?!.0?2)|29(?=.0?2.(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00)))(?:\x20|$))|(?:2[0-8]|1\d|0?[1-9]))([-./])(?:1[012]|0?[1-9])\1(?:1[6-9]|[2-9]\d)?\d\d(?:(?=\x20\d)\x20|$))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\x20[AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$"></asp:RegularExpressionValidator>
                      
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtTentativeDate"></asp:RequiredFieldValidator></td>
                    
                     <td>
                            <asp:CheckBox ID="chkInActive" runat="server" CssClass="textlevelleft" Text="Make Inactive" />
                        </td>  
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" CssClass="textlevel" Text="Participant Level :"></asp:Label>
                        </td>
                        <td>
                           <asp:DropDownList ID="ddlParticipantLevel" runat="server" CssClass="textlevelleft" Width="200px"
                                ToolTip="Select Training Nmae">
                            </asp:DropDownList>
                        </td>

                        <td>
                            <asp:Label ID="Label5" runat="server" CssClass="textlevel" Text="Venue :"></asp:Label>
                        </td>
                        <td>
                           <asp:DropDownList ID="ddlVenue" runat="server" CssClass="textlevelleft" Width="200px"
                                ToolTip="Select Training Nmae">
                            </asp:DropDownList>
                        </td>
                       </tr>
                       <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" CssClass="textlevel" Text="No of Participant :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNoofParticipant" runat="server" Width="200px" onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);" MaxLength="3"></asp:TextBox>
                         </td>
                         <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="txtNoofParticipant"></asp:RequiredFieldValidator>
                       
                            <asp:Label ID="Label7" runat="server" CssClass="textlevel" Text="Participant Matrix :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtParticipantMatrix" runat="server" Width="200px" MaxLength="50"></asp:TextBox>
                            </td>
                            <td>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtParticipantMatrix"></asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="Label8" runat="server" CssClass="textlevel" Text="Course Coordinator :"></asp:Label>
                        </td>
                        <td>
                           <asp:DropDownList ID="ddlCourseCoordinator" runat="server" CssClass="textlevelleft" Width="200px"
                                ToolTip="Select Training Nmae">
                            </asp:DropDownList>
                        </td>
                       <td>
                            <asp:Label ID="Label6" runat="server" CssClass="textlevel" Text="Remarks :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRemarks" runat="server" Width="200px" MaxLength="100"></asp:TextBox>
                             </td>  
                              <td><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="txtRemarks"></asp:RequiredFieldValidator>
                        </td>                       
                    </tr>
                </table>
            </fieldset>
            <br />
             <fieldset>
                <table>
                    <tr>
                        
                        <td>
                            <asp:Label ID="Label9" runat="server" CssClass="textlevel" Text="Respective Resource :"></asp:Label>
                        </td>
                        <td>
                           <asp:DropDownList ID="ddlRespectiveResource" runat="server" CssClass="textlevelleft" Width="200px"
                                ToolTip="Select Training Nmae">
                            </asp:DropDownList>
                        </td>
                        <td></td><td></td>
                         <td>
                            <asp:Button ID="btnAdd" runat="server" Text="Add" Width="60px" CausesValidation="False" OnClick="btnAdd_Click"/>
                       </td>
                    </tr>
                </table>
            </fieldset>
        </div>
        <div class="GridFormat1">
            <!--Grid view Code starts-->
            <asp:GridView ID="grList" runat="server" DataKeyNames="RespectiveResourceId,RespectiveResourceName" AutoGenerateColumns="False"
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
                     <asp:BoundField DataField="RespectiveResourceId" HeaderText="Respective Resource">
                        <ItemStyle CssClass="ItemStylecss" Width="30%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="RespectiveResourceName" HeaderText="Name">
                        <ItemStyle CssClass="ItemStylecss" Width="50%"></ItemStyle>
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
            <!--Grid view Code Ends-->
        </div>
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
                        Height="450px">                                                                                                                                                                                                                            
    <HeaderTemplate>
     Training Plan List
    </HeaderTemplate>
    <ContentTemplate>
    <div class="GridFormat3">
            <!--Grid view Code starts-->
            <asp:GridView ID="grTrainingPlan" runat="server" DataKeyNames="TrainingPlanId,TrainId,TrainName,TentativeDate,ParticipantLevel,DesigName,VenueId,VenueName,NoofParticipant,ParticipantMatrix,Remarks,CourseCoordinator,EmpName,IsActive" AutoGenerateColumns="False"
                EmptyDataText="No Record Found" Font-Size="9px" Width="99%" 
                onrowcommand="grTrainingPlan_RowCommand">
                <HeaderStyle BackColor="#B3CDE4" Font-Bold="True"></HeaderStyle>
                <SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" CssClass="ListHeader" Font-Bold="True">
                </SelectedRowStyle>
                <AlternatingRowStyle BackColor="#EFF3FB"></AlternatingRowStyle>
                <Columns>
                    <asp:ButtonField CommandName="DoubleClick" HeaderText="Edit" Text="Edit">
                        <ItemStyle CssClass="ItemStylecss" Width="10%" />
                    </asp:ButtonField>
                     <asp:BoundField DataField="TrainName" HeaderText="Train Name">
                        <ItemStyle CssClass="ItemStylecss" Width="80%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="TentativeDate" HeaderText="Tentative Date">
                        <ItemStyle CssClass="ItemStylecss" Width="80%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="DesigName" HeaderText="Participant Level">
                        <ItemStyle CssClass="ItemStylecss" Width="80%"></ItemStyle>
                    </asp:BoundField>
                     <asp:BoundField DataField="VenueName" HeaderText="Venue">
                        <ItemStyle CssClass="ItemStylecss" Width="80%"></ItemStyle>
                    </asp:BoundField>
                     <asp:BoundField DataField="NoofParticipant" HeaderText="No of Participant">
                        <ItemStyle CssClass="ItemStylecss" Width="80%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="ParticipantMatrix" HeaderText="Participant Matrix">
                        <ItemStyle CssClass="ItemStylecss" Width="80%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="Remarks" HeaderText="Remarks">
                        <ItemStyle CssClass="ItemStylecss" Width="80%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="EmpName" HeaderText="Course Coordinator">
                        <ItemStyle CssClass="ItemStylecss" Width="80%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="IsActive" HeaderText="Is Active">
                        <ItemStyle CssClass="ItemStylecss" Width="80%"></ItemStyle>
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
     </ContentTemplate>
   </cc1:TabPanel>
  </cc1:TabContainer>  
    </div>
</asp:Content>





