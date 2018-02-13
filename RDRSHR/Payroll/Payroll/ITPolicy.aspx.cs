using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;

public partial class Payroll_Payroll_ITPolicy : System.Web.UI.Page
{
    Payroll_PaySlipOptionMgr objOptMgr = new Payroll_PaySlipOptionMgr();
    dsIncomeTax objDS = new dsIncomeTax();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.ResetNumericText(this);
            DataTable dtPlc = objOptMgr.GetITPolicyData();
            foreach (DataRow dRow in dtPlc.Rows)
            {
                switch (dRow["POLICYID"].ToString().Trim())
                {
                    case "YHA":
                        txtYHAM.Text = dRow["MAMT"].ToString().Trim();
                        txtYHAF.Text = dRow["FAMT"].ToString().Trim();
                        txtYHAA.Text = dRow["AAMT"].ToString().Trim();
                        break;
                    case "MHA":
                        txtMHAM.Text = dRow["MAMT"].ToString().Trim();
                        txtMHAF.Text = dRow["FAMT"].ToString().Trim();
                        txtMHAA.Text = dRow["AAMT"].ToString().Trim();
                        break;
                    case "YTA":
                        txtYTAM.Text = dRow["MAMT"].ToString().Trim();
                        txtYTAF.Text = dRow["FAMT"].ToString().Trim();
                        txtYTAA.Text = dRow["AAMT"].ToString().Trim();
                        break;
                    case "SL0":
                        txtSlot0M.Text = dRow["MAMT"].ToString().Trim();
                        txtSlot0F.Text = dRow["FAMT"].ToString().Trim();
                        txtSlot0A.Text = dRow["AAMT"].ToString().Trim();
                        break;
                    case "SL10":
                        txtSlot10M.Text = dRow["MAMT"].ToString().Trim();
                        txtSlot10F.Text = dRow["FAMT"].ToString().Trim();
                        txtSlot10A.Text = dRow["AAMT"].ToString().Trim();
                        break;
                    case "SL15":
                        txtSlot15M.Text = dRow["MAMT"].ToString().Trim();
                        txtSlot15F.Text = dRow["FAMT"].ToString().Trim();
                        txtSlot15A.Text = dRow["AAMT"].ToString().Trim();
                        break;
                    case "SL20":
                        txtSlot20M.Text = dRow["MAMT"].ToString().Trim();
                        txtSlot20F.Text = dRow["FAMT"].ToString().Trim();
                        txtSlot20A.Text = dRow["AAMT"].ToString().Trim();
                        break;
                    case "SL25":
                        txtSlot25M.Text = dRow["MAMT"].ToString().Trim();
                        txtSlot25F.Text = dRow["FAMT"].ToString().Trim();
                        txtSlot25A.Text = dRow["AAMT"].ToString().Trim();
                        break;
                    case "MNT":
                        txtMinTaxM.Text = dRow["MAMT"].ToString().Trim();
                        txtMinTaxF.Text = dRow["FAMT"].ToString().Trim();
                        txtMinTaxA.Text = dRow["AAMT"].ToString().Trim();
                        break;
                    case "INVA":
                        txtInvAllowM.Text = dRow["MAMT"].ToString().Trim();
                        txtInvAllowF.Text = dRow["FAMT"].ToString().Trim();
                        txtInvAllowA.Text = dRow["AAMT"].ToString().Trim();
                        break;
                    case "INVR":
                        txtInvRebateM.Text = dRow["MAMT"].ToString().Trim();
                        txtInvRebateF.Text = dRow["FAMT"].ToString().Trim();
                        txtInvRebateA.Text = dRow["AAMT"].ToString().Trim();
                        break;
                    case "YMA":
                        txtYMAM.Text = dRow["MAMT"].ToString().Trim();
                        txtYMAF.Text = dRow["FAMT"].ToString().Trim();
                        txtYMAA.Text = dRow["AAMT"].ToString().Trim();
                        break;
                }
            }
        }
    }

    protected void ResetNumericText(Control parent)
    {
        foreach (Control c in parent.Controls)
        {
            if ((c.Controls.Count > 0))
            {
                ResetNumericText(c);
            }
            else if (c.GetType() == typeof(TextBox))
            {
                if (string.IsNullOrEmpty(((TextBox)(c)).Text) == true)
                    ((TextBox)(c)).Text = "0";
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            //Yearly House Rent Max Exemption
            DataRow nRow1 = objDS.DTITPOLICY.NewRow();
            nRow1["POLICYID"] = "YHA";
            nRow1["MAMT"] = txtYHAM.Text.Trim();
            nRow1["FAMT"] = txtYHAF.Text.Trim();
            nRow1["AAMT"] = txtYHAA.Text.Trim();
            objDS.DTITPOLICY.Rows.Add(nRow1);

            //Monthly House Rent Exemption
            DataRow nRow2 = objDS.DTITPOLICY.NewRow();
            nRow2["POLICYID"] = "MHA";
            nRow2["MAMT"] = txtMHAM.Text.Trim();
            nRow2["FAMT"] = txtMHAF.Text.Trim();
            nRow2["AAMT"] = txtMHAA.Text.Trim();
            objDS.DTITPOLICY.Rows.Add(nRow2);
            //Yearly Transport Allowance Exemption
            DataRow nRow3 = objDS.DTITPOLICY.NewRow();
            nRow3["POLICYID"] = "YTA";
            nRow3["MAMT"] = txtYTAM.Text.Trim();
            nRow3["FAMT"] = txtYTAF.Text.Trim();
            nRow3["AAMT"] = txtYTAA.Text.Trim();
            objDS.DTITPOLICY.Rows.Add(nRow3);
            //0 Income Tax Slot
            DataRow nRow4 = objDS.DTITPOLICY.NewRow();
            nRow4["POLICYID"] = "SL0";
            nRow4["MAMT"] = txtSlot0M.Text.Trim();
            nRow4["FAMT"] = txtSlot0F.Text.Trim();
            nRow4["AAMT"] = txtSlot0A.Text.Trim();
            objDS.DTITPOLICY.Rows.Add(nRow4);
            //10% Income Tax Slot
            DataRow nRow5 = objDS.DTITPOLICY.NewRow();
            nRow5["POLICYID"] = "SL10";
            nRow5["MAMT"] = txtSlot10M.Text.Trim();
            nRow5["FAMT"] = txtSlot10F.Text.Trim();
            nRow5["AAMT"] = txtSlot10A.Text.Trim();
            objDS.DTITPOLICY.Rows.Add(nRow5);
            //15% Income Tax Slot
            DataRow nRow6 = objDS.DTITPOLICY.NewRow();
            nRow6["POLICYID"] = "SL15";
            nRow6["MAMT"] = txtSlot15M.Text.Trim();
            nRow6["FAMT"] = txtSlot15F.Text.Trim();
            nRow6["AAMT"] = txtSlot15A.Text.Trim();
            objDS.DTITPOLICY.Rows.Add(nRow6);
            //20% Income Tax Slot
            DataRow nRow7 = objDS.DTITPOLICY.NewRow();
            nRow7["POLICYID"] = "SL20";
            nRow7["MAMT"] = txtSlot20M.Text.Trim();
            nRow7["FAMT"] = txtSlot20F.Text.Trim();
            nRow7["AAMT"] = txtSlot20A.Text.Trim();
            objDS.DTITPOLICY.Rows.Add(nRow7);
            //25% Income Tax Slot
            DataRow nRow8 = objDS.DTITPOLICY.NewRow();
            nRow8["POLICYID"] = "SL25";
            nRow8["MAMT"] = txtSlot25M.Text.Trim();
            nRow8["FAMT"] = txtSlot25F.Text.Trim();
            nRow8["AAMT"] = txtSlot25A.Text.Trim();
            objDS.DTITPOLICY.Rows.Add(nRow8);
            //Minimum Income Tax 
            DataRow nRow9 = objDS.DTITPOLICY.NewRow();
            nRow9["POLICYID"] = "MNT";
            nRow9["MAMT"] = txtMinTaxM.Text.Trim();
            nRow9["FAMT"] = txtMinTaxF.Text.Trim();
            nRow9["AAMT"] = txtMinTaxA.Text.Trim();
            objDS.DTITPOLICY.Rows.Add(nRow9);

            //Investment Allow % 
            DataRow nRow10 = objDS.DTITPOLICY.NewRow();
            nRow10["POLICYID"] = "INVA";
            nRow10["MAMT"] = txtInvAllowM.Text.Trim();
            nRow10["FAMT"] = txtInvAllowF.Text.Trim();
            nRow10["AAMT"] = txtInvAllowA.Text.Trim();
            objDS.DTITPOLICY.Rows.Add(nRow10);

            //Investment Rebate %
            DataRow nRow11 = objDS.DTITPOLICY.NewRow();
            nRow11["POLICYID"] = "INVR";
            nRow11["MAMT"] = txtInvRebateM.Text.Trim();
            nRow11["FAMT"] = txtInvRebateF.Text.Trim();
            nRow11["AAMT"] = txtInvRebateA.Text.Trim();
            objDS.DTITPOLICY.Rows.Add(nRow11);

            //Yearly Medical Max Exemption
            DataRow nRow12 = objDS.DTITPOLICY.NewRow();
            nRow12["POLICYID"] = "YMA";
            nRow12["MAMT"] = txtYMAM.Text.Trim();
            nRow12["FAMT"] = txtYMAF.Text.Trim();
            nRow12["AAMT"] = txtYMAA.Text.Trim();
            objDS.DTITPOLICY.Rows.Add(nRow12);

            objOptMgr.SaveITPolicyData(objDS.Tables["DTITPOLICY"], Session["USERID"].ToString(),
                Common.SetDateTime(DateTime.Now.ToString()));
            lblMsg.Text = "Policy Saved Successfully";

            objDS.DTITPOLICY.Rows.Clear();
            objDS.DTITPOLICY.Dispose();
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message.ToString();
        }
    }
}
