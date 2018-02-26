<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<SodetsoUsersManagement.Models.LoginModel>" %>

<!DOCTYPE html>
<html class="bg-black">
<head>
    <meta charset="UTF-8">
    <title>Login | Sodetso Users Management</title>
    <meta content='width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no' name='viewport'>
    <!-- bootstrap 3.0.2 -->
    <link href="../../Content/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <!-- font Awesome -->
    <link href="../../Content/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <!-- Theme style -->
    <link href="../../Content/css/AdminLTE.css" rel="stylesheet" type="text/css" />
</head>
<body class="bg-black">

    <div class="form-box" id="login-box">
        <div class="header">Sign In</div>

        <% using (Html.BeginForm("WebLogin", null, FormMethod.Post, new { role = "form", id = "FormUser", enctype = "multipart/form-data" }))
            { %>
        <div class="body bg-gray">
            <div class="form-group">
                <label for="exampleInputEmail1">Email</label>
                <%: Html.TextBoxFor(model => model.Email, new { @class = "form-control", @placeholder="Enter Email", @required = "true"}) %>
                <%: Html.ValidationMessageFor(model => model.Email, "", new { @class = "text-danger" }) %>
            </div>
            <div class="form-group">
                <label for="exampleInputEmail1">Password</label>
                <%: Html.PasswordFor(model => model.Password, new { @class = "form-control", @placeholder="Enter Password", @required = "true"}) %>
                <%: Html.ValidationMessageFor(model => model.Password, "", new { @class = "text-danger" }) %>
            </div>
            <div class="form-group">
                <input type="checkbox" name="remember_me" />
                Remember me
                   
            </div>
        </div>
        <div class="footer">
            <button type="submit" class="btn bg-olive btn-block">Sign me in</button>

        </div>
        <% } %>
    </div>


    <!-- jQuery 2.0.2 -->
    <script src="../../Content/js/jquery.min.js"></script>
    <!-- Bootstrap -->
    <script src="../../Content/js/bootstrap.min.js" type="text/javascript"></script>

</body>
</html>
