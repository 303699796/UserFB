<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Keywords.aspx.cs" Inherits="UserFB.Web.Chart_Analysis.Keywords" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <meta charset="UTF-8"/>
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0"/>
    <meta http-equiv="X-UA-Compatible" content="ie=edge"/>
    <title>关键词分析</title>
     <link rel="stylesheet" href="../bootstrap/vendor/simple-line-icons/css/simple-line-icons.css"/>
    <link rel="stylesheet" href="../bootstrap/vendor/font-awesome/css/fontawesome-all.min.css"/>
     <link rel="stylesheet" href="../bootstrap/css/styles.css"/>
       <script src="https://cdn.bootcss.com/echarts/4.2.1-rc1/echarts-en.common.min.js"></script>
    
    <style type="text/css">
        .auto-style1 {
            margin-right: 0px;
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
                        <a href="../S_Admin_List/List.aspx" class="nav-link ">
                            <i class="icon icon-puzzle"></i>反馈列表
                        </a>
                    </li>                                    
                         <li class="nav-item nav-dropdown"> 

                        <a href="#" class="nav-link nav-dropdown-toggle">
                            <i class="icon icon-grid"></i> 反馈分析 <i class="fa fa-caret-left"></i>
                        </a>

                        <ul class="nav-dropdown-items" >
                            <li class="nav-item" >
                                <a href="../Index.aspx" class="nav-link">
                                    <i class="icon icon-grid"></i> 反馈数量
                                </a>
                            </li>


                            <li class="nav-item">
                                <a href="../Chart_Analysis/Keywords.aspx" class="nav-link active">
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
                                    <i class="icon icon-energy"></i> 帮助列表
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
          
             <button type="button"  class="btn btn-block btn-info" style="width:100%;height:40px;border:none;font-weight:900;font-size:17px">反馈关键词</button>
               <br />
        
           
  <div class ="card " style="width:100%;height:500px">
      <div class="row">
            <asp:Image ID="Image1" runat="server" ImageAlign="Middle" ImageUrl="~/Images/beijing003.png" CssClass="auto-style1" Height="500px" />
            <asp:Image ID="Image2" runat="server"  ImageUrl="~/Images/Figure_Number.png" CssClass="auto-style1" Height="500px" />
      </div>      
       </div>
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />

              <asp:GridView ID="GridView1" runat="server" class="tab-content" style="width: 100%;text-align:center;word-break :break-all;word-wrap:break-word "
           RowStyle-Height="50px" AutoGenerateColumns="False" DataKeyNames="feedbackID"  AllowPaging="True"  >
           <Columns>
              
             
               <asp:TemplateField HeaderText="反馈用户">
                   <EditItemTemplate>
                       <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Users.userName") %>'></asp:TextBox>
                   </EditItemTemplate>
                   <ItemTemplate>
                       <asp:Label ID="Label1" runat="server" Text='<%# Bind("Users.userName") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:BoundField DataField="feedbackTime" HeaderText="反馈时间" />
               <asp:TemplateField HeaderText="反馈分类">
                   <EditItemTemplate>
                       <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Category.category") %>'></asp:TextBox>
                   </EditItemTemplate>
                   <ItemTemplate>
                       <asp:Label ID="Label2" runat="server" Text='<%# Bind("Category.category") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:BoundField DataField="Info" HeaderText="反馈内容" />
               <asp:BoundField DataField="contact" HeaderText="联系方式" />
           <%--    <asp:BoundField DataField="isInvalid" HeaderText="有效状态" />--%>
               <asp:BoundField DataField="solutionState" HeaderText="解决状态" />
               <asp:BoundField DataField="handler" HeaderText="负责人" />
               
               
           </Columns>

           <HeaderStyle Height="50px" />

<RowStyle Height="50px"></RowStyle>
             </asp:GridView>







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
