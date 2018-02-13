<%@ Page Title="" Language="C#" MasterPageFile="~/MasterBTMS.master" AutoEventWireup="true" CodeFile="TrainerSetup.aspx.cs" Inherits="Training_TrainerSetup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <script language="javascript" type="text/javascript" src="../JScripts/datetimepicker.js">
     //Date Time Picker script
    </script>
    <script language="javascript" type="text/javascript" src="../JScripts/Confirmation.js">
        //Delete Confirmation Message
    </script>

     <div class="officeSetup">
        <div id="formhead1">
            <div style="width: 96%; float: left;">
                Trainer Setup</div>
            <div style="margin: 2px; float: left; padding-right: 3px;">
                <a href="../Default.aspx">
                    <img src="../Images/close_icon.gif" /></a></div>
        </div>
        <!--Div for group-->
        <div class="MsgBox">
            <!--Div for msg-->
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
              <asp:HiddenField ID="hfId" runat="server" />
               <asp:HiddenField ID="hfIsUpdate" runat="server" />
        </div>
        <div class="officeSetupInner">
            <fieldset>
                <table>
                <tr>
                     <td><asp:Label ID="Label11" runat="server" CssClass="textlevel" Text="Trainer Name :"></asp:Label></td>
                     <td><asp:TextBox ID="txtTrainerName" runat="server" Width="200px"  MaxLength="50"></asp:TextBox></td>
                     <td><asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ControlToValidate="txtTrainerName"></asp:RequiredFieldValidator></td>
                    
                     <td><asp:Label ID="Label12" runat="server" CssClass="textlevel" Text="Address :"></asp:Label></td>
                     <td><asp:TextBox ID="txtAddress" runat="server" Width="200px"  MaxLength="100"></asp:TextBox></td>
                     <td><asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" ControlToValidate="txtAddress"></asp:RequiredFieldValidator></td>
                     
                 </tr>
                 <tr>
                    
                     <td><asp:Label ID="Label13" runat="server" CssClass="textlevel" Text="Contact No :"></asp:Label></td>
                     <td><asp:TextBox ID="txtContactNo" runat="server" Width="200px" onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);" MaxLength="20"></asp:TextBox></td>
                     <td><asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*" ControlToValidate="txtContactNo"></asp:RequiredFieldValidator></td>
              
                     <td><asp:Label ID="Label1" runat="server" CssClass="textlevel" Text="Email Id :"></asp:Label></td>
                     <td><asp:TextBox ID="txtEmailId" runat="server" Width="200px"  MaxLength="100"></asp:TextBox></td>
                     <td><asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                     ControlToValidate="txtEmailId" ErrorMessage="Invalid"></asp:RegularExpressionValidator></td>
                </tr>
                <tr>
                    <td><asp:Label ID="Label2" runat="server" CssClass="textlevel" Text="Organization :"></asp:Label></td>
                     <td><asp:TextBox ID="txtOrganization" runat="server" Width="200px" MaxLength="20"></asp:TextBox></td>
                     <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtOrganization"></asp:RequiredFieldValidator></td>
                       <td></td>
                    <td style="height: 22px">
                            <asp:CheckBox ID="chkInActive" runat="server" CssClass="textlevelleft" Text="Make Inactive" />
                        </td>
 
                </tr>
                </table>
            </fieldset>
            <br />
            
           
        </div>
        <div class="GridFormat1">
            <!--Grid view Code starts-->
            <asp:GridView ID="grList" runat="server" DataKeyNames="TrainnerId,TrainerName,Address,ContactNo,Organization,EmailId,IsActive" AutoGenerateColumns="False"
                EmptyDataText="No Record Found" Font-Size="9px" Width="99%" 
                onrowcommand="grList_RowCommand">
                <HeaderStyle BackColor="#B3CDE4" Font-Bold="True"></HeaderStyle>
                <SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" CssClass="ListHeader" Font-Bold="True">
                </SelectedRowStyle>
                <AlternatingRowStyle BackColor="#EFF3FB"></AlternatingRowStyle>
                <Columns>
                    <asp:ButtonField CommandName="DoubleClick" HeaderText="Edit" Text="Edit">
                        <ItemStyle CssClass="ItemStylecss" Width="8%" />
                    </asp:ButtonField>
                    <asp:BoundField DataField="TrainerName" HeaderText="Trainer Name">
                        <ItemStyle CssClass="ItemStylecss" Width="20%"></ItemStyle>
                    </asp:BoundField>

                     <asp:BoundField DataField="Address" HeaderText="Address" >
                        <ItemStyle CssClass="ItemStylecss" ></ItemStyle>
                      </asp:BoundField>

                      <asp:BoundField DataField="ContactNo" HeaderText="Contact No">
                        <ItemStyle CssClass="ItemStylecss"></ItemStyle>
                    </asp:BoundField>

                     <asp:BoundField DataField="Organization" HeaderText="Organization">
                        <ItemStyle CssClass="ItemStylecssCenter"></ItemStyle>
                    </asp:BoundField>

                     <asp:BoundField DataField="EmailId" HeaderText="Email Id">
                        <ItemStyle CssClass="ItemStylecssCenter"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="IsActive" HeaderText="Is Active">
                        <ItemStyle CssClass="ItemStylecssCenter"></ItemStyle>
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
                <asp:Button ID="btnSave" runat="server" Text="Save" Width="70px" OnClick="btnSave_Click"/>
                <asp:Button ID="btnDelete" runat="server" Text="Delete" Width="70px" OnClientClick="javascript:return DeleteConfirmation();"
                    OnClick="btnDelete_Click" />
            </div>
        </div>
        <br />
        <br />
    </div>
</asp:Content>

