<%@ Page Language="C#" MasterPageFile="~/MasterBTMS.master" AutoEventWireup="true"
    CodeFile="AdjustAttendance.aspx.cs" Inherits="Attendance_AdjustAttendance" Title="Adjust Attendance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript" src="../Script/datetimepicker.js">
    //Date Time Picker script
    </script>

    <script language="javascript" type="text/javascript">
    function ToUpper(ctrl)
    {   
    var t = ctrl.value;
    ctrl.value = t.toUpperCase(); 
    }
    </script>

    <script language="javascript" type="text/javascript">

window.onload=SearchByChanged;
function SearchByChanged()
{
    var ddlSB = document.getElementById('<%= ddlSearchBy.ClientID %>');
    var pnSV=document.getElementById('<%=pnlDept.ClientID%>');
    var pnlD=document.getElementById('<%=pnlValue.ClientID%>');
    var myindex  = ddlSB.selectedIndex
    var SelValue = ddlSB.options[myindex].value
    if(SelValue=="4")
    {
       // alert(SelValue);
        pnSV.style.visibility="hidden";
        pnlD.style.visibility="visible";
      
    }
    if(SelValue=="3")
    {
        //alert(SelValue);
        pnSV.style.visibility="visible";
        pnlD.style.visibility="hidden";
    }
    return DisplayControl();    
}

function ValidateEmpNo()
{
    var ddlSB = document.getElementById('<%= ddlSearchBy.ClientID %>');
    var txtV=document.getElementById('<%=txtEmpId.ClientID%>');
    var myindex  = ddlSB.selectedIndex
    var SelValue = ddlSB.options[myindex].value
    if(SelValue=="1")
    {
        //alert("hi");
        if(txtV.value='')
        {
            return false;
        }
    }
 return true;
}
  
 function DisplayControl()
 {
     var txtADT= document.getElementById('<%=txtAttnDateTo.ClientID%>');
     var ddlIH= document.getElementById('<%=ddlInHour.ClientID%>');
     var ddlIM= document.getElementById('<%=ddlInMin.ClientID%>');
     var ddlOH=document.getElementById('<%=ddlOutHour.ClientID%>');
     var ddlOM=document.getElementById('<%=ddlOutMin.ClientID%>');
     var ddlS=document.getElementById('<%=ddlStatus.ClientID%>');
     var ddlSh=document.getElementById('<%=ddlShift.ClientID%>');
      
     var chTo=document.getElementById('<%=chkTo.ClientID%>');
     var chIn=document.getElementById('<%=chkIn.ClientID%>');
     var chOut=document.getElementById('<%=chkOut.ClientID%>');
     var chStatus=document.getElementById('<%=chkStatus.ClientID%>');
     var chShift=document.getElementById('<%=chkShift.ClientID%>');

     if(chTo.checked==false)
        {
            txtADT.disabled=true;
        }
      if(chIn.checked==false)
        {
            ddlIH.disabled=true;
            ddlIM.disabled=true;
        }
        if(chOut.checked==false)
        {
            ddlOH.disabled=true;
            ddlOM.disabled=true;
        }
        if(chStatus.checked==false)
        {
            ddlS.disabled=true;
        }
         if(chShift.checked==false)
        {
            ddlSh.disabled=true;
        }
        return false;
}

function CheckBoxToSelect(cbControl)
{   
       var chkBox= document.getElementById(cbControl);
       var txtADT= document.getElementById('<%=txtAttnDateTo.ClientID%>');
       alert("To");
        if(chkBox.checked==false)
        {
         txtADT.disabled=true;
      
        }
        else
        {
        txtADT.disabled=false;
        }
       
        return false; 
}

function ChkToChanged()
{
    var txtADT= document.getElementById('<%=txtAttnDateTo.ClientID%>');
    var chTo=document.getElementById('<%=chkTo.ClientID%>');
    if(chTo.checked==false)
    {
       txtADT.disabled=true;      
    }
    else
    {
        txtADT.disabled=false;       
    }   
}

function ChkInChanged()
{
    var ddlIH= document.getElementById('<%=ddlInHour.ClientID%>');
    var ddlIM= document.getElementById('<%=ddlInMin.ClientID%>');
    var chIn=document.getElementById('<%=chkIn.ClientID%>');
    if(chIn.checked==false)
    {
       ddlIH.disabled=true;
       ddlIM.disabled=true;
    }
    else
    {
         ddlIH.disabled=false;
         ddlIM.disabled=false;
    }
}

