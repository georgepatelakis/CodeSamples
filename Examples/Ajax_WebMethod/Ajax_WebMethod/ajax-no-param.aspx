<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ajax-no-param.aspx.cs" Inherits="Ajax_WebMethod.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>  
    <script src="Scripts/jquery-1.9.1.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div id="Result">click me</div>
    </div>
    </form>

    <script>
        var myData = { 'a': 'val_a'};
        //$.ajax({
        //    type: "POST",
        //    url: "http://localhost:39114/WebForm1.aspx/MyMethod",
        //    data: myData, 
        //    success: function (msg) {
        //        alert(msg);
        //    }
        //});

        $(document).ready(function () {
            // Add the page method call as an onclick handler for the div.
            $("#Result").click(function () {
                $.ajax({
                    type: "POST",
                    url: "ajax-no-param.aspx/MyMethod",
                    contentType: "application/json",
                    dataType: "json", 
                    success: function (msg) {
                        // Replace the div's content with the page method's return.
                        alert(msg.d);
                    },
                    error: function (request, status, error) {
                        alert(error);
                    }
                });
            });
        });
    </script>
</body>
</html>
