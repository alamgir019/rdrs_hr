<%@ Page Title="" Language="C#" MasterPageFile="~/MasterBTMS.master" AutoEventWireup="true"
    CodeFile="OfficeSetup.aspx.cs" Inherits="EIS_OfficeSetup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../JScripts/Confirmation.js">
    </script>
    <div class="officeSetup">
        <div id="formhead1">
            <div style="width: 96%; float: left;">
                Office Setup</div>
            <div style="margin: 2px; float: left; padding-right: 3px;">
                <a href="../Default.aspx">
                    <img src="../Images/close_icon.gif" /></a></div>
        </div>
        <div class="MsgBox">
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </div>
        <div class="officeSetupInner">
            <cc1:TabContainer ID="TabContainer1" runat="server" Height="300px">
                <cc1:TabPanel runat="server" Height="280px" ID="TabPanel1" HeaderText="Office Setup">
                    <ContentTemplate>
                        <asp:HiddenField ID="hfID" runat="server" />
                        <asp:HiddenField ID="hfIsUpdate" runat="server" />
                         <asp:HiddenField ID="hfDivisionID" runat="server" />
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" CssClass="textlevel" Text="#Office ID"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtOfficeID" runat="server" Width="60px" Enabled="false" CssClass="textlevel"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" runat="server" CssClass="textlevel" Text="Office Title"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtOffTitle" runat="server" Width="296px" CssClass="textlevelleft"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtOffTitle"
                                        ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label4" runat="server" CssClass="textlevel" Text="Office Type"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlOffType" Width="300px" runat="server" CssClass="textlevelleft"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlOffType_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*" ControlToValidate="ddlOffType"
                                        Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label5" runat="server" CssClass="textlevel" Text="Parent Office"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlParentOff" Width="300px" runat="server" CssClass="textlevelleft">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td class="textlevel" style="width: 65px;">
                                    Division :
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlDivision" runat="server" Width="155px" CssClass="textlevelleft"
                                        OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                </td>
                                <tr>
                                    <td class="textlevel" style="width: 65px;">
                                        District :
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlDistrict" runat="server" Width="155px" CssClass="textlevelleft"
                                            AutoPostBack="True" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="textlevel" style="width: 65px;">
                                        Upazilla :
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlUpazila" runat="server" Width="155px" CssClass="textlevelleft">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>    
                                    <td>
                                        <asp:CheckBox ID="chkInActive" runat="server" CssClass="textlevelleft" Text="Make Inactive" />
                                    </td>
                                    
                                    <td>
                                        <asp:CheckBox ID="chkIsPayroleLoc" runat="server" CssClass="textlevelleft" Text="Make Payrole Location" />
                                    </td>
                                    
                                </tr>
                        </table>
                    </ContentTemplate>
                </cc1:TabPanel>
                <cc1:TabPanel runat="server" Height="280px" ID="TabPanel2" HeaderText="Office List">
                    <ContentTemplate>
                        <table>
                            <tr>
                                <td class="textlevel">
                                    Unit
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlUnitSearch" Width="200px" runat="server" CssClass="textlevelleft"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlUnitSearch_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td class="textlevel">
                                    Office Type
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlOffTypeSearch" Width="200px" runat="server" CssClass="textlevelleft"
                                        AutoPostBack="false">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" Width="70px" UseSubmitBehavior="False"
                                        CausesValidation="False" OnClick="btnSearch_Click" />
                                </td>
                            </tr>
                        </table>
                        <div style="width: 99%; overflow: scroll; height: 260px; margin-top: 10px;">
                            <asp:GridView ID="grOfficeList" runat="server" AutoGenerateColumns="False" EmptyDataText="No Record Found"
                                Font-Size="9px" Width="97%" OnRowCommand="grOfficeList_RowCommand" DataKeyNames="OfficeID,DivisionID,OfficeTypeID,ParentID,DivID,DistID,UpzID,IsPayLoc">
                                <HeaderStyle BackColor="#B3CDE4" Font-Bold="True"></HeaderStyle>
                                <SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" CssClass="ListHeader" Font-Bold="True">
                                </SelectedRowStyle>
                                <AlternatingRowStyle BackColor="#EFF3FB"></AlternatingRowStyle>
                                <Columns>
                                    <asp:ButtonField CommandName="RowEdit" HeaderText="Edit" Text="Edit">
                                        <ItemStyle Width="4%" CssClass="ItemStylecss" />
                                    </asp:ButtonField>
                                    <asp:BoundField DataField="OfficeTitle" HeaderText="Office Title">
                                        <ItemStyle CssClass="ItemStylecss" Width="20%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TypeName" HeaderText="Type">
                                        <ItemStyle CssClass="ItemStylecss" Width="15%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DivisionName" HeaderText="Unit">
                                        <ItemStyle CssClass="ItemStylecss" Width="20%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ParentOffice" HeaderText="Parent Office">
                                        <ItemStyle CssClass="ItemStylecss" Width="20%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="IsActive" HeaderText="Is Active">
                                        <ItemStyle CssClass="ItemStylecss" Width="5%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="IsPayLoc" HeaderText="Pay Location">
                                        <ItemStyle CssClass="ItemStylecss" Width="5%"></ItemStyle>
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </ContentTemplate>
                </cc1:TabPanel>
            </cc1:TabContainer>
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
            </div>
        </div>
    </div>
</asp:Content>