function ChkOutChanged()
{
   var ddlOH=document.getElementById('<%=ddlOutHour.ClientID%>');
   var ddlOM=document.getElementById('<%=ddlOutMin.ClientID%>');
   var chOut=document.getElementById('<%=chkOut.ClientID%>');
   if(chOut.checked==false)
   {
        ddlOH.disabled=true;
        ddlOM.disabled=true;
   }
    else
    {
        ddlOH.disabled=false;
        ddlOM.disabled=false;
    }
}

function ChkStatusChanged()
{
   var ddlS=document.getElementById('<%=ddlStatus.ClientID%>');
   var chStatus=document.getElementById('<%=chkStatus.ClientID%>');
   if(chStatus.checked==false)
   {
        ddlS.disabled=true;
   }
    else
    {
        ddlS.disabled=false;         
    }
}

function ChkShiftChanged()
{
  var ddlSh=document.getElementById('<%=ddlShift.ClientID%>');
  var chShift=document.getElementById('<%=chkShift.ClientID%>');
  if(chShift.checked==false)
  {
        ddlSh.disabled=true;
  }
  else
  {
        ddlSh.disabled=false;
  }
}
function selectAllNone(grID, value) 
{
      var tvNodes = document.getElementById(grID);
      var chBoxes = tvNodes.getElementsByTagName("input");
      for (var i = 0; i < chBoxes.length; i++) 
      {
          var chk = chBoxes[i];
          if (chk.type == "checkbox") 
          {
                chk.checked = value;
                //alert(tvNodes[i].href);
          }
       }  
}

