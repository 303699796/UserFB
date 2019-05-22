<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_Setting.aspx.cs" Inherits="UserFB.Web.Setting.Admin_Setting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="UTF-8"/>
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0"/>
    <meta http-equiv="X-UA-Compatible" content="ie=edge"/>
    <title>管理员设置</title>
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
            <li class="nav-item d-md-down-none">
               <a href="../S_Admin_List/ApplyMessage_List.aspx">
                    <i class="fa fa-bell"></i>
               
                    <asp:Label ID="LabelApply" runat="server" class="badge badge-pill badge-danger" ></asp:Label>
                </a>
            </li>

            <li class="nav-item d-md-down-none">
                 <a href="../S_Admin_List/Reply_Message.aspx">
                    <i class="fa fa-envelope-open"></i>
                
                    <asp:Label ID="LabelMessage" runat="server"  class="badge badge-pill badge-danger" ></asp:Label>
                </a>
            </li>

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
                        <a href="../S_Admin_List/List.aspx" class="nav-link active">
                            <i class="icon icon-puzzle"></i>反馈列表
                        </a>
                    </li>                                    
                         <li class="nav-item nav-dropdown">
                        <a href="#" class="nav-link nav-dropdown-toggle">
                            <i class="icon icon-grid"></i> 反馈分析 <i class="fa fa-caret-left"></i>
                        </a>

                        <ul class="nav-dropdown-items">
                            <li class="nav-item">
                                <a href="../Index.aspx" class="nav-link">
                                    <i class="icon icon-grid"></i> 反馈数量
                                </a>
                            </li>


                            <li class="nav-item">
                                <a href="../Chart_Analysis/Keywords.aspx" class="nav-link">
                                    <i class="icon icon-grid"></i> 热门关键词
                                </a>
                            </li>

                            <li class="nav-item">
                                <a href="../Chart_Analysis/User_Analysis.aspx" class="nav-link">
                                    <i class="icon icon-target"></i> 用户画像
                                </a>
                            </li>
                        </ul>
                    </li>

                      <li class="nav-item nav-dropdown">
                        <a href="#" class="nav-link nav-dropdown-toggle">
                            <i class="icon icon-target"></i> 我的消息 <i class="fa fa-caret-left"></i>
                        </a>

                        <ul class="nav-dropdown-items">
                            <li class="nav-item">
                                <a href="../S_Admin_List/ApplyMessage_List.aspx" class="nav-link">
                                    <i class="icon icon-target"></i> 审批消息
                                </a>
                            </li>


                            <li class="nav-item">
                                <a href="../S_Admin_List/Reply_Message.aspx" class="nav-link">
                                    <i class="icon icon-target"></i> 回复消息
                                </a>
                            </li>

                           
                        </ul>
                    </li>

                    <li class="nav-item nav-dropdown">
                        <a href="#" class="nav-link nav-dropdown-toggle">
                            <i class="icon icon-energy"></i> 设置 <i class="fa fa-caret-left"></i>
                        </a>

                        <ul class="nav-dropdown-items">
                            <li class="nav-item">
                                <a href="../Setting/Question_Setting.aspx" class="nav-link">
                                    <i class="icon icon-energy"></i> 常见问题
                                </a>
                            </li>

                            <li class="nav-item">
                                <a href="../Setting/Category_Setting.aspx" class="nav-link">
                                    <i class="icon icon-energy"></i> 问题分类
                                </a>
                            </li>

                            <li class="nav-item">
                                <a href="../Setting/Admin_Setting.aspx" class="nav-link">
                                    <i class="icon icon-energy"></i> 管理员设置
                                </a>
                            </li>                         
                        </ul>
                    </li>                 
                        </ul>     
            </nav>
        </div>

        <div class="content">
        <button type="button"  class="btn btn-block btn-info" style="width:100%;height:40px;border:none;font-weight:900;font-size:17px">管理员设置</button>
               <br />  
                <div class="card" style="width:100%;height:500px">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                class="tab-content" style="width: 100%;text-align:center;word-break :break-all;word-wrap:break-word " RowStyle-Height="50px"
                OnRowDeleting="GridView1_RowDeleting"  OnRowDataBound="GridView1_RowDataBound" OnRowEditing="GridView1_RowEditing"
           OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating" DataKeyNames="adminID" >
                    <Columns>
                
                    <asp:TemplateField HeaderText="管理员ID">
                        <EditItemTemplate>
                            <asp:Label ID="LabelID" runat="server" Text='<%# Eval("adminID") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Labelid" runat="server" Text='<%# Bind("adminID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="管理员">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtAdmin" runat="server" Text='<%# Bind("adminName") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="LabelAdmin" runat="server" Text='<%# Bind("adminName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                        <asp:TemplateField HeaderText="密码" Visible="False">
                            <EditItemTemplate>
                                <asp:Label ID="LabelPassword" runat="server" Text='<%# Eval("adminPassword") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Labelpassword" runat="server" Text='<%# Bind("adminPassword") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="部门">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtDepartment" runat="server" Text='<%# Bind("department") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="LabelDepartment" runat="server" Text='<%# Bind("department") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="职位">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtJob" runat="server" Text='<%# Bind("job") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="LabelJob" runat="server" Text='<%# Bind("job") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="权限">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPermission" runat="server" Text='<%# Bind("permission") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="LabelPermission" runat="server" Text='<%# Bind("permission") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                   
                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                   
                </Columns>
                    <HeaderStyle Height="50px" />

<RowStyle Height="50px"></RowStyle>

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
