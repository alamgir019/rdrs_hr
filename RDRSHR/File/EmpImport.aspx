<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmpImport.aspx.cs" Inherits="File_EmpImport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
    <div>
        <table style="font-size:12px">
            <tr>
                <td>
                   Intervention
                </td>
                <td>
                    <asp:DropDownList ID="ddlOrg" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    HR Designation (4)
                </td>
                <td>
                    <asp:DropDownList ID="ddlDesig" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    Functional Designation (7)
                </td>
                <td>
                    <asp:DropDownList ID="ddlSubDept" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                  Department
                </td>
                <td>
                    <asp:DropDownList ID="ddlClinic" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Religion
                </td>
                <td>
                    <asp:DropDownList ID="ddlLocationCategory" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                   Grade
                </td>
                <td>
                    <asp:DropDownList ID="ddlGrade" runat="server">
                    </asp:DropDownList>
                </td>
                <td class="textlevel">
                                    Grade Step :
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlGradeLevel" CssClass="textlevelleft" runat="server" >
                                    </asp:DropDownList>
                                </td>
            </tr>
            <tr>
                <td>
                   Highest Education (20)
                </td>
                <td>
                    <asp:DropDownList ID="ddlEducation" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                   Sector
                </td>
                <td>
                    <asp:DropDownList ID="ddlDistrict" runat="server">
                    </asp:DropDownList>
                </td>
                 <td>
                   Blood Group (27)
                </td>
                <td>
                    <asp:DropDownList ID="ddlBloodGroup" runat="server"></asp:DropDownList>
                </td>
                
                <td class="textlevel">
                    Function :
                </td>
                <td>
                    <asp:DropDownList ID="ddlPosByFunction" runat="server" CssClass="textlevelleft">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="textlevel">
                    Place of Posting :
                </td>
                <td>
                    <asp:DropDownList ID="ddlPostingPlace" runat="server" CssClass="textlevelleft">
                    </asp:DropDownList>
                </td>
                
                <td class="textlevel">
                    Posting District :
                </td>
                <td>
                    <asp:DropDownList ID="ddlPostDistrict" runat="server" CssClass="textlevelleft">
                    </asp:DropDownList>
                </td>
                <td class="textlevel">
                                    Salary Location :
                                </td>
                                <td style="height: 15px">
                                    <asp:DropDownList ID="ddlSalaryLoc" runat="server" CssClass="textlevelleft">
                                    </asp:DropDownList>
                                </td>
                                
                                <td class="textlevel">
                                    Posting Division :
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPostDivision" runat="server" CssClass="textlevelleft">
                                    </asp:DropDownList>
                                </td>
            </tr>
            <tr>
            <td class="textlevel" >
                                                   Home Upazilla :
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlPerUpazila" runat="server" CssClass="textlevelleft" >
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="textlevel">
                                                  Home District :
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlPerDistrict" runat="server" CssClass="textlevelleft">
                                                    </asp:DropDownList>
                                                </td>
                                <td class="textlevel">
                                    &nbsp;Employee Type :
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlEmpType" runat="server" CssClass="textlevelleft">
                                    </asp:DropDownList>
                                </td><td style="height: 15px" class="textlevel">
                                    Appointment Type:
                                </td>
                                <td style="height: 15px">
                                    <asp:DropDownList ID="ddlAppointType" runat="server" CssClass="textlevelleft">
                                        <asp:ListItem Text="Core" Value="C"></asp:ListItem>
                                        <asp:ListItem Text="Project" Value="P"></asp:ListItem>
                                        <asp:ListItem Value="V">Voluntary</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
            </tr>
        </table>
    </div>
    <div>
        <table>
            <tr>
                <td>
                    <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
                </td>
                <td>
                    <asp:Button ID="btnValidate" runat="server" Text="Validates" OnClick="btnValidate_Click" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </div>
    <div>
        <asp:GridView ID="grPayroll" runat="server" AutoGenerateColumns="true" ShowHeader="true" Font-Size="X-Small">
        </asp:GridView>
    </div>
    </form>
</body>
</html>
