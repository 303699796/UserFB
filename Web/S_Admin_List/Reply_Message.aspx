<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reply_Message.aspx.cs" Inherits="UserFB.Web.S_Admin_List.Reply_Message" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <meta charset="UTF-8"/>
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0"/>
    <meta http-equiv="X-UA-Compatible" content="ie=edge"/>
    <title>问题设置</title>
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
            <li class="nav-item d-md-down-none">
                <a href="#">
                    <i class="fa fa-bell"></i>
                   <%-- <span class="badge badge-pill badge-danger">5</span>--%>
                    <asp:Label ID="LabelApply" runat="server" class="badge badge-pill badge-danger" ></asp:Label>
                </a>
            </li>

            <li class="nav-item d-md-down-none">
                <a href="#">
                    <i class="fa fa-envelope-open"></i>
                   <%-- <span class="badge badge-pill badge-danger">5</span>--%>
                    <asp:Label ID="LabelMessage" runat="server"  class="badge badge-pill badge-danger" ></asp:Label>
                </a>
            </li>

            <li class="nav-item dropdown">
                <a class="nav-link dropdown-toggle" href="#" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                    <img src="../Images/用户头像.jpg" class="avatar avatar-sm" alt="logo">
                     <%--  <span class="small ml-1 d-md-down-none">John Smith</span>--%>
                    <asp:Label ID="Label1" runat="server" class="small ml-1 d-md-down-none" Text="欢迎您！"></asp:Label>
                    <asp:Label ID="LabelUser" runat="server" class="small ml-1 d-md-down-none"></asp:Label>
                </a>

                <div class="dropdown-menu dropdown-menu-right">
                    <div class="dropdown-header"></div>

                    <%--<a href="#" class="dropdown-item">
                        <i class="fa fa-user"></i> 退出登录
                    </a>

                    <a href="#" class="dropdown-item">
                        <i class="fa fa-envelope"></i> 我的回复消息 
                    </a>

                    <div class="dropdown-header">Settings</div>

                    <a href="#" class="dropdown-item">
                        <i class="fa fa-bell"></i> Notifications
                    </a>

                    <a href="#" class="dropdown-item">
                        <i class="fa fa-wrench"></i> Settings
                    </a>--%>

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
                    <li class="nav-title">Navigation</li>

                    <li class="nav-item">
                        <a href="index.html" class="nav-link active">
                            <i class="icon icon-speedometer"></i> 首页
                        </a>
                    </li>
                       <li class="nav-item">
                        <a href="forms.html" class="nav-link">
                            <i class="icon icon-puzzle"></i>分配列表
                        </a>
                    </li>                                    
                         <li class="nav-item nav-dropdown">
                        <a href="#" class="nav-link nav-dropdown-toggle">
                            <i class="icon icon-target"></i> 反馈分析 <i class="fa fa-caret-left"></i>
                        </a>

                        <ul class="nav-dropdown-items">
                            <li class="nav-item">
                                <a href="layouts-normal.html" class="nav-link">
                                    <i class="icon icon-target"></i> 反馈数量
                                </a>
                            </li>

                            <li class="nav-item">
                                <a href="layouts-fixed-sidebar.html" class="nav-link">
                                    <i class="icon icon-target"></i> 反馈分类
                                </a>
                            </li>

                            <li class="nav-item">
                                <a href="layouts-fixed-header.html" class="nav-link">
                                    <i class="icon icon-target"></i> 热门关键词
                                </a>
                            </li>

                            <li class="nav-item">
                                <a href="layouts-hidden-sidebar.html" class="nav-link">
                                    <i class="icon icon-target"></i> 用户画像
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
                                <a href="alerts.html" class="nav-link">
                                    <i class="icon icon-energy"></i> 常见问题
                                </a>
                            </li>

                            <li class="nav-item">
                                <a href="buttons.html" class="nav-link">
                                    <i class="icon icon-energy"></i> 问题分类
                                </a>
                            </li>

                            <li class="nav-item">
                                <a href="cards.html" class="nav-link">
                                    <i class="icon icon-energy"></i> 管理员设置
                                </a>
                            </li>                         
                        </ul>
                    </li>                 
                        </ul>     
            </nav>
        </div>


        <div class="content">
           <div class="row">
                <div class="col-md-6">
                    <div class="card">
                    
                        <div class="card-header bg-light" style="width:1200px;height:50px;border:none">
                         <h5>我的回复消息</h5>
                            <asp:Label ID="Labeltest" runat="server" Text="Label"></asp:Label>
                     
                        </div>
                            
                     </div>
                </div>
            </div>

            


            <div class="col-md-10">
                        <div class="card">
                            <div class="card-header bg-light">
                                
                            </div>

                            <div class="card-body">
                              
                                    <asp:GridView ID="GridView1" class="tab-content" style="width: 100%;text-align:left;word-break :break-all;word-wrap:break-word "
           RowStyle-Height="50px" runat="server" AutoGenerateColumns="False" DataKeyNames="replyID" BorderWidth="0px" GridLines="Horizontal" ShowHeader="False">
                                        <Columns>
                                            <asp:TemplateField HeaderText="回复时间">
                                                <EditItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("time") %>'></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("time") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ID">
                                                <EditItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text="ID为"></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label7" runat="server" Text="ID为"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="回复用户">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("replierID") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("replierID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="用户">
                                                <EditItemTemplate>
                                                    <asp:Label ID="Label8" runat="server" Text="的用户"></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label6" runat="server" Text="的用户"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="回复">
                                                <EditItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Text="回复了你："></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text="回复了你："></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="回复内容">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("text") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("text") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Font-Bold="True" />
                                            </asp:TemplateField>
                                        <asp:TemplateField HeaderText="原反馈内容">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Feedback.Info") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Feedback.Info") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ShowHeader="False">
                   <ItemTemplate>
                      
                         <button  id="Btn_Dtr" class="btn btn-primary" type="button"  data-toggle="modal" data-target="#modal-1"  style="width:80px"  >回复</button>
                   
                   <asp:Button ID="Button2" runat="server"   CausesValidation="false" CommandName="getID"  Text="回复1" CssClass="btn btn-primary"  CommandArgument='<%# Eval("feedbackID") %>' OnClick="Button2_Click"/>
                   </ItemTemplate>
                                              
               </asp:TemplateField>
              
                                        </Columns>

<RowStyle Height="50px"></RowStyle>
                                    </asp:GridView> 


    <div class="modal fade" id="modal-1" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title">回复用户</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>

            <div class="modal-body">
                <asp:Label ID="LabelReceive" runat="server" Text="回复给："></asp:Label>
                <asp:Label ID="LabelName" runat="server" ></asp:Label>
                 <asp:Label ID="LabelReply" runat="server" Text="请输入回复信息"></asp:Label>
                &nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtReply" runat="server" TextMode="MultiLine" Width="300px" Height="100px"></asp:TextBox>
                 
            </div>

            <div class="modal-footer" >
                <button type="button" class="btn btn-link"  data-dismiss="modal">取消</button>   
                <asp:Button ID="BntReply" type="button" runat="server"  class="btn btn-primary" OnClick="BntReply_Click"  Text="回复" />
            </div>
        </div>
    </div>
</div>

                                   
                              
                                <hr/>
          
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
