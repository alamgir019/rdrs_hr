using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Data.OleDb;
public partial class File_EmpImport : System.Web.UI.Page
{
    MasterTablesManager objMasMgr = new MasterTablesManager();
    EmpInfoManager objEmpInfo = new EmpInfoManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        Common.FillDropDownList(objMasMgr.SelectDesignation(0), ddlDesig, "DESIGNAME", "DESIGID", false);
        Common.FillDropDownList_Nil(objMasMgr.SelectJobTitle(0), ddlSubDept);
        //Common.FillDropDownList(objMasMgr.SelectJobTitle(0), ddlSubDept, "SUBDEPTNAME", "SUBDEPTID", false);
        Common.FillDropDownList_Nil(objMasMgr.SelectDepartment(0), ddlClinic);
        //Common.FillDropDownList(objMasMgr.SelectClinic(), ddlClinic, "CLINICNAME", "CLINICID", false);
        Common.FillDropDownList_Nil(objMasMgr.SelectReligionList(0), ddlLocationCategory);
        //Common.FillDropDownList(objMasMgr.SelectLocationCategory(0), ddlLocationCategory, "LOCCATNAME", "LOCCATID", false);
        Common.FillDropDownList(objMasMgr.SelectDivision(0), ddlOrg, "DIVISIONNAME", "DIVISIONID", false);
        Common.FillDropDownList_Nil(objMasMgr.SelectGrade(0), ddlGrade);
        //Common.FillDropDownList(objMasMgr.SelectEmpTypeList(0), ddlEmpType, "TYPENAME", "EMPTYPEID", false);
        Common.FillDropDownList(objEmpInfo.SelectDegree(0,"Y",""), ddlEducation, "DEGREENAME", "DEGREEID", false);
        Common.FillDropDownList_Nil(objMasMgr.SelectSector(0), ddlDistrict);
        //Common.FillDropDownList(objMasMgr.SelectHomeDistrict(0), ddlDistrict, "DISTNAME", "DISTID", false);
        Common.FillDropDownList(objMasMgr.SelectBloodGroupList(0), ddlBloodGroup, "BLOODGROUPNAME", "BLOODGROUPID", false);
        Common.FillDropDownList_Nil(objMasMgr.SelectPositionByFunction(0), ddlPosByFunction);
        Common.FillDropDownList_Nil(objMasMgr.SelectLocation(0), ddlPostingPlace);
        Common.FillDropDownList_Nil(objMasMgr.SelectDivisionWiseDistrict2(0), ddlPostDistrict);
        Common.FillDropDownList_Nil(objMasMgr.SelectSalaryLocation(0), ddlSalaryLoc);
        Common.FillDropDownList_Nil(objMasMgr.SelectPoistingDivision(0), ddlPostDivision);
        Common.FillDropDownList_Nil(objMasMgr.SelectHomeUpazilla(0, 0, "Y"), ddlPerUpazila);
        Common.FillDropDownList_Nil(objMasMgr.SelectHomeDistrict(0, 0, "Y"), ddlPerDistrict);
        Common.FillDropDownList_Nil(objMasMgr.SelectEmpTypeContract(0), ddlEmpType);
        Common.FillDropDownList_Nil(objMasMgr.SelectGradeLevel(0), ddlGradeLevel);
    }


    protected void btnUpload_Click(object sender, EventArgs e)
    {
        string connstr = "Provider=Microsoft.Jet.Oledb.4.0;Data Source=D:\\RDRS Data Migration\\empinfo.xls;Extended Properties=Excel 8.0";
        OleDbConnection conn = new OleDbConnection(connstr);
        string strSQL = "SELECT * FROM [Sheet1$]";

        OleDbCommand cmd = new OleDbCommand(strSQL, conn);
        DataSet ds = new DataSet();
        OleDbDataAdapter da = new OleDbDataAdapter(cmd);
        da.Fill(ds);
        grPayroll.DataSource = ds;
        grPayroll.DataBind();
    }

    protected void btnValidate_Click(object sender, EventArgs e)
    {
         foreach (GridViewRow gRow in grPayroll.Rows)
            {
                //intervention ddlOrg
                foreach (ListItem itm in ddlOrg.Items)
                {
                    if (gRow.Cells[0].Text.Trim().ToUpper() == itm.Text.Trim().ToUpper())
                    {
                        gRow.Cells[0].Text = itm.Value.Trim();
                        gRow.Cells[0].BackColor = System.Drawing.Color.Green;
                        break;
                    }
                }
                // Designation 6
                foreach (ListItem itm in ddlDesig.Items)
                {
                    if (gRow.Cells[6].Text.Trim().ToUpper() == itm.Text.Trim().ToUpper())
                    {
                        gRow.Cells[6].Text = itm.Value.Trim();
                        gRow.Cells[6].BackColor = System.Drawing.Color.Green;
                        break;
                    }
                }
                // fnctional designation (7)
                foreach (ListItem itm in ddlSubDept.Items)
                {
                    if (gRow.Cells[7].Text.Trim().ToUpper() == itm.Text.Trim().ToUpper())
                    {
                        gRow.Cells[7].Text = itm.Value.Trim();
                        gRow.Cells[7].BackColor = System.Drawing.Color.Green;
                        break;
                    }
                }
                // Blood group
                foreach (ListItem itm in ddlBloodGroup.Items)
                {
                    if (gRow.Cells[9].Text.Trim().ToUpper() == itm.Text.Trim().ToUpper())
                    {
                        gRow.Cells[9].Text = itm.Value.Trim();
                        gRow.Cells[9].BackColor = System.Drawing.Color.Green;
                        break;
                    }
                }
                //  Religion 
                foreach (ListItem itm in ddlLocationCategory.Items)
                {
                    if (gRow.Cells[12].Text.Trim().ToUpper() == itm.Text.Trim().ToUpper())
                    {
                        gRow.Cells[12].Text = itm.Value.Trim();
                        gRow.Cells[12].BackColor = System.Drawing.Color.Green;
                        break;
                    }
                }

                //  grade
                foreach (ListItem itm in ddlGrade.Items)
                {
                    if (gRow.Cells[13].Text.Trim().ToUpper() == itm.Text.Trim().ToUpper())
                    {
                        gRow.Cells[13].Text = itm.Value.Trim();
                        gRow.Cells[13].BackColor = System.Drawing.Color.Green;
                        break;
                    }
                }

                //  step grade
                foreach (ListItem itm in ddlGradeLevel.Items)
                {
                    if (gRow.Cells[14].Text.Trim().ToUpper() == itm.Text.Trim().ToUpper())
                    {
                        gRow.Cells[14].Text = itm.Value.Trim();
                        gRow.Cells[14].BackColor = System.Drawing.Color.Green;
                        break;
                    }
                }
                //  Department
                foreach (ListItem itm in ddlClinic.Items)
                {
                    if (gRow.Cells[21].Text.Trim().ToUpper() == itm.Text.Trim().ToUpper())
                    {
                        gRow.Cells[21].Text = itm.Value.Trim();
                        gRow.Cells[21].BackColor = System.Drawing.Color.Green;
                        break;
                    }
                }
                // sector
                foreach (ListItem itm in ddlDistrict.Items)
                {
                    if (gRow.Cells[22].Text.Trim().ToUpper() == itm.Text.Trim().ToUpper())
                    {
                        gRow.Cells[22].Text = itm.Value.Trim();
                        gRow.Cells[22].BackColor = System.Drawing.Color.Green;
                        break;
                    }
                }

                // functional designation
                foreach (ListItem itm in ddlSubDept.Items)
                {
                    if (gRow.Cells[24].Text.Trim().ToUpper() == itm.Text.Trim().ToUpper())
                    {
                        gRow.Cells[24].Text = itm.Value.Trim();
                        gRow.Cells[24].BackColor = System.Drawing.Color.Green;
                        break;
                    }
                }


                // posting place
                foreach (ListItem itm in ddlPostingPlace.Items)
                {
                    if (gRow.Cells[25].Text.Trim().ToUpper() == itm.Text.Trim().ToUpper())
                    {
                        gRow.Cells[25].Text = itm.Value.Trim();
                        gRow.Cells[25].BackColor = System.Drawing.Color.Green;
                        break;
                    }
                }

                // posting district
                foreach (ListItem itm in ddlPostDistrict.Items)
                {
                    if (gRow.Cells[27].Text.Trim().ToUpper() == itm.Text.Trim().ToUpper())
                    {
                        gRow.Cells[27].Text = itm.Value.Trim();
                        gRow.Cells[27].BackColor = System.Drawing.Color.Green;
                        break;
                    }
                }
                // salary location
                foreach (ListItem itm in ddlSalaryLoc.Items)
                {
                    if (gRow.Cells[28].Text.Trim().ToUpper() == itm.Text.Trim().ToUpper())
                    {
                        gRow.Cells[28].Text = itm.Value.Trim();
                        gRow.Cells[28].BackColor = System.Drawing.Color.Green;
                        break;
                    }
                }
                // posting division
                foreach (ListItem itm in ddlPostDivision.Items)
                {
                    if (gRow.Cells[29].Text.Trim().ToUpper() == itm.Text.Trim().ToUpper())
                    {
                        gRow.Cells[29].Text = itm.Value.Trim();
                        gRow.Cells[29].BackColor = System.Drawing.Color.Green;
                        break;
                    }
                }
                //   home upazilla (27)
                foreach (ListItem itm in ddlPerUpazila.Items)
                {
                    if (gRow.Cells[30].Text.Trim().ToUpper() == itm.Text.Trim().ToUpper())
                    {
                        gRow.Cells[30].Text = itm.Value.Trim();
                        gRow.Cells[30].BackColor = System.Drawing.Color.Green;
                        break;
                    }
                }
                // home District
                foreach (ListItem itm in ddlPerDistrict.Items)
                {
                    if (gRow.Cells[31].Text.Trim().ToUpper() == itm.Text.Trim().ToUpper())
                    {
                        gRow.Cells[31].Text = itm.Value.Trim();
                        gRow.Cells[31].BackColor = System.Drawing.Color.Green;
                        break;
                    }
                }

                // Highest Education
                foreach (ListItem itm in ddlEducation.Items)
                {
                    if (gRow.Cells[36].Text.Trim().ToUpper() == itm.Text.Trim().ToUpper())
                    {
                        gRow.Cells[36].Text = itm.Value.Trim();
                        gRow.Cells[36].BackColor = System.Drawing.Color.Green;
                        break;
                    }
                }
                // employee type
                foreach (ListItem itm in ddlEmpType.Items)
                {
                    if (gRow.Cells[37].Text.Trim().ToUpper() == itm.Text.Trim().ToUpper())
                    {
                        gRow.Cells[37].Text = itm.Value.Trim();
                        gRow.Cells[37].BackColor = System.Drawing.Color.Green;
                        break;
                    }
                }
                // appointment type
                foreach (ListItem itm in ddlAppointType.Items)
                {
                    if (gRow.Cells[39].Text.Trim().ToUpper() == itm.Text.Trim().ToUpper())
                    {
                        gRow.Cells[39].Text = itm.Value.Trim();
                        gRow.Cells[39].BackColor = System.Drawing.Color.Green;
                        break;
                    }
                }
              
           
        }
          
    }
   
}