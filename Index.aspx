<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Master.Master" Inherits="System.Web.Mvc.ViewPage<SodetsoUsersManagement.Models.DashboardModels>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%: ViewBag.PageTitle = "Dashboard" %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<!-- Small boxes (Stat box) -->
    <div class="row">
        <div class="col-lg-3 col-xs-6">
            <!-- small box -->
            <div class="small-box bg-aqua">
                <div class="inner">
                    <h4><%: Model.UsersList %>
                                    </h4>
                    <p>
                        Users List
                                   
                    </p>
                </div>
                <div class="icon">
                    <i class="fa fa-users"></i>
                </div>
                <a href="/UsersManagement/UsersList" class="small-box-footer">View <i class="fa fa-arrow-circle-right"></i>
                </a>
            </div>
        </div>
        <!-- ./col -->
        <div class="col-lg-3 col-xs-6">
            <!-- small box -->
            <div class="small-box bg-green">
                <div class="inner">
                    <h4><%: Model.ActiveUsers %></h4>
                    <p>
                        Active Users
                                   
                    </p>
                </div>
                <div class="icon">
                    <i class="fa fa-check-square-o"></i>
                </div>
                <a href="/UsersManagement/ActiveUsers" class="small-box-footer">View <i class="fa fa-arrow-circle-right"></i>
                </a>
            </div>
        </div>
        <!-- ./col -->
        <div class="col-lg-3 col-xs-6">
            <!-- small box -->
            <div class="small-box bg-yellow">
                <div class="inner">
                    <h4><%: Model.InActiveUsers %>
                                    </h4>
                    <p>
                        Inactive Users
                                   
                    </p>
                </div>
                <div class="icon">
                    <i class="fa fa-minus-square-o"></i>
                </div>
                <a href="/UsersManagement/InactiveUsers" class="small-box-footer">View <i class="fa fa-arrow-circle-right"></i>
                </a>
            </div>
        </div>
        <!-- ./col -->
        <div class="col-lg-3 col-xs-6">
            <!-- small box -->
            <div class="small-box bg-red">
                <div class="inner">
                    <h4><%: Model.ArchivedUsers %>
                                    </h4>
                    <p>
                        Archived Users
                                   
                    </p>
                </div>
                <div class="icon">
                    <i class="fa fa-trash-o"></i>
                </div>
                <a href="/UsersManagement/ArchivedUsers" class="small-box-footer">View <i class="fa fa-arrow-circle-right"></i>
                </a>
            </div>
        </div>
        <!-- ./col -->
    </div>
    <!-- /.row -->

    <!-- top row -->
    <div class="row">
        <div class="col-xs-12 connectedSortable">
        </div>
        <!-- /.col -->
    </div>
    <!-- /.row -->
</asp:Content>
