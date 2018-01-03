<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<script type="text/javascript">
       function SetDefaultPass(parameters) {
           try {
               document.getElementById('passTB').value = parameters;
           } catch (e) {
               alert(e);
           }
       }
   </script>
    <title>Login</title>
  
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/normalize/5.0.0/normalize.min.css"/>
    <link href="login.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/prefixfree/1.0.7/prefixfree.min.js"></script>
</head>
<body>

  <div class="login">
	<h1>Login</h1>
    <form method="post" runat="server">
    	<input type="text" id="usernameTB" runat="server" name="u" placeholder="Username" required="required" />
        <input type="password" id="passTB" runat="server" name="p" placeholder="Password" required="required"/>
        <br />
    <asp:CheckBox ID="saveCB" runat="server"  /> <asp:Label ID="saveLBL" runat="server" Text="Remember Me?" ForeColor="White"></asp:Label>
       
         <asp:Button id="loginBTN" runat="server" Text="Let me in!" class="btn btn-primary btn-block btn-large" OnClick="loginBTN_Click"></asp:Button>
        <asp:Label ID="wpLBL" runat="server" Text="" ForeColor="Maroon"></asp:Label>
    </form>
</div>

    <script  src="js/index.js"></script>

</body>
</html>
