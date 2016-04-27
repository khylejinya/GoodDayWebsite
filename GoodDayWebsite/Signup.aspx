<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="GoodDayWebsite.Signup" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <title>Good Day Coffee - Sign Up</title>
    <!-- Google Fonts -->
    <link href='https://fonts.googleapis.com/css?family=Roboto+Slab:400,100,300,700|Lato:400,100,300,700,900' rel='stylesheet' type='text/css'>
    <link rel="stylesheet" href="css/LoginAnimate.css">
    <!-- Custom Stylesheet -->
    <link rel="stylesheet" href="css/LoginStyle.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.4/jquery.min.js"></script>

    <script type = "text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Create a new account?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
        </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <div class="top">
            <h1 id="title" class="hidden"><span id="logo">Good <span>DAY</span></span></h1>
        </div>
        <div class="login-box animated fadeInUp">
            <div class="box-header">
                <h2>Sign Up</h2>
            </div>
            <h3>Sign up for free!</h3>
            <label for="username">Username</label>
            <br />
            <asp:TextBox ID="username" runat="server"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ErrorMessage="Required" ForeColor="Red" ControlToValidate="username"
                runat="server" />
            <%--<input type="text" id="emailAddress">--%>
            <br />
            <label for="password">Enter a Password</label>
            <br />
            <asp:TextBox ID="password" runat="server"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ErrorMessage="Required" ForeColor="Red" ControlToValidate="password"
                runat="server" />
            <%--<input type="password" id="password">--%>
            <br />
            <label for="password2">Confirm Password</label>
            <br />
            <asp:TextBox ID="password2" runat="server"></asp:TextBox>
            <br />
            <asp:CompareValidator ErrorMessage="Passwords do not match." ForeColor="Red" ControlToCompare="password"
                ControlToValidate="password2" runat="server" />

            <br />
            <label for="email">Email Address</label>
            <br />
            <asp:TextBox ID="emailAddress" runat="server"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ErrorMessage="Required" Display="Dynamic" ForeColor="Red"
                ControlToValidate="emailAddress" runat="server" />
            <asp:RegularExpressionValidator runat="server" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                ControlToValidate="emailAddress" ForeColor="Red" ErrorMessage="Invalid email address." />
            <br />
            <%--<asp:Button ID="button" runat="server" OnClick = "RegisterUser" Text="Sign Up" OnClientClick = "Confirm()"/>--%>
            <asp:Button ID="button1" runat="server" OnClick = "RegisterUser" Text="Sign Up"/>

            <br />
        </div>
    </div>
    </form>
</body>
<script type = "text/javascript">
	$(document).ready(function () {
    	$('#logo').addClass('animated fadeInDown');
    	$("input:text:visible:first").focus();
	});
	$('#username').focus(function() {
		$('label[for="username"]').addClass('selected');
	});
	$('#username').blur(function() {
		$('label[for="username"]').removeClass('selected');
	});
	$('#password').focus(function() {
		$('label[for="password"]').addClass('selected');
	});
	$('#password').blur(function() {
		$('label[for="password"]').removeClass('selected');
	});

        
    </script>
</html>