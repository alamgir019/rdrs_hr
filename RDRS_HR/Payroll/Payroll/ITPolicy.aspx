<%@ Page Language="C#" MasterPageFile="~/MasterBTMS.master" AutoEventWireup="true"
    CodeFile="ITPolicy.aspx.cs" Inherits="Payroll_Payroll_ITPolicy" Title="IT Policy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="officeSetup">
        <div id="formhead1">
            IT Policy</div>
        <div class="MsgBox">
            <asp:Label ID="lblMsg" runat="server" Width="98%" Font-Bold="True" ForeColor="Fuchsia"></asp:Label>
        </div>
        <div style="margin-top: 10px; margin-left: 20px;">
            <table>
                <tr>
                    <td class="textlevel">
                    </td>
                    <td style="text-align: center; background-color: #C04400; color: White; font-weight: bold;">
                        Male</td>
                    <td style="text-align: center; background-color: #C04400; color: White; font-weight: bold;">
                        Female</td>
                    <td style="text-align: center; background-color: #C04400; color: White; font-weight: bold;">
                        Autistic
                    </td>
                </tr>
                <tr>
                    <td class="textlevel">
                        Yearly House Rent Max Exemption</td>
                    <td>
                        <asp:TextBox ID="txtYHAM" runat="server" Width="100px" CssClass="TextBoxAmt100"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="txtYHAF" runat="server" Width="100px" CssClass="TextBoxAmt100"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="txtYHAA" runat="server" Width="100px" CssClass="TextBoxAmt100"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="textlevel" style="height: 24px">
                        Monthly House Rent Exemption</td>
                    <td style="height: 24px">
                        <asp:TextBox ID="txtMHAM" runat="server" Width="100px" CssClass="TextBoxAmt100"></asp:TextBox></td>
                    <td style="height: 24px">
                        <asp:TextBox ID="txtMHAF" runat="server" Width="100px" CssClass="TextBoxAmt100"></asp:TextBox></td>
                    <td style="height: 24px">
                        <asp:TextBox ID="txtMHAA" runat="server" Width="100px" CssClass="TextBoxAmt100"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="textlevel">
                        Yearly Transport Allowance Exemption</td>
                    <td>
                        <asp:TextBox ID="txtYTAM" runat="server" Width="100px" CssClass="TextBoxAmt100"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="txtYTAF" runat="server" Width="100px" CssClass="TextBoxAmt100"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="txtYTAA" runat="server" Width="100px" CssClass="TextBoxAmt100"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="textlevel">
                        Yearly Medical Allowance Exemption</td>
                    <td>
                        <asp:TextBox ID="txtYMAM" runat="server" Width="100px" CssClass="TextBoxAmt100"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="txtYMAF" runat="server" Width="100px" CssClass="TextBoxAmt100"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="txtYMAA" runat="server" Width="100px" CssClass="TextBoxAmt100"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="textlevel" style="">
                    </td>
                    <td style="height: 16px;">
                    </td>
                    <td style="height: 16px;">
                    </td>
                    <td style="height: 16px;">
                    </td>
                </tr>
                <tr>
                    <td class="textlevel" style="height: 16px; background-color: #186D0B">
                        0 Income Tax Slot</td>
                    <td style="height: 16px; background-color: #186D0B">
                        <asp:TextBox ID="txtSlot0M" runat="server" Width="100px" CssClass="TextBoxAmt100"></asp:TextBox></td>
                    <td style="height: 16px; background-color: #186D0B">
                        <asp:TextBox ID="txtSlot0F" runat="server" Width="100px" CssClass="TextBoxAmt100"></asp:TextBox></td>
                    <td style="height: 16px; background-color: #186D0B">
                        <asp:TextBox ID="txtSlot0A" runat="server" Width="100px" CssClass="TextBoxAmt100"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="textlevel" style="background-color: #00A3F6;">
                        10% Income Tax Slot</td>
                    <td style="height: 16px; background-color: #00A3F6">
                        <asp:TextBox ID="txtSlot10M" runat="server" Width="100px" CssClass="TextBoxAmt100"></asp:TextBox></td>
                    <td style="height: 16px; background-color: #00A3F6">
                        <asp:TextBox ID="txtSlot10F" runat="server" Width="100px" CssClass="TextBoxAmt100"></asp:TextBox></td>
                    <td style="height: 16px; background-color: #00A3F6">
                        <asp:TextBox ID="txtSlot10A" runat="server" Width="100px" CssClass="TextBoxAmt100"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="textlevel" style="background-color: #EACF54;">
                        15% Income Tax Slot</td>
                    <td style="height: 16px; background-color: #EACF54">
                        <asp:TextBox ID="txtSlot15M" runat="server" Width="100px" CssClass="TextBoxAmt100"></asp:TextBox></td>
                    <td style="height: 16px; background-color: #EACF54">
                        <asp:TextBox ID="txtSlot15F" runat="server" Width="100px" CssClass="TextBoxAmt100"></asp:TextBox></td>
                    <td style="height: 16px; background-color: #EACF54">
                        <asp:TextBox ID="txtSlot15A" runat="server" Width="100px" CssClass="TextBoxAmt100"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="textlevel" style="background-color: #FF4B3C;">
                        20% Income Tax Slot</td>
                    <td style="height: 16px; background-color: #FF4B3C">
                        <asp:TextBox ID="txtSlot20M" runat="server" Width="100px" CssClass="TextBoxAmt100"></asp:TextBox></td>
                    <td style="height: 16px; background-color: #FF4B3C">
                        <asp:TextBox ID="txtSlot20F" runat="server" Width="100px" CssClass="TextBoxAmt100"></asp:TextBox></td>
                    <td style="height: 16px; background-color: #FF4B3C">
                        <asp:TextBox ID="txtSlot20A" runat="server" Width="100px" CssClass="TextBoxAmt100"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="textlevel" style="background-color: #008080;">
                        25% Income Tax Slot</td>
                    <td style="height: 16px; background-color: #008080">
                        <asp:TextBox ID="txtSlot25M" runat="server" Width="100px" CssClass="TextBoxAmt100"></asp:TextBox></td>
                    <td style="height: 16px; background-color: #008080">
                        <asp:TextBox ID="txtSlot25F" runat="server" Width="100px" CssClass="TextBoxAmt100"></asp:TextBox></td>
                    <td style="height: 16px; background-color: #008080">
                        <asp:TextBox ID="txtSlot25A" runat="server" Width="100px" CssClass="TextBoxAmt100"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="textlevel" style="">
                    </td>
                    <td style="height: 16px;">
                    </td>
                    <td style="height: 16px;">
                    </td>
                    <td style="height: 16px;">
                    </td>
                </tr>
                <tr>
                    <td class="textlevel" style="height: 16px; background-color: #8EC439;">
                        Investment Allowance</td>
                    <td style="height: 16px; background-color: #8EC439;">
                        <asp:TextBox ID="txtInvAllowM" runat="server" CssClass="TextBoxAmt60"></asp:TextBox>%</td>
                    <td style="height: 16px; background-color: #8EC439;">
                        <asp:TextBox ID="txtInvAllowF" runat="server" CssClass="TextBoxAmt60"></asp:TextBox>%</td>
                    <td style="height: 16px; background-color: #8EC439;">
                        <asp:TextBox ID="txtInvAllowA" runat="server" CssClass="TextBoxAmt60"></asp:TextBox>%</td>
                </tr>
                <tr>
                    <td class="textlevel" style="height: 16px; background-color: #8EC439;">
                        Investment Rebate</td>
                    <td style="height: 16px; background-color: #8EC439;">
                        <asp:TextBox ID="txtInvRebateM" runat="server" CssClass="TextBoxAmt60"></asp:TextBox>%</td>
                    <td style="height: 16px; background-color: #8EC439;">
                        <asp:TextBox ID="txtInvRebateF" runat="server" CssClass="TextBoxAmt60"></asp:TextBox>%</td>
                    <td style="height: 16px; background-color: #8EC439;">
                        <asp:TextBox ID="txtInvRebateA" runat="server" CssClass="TextBoxAmt60"></asp:TextBox>%</td>
                </tr>
                <tr>
                    <td class="textlevel">
                    </td>
                    <td style="height: 16px">
                    </td>
                    <td style="height: 16px">
                    </td>
                    <td style="height: 16px">
                    </td>
                </tr>
                <tr>
                    <td class="textlevel" style="background-color: #aaacae">
                        Minimum Tax</td>
                    <td style="height: 16px; background-color: #aaacae">
                        <asp:TextBox ID="txtMinTaxM" runat="server" CssClass="TextBoxAmt100" Width="100px"></asp:TextBox></td>
                    <td style="height: 16px; background-color: #aaacae">
                        <asp:TextBox ID="txtMinTaxF" runat="server" CssClass="TextBoxAmt100" Width="100px"></asp:TextBox></td>
                    <td style="height: 16px; background-color: #aaacae">
                        <asp:TextBox ID="txtMinTaxA" runat="server" CssClass="TextBoxAmt100" Width="100px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td style="text-align: right;">
                    </td>
                    <td style="text-align: right">
                    </td>
                    <td style="text-align: right">
                        <br />
                        <asp:Button ID="btnSave" runat="server" Text="Save" Width="100px" OnClick="btnSave_Click" /></td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
