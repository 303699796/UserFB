<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Question.aspx.cs" Inherits="UserFB.Web.Users.Question" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <meta charset="UTF-8"/>
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0"/>
    <meta http-equiv="X-UA-Compatible" content="ie=edge"/>
    <title>填写反馈</title>

      <link rel="stylesheet" href="../bootstrap/vendor/simple-line-icons/css/simple-line-icons.css"/>
    <link rel="stylesheet" href="../bootstrap/vendor/font-awesome/css/fontawesome-all.min.css"/>
     <link rel="stylesheet" href="../bootstrap/css/styles.css"/>
</head>
<body class="sidebar-hidden header-fixed">
    <form id="form1" runat="server">
<div class="page-wrapper">
    <nav class="navbar page-header">
        <a href="#" class="btn btn-link sidebar-mobile-toggle d-md-none mr-auto">
            <i class="fa fa-bars"></i>
        </a>

        <a class="navbar-brand" href="#">
            <img src="../Images/用户反馈系统2.PNG" alt="logo">
        </a>

        <a href="#" class="btn btn-link sidebar-toggle d-md-down-none">
            <i class="fa fa-bars"></i>
        </a>

        <ul class="navbar-nav ml-auto">
            <li class="nav-item d-md-down-none">
                <a href="#">
                    <i class="fa fa-bell"></i>
                    <span class="badge badge-pill badge-danger">5</span>
                </a>
            </li>

            <li class="nav-item d-md-down-none">
                <a href="#">
                    <i class="fa fa-envelope-open"></i>
                    <span class="badge badge-pill badge-danger">5</span>
                </a>
            </li>

            <li class="nav-item dropdown">
                <a class="nav-link dropdown-toggle" href="#" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                    <img src="../Images/用户头像.jpg" class="avatar avatar-sm" alt="logo">
                    <span class="small ml-1 d-md-down-none">John Smith</span>
                </a>

                <div class="dropdown-menu dropdown-menu-right">
                    <div class="dropdown-header">Account</div>

                    <a href="#" class="dropdown-item">
                        <i class="fa fa-user"></i> Profile
                    </a>

                    <a href="#" class="dropdown-item">
                        <i class="fa fa-envelope"></i> Messages
                    </a>

                    <div class="dropdown-header">Settings</div>

                    <a href="#" class="dropdown-item">
                        <i class="fa fa-bell"></i> Notifications
                    </a>

                    <a href="#" class="dropdown-item">
                        <i class="fa fa-wrench"></i> Settings
                    </a>

                    <a href="#" class="dropdown-item">
                        <i class="fa fa-lock"></i> Logout
                    </a>
                </div>
            </li>
        </ul>
    </nav>

  

        <div class="content">
            <div class="container-fluid">
                <div class="row">
                    <div class="Columns">

                   
                    <div class="col-md-2">
                        <div class="list-group">
                            <a href="#" class="list-group-item">常见问题</a>
                            <a href="#" class="list-group-item active">填写反馈</a>
                            <a href="#" class="list-group-item">我的消息</a>
                            <a href="#" class="list-group-item">历史反馈</a>
                          
                               <a  class="list-group-item" >   &nbsp;</a>
                               <a class="list-group-item" style="border:none">  &nbsp;</a>
                             <a  class="list-group-item" style="border:none">   &nbsp;</a>
                               <a class="list-group-item" style="border:none">  &nbsp;</a>
                             <a  class="list-group-item" style="border:none">   &nbsp;</a>
                               <a class="list-group-item" style="border:none">  &nbsp;</a>
                             <a  class="list-group-item" style="border:none">   &nbsp;</a>
                               <a class="list-group-item" style="border:none">  &nbsp;</a>
                             <a  class="list-group-item" style="border:none">   &nbsp;</a>
                               <a class="list-group-item" style="border:none">  &nbsp;</a>
                            
                        </div>
                    </div>
                         </div>


                   

                          <asp:DropDownList ID="DropDownList_Category" runat="server" >

                        </asp:DropDownList>
                             



                   
                    <div>
                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="categoryID"
                              class="tab-content" style="width: 100%;text-align:center;word-break :break-all;word-wrap:break-word " RowStyle-Height="100px">
                            <Columns>
                                <asp:TemplateField HeaderText="请选择问题分类" ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandName="" OnClick="LinkButton1_Click" Text='<%# Eval("category") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                            </Columns>

<RowStyle Height="100px"></RowStyle>
                            
                        </asp:GridView>

                       
                          <asp:Button ID="Button1" runat="server" Text="Button" />
                    </div>
                  
                    &nbsp; &nbsp; &nbsp; &nbsp;
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="questionID"
                         class="tab-content" style="width: 400%;text-align:center;word-break :break-all;word-wrap:break-word " RowStyle-Height="50px">
                        <Columns>
                            <asp:TemplateField HeaderText="问题分类">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Category.category") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Category.category") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="question" HeaderText="遇到的问题" />
                            <asp:BoundField DataField="solution" HeaderText="如何解决？" />
                        </Columns>

<RowStyle Height="50px"></RowStyle>

                    </asp:GridView>


                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" Visible="False"
                         class="tab-content" style="width: 400%;text-align:center;word-break :break-all;word-wrap:break-word " RowStyle-Height="50px">
                        <Columns>
                            <asp:BoundField DataField="question" HeaderText="遇到的问题" />
                            <asp:BoundField DataField="solution" HeaderText="如何解决" />
                        </Columns>
                    </asp:GridView>

                         
                        </div>
                
                </div>
            </div>
         </div>
     
      
  

         </form>  
 <script src="../bootstrap/vendor/jquery/jquery.min.js"></script>
<script src="../bootstrap/vendor/popper.js/popper.min.js"></script>
<script src="../bootstrap/vendor/bootstrap/js/bootstrap.min.js"></script>
<script src="../bootstrap/vendor/chart.js/chart.min.js"></script>
<script src="../bootstrap/js/carbon.js"></script>
<script src="../bootstrap/js/demo.js"></script>

</body>
</html>