<%@ Page Language="C#" MasterPageFile="~/MasterBTMS.master" AutoEventWireup="true"
    CodeFile="HomePoliceStation.aspx.cs" Inherits="HomePoliceStation" Title="Home Police Station" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../JScripts/Confirmation.js">
    </script>
    <div class="setup">
        <div id='formhead1'>
            <div style="width: 96%; float: left;">
                Geo Thana Setup</div>
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
                            <asp:Label ID="Label2" runat="server" CssClass="textlevel" Text="Upazilla Name :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtName" runat="server" Width="309px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                      <tr>
                        <td class="textlevel">
                            District :
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlDistrict" runat="server" Width="155px" CssClass="textlevelleft"
                               AutoPostBack="true" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" >
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="*" ControlToValidate="ddlDistrict"
                                            Operator="NotEqual" ValueToCompare="-1" ></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="textlevel">
                            Upazilla :
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlUpzilla" runat="server" Width="155px" CssClass="textlevelleft"
                               >
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*" ControlToValidate="ddlUpzilla"
                                            Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:CheckBox ID="ChkIsActive" Text="Mark Inactive" CssClass="textlevelleft" runat="server" />
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>
        <div class="GridFormat1">
            <!--Grid view Code starts-->
            <asp:GridView ID="grList" runat="server" DataKeyNames="PsId,IsActive,DistID,UpzId" AutoGenerateColumns="False"
                EmptyDataText="No Record Found" Font-Size="9px" Width="100%" OnRowCommand="grList_RowCommand">
                <HeaderStyle BackColor="#B3CDE4" Font-Bold="True"></HeaderStyle>
                <SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" CssClass="ListHeader" Font-Bold="True">
                </SelectedRowStyle>
                <AlternatingRowStyle BackColor="#EFF3FB"></AlternatingRowStyle>
                <Columns>
                    <asp:ButtonField CommandName="DoubleClick" HeaderText="Edit" Text="Edit">
                        <ItemStyle CssClass="ItemStylecss" Width="10%" />
                    </asp:ButtonField>
                    <asp:BoundField DataField="DistName" HeaderText="District Name">
                        <ItemStyle CssClass="ItemStylecss" Width="25%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="UpzName" HeaderText="Upazilla Name">
                        <ItemStyle CssClass="ItemStylecss" Width="25%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="PSName" HeaderText="Thana Name">
                        <ItemStyle CssClass="ItemStylecss" Width="25%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="IsActive" HeaderText="Is Active">
                        <ItemStyle CssClass="ItemStylecss" Width="10%"></ItemStyle>
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
        </div>
    </div>
</asp:Content>