function ValidateIsNextDay()
{
    var ddlIH = document.getElementById('<%= ddlInHour.ClientID %>');
    var ddlIM = document.getElementById('<%= ddlInMin.ClientID %>');
    var ddlOH = document.getElementById('<%= ddlOutHour.ClientID %>');
    var ddlOM = document.getElementById('<%= ddlOutMin.ClientID %>');
    var chND=document.getElementById('<%=chkIsNextDay.ClientID%>');
    
    var myindexIH  = ddlIH.selectedIndex;
    var SelValueIH = ddlIH.options[myindexIH].value;
    
    var myindexIM  = ddlIM.selectedIndex;
    var SelValueIM = ddlIM.options[myindexIM].value;
    
    var myindexOH  = ddlOH.selectedIndex;
    var SelValueOH = ddlOH.options[myindexOH].value;
    
    var myindexOM  = ddlOM.selectedIndex;
    var SelValueOM = ddlOM.options[myindexOM].value;
    
    var IH= parseInt(SelValueIH);
    var OH= parseInt(SelValueOH);
    var IM= parseInt(SelValueIM);
    var OM= parseInt(SelValueOM);
     
    if(OH == IH)
    {
       if(OM < IM)
        {
            
            alert("Out Time is Selected as Next Day");
            chND.checked=true;
        }
        else
        {
            chND.checked=false;
        }
    }
    else if(OH < IH)
    {
        chND.checked=true;
    }
//    else if(OH > IH)
//    {
//        chND.checked=false;
//    }
}
    </script>

    <div class="formStyle">
        <div id="formhead3">
            Adjust Attendance</div>
        <div class="MsgBox">
            <asp:Label ID="lblMsg" runat="server" CssClass="msglabel"></asp:Label>
        </div>
        <div class="iesEmp">
            <fieldset>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <contenttemplate>
                <table>
                    <tbody>
                        <tr>
                            <td style="width: 3px; height: 24px" align="right">
                                <asp:Label ID="Label1" runat="server" Text="Search By :" CssClass="textlevel" Width="79px"></asp:Label></td>
                            <td style="width: 81px; height: 24px">
                                <asp:DropDownList ID="ddlSearchBy" runat="server" Width="100px" onchange="SearchByChanged()"
                                    OnSelectedIndexChanged="ddlSearchBy_SelectedIndexChanged" CssClass="textlevelleft">
                                    <asp:ListItem Value="3">Location</asp:ListItem>
                                    <asp:ListItem Value="4">Employee ID</asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="width: 3px; height: 24px">
                            </td>
                            <td style="width: 3px; height: 24px">
                                <asp:Panel ID="pnlValue" runat="server" Width="125px" Height="25px">
                                    <table>
                                        <tbody>
                                            <tr>
                                                <td style="width: 3px">
                                                    <asp:Label ID="Label4" runat="server" Text="Enter Value :" CssClass="textlevel"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="txtEmpId" runat="server" Width="80px" onkeyup="ToUpper(this)"></asp:TextBox></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </asp:Panel>
                            </td>
                            <td style="width: 3px; height: 24px; text-align: right" align="right">
                                <asp:Label ID="Label2" runat="server" Text="Attendance Date :" CssClass="textlevel"
                                    Width="94px"></asp:Label></td>
                            <td style="width: 3px; height: 24px">
                                <asp:TextBox ID="txtAttnFromDate" runat="server" Width="80px"></asp:TextBox></td>
                            <td style="width: 3px; height: 24px">
                                <a href="javascript:NewCal('<%= txtAttnFromDate.ClientID %>','ddmmyyyy')">
                                    <img style="border-right: 0px; border-top: 0px; border-left: 0px; border-bottom: 0px"
                                        height="16" alt="Pick a date" src="../images/cal.gif" width="16" /></a></td>
                            <td style="width: 3px; height: 24px">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                    ControlToValidate="txtAttnFromDate"></asp:RequiredFieldValidator></td>
                            <td style="width: 3px; height: 24px">
                                <asp:CheckBox ID="chkTo" onclick="ChkToChanged()" runat="server" Text="To" CssClass="textlevelshort"
                                    Width="40px"></asp:CheckBox></td>
                            <td style="width: 3px; height: 24px">
                                <asp:TextBox ID="txtAttnDateTo" runat="server" Width="94px"></asp:TextBox></td>
                            <td style="width: 3px; height: 24px">
                                <a href="javascript:NewCal('<%= txtAttnDateTo.ClientID %>','ddmmyyyy')">
                                    <img style="border-right: 0px; border-top: 0px; border-left: 0px; border-bottom: 0px"
                                        height="16" alt="Pick a date" src="../images/cal.gif" width="16" /></a></td>
                            <td style="width: 3px; height: 24px">
                            </td>
                        </tr>
                    </tbody>
                </table>
                <table>
                    <tbody>
                        <tr>
                            <td style="height: 24px; text-align: left" align="left" colspan="6">
                                <asp:Panel ID="pnlDept" runat="server">
                                    <table>
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label6" runat="server" CssClass="textlevel" Width="72px">Location :</asp:Label></td>
                                                <td style="width: 103px">
                                                    <asp:DropDownList ID="ddlLocation" CssClass="textlevelleft" runat="server" Width="211px" Font-Size="9pt">
                                                    </asp:DropDownList></td>
                                                <td style="width: 86px">
                                                </td>
                                                <td style="width: 86px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblEmpType" runat="server" CssClass="textlevel" Width="76px" Visible="False">Emp Type :</asp:Label></td>
                                                <td style="width: 103px">
                                                    <asp:DropDownList ID="ddlEmpType" CssClass="textlevelleft" runat="server" Width="210px" onchange="SearchByChanged()"
                                                        Font-Size="9pt" Visible="False" Enabled="True" AutoPostBack="True">
                                                    </asp:DropDownList></td>
                                                <td style="width: 86px">
                                                    <asp:Label ID="lblName" runat="server" CssClass="textlevel" Width="76px" Visible="False">Team :</asp:Label></td>
                                                <td style="width: 86px">
                                                    <asp:DropDownList ID="ddlSearchValue" CssClass="textlevelleft" runat="server" Width="210px" Visible="False">
                                                    </asp:DropDownList></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <table>
                                        <tbody>
                                        </tbody>
                                    </table>
                                </asp:Panel>
                            </td>
                            <td style="width: 115px; height: 24px" align="right" colspan="4">
                                <asp:Label ID="Label3" runat="server" Text="Attendance Status :" CssClass="textlevel"
                                    Width="100px"></asp:Label></td>
                            <td style="width: 3px; height: 24px">
                                <asp:DropDownList ID="ddlAttnStatus" runat="server" CssClass="textlevelleft">
                                    <asp:ListItem Value="0">All</asp:ListItem>
                                    <asp:ListItem Value="A">Absent (A)</asp:ListItem>
                                    <asp:ListItem Value="L">Late (L)</asp:ListItem>
                                    <asp:ListItem Value="LV">Leave (LV)</asp:ListItem>
                                    <asp:ListItem Value="P">Present</asp:ListItem>
                                    <asp:ListItem Value="X">Shift Error</asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="width: 3px; height: 24px">
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*" ControlToValidate="ddlAttnStatus"
                                    Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator></td>
                            <td style="width: 3px; height: 24px">
                                <asp:Button ID="btnRetrieve" OnClick="btnRetrieve_Click" runat="server" Text="Retrieve"
                                    Width="90px" OnClientClick="return ValidateEmpNo();"></asp:Button></td>
                        </tr>
                    </tbody>
                </table>
                </contenttemplate>
                    <triggers>
