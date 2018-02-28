<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Master.Master" Inherits="System.Web.Mvc.ViewPage<SodetsoUsersManagement.Models.EditUserModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%: ViewBag.PageTitle = "Edit User" %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <!-- row -->
    <div class="row">
        <div class="col-md-6">
            <% if (TempData["Success"] != null)
               { %>
            <div class="alert alert-success alert-dismissable">
                <i class="fa fa-check"></i>
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                <b>Alert!</b> Success.
       
            </div>
            <% } %>
        </div>
    </div>

    <div class="row">
        <!-- left column -->
        <div class="col-md-12">
            <!-- general form elements -->
            <div class="box box-primary">
                <div class="box-header">
                    <h3 class="box-title">User Form</h3>
                </div>
                <!-- /.box-header -->
                <!-- form start -->
                <% using (Html.BeginForm("UpdateUser", null, FormMethod.Post, new { role = "form", id = "FormUser", enctype = "multipart/form-data" }))
                   { %>

                <div class="box-body">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label for="exampleInputEmail1">Firstname</label>
                                <%: Html.TextBoxFor(model => model.Firstname, new { @class = "form-control", @placeholder="Enter Firstname", @required = "true"}) %>
                                <%: Html.ValidationMessageFor(model => model.Firstname, "", new { @class = "text-danger" }) %>
                                <input type="hidden" class="form-control" name="UserID" id="UserID" value="<%: Model.UserID %>" />
                            </div>
                            <div class="form-group">
                                <label for="exampleInputEmail1">Middlename</label>
                                <%: Html.TextBoxFor(model => model.Middlename, new { @class = "form-control", @placeholder="Enter Middlename"}) %>
                            </div>
                            <div class="form-group">
                                <label for="exampleInputEmail1">Lastname</label>
                                <%: Html.TextBoxFor(model => model.Lastname, new { @class = "form-control", @placeholder="Enter Lastname"}) %>
                            </div>
                            <div class="form-group">
                                <label>Gender</label>
                                <%: Html.DropDownListFor(model => model.Gender,
                                    new SelectList(Model.sex, "GenderID", "Description"), 
                                    new {@class="form-control"})
                                %>
                            </div>
                            <div class="form-group">
                                <label>Position</label>
                                <%: Html.TextBoxFor(model => model.Position, new { @class = "form-control", @placeholder="Enter Position"}) %>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="form-group">
                                <label for="exampleInputEmail1">Phone</label>
                                <%: Html.TextBoxFor(model => model.Phone, new { @class = "form-control", @placeholder="Enter Phone"}) %>
                            </div>
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
                                <label for="exampleInputEmail1">ConfirmPassword</label>
                                <%: Html.PasswordFor(model => model.CPassword, new { @class = "form-control", @placeholder = "Confirm Password", id = "CPassword", @required = "true" }) %>
                                <%: Html.ValidationMessageFor(model => model.CPassword, "", new { @class = "text-danger" }) %>
                            </div>
                            <div class="form-group">
                                <label for="exampleInputFile">File input</label>
                                <input type="file" id="ImageData" name="ImageData">
                            </div>
                        </div>
                    </div>
                </div>
                <!-- /.box-body -->

                <div class="box-footer" align="right">
                    <button type="submit" class="btn btn-primary">Save</button>
                </div>
                <% } %>
            </div>
            <!-- /.box -->

        </div>
        <!--/.col (left) -->

    </div>
    <!-- /.row -->
</asp:Content>
