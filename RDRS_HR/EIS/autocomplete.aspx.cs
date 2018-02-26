using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EIS_autocomplete : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        //lbl.InnerText = tbAuto.Text;

        //string pattern1 = @"(^\\w+\\s*\\[){1}(\\w+){1}(\\]){1}";
        //string pattern2 = "(^\\w+\\[){1}(\\w){1}";
        //string pattern3 = "(^\\w+\\[)+(\\w+){1}(\\])$";
        //bool tt1 = System.Text.RegularExpressions.Regex.IsMatch(tbAuto.Text, pattern1);
        //bool tt2 = System.Text.RegularExpressions.Regex.IsMatch(tbAuto.Text, pattern2);
        //bool tt3 = System.Text.RegularExpressions.Regex.IsMatch(tbAuto.Text, pattern3);
        //Regex extractInitials1 = new Regex(pattern1);
        //string rp1= extractInitials1.Replace(tbAuto.Text, "$1" );

        //var match1 = Regex.Match(tbAuto.Text, pattern1);
        //var match2 = Regex.Match(tbAuto.Text, "(^\\w+\\[)");
        var match3 = Regex.Match(tbAuto.Text, "(^(\\w+\\s)+\\[)*(\\w+)");

        //string rr0 = match.Groups[0].Value;
        //string rr1 = match.Groups[1].Value;
        //string rr2 = match.Groups[2].Value;

    }
}