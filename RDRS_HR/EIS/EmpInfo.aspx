<%@ Page Language="C#" MasterPageFile="~/MasterBTMS.master" AutoEventWireup="true"
    CodeFile="EmpInfo.aspx.cs" Inherits="EmpInfoSetup" Title="EmpInfo Setup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../JScripts/datetimepicker.js"></script>
    <script language="javascript" type="text/javascript" src="../JScripts/Confirmation.js"></script>
     <script type="text/javascript">
         function AddEmpName() {
             var FirstName = document.getElementById('<%= txtFirstName.ClientID %>').value;
             var MiddleName = document.getElementById('<%= txtMiddleName.ClientID %>').value;
             if (MiddleName == "") {
             }
             else {
                 MiddleName = " " + MiddleName;
             }
             var LastName = " " + document.getElementById('<%= txtLastName.ClientID %>').value;
             var FullName = FirstName + MiddleName + LastName;
             document.getElementById('<%= txtFullName.ClientID %>').value = FullName;
         }

         function CheckMaraitalStatus() {
             var MarraigeStatus = document.getElementById('<%= ddlMaritalStatus.ClientID %>').value;
             var MarriageDate = document.getElementById('<%= txtMarriageDate.ClientID %>');
             var SpouseName = document.getElementById('<%= txtSpouseName.ClientID %>');
             if (MarraigeStatus == "M") {               
                 MarriageDate.disabled = false;                
                 SpouseName.disabled = false;
             }
             else {
                 MarriageDate.value = "";
                 MarriageDate.disabled = true;
                 SpouseName.value = "";
                 SpouseName.disabled = true;
             }            
         }
        function ToUpper(ctrl) {
            var t = ctrl.value;
            ctrl.value = t.toUpperCase();
        }
    </script>
    <div class="formStyle">
        <div id='formhead2'>
            <div style="width: 98%; float: left;">
                Employee Information (General)</div>
            <div style="margin: 2px; float: left; padding-right: 3px;">
                <a href="../Default.aspx">
                    <img src="../Images/close_icon.gif" /></a></div>
        </div>
        <!--Div for group-->
        <div class="MsgBox">
            <!--Div for msg-->
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </div>
        <div class="Div950">
            <!--Div for Controls-->
            <fieldset>
                <legend>General Information</legend>
                <fieldset style="background-color: #C2D69B;">
                    <div>
                        <div style="float: left; width: 50%;">
                            <table>
                                <tr>
                                    <td class="textlevel">Emp Id :</td>
                                    <td>
                                        <asp:TextBox ID="txtEmpID" runat="server" MaxLength="20" Width="80px"></asp:TextBox>
                                        &nbsp;<asp:Button ID="cmdFind" runat="server" OnClick="cmdFind_Click" Text="Find"
                                            Width="83px" CausesValidation="False" />
                                    </td>
                                    <td style="text-align: left">
                                        <asp:RequiredFieldValidator ID="ReqFieldVal" runat="server" ErrorMessage="*" ControlToValidate="txtEmpID"></asp:RequiredFieldValidator>
                                    </td>
                                    <td class="textlevel">&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td></td>
                                    <td style="width: 86px;">
                                        <asp:LinkButton ID="lnkBtnEmpHRInfo" runat="server" CausesValidation="False" OnClick="lnkBtnEmpHRInfo_Click"
                                            Text="Emp HR Info"></asp:LinkButton>
                                    </td>
                                    <td style="width: 86px;" class="textlevel">Old Emp Id :</td>
                                    <td style="width: 86px;">
                                        <asp:TextBox ID="txtOldEmpID" runat="server" MaxLength="20" Width="80px"></asp:TextBox>
                                        <cc1:FilteredTextBoxExtender ID="txtOldEmpID_FilteredTextBoxExtender" 
                                            runat="server" Enabled="True" 
                                            FilterType="Custom,Numbers,LowercaseLetters,UppercaseLetters" 
                                            TargetControlID="txtOldEmpID" ValidChars="-">
                                        </cc1:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div style="float: right; text-align: right; width: 45%;">
                            <table>
                                <tr>
                                    <td class="textlevel">Applicant ID :</td>
                                    <td>
                                        <asp:TextBox ID="TextBox7" runat="server" Width="80px">
                                        </asp:TextBox>
                                        <asp:Button ID="Button1" runat="server" Text="Load Info" CausesValidation="False" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </fieldset>
                <div style="width: 100%; height: auto; float: left;">
                    <div style="width: 50%; height: auto; float: left;">
                        <fieldset style="width: 600px;">
                            <legend>Employee Name</legend>
                            <div style="background-color: #B8CCE4;">
                                <table style="margin-left: 73px;">
                                    <tr>
                                        <td style="width: 53px;" class="textlevelleft">Title</td>
                                        <td style="width: 53px;" class="textlevelleft">&nbsp;</td>
                                        <td class="textlevelleft">First Name</td>
                                        <td style="width: 11px"></td>
                                        <td style="width: 73px;" class="textlevelleft">Middle Name</td>
                                        <td style="width: 15px;"></td>
                                        <td class="textlevelleft">Last Name</td>
                                        <td class="textlevel" style="width: 17px"></td>
                                        <td class="textlevelleft" style="width: 17px"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 53px">
                                            <asp:DropDownList ID="ddlTitle" Width="50px" runat="server" CssClass="textlevelleft"
                                                AutoPostBack="True" OnSelectedIndexChanged="ddlTitle_SelectedIndexChanged">
                                                <asp:ListItem Value="">N/A</asp:ListItem>
                                                <asp:ListItem>Mr</asp:ListItem>
                                                <asp:ListItem>Ms</asp:ListItem>
                                                <asp:ListItem Value="Dr.">Dr.</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 53px">
                                            <asp:CompareValidator ID="CompareValidator4" runat="server" ErrorMessage="*" ControlToValidate="ddlTitle"
                                                Operator="NotEqual" ValueToCompare="N/A"></asp:CompareValidator>
                                        </td>
                                        <td style="width: 30px">
                                            <asp:TextBox ID="txtFirstName" runat="server" MaxLength="50" Width="100px" 
                                                onchange="javascript:AddEmpName();" ontextchanged="txtFirstName_TextChanged1"></asp:TextBox>
                                        </td>
                                        <td style="width: 11px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtfirstname"
                                                ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </td>
                                        <td style="width: 73px">
                                            <asp:TextBox ID="txtMiddleName" runat="server" MaxLength="50" Width="80px" 
                                                onchange="javascript:AddEmpName();"></asp:TextBox>
                                        </td>
                                        <td style="width: 15px"></td>
                                        <td class="textlevel" style="width: 17px">
                                            <asp:TextBox ID="txtLastName" runat="server" MaxLength="50" Width="100px" 
                                                onchange="javascript:AddEmpName();"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtLastName"
                                                ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </td>
                                        <td class="textlevel" style="width: 17px">&nbsp;</td>
                                    </tr>
                                </table>
                                <table>
                                    <tr>
                                        <td class="textlevel">Emp Name :</td>
                                        <td>
                                            <asp:TextBox ID="txtFullName" runat="server" Width="388px" MaxLength="200"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtFullName"
                                                ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </fieldset>
                        <div>
                            <div style="text-align: left; float: left; width: 630px;">
                                <fieldset>
                                    <legend>Present Address </legend>
                                    <div style="background-color: #C2D69B;">
                                        <table>
                                            <tr>
                                                <td style="width: 65px; text-align: right;" class="textlevel">Address :&nbsp;</td>
                                                <td style="width: 90px; height: 40px;" colspan="3">
                                                    <asp:TextBox ID="txtPreAddress" runat="server" TextMode="MultiLine" Width="440px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="textlevel" style="width: 65px;">Phone :</td>
                                                <td>
                                                    <asp:TextBox ID="txtPrePhone" runat="server" Width="150px"></asp:TextBox>
                                                </td>
                                                <td class="textlevel">Fax :</td>
                                                <td>
                                                    <asp:TextBox ID="txtPreFax" runat="server" Width="150px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="textlevel" style="width: 65px;">Division :</td>
                                                <td>
                                                    <asp:DropDownList ID="ddlPreDivision" runat="server" Width="155px" CssClass="textlevelleft" OnSelectedIndexChanged="ddlPreDivision_SelectedIndexChanged" AutoPostBack="true">
                                                    </asp:DropDownList> 
                                                </td>
                                                <td class="textlevel">District :</td>
                                                <td>
                                                    <asp:DropDownList ID="ddlPreDistrict" runat="server" Width="155px" CssClass="textlevelleft"
                                                         OnSelectedIndexChanged="ddlPreDistrict_SelectedIndexChanged" AutoPostBack="true" >
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td class="textlevel" style="width: 65px;">Upazilla :</td>
                                                <td>
                                                    <asp:DropDownList ID="ddlPreUpzilla" runat="server" Width="155px" CssClass="textlevelleft"  OnSelectedIndexChanged="ddlPreUpzilla_SelectedIndexChanged" AutoPostBack="true">
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="textlevel">Police Station :</td>
                                                <td>
                                                    <asp:DropDownList ID="ddlPrePS" runat="server" Width="155px" CssClass="textlevelleft"></asp:DropDownList>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td class="textlevel" style="width: 65px;">Country :</td>
                                                <td>
                                                     <asp:DropDownList ID="ddlPreCountry" runat="server" Width="155px" CssClass="textlevelleft"
                                                        AutoPostBack="True"></asp:DropDownList>
                                                </td>
                                                <td class="textlevel"></td>
                                                <td></td>
                                            </tr>
                                             </table>
                                    </div>
                                </fieldset>
                                <fieldset>
                                    <legend>Permanent Address </legend>
                                    <div style="background-color: #F2DBDB">
                                        <table>
                                            <tr>
                                                <td class="textlevel" style="width: 65px;">Address :</td>
                                                <td colspan="3">
                                                    <asp:TextBox ID="txtPerAddress" runat="server" TextMode="MultiLine" Width="440px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="textlevel" style="width: 65px;">Phone :</td>
                                                <td>
                                                    <asp:TextBox ID="txtPerPhone" runat="server" Width="150px"></asp:TextBox>
                                                </td>
                                                <td class="textlevel">Fax :</td>
                                                <td>
                                                    <asp:TextBox ID="txtPerFax" runat="server" Width="150px"></asp:TextBox>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td class="textlevel" style="width: 65px;">Division :</td>
                                                <td>
                                                    <asp:DropDownList ID="ddlPerDivision" runat="server" Width="155px" CssClass="textlevelleft" OnSelectedIndexChanged="ddlPerDivision_SelectedIndexChanged" AutoPostBack="true">
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="textlevel">District :</td>
                                                <td>
                                                    <asp:DropDownList ID="ddlPerDistrict" runat="server" Width="155px" CssClass="textlevelleft"
                                                       OnSelectedIndexChanged="ddlPerDistrict_SelectedIndexChanged" AutoPostBack="true">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="textlevel" style="width: 65px;">Upazilla :</td>
                                                <td>
                                                    <asp:DropDownList ID="ddlPerUpazila" runat="server" Width="155px" CssClass="textlevelleft" OnSelectedIndexChanged="ddlPerUpazila_SelectedIndexChanged" AutoPostBack="true">
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="textlevel">Police Station :</td>
                                                <td>
                                                   <asp:DropDownList ID="ddlPerPS" runat="server" Width="155px" CssClass="textlevelleft">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="textlevel" style="width: 65px;">Country :</td>
                                                <td>
                                                     <asp:DropDownList ID="ddlPerCountry" runat="server" Width="155px" CssClass="textlevelleft"
                                                        AutoPostBack="True" OnSelectedIndexChanged="ddlPerCountry_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="textlevel"></td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td class="textlevel" style="width: 65px;">&nbsp;</td>
                                                <td>
                                                    <asp:CheckBox ID="chkSameAsPresent" runat="server" Text="Same as Present Address" AutoPostBack="True" 
                                                         oncheckedchanged="chkSameAsPresent_CheckedChanged" />
                                                </td>
                                                <td class="textlevel">&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                    <table>
                        <tr>
                            <td>
                                <div style="height: auto; width: 40%; float: left">
                                    <div style="text-align: center; width: 222px;">
                                        <fieldset style="width: 222px; text-align: center;">
                                            <legend>Emp Photo</legend>
                                            <div style="background-color: #B8CCE4;">
                                                <asp:Image ID="imgEmp" runat="server" Height="142px" Width="150px" />
                                            </div>
                                        </fieldset>
                                        <fieldset style="width: 222px; text-align: left;">
                                            <div style="background-color: #F2DBDB;">
                                                <table>
                                                    <tr>
                                                        <td style="width: 3px">
                                                            <asp:FileUpload ID="FileUpload1" runat="server" Width="209px" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </fieldset>
                                    </div>
                                </div>
                            </td>
                            <td>
                                <div style="height: auto; width: 40%; float: left">
                                    <div style="text-align: center; width: 222px;">
                                        <fieldset style="width: 222px; text-align: center;">
                                            <legend>Emp Signature</legend>
                                            <div style="background-color: #B8CCE4;">
                                                <asp:Image ID="ImgSign" runat="server" Height="142px" Width="150px" />
                                            </div>
                                        </fieldset>
                                        <fieldset style="width: 222px; text-align: left;">
                                            <div style="background-color: #F2DBDB;">
                                                <table>
                                                    <tr>
                                                        <td style="width: 3px">
                                                            <asp:FileUpload ID="FileUpload2" runat="server" Width="209px" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </fieldset>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="width: 100%; height: auto; float: left;">
                    <fieldset>
                        <legend>Personal Information</legend>
                        <div style="background-color: #B8CCE4">
                            <asp:HiddenField ID="hfIsUpadate" runat="server" />
                            <asp:HiddenField ID="hfID" runat="server" />
                            <asp:HiddenField ID="hfEmpImage" runat="server" />
                            <asp:HiddenField ID="hfEmpSignImage" runat="server" />
                            <table>
                                <tr>
                                    <td class="textlevel">Father's Name :</td>
                                    <td>
                                        <asp:TextBox ID="txtFatherName" runat="server" Width="155px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtFatherName"
                                            ErrorMessage="*"></asp:RequiredFieldValidator>
                                    </td>
                                    <td class="textlevel">Mother's Name :</td>
                                    <td style="width: 158px">
                                        <asp:TextBox ID="txtMotherName" runat="server" Width="155px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtMotherName"
                                            ErrorMessage="*"></asp:RequiredFieldValidator>
                                    </td>
                                    <td ></td>
                                    <td class="textlevel">Spouse Name </td>
                                    <td>
                                        <asp:TextBox ID="txtSpouseName" runat="server" Width="155px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="textlevel">Sex :</td>
                                    <td>
                                        <asp:DropDownList ID="ddlGender" runat="server" Width="160px" CssClass="textlevelleft">
                                            <asp:ListItem Value="N">Nil</asp:ListItem>
                                            <asp:ListItem Value="M">Male</asp:ListItem>
                                            <asp:ListItem Value="F">Female</asp:ListItem>
                                            <asp:ListItem Value="O">Other</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="*" ControlToValidate="ddlGender"
                                            Operator="NotEqual" ValueToCompare="N"></asp:CompareValidator>
                                    </td>
                                    <td class="textlevel">DOB :</td>
                                    <td style="width: 158px">
                                        <asp:TextBox ID="txtDob" runat="server" Width="100px"></asp:TextBox>
                                        <a href="javascript:NewCal('<%= txtDob.ClientID %>','ddmmyyyy')">
                                            <img style="border-right: 0px; border-top: 0px; border-left: 0px; border-bottom: 0px"
                                                height='16' alt="Pick a date" src="../images/cal.gif" width='16' /></a>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtDob"
                                            ErrorMessage="*"></asp:RequiredFieldValidator>
                                    </td>
                                    <td></td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtDob"
                                            CssClass="validator" ErrorMessage="Invalid" ValidationExpression="^(?=\d)(?:(?:31(?!.(?:0?[2469]|11))|(?:30|29)(?!.0?2)|29(?=.0?2.(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00)))(?:\x20|$))|(?:2[0-8]|1\d|0?[1-9]))([-./])(?:1[012]|0?[1-9])\1(?:1[6-9]|[2-9]\d)?\d\d(?:(?=\x20\d)\x20|$))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\x20[AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$"></asp:RegularExpressionValidator>
                                    </td>
                                    <td class="textlevel">Age :</td>
                                    <td>
                                        <asp:TextBox ID="txtyear" runat="server" Width="60px"></asp:TextBox>
                                        &nbsp;<asp:TextBox ID="txtmonth" runat="server" Width="60px"></asp:TextBox>
                                        <asp:TextBox ID="txtday" runat="server" Width="60px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnCalculate" runat="server" OnClick="btnCalculate_Click" Text="Age"
                                            Width="44px" CausesValidation="false" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="textlevel">Religion :</td>
                                    <td>
                                        <asp:DropDownList ID="ddlReligion" runat="server" Width="160px" CssClass="textlevelleft"></asp:DropDownList>
                                    </td>
                                    <td style="width: 2px">
                                        <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="*" ControlToValidate="ddlReligion"
                                            Operator="NotEqual" ValueToCompare="99999"></asp:CompareValidator>
                                    </td>
                                    <td class="textlevel">Blood Group :</td>
                                    <td style="width: 158px">
                                        <asp:DropDownList ID="ddlBloodGroup" runat="server" Width="160px" CssClass="textlevelleft"></asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:CompareValidator ID="CompareValidator5" runat="server" ErrorMessage="*" ControlToValidate="ddlReligion"
                                            Operator="NotEqual" ValueToCompare="99999"></asp:CompareValidator>
                                    </td>
                                    <td></td>
                                    <td class="textlevel">DOB ID :</td>
                                    <td>
                                        <asp:TextBox ID="txtDOBId" runat="server" Width="155px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="textlevel" style="height: 26px">Marital Status :</td>
                                    <td style="height: 26px">
                                        <asp:DropDownList ID="ddlMaritalStatus" runat="server" Width="160px" 
                                            CssClass="textlevelleft"  onchange="CheckMaraitalStatus()">
                                            <asp:ListItem Value="N">Nil</asp:ListItem>
                                            <asp:ListItem Value="S">Single</asp:ListItem>
                                            <asp:ListItem Value="M">Married</asp:ListItem>
                                            <asp:ListItem Value="W">Widow</asp:ListItem>
                                            <asp:ListItem Value="E">Seperated</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 2px; height: 26px;"></td>
                                    <td class="textlevel" style="height: 26px">Marriage Date:</td>
                                    <td style="height: 26px; width: 158px;">
                                        <asp:TextBox ID="txtMarriageDate" runat="server" Width="100px"></asp:TextBox>
                                        <a href="javascript:NewCal('<%= txtMarriageDate.ClientID %>','ddmmyyyy')">
                                            <img style="border-right: 0px; border-top: 0px; border-left: 0px; border-bottom: 0px"
                                                height='16' alt="Pick a date" src="../images/cal.gif" width='16' /></a>
                                    </td>
                                    <td style="height: 26px"></td>
                                    <td style="height: 26px; width: 39px;">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtMarriageDate"
                                            CssClass="validator" ErrorMessage="Invalid" ValidationExpression="^(?=\d)(?:(?:31(?!.(?:0?[2469]|11))|(?:30|29)(?!.0?2)|29(?=.0?2.(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00)))(?:\x20|$))|(?:2[0-8]|1\d|0?[1-9]))([-./])(?:1[012]|0?[1-9])\1(?:1[6-9]|[2-9]\d)?\d\d(?:(?=\x20\d)\x20|$))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\x20[AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$"></asp:RegularExpressionValidator>
                                    </td>
                                    <td class="textlevel" style="height: 26px">Personal Email :</td>
                                    <td style="height: 26px">
                                        <asp:TextBox ID="txtPersonalEmail" runat="server" Width="155px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="textlevel">Nationality :</td>
                                    <td>
                                        <asp:TextBox ID="txtNationality" runat="server" Width="155px">Bangladeshi</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtNationality"
                                            ErrorMessage="*"></asp:RequiredFieldValidator>
                                    </td>
                                    <td class="textlevel">National ID :</td>
                                    <td style="width: 158px">
                                        <asp:TextBox ID="txtNationalId" runat="server" Width="155px" MaxLength="100"></asp:TextBox>
                                    </td>
                                    <td style="width: 6px">&nbsp;</td>
                                    <td style="width: 39px"></td>
                                    <td class="textlevel">Office Email :</td>
                                    <td>
                                        <asp:TextBox ID="txtOfficeEmail" runat="server" Width="155px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="textlevel">TIN No :</td>
                                    <td>
                                        <asp:TextBox ID="txtTINNo" runat="server" MaxLength="100" Width="155px"></asp:TextBox>
                                    </td>
                                    <td></td>
                                    <td class="textlevel">Circle :</td>
                                    <td style="width: 158px">
                                        <asp:TextBox ID="txtCircle" runat="server" Width="155px"></asp:TextBox>
                                    </td>
                                    <td></td>
                                    <td style="width: 39px"></td>
                                    <td class="textlevel">Zone :</td>
                                    <td>
                                        <asp:TextBox ID="txtZone" runat="server" Width="155px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="textlevel">Passport No :</td>
                                    <td>
                                        <asp:TextBox ID="txtPassportNo" runat="server" Width="155px"></asp:TextBox>
                                    </td>
                                    <td></td>
                                    <td class="textlevel">Passport Exp Date :</td>
                                    <td style="width: 158px">
                                        <asp:TextBox ID="txtPassExpDate" runat="server" Width="100px"></asp:TextBox>
                                        <a href="javascript:NewCal('<%= txtPassExpDate.ClientID %>','ddmmyyyy')">
                                            <img style="border-right: 0px; border-top: 0px; border-left: 0px; border-bottom: 0px"
                                                height='16' alt="Pick a date" src="../images/cal.gif" width='16' /></a>
                                    </td>
                                    <td></td>
                                    <td style="width: 39px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtPassExpDate"
                                            CssClass="validator" ErrorMessage="Invalid" ValidationExpression="^(?=\d)(?:(?:31(?!.(?:0?[2469]|11))|(?:30|29)(?!.0?2)|29(?=.0?2.(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00)))(?:\x20|$))|(?:2[0-8]|1\d|0?[1-9]))([-./])(?:1[012]|0?[1-9])\1(?:1[6-9]|[2-9]\d)?\d\d(?:(?=\x20\d)\x20|$))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\x20[AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$"></asp:RegularExpressionValidator>
                                    </td>
                                    <td class="textlevel">Pasport Issue Office :</td>
                                    <td>
                                        <asp:TextBox ID="txtPasportIssOff" runat="server" Width="155px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="textlevel">Skype ID :</td>
                                    <td>
                                        <asp:TextBox ID="txtSkypeID" runat="server" Width="155px"></asp:TextBox>
                                    </td>
                                    <td></td>
                                    <td class="textlevel">Office Ext :</td>
                                    <td style="width: 158px">
                                        <asp:TextBox ID="txtOffPhExt" runat="server" Width="155px" Visible="true"></asp:TextBox>
                                    </td>
                                    <td></td>
                                    <td style="width: 39px"></td>
                                    <td class="textlevel">Nature :</td>
                                    <td>
                                        <asp:DropDownList ID="ddlNature" runat="server" Width="160px" 
                                            CssClass="textlevelleft">
                                            <asp:ListItem Value="99999">Nil</asp:ListItem>
                                            <asp:ListItem Value="S">Static</asp:ListItem>
                                            <asp:ListItem Value="O">Out Reach</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="textlevel" style="height: 26px">Office Cell No:</td>
                                    <td style="height: 26px">
                                        <asp:TextBox ID="txtCellPhone" runat="server" Width="155px"></asp:TextBox>
                                    </td>
                                    <td style="height: 26px"></td>
                                    <td class="textlevel" style="height: 26px">Personal Cell No:</td>
                                    <td style="height: 26px; width: 158px;">
                                        <asp:TextBox ID="txtLandPhone" runat="server" Width="155px"></asp:TextBox>
                                    </td>
                                    <td style="height: 26px"></td>
                                    <td style="height: 26px; width: 39px;"></td>
                                    <td class="textlevel" style="height: 26px">SSM MR No. :</td>
                                    <td>
                                        <asp:TextBox ID="txtSSMMrNo" runat="server" Width="155px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="textlevel">Highest Education :</td>
                                    <td>
                                        <asp:DropDownList ID="ddlHighestEdu" runat="server" Width="160px" CssClass="textlevelleft">
                                            <asp:ListItem Value="99999">Nil</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtFatherName"
                                            ErrorMessage="*"></asp:RequiredFieldValidator>
                                    </td>
                                    <td class="textlevel" valign="top">&nbsp;Subject :</td>
                                    <td style="width: 158px">
                                        <asp:TextBox ID="txtSubject" runat="server" Width="155px" Visible="false"></asp:TextBox>
                                        <asp:DropDownList ID="ddlSubject" runat="server" Width="127px" CssClass="textlevelleft"></asp:DropDownList>

                                    </td>
                                    <td></td>
                                    <td style="width: 39px"></td>
                                    <td class="textlevel">&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="textlevel">Special Skill :</td>
                                    <td>
                                        <asp:DropDownList ID="ddlSpecialSkill" runat="server" Width="160px" CssClass="textlevelleft">
                                            <asp:ListItem Value="99999">Nil</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td></td>
                                    <td class="textlevel" valign="top">Proff Degree :</td>
                                    <td style="width: 158px">
                                        <asp:DropDownList ID="ddlProffDegree" runat="server" Width="160px" CssClass="textlevelleft">
                                            <asp:ListItem Value="99999">Nil</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td></td>
                                    <td style="width: 39px"></td>
                                    <td class="textlevel">&nbsp;</td>
                                    <td>
                                       <%-- <asp:CheckBox ID="chkIsSpectacled" runat="server" CssClass="textlevelleft" 
                                            Text="Is Spectacled" Visible="False" />--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="textlevel">
                                       <asp:CheckBox ID="chkIsRelativeSC" runat="server" CssClass="textlevel" 
                                            Text="Relative in RDRS" /></td>
                                    <td>
                                        <asp:TextBox ID="txtRelativeID" runat="server" placeholder="Relative Emp ID."></asp:TextBox>
                                    </td>
                                    <td></td>
                                    <td class="textlevel" valign="top">Relative Name:</td>
                                    <td style="width: 158px">
                                        <asp:TextBox ID="txtRelativeInfo" runat="server" ></asp:TextBox>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td style="width: 39px">&nbsp;</td>
                                    <td class="textlevel">Relation :</td>
                                    <td class="textlevel">
                                        <asp:DropDownList ID="ddlRelation" runat="server" Width="160px" CssClass="textlevelleft"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="textlevel">Skills / Proficiency:</td>
                                    <td colspan="4">
                                        <textarea id="txtSkillProficiency" runat="server" style="width:100%" rows="5"></textarea>
                                    </td>
                                    <td></td>
                                    <td></td>
                                    <td  class="textlevel">Other Emp ID:</td>
                                    <td >
                                        <textarea id="txtOtherEmpIDNote" runat="server" style="width:100%" rows="3"></textarea>
                                    </td>
                                </tr>
                                </table>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" Enabled="True"
                                FilterType="Custom,Numbers,LowercaseLetters,UppercaseLetters" TargetControlID="txtEmpId"
                                ValidChars="-">
                            </cc1:FilteredTextBoxExtender>
                            <%--<asp:TextBox ID="txtunit" runat="server" Visible="False" Width="115px"></asp:TextBox>--%>
                        </div>
                    </fieldset>
                </div>
                <div style="width: 100%; height: auto; float: left;">
                    <fieldset>
                        <legend>Driving Information</legend>
                        <div style="background-color: #B8dCE4">
                            <table>
                                <tr>
                                    <td class="textlevel">License No. :</td>
                                    <td>
                                        <asp:TextBox ID="txtLicenseNo" runat="server" Width="155px" Visible="true"></asp:TextBox>
                                    </td>
                                    <td class="textlevel">Expire Date :</td>
                                    <td>
                                        <asp:TextBox ID="txtLicenseExpDate" runat="server" Width="120px" Visible="true"></asp:TextBox>
                                    </td>
                                    <td>
                                        <a href="javascript:NewCal('<%= txtLicenseExpDate.ClientID %>','ddmmyyyy')">
                                            <img style="border-right: 0px; border-top: 0px; border-left: 0px; border-bottom: 0px"
                                                height='16' alt="Pick a date" src="../images/cal.gif" width='16' /></a>
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtLicenseExpDate"
                                            CssClass="validator" ErrorMessage="Invalid" ValidationExpression="^(?=\d)(?:(?:31(?!.(?:0?[2469]|11))|(?:30|29)(?!.0?2)|29(?=.0?2.(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00)))(?:\x20|$))|(?:2[0-8]|1\d|0?[1-9]))([-./])(?:1[012]|0?[1-9])\1(?:1[6-9]|[2-9]\d)?\d\d(?:(?=\x20\d)\x20|$))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\x20[AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$"></asp:RegularExpressionValidator>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </fieldset>
                </div>
            </fieldset>
        </div>
        <div class="DivCommand1">
            <div class="DivCommandL">
                <asp:Button ID="btnClear" runat="server" Text="Refresh" Width="70px" OnClick="btnClear_Click"
                    UseSubmitBehavior="False" CausesValidation="False" />
            </div>
            <div class="DivCommandR">
                <asp:Button ID="btnSave" runat="server" Text="Save" Width="70px" OnClick="btnSave_Click" />
                <asp:Button ID="btnDelete" runat="server" Text="Delete" Width="70px" OnClientClick="javascript:return DeleteConfirmation();"
                    OnClick="btnDelete_Click" />
            </div>
        </div>
    </div>
</asp:Content>
