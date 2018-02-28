<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Master.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<SodetsoUsersManagement.Models.UsersListModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%: ViewBag.PageTitle = "Active Users" %>
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
        <div class="col-xs-12">
            <div class="box box-primary">

                <!-- /.box-header -->
                <div class="box-body table-responsive">
                    <table id="example1" class="table table-bordered table-hover">
                        <thead>
                            <tr>
                                <th>Image</th>
                                <th>Name</th>
                                <th>Gender</th>
                                <th>Position</th>
                                <th>Phone</th>
                                <th>Action</th>
                            </tr>
                        </thead>
                        <tbody>
                            <% foreach (var item in Model)
                               {%>
                            <tr>
                                <td>
                                    <% if (item.Image == null)
                                       { %>
                                    <img src="../../assets/img/avatar.png" alt="<%: @Html.DisplayFor(m => item.Firstname) %>" height="70" width="70" />

                                    <%}
                                       else
                                       { %>

                                    <%      
                                           {
                                               var base64 = Convert.ToBase64String(item.Image);
                                               var imgSrc = String.Format("data:image/jpg;base64,{0}", base64);
                                    %>

                                    <img src="<%: @imgSrc %>" alt="<%: @Html.DisplayFor(m => item.Firstname) %>" height="70" width="70" /><%} %>
                                    <%} %>
                                </td>

                                <td><%: Html.DisplayFor(m => item.Firstname) %> <%: Html.DisplayFor(m => item.Middlename) %> <%: Html.DisplayFor(m => item.Lastname) %></td>
                                <td><%: Html.DisplayFor(m => item.Gender) %></td>
                                <td><%: Html.DisplayFor(m => item.Position) %></td>
                                <td><%: Html.DisplayFor(m => item.Phone) %></td>
                                <td>
                                    <a href="#DeactivateUserModal<%: Html.DisplayFor(m => item.UserID) %>" data-toggle="modal"><span class="label label-warning">Deactivate</span></a>

                                    <!-- Deactvate User Modal -->
                                    <div class="modal fade" id="DeactivateUserModal<%: Html.DisplayFor(m => item.UserID) %>" tabindex="-1" role="dialog" aria-hidden="true">
                                        <div class="modal-dialog">
                                            <div class="modal-content">
                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                                    <h4 class="modal-title">Deactivate User</h4>
                                                </div>
                                                <% using (Html.BeginForm("ActiveUsersPageDeactivateUser", null, FormMethod.Post, new { @class = "smart-form client-form", role = "form", id = "smart-form-register", enctype = "multipart/form-data" }))
                                                   { %>
                                                <div class="modal-body">
                                                    Are you sure you want to deactivate the User <strong><%: Html.DisplayFor(m => item.Firstname) %> <%: Html.DisplayFor(m => item.Middlename) %> <%: Html.DisplayFor(m => item.Lastname) %></strong>?
                                                           
                                                           

                                                    <input type="hidden" class="form-control" name="UserID" value="<%: Html.DisplayFor(m => item.UserID) %>" />
                                                    <input type="hidden" name="Operation" value="Deactivate" />
                                                </div>
                                                <div class="modal-footer clearfix">
                                                    <button type="submit" class="btn btn-primary">Yes</button>
                                                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cancel</button>
                                                </div>
                                                <% }%>
                                            </div>
                                            <!-- /.modal-content -->
                                        </div>
                                        <!-- /.modal-dialog -->
                                    </div>
                                    <!-- /.Disable User modal -->
                                </td>

                            </tr>
                            <% } %>
                        </tbody>
                        <tfoot>
                            <tr>
                                <th>Image</th>
                                <th>Name</th>
                                <th>Gender</th>
                                <th>Position</th>
                                <th>Phone</th>
                                <th>Action</th>
                            </tr>
                        </tfoot>
                    </table>
                </div>
                <!-- /.box-body -->
            </div>
            <!-- /.box -->
        </div>
    </div>
</asp:Content>
