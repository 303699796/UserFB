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
    <style type="text/css">
        .auto-style1 {
            position: relative;
            width: 100%;
            min-height: 1px;
            -webkit-box-flex: 0;
            -ms-flex: 0 0 50%;
            flex: 0 0 50%;
            max-width: 50%;
            left: 9px;
            top: -12px;
            padding-left: 15px;
            padding-right: 15px;
        }
    </style>
</head>
<body class="sidebar-fixed header-fixed">
    <form id="form1" runat="server" onsubmit="return false">
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
        </nav>
    </div>


   <div class="main-container">
         <div class="sidebar">
            <nav class="sidebar-nav">
                <ul class="nav">
                    <li class="nav-title">Navigation</li>

                    <li class="nav-item">
                        <a href="index.html" class="nav-link">
                            <i class="icon icon-speedometer"></i> 首页
                        </a>
                    </li>
                       <li class="nav-item">
                        <a href="forms.html" class="nav-link active">
                            <i class="icon  icon-puzzle"></i> 申请权限
                        </a>
                    </li>  
                        </ul>    
                
            </nav>
        </div>  
       

        <div class="content">
            <div class="row">
                <div class="col-md-6">
                    <div class="card">
                        <div class="card-header bg-light" style="width:1200px;height:50px;border:none">
                         <h5>权限申请</h5> 
                        </div>
                       

                       
                    </div>
                </div>

            </div>
            <h6>用户信息</h6>
            <asp:GridView ID="GridView1" runat="server" class="tab-content" style="width: 100%;text-align:center;word-break :break-all;word-wrap:break-word " RowStyle-Height="100px">
                 <Columns>
            <asp:TemplateField HeaderText ="用户ID">
                        <ItemTemplate>
                            <asp:Label ID="Label_ID" runat="server" Text='<%#Bind("adminID")%>'></asp:Label>
                          </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText ="用户名">
                        <ItemTemplate>
                            <asp:Label ID="Label_Name" runat="server"  style="text-align:center"  Text='<%#Bind("adminName")%>'></asp:Label>                         
                          </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText ="部门">
                        <ItemTemplate>
                            <asp:Label ID="Label_Department" runat="server"  style="text-align:center"  Text='<%#Bind("department")%>'></asp:Label>                         
                          </ItemTemplate>
                    </asp:TemplateField>

                      <asp:TemplateField HeaderText ="职位">
                        <ItemTemplate>
                            <asp:Label ID="Label_Job" runat="server"  style="text-align:center"  Text='<%#Bind("job")%>'></asp:Label>                         
                          </ItemTemplate>
                    </asp:TemplateField>

                      </Columns>
                    <RowStyle />
            </asp:GridView>


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
