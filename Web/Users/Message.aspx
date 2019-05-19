﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Message.aspx.cs" Inherits="UserFB.Web.Users.Message" %>

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
                    <div class="col-md-2">
                        <div class="list-group">
                            <a href="#" class="list-group-item">常见问题</a>
                            <a href="#" class="list-group-item active">填写反馈</a>
                            <a href="#" class="list-group-item">我的消息</a>
                            <a href="#" class="list-group-item">历史反馈</a>
                        </div>
                    </div>

                    <div class="col-md-10">
                        <div class="card">
                            <div class="card-header bg-light">
                                
                            </div>

                            <div class="card-body">
                                <asp:Label ID="Labeltest" runat="server" Text="Label"></asp:Label>
                                    <asp:GridView ID="GridView1" class="tab-content" style="width: 100%;text-align:center;word-break :break-all;word-wrap:break-word "
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
                                            <asp:TemplateField HeaderText="回复者">
                                                <EditItemTemplate>
                                                    <asp:Label ID="LabelName1" runat="server"  Text="官方小助手"></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="LabelName" runat="server" Text="官方小助手"></asp:Label>
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

