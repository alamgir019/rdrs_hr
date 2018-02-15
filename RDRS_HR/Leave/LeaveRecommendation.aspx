<%@ Page Language="C#" MasterPageFile="~/MasterBTMS.master" AutoEventWireup="true"
    CodeFile="LeaveRecommendation.aspx.cs" Inherits="Leave_LeaveRecommendation" Title="Leave Recommendation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
        function ToUpper(ctrl) {
            var t = ctrl.value;
            ctrl.value = t.toUpperCase();
        }
    </script>
    <div class="formStyle">
        <div id='formhead4'>
            Leave Recommendation</div>
        <div class="iesEmp">
            <!--Div for group-->
            <asp:UpdateProgress ID="UpProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel1"
                DisplayAfter="0">
                <ProgressTemplate>
                    <div style="position: absolute; visibility: visible; border: none; z-index: 100;
                        width: 100%; height: 100%; background: #999; filter: alpha(opacity=80); -moz-opacity: .8;
                        opacity: .8; text-align: center;">
                        <img style="position: relative; top: 45%;" src="../Images/photo-loader.gif" alt="" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="Div900">
                        <fieldset>
                            <legend>Pending Leave List</legend>
                            <div class="MsgBox">
                                <!--Div for msg-->
                                <asp:Label ID="lblMsg" runat="server" ForeColor="Navy" CssClass="msglabel" Font-Bold="True"></asp:Label>
                            </div>
                            <div style="border-right: gray 1px solid; border-top: gray 1px solid; margin: 0px 5px 5px 10px;
                                overflow: scroll; border-left: gray 1px solid; width: 98%; border-bottom: gray 1px solid;
                                height: 400px">
                                <!--Grid view Code starts for First TAB-->
                                <asp:GridView ID="grLeaveApp" runat="server" Font-Size="9px" Width="100%" AutoGenerateColumns="False"
                                    DataKeyNames="LvAppID,LTypeTitle,LTypeId,LNature,AppDate,LeaveStart,LeaveEnd,Duration,InsertedBy,
                                            LTReason,LAbbrName,EmpId,Fullname,SupervisorId" EmptyDataText="No Record Found"
                                    OnRowCommand="grLeaveApp_RowCommand" 
                                    onselectedindexchanged="grLeaveApp_SelectedIndexChanged">
                                    <Columns>
                                    
                                        <asp:BoundField HeaderText="SL No.">
                                            <ItemStyle Width="3%" CssClass="ItemStylecss"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="EmpId" HeaderText="APPLICANT">
                                            <ItemStyle Width="20%" CssClass="ItemStylecss"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="AppDate" HeaderText=" APPLIED ON">
                                            <ItemStyle Width="5%" CssClass="ItemStylecss"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="LTypeTitle" HeaderText="LEAVE TYPE">
                                            <ItemStyle Width="10%" CssClass="ItemStylecss"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="LeaveStart" HeaderText="FROM">
                                            <ItemStyle Width="5%" CssClass="ItemStylecss"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="LeaveEnd" HeaderText="TO">
                                            <ItemStyle Width="5%" CssClass="ItemStylecss"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="LDurInDays" HeaderText="Total Days">
                                            <ItemStyle Width="5%" CssClass="ItemStylecssCenter"></ItemStyle>
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="InsertedBy" HeaderText="APPLIED BY">
                                            <ItemStyle Width="10%" CssClass="ItemStylecss"></ItemStyle>
                                        </asp:BoundField>
                                       
                                        <asp:TemplateField HeaderText="APPROVER">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtApproverId" MaxLength="20" Width="80px" runat="server" CssClass="TextBoxAmt60"
                                                    Enabled="true" Text='<%# Bind("SupervisorId") %>' />
                                               <%--  <asp:Button ID="btnApproverId" MaxLength="6" Width="40px" runat="server" Text="..."
                                                    Enabled="true" />--%>
                                            </ItemTemplate>
                                             <ItemStyle Width="15%" CssClass="ItemStylecss"></ItemStyle>
                                        </asp:TemplateField>
                                         <asp:ButtonField HeaderText="" Text="VIEW" CommandName="ViewClick">
                                            <ItemStyle Width="5%" CssClass="ItemStylecss" Font-Bold="true"></ItemStyle>
                                        </asp:ButtonField>                                        
                                        <asp:ButtonField HeaderText="" Text="RECOMMEND" CommandName="RecommendClick">
                                            <ItemStyle Width="5%" CssClass="ItemStylecss" ForeColor="green" Font-Bold="true">
                                            </ItemStyle>
                                        </asp:ButtonField>
                                        <asp:ButtonField HeaderText="" Text="REGRET" CommandName="DenyClick">
                                            <ItemStyle Width="5%" CssClass="ItemStylecss" ForeColor="red" Font-Bold="true"></ItemStyle>
                                        </asp:ButtonField>
                                    </Columns>
                                    <SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>
                                    <HeaderStyle BackColor="#B3CDE4" Font-Bold="True"></HeaderStyle>
                                    <AlternatingRowStyle BackColor="#EFF3FB"></AlternatingRowStyle>
                                </asp:GridView>
                            </div><asp:HiddenField ID="hfLDates" runat="server"></asp:HiddenField>
                            <asp:HiddenField ID="hfLEnjoyed" runat="server"></asp:HiddenField>
                        </fieldset>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
