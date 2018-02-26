<%@ Page Language="C#" AutoEventWireup="true" CodeFile="autocomplete.aspx.cs" Inherits="EIS_autocomplete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AutoComplete Box with jQuery</title>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css"/>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/jquery-ui.min.js"></script>
    <script type="text/javascript">
	    $(function() {
	        $(".tb").autocomplete({
	            source: function(request, response) {
	                $.ajax({
	                    url: "employeelist.asmx/FetchEmailList",
	                    data: "{ 'mail': '" + request.term + "' }",
	                    dataType: "json",
	                    type: "POST",
	                    contentType: "application/json; charset=utf-8",
	                    dataFilter: function(data) { return data; },
	                    success: function (data) {
	                        response($.map(data.d, function(item) {
	                            return {
	                                value: item.Email
	                            }
	                        }))
	                    },
	                    error: function(XMLHttpRequest, textStatus, errorThrown) {
	                        alert(textStatus);
	                    }
	                });
	            },
	            minLength: 2
	        });
	    });
	</script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="demo">
        <div class="ui-widget">
            <label id="lbl" runat="server" for="tbAuto">Enter Email: </label>
             <asp:TextBox ID="tbAuto" class="tb" runat="server"></asp:TextBox>
            <asp:Button runat="server" ID="btnSave" Text="Save" OnClick="btnSave_Click" />
        </div>
    </div>
    </form>
</body>
</html>
