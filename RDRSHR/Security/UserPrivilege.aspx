<%@ Page Title="" Language="C#" MasterPageFile="~/MasterBTMS.master" AutoEventWireup="true"
    CodeFile="UserPrivilege.aspx.cs" Inherits="Security_UserPrivilege" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../JScripts/datetimepicker.js">
        //Date Time Picker script
    </script>
    <script language="javascript" type="text/javascript" src="../JScripts/Confirmation.js"></script>    
    <div class="officeSetup">
        <div id="formhead1">
            <div style="width: 96%; float: left;">User Privilege</div>
            <div style="margin: 2px; float: left; padding-right: 3px;">
            <a href="../Default.aspx"><img src="../Images/close_icon.gif" /></a></div>
        </div>
        <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" 
            Width="100%" Height="520px">
            <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1" Width="860px" Height="480px">
                <HeaderTemplate>
                    Add User Privilege
                </HeaderTemplate>
                <ContentTemplate>
                <asp:HiddenField ID="hfId" runat="server" />
                    <!--Div for group-->
                    <div class="MsgBox">
                        <!--Div for msg-->
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                    </div>
                    <div class="officeSetupInner">
                        <fieldset>
                            <!--Div for Controls-->
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label5" runat="server" CssClass="textlevel" Text="User Id :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlUserId" runat="server" CssClass="textlevelleft" Width="200px"
                                            ToolTip="Select User">
                                        </asp:DropDownList>
                                    </td>
                                    <td></td>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" CssClass="textlevel" Text="Intervention :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlIntervention" runat="server" CssClass="textlevelleft" 
                                            Width="200px" AutoPostBack="True"
                                            ToolTip="Select Intervention" 
                                            OnSelectedIndexChanged="ddlIntervention_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" CssClass="textlevel" Text="Head Office :"></asp:Label>
                                    </td>
                                    <td>                                        
                                        <asp:DropDownList ID="ddlHeadOffice" runat="server" CssClass="textlevelleft" Width="200px"
                                            ToolTip="Select Office" AutoPostBack="True"
                                            onselectedindexchanged="ddlHeadOffice_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td></td>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" CssClass="textlevel" Text="CCO :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlCCO" runat="server" CssClass="textlevelleft" Width="200px"
                                            ToolTip="Select CCO" onselectedindexchanged="ddlCCO_SelectedIndexChanged" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label13" runat="server" CssClass="textlevel" Text="Zone :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlZone" runat="server" CssClass="textlevelleft" Width="200px"
                                            ToolTip="Select Zone"  AutoPostBack="True"
                                            onselectedindexchanged="ddlZone_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td></td>
                                    <td>
                                        <asp:Label ID="Label14" runat="server" CssClass="textlevel" Text="Unit :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlUnit" runat="server" CssClass="textlevelleft" Width="200px"
                                            ToolTip="Select Unit"  AutoPostBack="True"
                                            onselectedindexchanged="ddlUnit_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label6" runat="server" CssClass="textlevel" Text="District :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="textlevelleft" Width="200px"
                                            ToolTip="Select District"  AutoPostBack="True"
                                            onselectedindexchanged="ddlDistrict_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td></td>
                                    <td>
                                        <asp:Label ID="Label12" runat="server" CssClass="textlevel" Text="Area :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlArea" runat="server" CssClass="textlevelleft" Width="200px"
                                            ToolTip="Select Area"  AutoPostBack="True"
                                            onselectedindexchanged="ddlArea_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>   
                                    <td>
                                        <asp:Label ID="Label4" runat="server" CssClass="textlevel" Text="Branch :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlBranch" runat="server" CssClass="textlevelleft" Width="200px"
                                            ToolTip="Select Branch" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </td>
                                    <td></td>
                                    <td>
                                        <asp:Label ID="Label15" runat="server" CssClass="textlevel" Text="Upazilla :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlUpazilla" runat="server" CssClass="textlevelleft"
                                            Width="200px" ToolTip="Select Upazilla">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label8" runat="server" CssClass="textlevel" Text="Project :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlProject" runat="server" CssClass="textlevelleft"
                                            Width="200px" ToolTip="Select Project">
                                        </asp:DropDownList>
                                    </td>
                                    <td></td>
                                    <td>
                                        <asp:Label ID="Label10" runat="server" CssClass="textlevel" Text="Sector :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlSector" runat="server" CssClass="textlevelleft" Width="200px"
                                            ToolTip="Select Sector">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label11" runat="server" CssClass="textlevel" Text="Grade :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlGrade" runat="server" CssClass="textlevelleft" Width="200px"
                                            ToolTip="Select Grade">
                                        </asp:DropDownList>
                                    </td>
                                    <td></td>
                                    <td>
                                        <asp:Label ID="Label9" runat="server" CssClass="textlevel" Text="Screen Name :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlScreen" runat="server" CssClass="textlevelleft" Width="200px"
                                            ToolTip="Select Screen"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="chkView" runat="server" Checked="true" CssClass="textlevelleft" Text="View" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkInsert" runat="server" Checked="true" CssClass="textlevelleft" Text="Insert" />  
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:CheckBox ID="chkDelete" runat="server" Checked="true" CssClass="textlevelleft" Text="Delete" />
                                    </td>
                                    <td></td>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnAdd" runat="server" Text="Add" Width="60px" CausesValidation="False"
                                            OnClick="btnAdd_Click" />
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </div>
                    <div class="GridFormat1">
                        <!--Grid view Code starts-->
                         <%--onrowcommand="grList_RowCommand" onrowdeleting="grList_RowDeleting"--%>
                        <asp:GridView ID="grList" runat="server" 
                            DataKeyNames="UserId,ViewId,ViewPerm,InsertPerm,DeletePerm,InterventionId,HeadOfficeId,CCOId,ZoneId,UnitId,AreaId,BranchId,DistrictId,UpazillaId,ProjectId,GradeId,SectorId" AutoGenerateColumns="False"
                        EmptyDataText="No Record Found" Font-Size="9px" Width="99%" >
                            <HeaderStyle BackColor="#B3CDE4" Font-Bold="True"></HeaderStyle>
                            <SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" CssClass="ListHeader" Font-Bold="True">
                            </SelectedRowStyle>
                            <AlternatingRowStyle BackColor="#EFF3FB"></AlternatingRowStyle>
                            <Columns>
                               <%-- <asp:ButtonField CommandName="DoubleClick" HeaderText="Edit" Text="Edit">
                                    <ItemStyle CssClass="ItemStylecss" Width="10%" />
                                </asp:ButtonField>
                                <asp:ButtonField CommandName="Delete" HeaderText="Delete" Text="Delete">
                                    <ItemStyle CssClass="ItemStylecss" Width="10%" />
                                </asp:ButtonField>--%>
                                <asp:BoundField DataField="UserId" HeaderText="User Id">
                                    <ItemStyle CssClass="ItemStylecss" Width="20%"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="PageName" HeaderText="View Name">
                                    <ItemStyle CssClass="ItemStylecss" Width="30%"></ItemStyle>
                                </asp:BoundField>                                
                                <asp:BoundField DataField="ViewPerm" HeaderText="View Permission">
                                    <ItemStyle CssClass="ItemStylecss" Width="10%"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="InsertPerm" HeaderText="Insert Permission">
                                    <ItemStyle CssClass="ItemStylecss" Width="10%"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="DeletePerm" HeaderText="Delete Permission">
                                    <ItemStyle CssClass="ItemStylecss" Width="10%"></ItemStyle>
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                        <!--Grid view Code Ends-->
                    </div>
                    <div class="DivCommand1">
                        <div class="DivCommandL">
                            <asp:Button ID="btnClear" runat="server" Text="Refresh" Width="70px" OnClick="btnClear_Click" CausesValidation="False" />
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
                    User Permission List
                </HeaderTemplate>
                <ContentTemplate>                
                    <!--Div for group-->
                    <div class="MsgBox">
                        <!--Div for msg-->
                        <asp:Label ID="lblViewMsg" runat="server"></asp:Label>
                    </div>
                    <div class="officeSetupInner">
                        <fieldset>
                            <!--Div for Controls-->
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label7" runat="server" CssClass="textlevel" Text="User Id :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlUsers" runat="server" CssClass="textlevelleft" Width="200px"
                                            ToolTip="Select User">
                                        </asp:DropDownList>
                                    </td>
                                    <td></td>                                    
                                    <td>
                                        <asp:Label ID="Label16" runat="server" CssClass="textlevel" Text="Screen Name :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlScreens" runat="server" CssClass="textlevelleft" Width="200px"
                                            ToolTip="Select Screen"></asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnView" runat="server" Text="View" Width="60px" CausesValidation="False"
                                            OnClick="btnView_Click" />
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </div>
                    <div class="GridFormat3">
                        <asp:GridView ID="grPrivilegeList" runat="server" DataKeyNames="ID,UserId,ViewId,PageName,ViewPerm,InsertPerm,DeletePerm,InterventionId,HeadOfficeId,CCOId,ZoneId,UnitId,AreaId,BranchId,DistrictId,UpazillaId,ProjectId,GradeId,SectorId,InterventionName,HeadOfficeName,CCOName,ZoneName,UnitName,AreaName,BranchName,DistrictName,ProjectName,GradeName,SectorName"
                            AutoGenerateColumns="False" EmptyDataText="No Record Found" 
                            Font-Size="9px" Width="99%" OnRowCommand="grPrivilegeList_RowCommand" 
                            OnRowDeleting="grPrivilegeList_RowDeleting">
                            <HeaderStyle BackColor="#B3CDE4" Font-Bold="True"></HeaderStyle>
                            <SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" CssClass="ListHeader" Font-Bold="True">
                            </SelectedRowStyle>
                            <AlternatingRowStyle BackColor="#EFF3FB"></AlternatingRowStyle>
                            <Columns>
                                <asp:ButtonField CommandName="DoubleClick" HeaderText="Edit" Text="Edit">
                                    <ItemStyle CssClass="ItemStylecss" Width="8%" />
                                </asp:ButtonField>
                                <asp:ButtonField CommandName="Delete" HeaderText="Delete" Text="Delete">
                                    <ItemStyle CssClass="ItemStylecss" Width="10%" />
                                </asp:ButtonField>
                                <asp:BoundField DataField="UserId" HeaderText="User Id">
                                    <ItemStyle CssClass="ItemStylecss" Width="20%"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="PageName" HeaderText="View Name">
                                    <ItemStyle CssClass="ItemStylecss" Width="20%"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="ViewPerm" HeaderText="View Permission">
                                    <ItemStyle CssClass="ItemStylecss"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="InsertPerm" HeaderText="Insert Permission">
                                    <ItemStyle CssClass="ItemStylecss"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="DeletePerm" HeaderText="Delete Permission">
                                    <ItemStyle CssClass="ItemStylecssCenter"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="InterventionName" HeaderText="Intervention">
                                    <ItemStyle CssClass="ItemStylecssCenter"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="HeadOfficeName" HeaderText="HeadOffice">
                                    <ItemStyle CssClass="ItemStylecssCenter"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="CCOName" HeaderText="CCO">
                                    <ItemStyle CssClass="ItemStylecssCenter"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="ZoneName" HeaderText="Zone">
                                    <ItemStyle CssClass="ItemStylecssCenter"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="UnitName" HeaderText="Unit">
                                    <ItemStyle CssClass="ItemStylecssCenter"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="AreaName" HeaderText="Area">
                                    <ItemStyle CssClass="ItemStylecssCenter"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="BranchName" HeaderText="Branch">
                                    <ItemStyle CssClass="ItemStylecssCenter"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="DistrictName" HeaderText="District">
                                    <ItemStyle CssClass="ItemStylecssCenter"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="ProjectName" HeaderText="Project">
                                    <ItemStyle CssClass="ItemStylecssCenter"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="GradeName" HeaderText="Grade">
                                    <ItemStyle CssClass="ItemStylecssCenter"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="SectorName" HeaderText="Sector">
                                    <ItemStyle CssClass="ItemStylecssCenter"></ItemStyle>
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>                        
                    </div>
                    
                    <div class="DivCommand1">
                        <div class="DivCommandR">
                            <asp:Button ID="btnRefresh" runat="server" Text="Refresh" Width="70px" OnClick="btnRefresh_Click" />
                        </div>
                    </div>
                </ContentTemplate>
            </cc1:TabPanel>
        </cc1:TabContainer>
    </div>
</asp:Content>