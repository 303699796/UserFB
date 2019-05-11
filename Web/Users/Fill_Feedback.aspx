<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Fill_Feedback.aspx.cs" Inherits="UserFB.Web.Users.Fill_Feedback" %>

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
                                <div class="row mb-5">
                                    <div class="col-md-4 mb-4">
                                        <div>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 请选择您要反馈的问题类型</div>
                                        
                                    </div>

                                   <div class="col-md-8">
                                           

                                         <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                      
                                            <%--<select id="single-select" class="form-control">
                                                <option>1</option>
                                                <option>2</option>
                                                <option>3</option>
                                                <option>4</option>
                                                <option>5</option>
                                            </select>--%>

                                           <asp:DropDownList ID="DropDownList_Category" runat="server" class="form-control" DataTextField="category" >                                               
                                           </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                              </div>
                                </div>
                                <hr/>

                                <div class="row mt-5">
                                    <div class="col-md-4 mb-4">
                                        <div>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 请尽量详细描述您的问题</div>

                                    </div>

                                    <div class="col-md-8">
                                        <div class="row">
 
                                             <div class="col-md-6">
                                                <div class="form-group">
                                                   <asp:TextBox ID="txbInfo" runat="server" class="form-control" TextMode="MultiLine" Height="180px" ></asp:TextBox>
                                                     <br />                                          
                                                                                                                                                 
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                              <div class="row mt-5">
                                    <div class="col-md-4 mb-4">
                                        <div>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 您的联系方式/QQ/微信</div>

                                    </div>

                                    <div class="col-md-8">
                                        <div class="row">
 
                                             <div class="col-md-6">
                                                <div class="form-group">                                                                                                        
                                                   <asp:TextBox ID="txbContact" runat="server" class="form-control"    ></asp:TextBox>
                                                 <br />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            
                            <div class="card-footer bg-light text-center">
                               <%-- <button type="submit" class="btn btn-primary" >提 &nbsp; &nbsp; &nbsp;交</button>--%>
                                <asp:Button ID="But_submit" runat="server" class="btn btn-primary" Text="提   交" OnClick="But_submit_Click" />
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

