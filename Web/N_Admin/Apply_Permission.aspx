<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Apply_Permission.aspx.cs" Inherits="UserFB.Web.N_Admin.Apply_Permission" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="UTF-8"/>
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0"/>
    <meta http-equiv="X-UA-Compatible" content="ie=edge"/>
    <title>申请权限</title>
     <link rel="stylesheet" href="../bootstrap/vendor/simple-line-icons/css/simple-line-icons.css"/>
    <link rel="stylesheet" href="../bootstrap/vendor/font-awesome/css/fontawesome-all.min.css"/>
     <link rel="stylesheet" href="../bootstrap/css/styles.css"/>
       <script src="https://cdn.bootcss.com/echarts/4.2.1-rc1/echarts-en.common.min.js"></script>
    </head>
<body class="sidebar-fixed header-fixed">
    <form id="form1" runat="server" >
<div class="page-wrapper">
    <div class="page-header">
        <nav class="navbar page-header">
            <a href="#" class="btn btn-link sidebar-mobile-toggle d-md-none mr-auto">
                <i class="fa fa-bars"></i>
            </a>

            <a class="navbar-brand" href="#">
                <img src="../Images/用户反馈处理系统2.PNG" alt="logo"/>
                
            </a>

            <a href="#" class="btn btn-link sidebar-toggle d-md-down-none">
                <i class="fa fa-bars"></i>
            </a>     
              <ul class="navbar-nav ml-auto">


           <%-- <li class="nav-item d-md-down-none">
                <a href="../N_Admin_List/Apply_Permission.aspx">
                    <i class="fa fa-envelope-open"></i>
                
                    <asp:Label ID="LabelMessage" runat="server"  class="badge badge-pill badge-danger" Text="2" ></asp:Label>
                </a>
            </li>--%>

            <li class="nav-item dropdown">
                <a class="nav-link dropdown-toggle" href="#" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                    <img src="../Images/用户头像.jpg" class="avatar avatar-sm" alt="logo">
                  
                    <asp:Label ID="Label5" runat="server" class="small ml-1 d-md-down-none" Text="欢迎您！"></asp:Label>
                    <asp:Label ID="LabelUser" runat="server" Font-Bold="true">  </asp:Label>
                </a>

                <div class="dropdown-menu dropdown-menu-right">
                    <div class="dropdown-header"></div>

                   
                    <a href="../Login/AdminLogin.aspx" class="dropdown-item">
                        <i class="fa fa-lock"></i> 退出登录
                    </a>
                </div>
            </li>
        </ul>
        </nav>
    </div>


   <div class="main-container">
         <div class="sidebar">
            <nav class="sidebar-nav">
                <ul class="nav">
                      <li class="nav-title">目录</li>

                    <li class="nav-item">
                        <a href="N_Index.aspx" class="nav-link ">
                            <i class="icon icon-speedometer"></i> 首页
                        </a>
                    </li>
                       <li class="nav-item">
                        <a href="Apply_Permission.aspx" class="nav-link active">
                            <i class="icon icon-puzzle"></i> 申请权限
                        </a>
                    </li>  
                        </ul>    
                
            </nav>
        </div>  
       

        <div class="content">
            <div class="row">
                <div class="col-md-6">
                    <div class="card">
                        <div class="card-header bg-light" style="font-weight:700">
                            个人信息
                        </div>

                        <div class="card-body">
                            <div class="table-responsive">


                                <div class="col-md-6">
                                         <div class="form-group">    
                                          <asp:Label ID="LabelID"   class="form-control-label" runat="server" Text="用户ID :"></asp:Label>
                                           
                                           <asp:TextBox ID="txtID" class="form-control" Width="190%" runat="server" ReadOnly></asp:TextBox>
                         <br />
                                          <asp:Label ID="LabelName" class="form-control-label" runat="server" Text="用户名 :"></asp:Label>
                                            
                                           <asp:TextBox ID="txtName" class="form-control" Width="190%" runat="server" ReadOnly></asp:TextBox>
                                   <br />
                                          <asp:Label ID="LabelDepartment" class="form-control-label" runat="server" Text="部门 :"></asp:Label>
                                           <asp:TextBox ID="txtDepartment" class="form-control" Width="190%" runat="server" ReadOnly></asp:TextBox>
                                    <br />
                                          <asp:Label ID="LabelJob" class="form-control-label" runat="server" Text="职位 :"></asp:Label>
                                           <asp:TextBox ID="txtJob" class="form-control" Width="190%" runat="server" ReadOnly></asp:TextBox>
 </div>
                                        </div>

                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-md-6">
                    <div class="card">
                        <div class="card-header bg-light" style="font-weight:700">
                            权限申请
                        </div>

                        <div class="card-body">
                            <div class="table-responsive">
                                 <div class="card-footer bg-light text-center">
                                  <h5>— — 请选择要申请的权限 — —  </h5>
                             <br />
                              <asp:RadioButtonList ID="RadioButtonList_Choose" RepeatDirection="Horizontal"  runat="server" Height="10px" Width="100%">
                                      <asp:ListItem Value="1">&nbsp;&nbsp;&nbsp;&nbsp;普通管理员</asp:ListItem>
                                    <asp:ListItem Value="2">&nbsp;&nbsp;&nbsp;&nbsp;超级管理员</asp:ListItem>
                                </asp:RadioButtonList>
                                  
                          
                                <asp:Button ID="But_Apply" runat="server" class="btn btn-primary" Text="提   交" OnClick="But_Apply_Click" />
                            </div>
                                  <br />   <br />
                                <div style="text-align:center">
                                      <h5>— — — 权限介绍— — — </h5>
                                </div>
                        
                                 <br />
                                <h6> ①  普通管理员：</h6>
                                <h6> ②  超级管理员：</h6>
                              
                             
                               
                            </div>
                                  
                        </div>
                    </div>
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
