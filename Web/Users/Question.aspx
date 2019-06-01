<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Question.aspx.cs" Inherits="UserFB.Web.Users.Question" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <meta charset="UTF-8"/>
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0"/>
    <meta http-equiv="X-UA-Compatible" content="ie=edge"/>
    <title>帮助列表</title>

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
                <a href="../Users/Message.aspx">
                    <i class="fa fa-bell"></i>
               
                    <asp:Label ID="LabelMessage" runat="server" class="badge badge-pill badge-danger" ></asp:Label>
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

                   
                     <a href="../Login/UserLogin.aspx" class="dropdown-item">
                        <i class="fa fa-lock"></i> 退出登录
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
                             <a href="../Users\Question.aspx" class="list-group-item active">帮助列表</a>
                            <a href="../Users/Fill_Feedback.aspx" class="list-group-item">填写反馈</a>
                            <a href="../Users\Message.aspx"  class="list-group-item ">我的消息</a>
                           
                          
                               <a  class="list-group-item" >   &nbsp;</a>
                             <a class="list-group-item" style="border:none;height:400px">  &nbsp;</a>
                            
                            
                        </div>
                    </div>
                         


                  
                    <div class="Column">

                         <div class="row">
                         
                                &nbsp; &nbsp; &nbsp;
                             <asp:Button ID="Button2" class="btn btn-info" runat="server" Text="请选择问题分类" />
                          <asp:DropDownList ID="DropDownList_Category"  class="form-control" style="width:250px"  runat="server" > </asp:DropDownList>
                                &nbsp; &nbsp; &nbsp; &nbsp;
                         <asp:Button ID="But_Search" runat="server" class="btn btn-info" Text="查  找" OnClick="But_Search_Click" />
                                 &nbsp; &nbsp; &nbsp; &nbsp;
                             <asp:Button ID="Btn_All" runat="server" class="btn btn-info" Text="查看全部" OnClick="Btn_All_Click" Visible="false" />
                 
                    </div>  
                        <div>
                       

                       
                         
                    </div>
                        <br />
                     
                  <div class="card" style="height:550px">
                    &nbsp; &nbsp; &nbsp; &nbsp;  &nbsp; &nbsp;  &nbsp; &nbsp;&nbsp; &nbsp;
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="questionID"
                         class="tab-content" style="width: 1200px;text-align:center;word-break :break-all;word-wrap:break-word " RowStyle-Height="50px" OnRowDataBound="GridView1_RowDataBound">
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
                          <HeaderStyle Height="50px" />
<RowStyle Height="50px"></RowStyle>

                    </asp:GridView>
                     
                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" Visible="False"
                         class="tab-content" style="width: 1200px;text-align:center ;word-break :break-all;word-wrap:break-word " RowStyle-Height="50px">
                        <Columns>
                            <asp:BoundField DataField="question" HeaderText="遇到的问题" />
                            <asp:BoundField DataField="solution" HeaderText="如何解决" />
                        </Columns>
                         <HeaderStyle Height="50px" />
                    </asp:GridView>
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