<asp:AsyncPostBackTrigger ControlID="btnRetrieve" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
                </asp:UpdatePanel>
            </fieldset>
            &nbsp;
        </div>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <contenttemplate>
        <div class="iesEmp">
            <fieldset>
                <table>
                    <tbody>
                        <tr>
                            <td style="width: 3px">
                                <asp:CheckBox ID="chkIn" onclick="ChkInChanged()" runat="server" Text="In Time" CssClass="textlevelshort"
                                    Width="60px"></asp:CheckBox></td>
                            <td style="width: 3px">
                                <asp:DropDownList ID="ddlInHour" runat="server" Width="45px" CssClass="textlevelleft">
                                    <asp:ListItem Value="1">01</asp:ListItem>
                                    <asp:ListItem Value="02">02</asp:ListItem>
                                    <asp:ListItem Value="03">03</asp:ListItem>
                                    <asp:ListItem Value="04">04</asp:ListItem>
                                    <asp:ListItem Value="05">05</asp:ListItem>
                                    <asp:ListItem Value="06">06</asp:ListItem>
                                    <asp:ListItem Value="07">07</asp:ListItem>
                                    <asp:ListItem Value="08">08</asp:ListItem>
                                    <asp:ListItem Value="09">09</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                    <asp:ListItem>11</asp:ListItem>
                                    <asp:ListItem>12</asp:ListItem>
                                    <asp:ListItem>13</asp:ListItem>
                                    <asp:ListItem>14</asp:ListItem>
                                    <asp:ListItem>15</asp:ListItem>
                                    <asp:ListItem>16</asp:ListItem>
                                    <asp:ListItem>17</asp:ListItem>
                                    <asp:ListItem>18</asp:ListItem>
                                    <asp:ListItem>19</asp:ListItem>
                                    <asp:ListItem>20</asp:ListItem>
                                    <asp:ListItem>21</asp:ListItem>
                                    <asp:ListItem>22</asp:ListItem>
                                    <asp:ListItem>23</asp:ListItem>
                                    <asp:ListItem>24</asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="width: 3px">
                                <asp:DropDownList ID="ddlInMin" runat="server" Width="45px" CssClass="textlevelleft">
                                    <asp:ListItem Value="00">00</asp:ListItem>
                                    <asp:ListItem>01</asp:ListItem>
                                    <asp:ListItem>02</asp:ListItem>
                                    <asp:ListItem>03</asp:ListItem>
                                    <asp:ListItem>04</asp:ListItem>
                                    <asp:ListItem>05</asp:ListItem>
                                    <asp:ListItem>06</asp:ListItem>
                                    <asp:ListItem>07</asp:ListItem>
                                    <asp:ListItem>08</asp:ListItem>
                                    <asp:ListItem>09</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                    <asp:ListItem>11</asp:ListItem>
                                    <asp:ListItem>12</asp:ListItem>
                                    <asp:ListItem>13</asp:ListItem>
                                    <asp:ListItem>14</asp:ListItem>
                                    <asp:ListItem>15</asp:ListItem>
                                    <asp:ListItem>16</asp:ListItem>
                                    <asp:ListItem>17</asp:ListItem>
                                    <asp:ListItem>18</asp:ListItem>
                                    <asp:ListItem>19</asp:ListItem>
                                    <asp:ListItem>20</asp:ListItem>
                                    <asp:ListItem>21</asp:ListItem>
                                    <asp:ListItem>22</asp:ListItem>
                                    <asp:ListItem>23</asp:ListItem>
                                    <asp:ListItem>24</asp:ListItem>
                                    <asp:ListItem>25</asp:ListItem>
                                    <asp:ListItem>26</asp:ListItem>
                                    <asp:ListItem>27</asp:ListItem>
                                    <asp:ListItem>28</asp:ListItem>
                                    <asp:ListItem>29</asp:ListItem>
                                    <asp:ListItem>30</asp:ListItem>
                                    <asp:ListItem>31</asp:ListItem>
                                    <asp:ListItem>32</asp:ListItem>
                                    <asp:ListItem>33</asp:ListItem>
                                    <asp:ListItem>34</asp:ListItem>
                                    <asp:ListItem>35</asp:ListItem>
                                    <asp:ListItem>36</asp:ListItem>
                                    <asp:ListItem>37</asp:ListItem>
                                    <asp:ListItem>38</asp:ListItem>
                                    <asp:ListItem>39</asp:ListItem>
                                    <asp:ListItem>40</asp:ListItem>
                                    <asp:ListItem>41</asp:ListItem>
                                    <asp:ListItem>42</asp:ListItem>
                                    <asp:ListItem>43</asp:ListItem>
                                    <asp:ListItem>44</asp:ListItem>
                                    <asp:ListItem>45</asp:ListItem>
                                    <asp:ListItem>46</asp:ListItem>
                                    <asp:ListItem>47</asp:ListItem>
                                    <asp:ListItem>48</asp:ListItem>
                                    <asp:ListItem>49</asp:ListItem>
                                    <asp:ListItem>50</asp:ListItem>
                                    <asp:ListItem>51</asp:ListItem>
                                    <asp:ListItem>52</asp:ListItem>
                                    <asp:ListItem>53</asp:ListItem>
                                    <asp:ListItem>54</asp:ListItem>
                                    <asp:ListItem>55</asp:ListItem>
                                    <asp:ListItem>56</asp:ListItem>
                                    <asp:ListItem>57</asp:ListItem>
                                    <asp:ListItem>58</asp:ListItem>
                                    <asp:ListItem>59</asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="width: 3px">
                                <asp:CheckBox ID="chkOut" onclick="ChkOutChanged()" runat="server" Text="Out Time"
                                    CssClass="textlevelshort" Width="70px"></asp:CheckBox></td>
                            <td style="width: 4px">
                                <asp:DropDownList ID="ddlOutHour" runat="server" Width="45px" CssClass="textlevelleft" OnSelectedIndexChanged="ddlOutHour_SelectedIndexChanged">
                                    <%--onchange="ValidateIsNextDay();"--%>
                                    <asp:ListItem Value="1">01</asp:ListItem>
                                    <asp:ListItem Value="02">02</asp:ListItem>
                                    <asp:ListItem Value="03">03</asp:ListItem>
                                    <asp:ListItem Value="04">04</asp:ListItem>
                                    <asp:ListItem Value="05">05</asp:ListItem>
                                    <asp:ListItem Value="06">06</asp:ListItem>
                                    <asp:ListItem Value="07">07</asp:ListItem>
                                    <asp:ListItem Value="08">08</asp:ListItem>
                                    <asp:ListItem Value="09">09</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                    <asp:ListItem>11</asp:ListItem>
                                    <asp:ListItem>12</asp:ListItem>
                                    <asp:ListItem>13</asp:ListItem>
                                    <asp:ListItem>14</asp:ListItem>
                                    <asp:ListItem>15</asp:ListItem>
                                    <asp:ListItem>16</asp:ListItem>
                                    <asp:ListItem>17</asp:ListItem>
                                    <asp:ListItem>18</asp:ListItem>
                                    <asp:ListItem>19</asp:ListItem>
                                    <asp:ListItem>20</asp:ListItem>
                                    <asp:ListItem>21</asp:ListItem>
                                    <asp:ListItem>22</asp:ListItem>
                                    <asp:ListItem>23</asp:ListItem>
                                    <asp:ListItem>24</asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="width: 3px">
                                <asp:DropDownList ID="ddlOutMin" runat="server" Width="45px" onchange="ValidateIsNextDay()">
                                    <asp:ListItem Value="00">00</asp:ListItem>
                                    <asp:ListItem>01</asp:ListItem>
                                    <asp:ListItem>02</asp:ListItem>
                                    <asp:ListItem>03</asp:ListItem>
                                    <asp:ListItem>04</asp:ListItem>
                                    <asp:ListItem>05</asp:ListItem>
                                    <asp:ListItem>06</asp:ListItem>
                                    <asp:ListItem>07</asp:ListItem>
                                    <asp:ListItem>08</asp:ListItem>
                                    <asp:ListItem>09</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                    <asp:ListItem>11</asp:ListItem>
                                    <asp:ListItem>12</asp:ListItem>
                                    <asp:ListItem>13</asp:ListItem>
                                    <asp:ListItem>14</asp:ListItem>
                                    <asp:ListItem>15</asp:ListItem>
                                    <asp:ListItem>16</asp:ListItem>
                                    <asp:ListItem>17</asp:ListItem>
                                    <asp:ListItem>18</asp:ListItem>
                                    <asp:ListItem>19</asp:ListItem>
                                    <asp:ListItem>20</asp:ListItem>
                                    <asp:ListItem>21</asp:ListItem>
                                    <asp:ListItem>22</asp:ListItem>
                                    <asp:ListItem>23</asp:ListItem>
                                    <asp:ListItem>24</asp:ListItem>
                                    <asp:ListItem>25</asp:ListItem>
                                    <asp:ListItem>26</asp:ListItem>
                                    <asp:ListItem>27</asp:ListItem>
                                    <asp:ListItem>28</asp:ListItem>
                                    <asp:ListItem>29</asp:ListItem>
                                    <asp:ListItem>30</asp:ListItem>
                                    <asp:ListItem>31</asp:ListItem>
                                    <asp:ListItem>32</asp:ListItem>
                                    <asp:ListItem>33</asp:ListItem>
                                    <asp:ListItem>34</asp:ListItem>
                                    <asp:ListItem>35</asp:ListItem>
                                    <asp:ListItem>36</asp:ListItem>
                                    <asp:ListItem>37</asp:ListItem>
                                    <asp:ListItem>38</asp:ListItem>
                                    <asp:ListItem>39</asp:ListItem>
                                    <asp:ListItem>40</asp:ListItem>
                                    <asp:ListItem>41</asp:ListItem>
                                    <asp:ListItem>42</asp:ListItem>
                                    <asp:ListItem>43</asp:ListItem>
                                    <asp:ListItem>44</asp:ListItem>
                                    <asp:ListItem>45</asp:ListItem>
                                    <asp:ListItem>46</asp:ListItem>
                                    <asp:ListItem>47</asp:ListItem>
                                    <asp:ListItem>48</asp:ListItem>
                                    <asp:ListItem>49</asp:ListItem>
                                    <asp:ListItem>50</asp:ListItem>
                                    <asp:ListItem>51</asp:ListItem>
                                    <asp:ListItem>52</asp:ListItem>
                                    <asp:ListItem>53</asp:ListItem>
                                    <asp:ListItem>54</asp:ListItem>
                                    <asp:ListItem>55</asp:ListItem>
                                    <asp:ListItem>56</asp:ListItem>
                                    <asp:ListItem>57</asp:ListItem>
                                    <asp:ListItem>58</asp:ListItem>
                                    <asp:ListItem>59</asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="width: 3px">
                                <asp:CheckBox ID="chkIsNextDay" runat="server" Text="Next day" CssClass="textlevel"
                                    Width="70px"></asp:CheckBox></td>
                            <td style="width: 3px">
                                <asp:CheckBox ID="chkStatus" onclick="ChkStatusChanged()" runat="server" Text="Status"
                                    CssClass="textlevel" Width="70px"></asp:CheckBox></td>
                            <td style="width: 3px">
                                <asp:DropDownList ID="ddlStatus" runat="server" Width="100px" CssClass="textlevelleft">
                                    <asp:ListItem Value="-1">Select</asp:ListItem>
                                    <asp:ListItem Value="W">Weekend</asp:ListItem>
                                    <asp:ListItem Value="H">Holiday</asp:ListItem>
                                    <asp:ListItem Value="A">Absent</asp:ListItem>
                                    <asp:ListItem Value="WD">Working Day</asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="width: 3px">
                            </td>
                            <td style="width: 70px">
                            </td>
                            <td style="width: 3px">
                                <asp:CheckBox ID="chkShift" onclick="ChkShiftChanged()" runat="server" Text="Set Shift As"
                                    CssClass="textlevel" OnCheckedChanged="chkShift_CheckedChanged"></asp:CheckBox></td>
                            <td style="width: 3px">
                                <asp:DropDownList ID="ddlShift" runat="server" Width="100px" CssClass="textlevelleft">
                                </asp:DropDownList></td>
                            <td style="width: 3px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 3px">
                                <asp:Label ID="Label5" runat="server" Text="Remarks" CssClass="textlevelshort" Width="60px"></asp:Label></td>
                            <td colspan="10">
                                <asp:TextBox ID="txtRemarks" runat="server" Width="580px"></asp:TextBox></td>
                            <td style="width: 3px">
                            </td>
                            <td colspan="2">
                                <asp:Button ID="btnAdd" OnClick="btnAdd_Click" runat="server" Text="Add" Width="120px"
                                    OnClientClick="ValidateIsNextDay();"></asp:Button></td>
                        </tr>
                    </tbody>
                </table>
            </fieldset>
        </div>
        <div class="Grid650">
            <asp:GridView ID="grAttnAdj" runat="server" Width="1640px" Font-Size="9px" EmptyDataText="No Record Found"
                DataKeyNames="SL,SunIn,SunOut,ArvlGrace,AttnPolicyId,LunchBreak,OTStartGrace,IsUpdated"
                AutoGenerateColumns="False">
                <HeaderStyle BackColor="#B3CDE4" Font-Bold="True" />
                <SelectedRowStyle BackColor="#D1DDF1" CssClass="ListHeader" Font-Bold="True" ForeColor="#333333" />
                <AlternatingRowStyle BackColor="#EFF3FB" />
                <Columns>
                    <asp:TemplateField HeaderText="Select">
                        <ItemStyle CssClass="ItemStylecss" />
                        <ItemTemplate>
                            <asp:CheckBox ID="chkBox" runat="Server"></asp:CheckBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="EmpId" HeaderText="Emp.No">
                        <ItemStyle CssClass="ItemStylecss" Width="80px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="FullName" HeaderText="Employee Name">
                        <ItemStyle CssClass="ItemStylecss" Width="160px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="JobTitle" HeaderText="Designation">
                        <ItemStyle CssClass="ItemStylecss" Width="120px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="DeptName" HeaderText="Department">
                        <ItemStyle CssClass="ItemStylecss" Width="140px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="AttndDate" HeaderText="Date">
                        <ItemStyle CssClass="ItemStylecss" Width="80px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="SignInTime" HeaderText="In Time">
                        <ItemStyle CssClass="ItemStylecss" Width="140px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="InLocation" HeaderText="In Loc.">
                        <ItemStyle CssClass="ItemStylecss" Width="80px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="SignOutTime" HeaderText="Out Time">
                        <ItemStyle CssClass="ItemStylecss" Width="140px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="OutLocation" HeaderText="Out Loc.">
                        <ItemStyle CssClass="ItemStylecss" Width="80px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Status" HeaderText="Status">
                        <ItemStyle CssClass="ItemStylecss" Width="60px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Delay">
                        <ItemTemplate>
                            <asp:Label ID="lblDelays" runat="server" Text='<%# CalculateDelay(Convert.ToString(Eval("SignInTime")),Convert.ToString(Eval("SunIn")),Convert.ToString(Eval("ArvlGrace"))) %>' />
                        </ItemTemplate>
                        <ItemStyle CssClass="ItemStylecss" Width="40px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Remarks" HeaderText="Remarks">
                        <ItemStyle CssClass="ItemStylecss" Width="180px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="PolicyName" HeaderText="Shift Held">
                        <ItemStyle CssClass="ItemStylecss" Width="80px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ChangedShift" HeaderText="Changed Shift">
                        <ItemStyle CssClass="ItemStylecss" Width="80px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CardNo" HeaderText="CardNo">
                        <ItemStyle CssClass="ItemStylecss" Width="80px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="isUpdatedManually" HeaderText="Is Manual">
                        <ItemStyle CssClass="ItemStylecss" Width="80px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ExtraTimeWorked" HeaderText="OT(Min.)">
                        <ItemStyle CssClass="ItemStylecss" Width="60px" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </div>
        <div style="margin-left: 15px" id="Div1">
            <a id="A1" onclick="javascript: selectAllNone('<%= this.grAttnAdj.ClientID %>',true)"
                href="#">Select All</a> <a id="A2" onclick="javascript: selectAllNone('<%= this.grAttnAdj.ClientID %>',false)"
                    href="#">Clear All</a>
        </div>
        </contenttemplate>
            <triggers>
<asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
        </asp:UpdatePanel>
        <div id="DivCommand1">
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnRefresh" runat="server" Text="Refresh" Width="70px" CausesValidation="False"
                            OnClick="btnRefresh_Click" /></td>
                    <td align="right">
                        <asp:Button ID="btnSave" runat="server" Text="Adjust Attendance" Width="120px" OnClick="btnSave_Click" /></td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
