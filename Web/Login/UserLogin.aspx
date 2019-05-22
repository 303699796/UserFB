<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="UserFB.Web.Login.UserLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="UTF-8"/>
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0"/>
    <meta http-equiv="X-UA-Compatible" content="ie=edge"/>
    <title>用户登陆</title>

      <link rel="stylesheet" href="../bootstrap/vendor/simple-line-icons/css/simple-line-icons.css"/>
    <link rel="stylesheet" href="../bootstrap/vendor/font-awesome/css/fontawesome-all.min.css"/>
     <link rel="stylesheet" href="../bootstrap/css/styles.css"/>



     </head>
<body>
<form id="form1" runat="server">

<div class="page-wrapper flex-row align-items-center">
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-md-5">
                <div class="card p-4">
                    <div class="card-header text-center text-uppercase h4 font-weight-light">
                        用户登录
                    </div>
                      <a href="AdminLogin.aspx" class="btn btn-link" style="font-size:smaller">我是管理员 ></a>


                    <div class="card-body py-5">
                        <div class="form-group">
                            <label class="form-control-label">用户名</label>
                              &nbsp; &nbsp; &nbsp; 
                            <asp:RequiredFieldValidator ID="rfvtxbUserName" runat="server" ControlToValidate="txbUserName" Display="Dynamic" ErrorMessage="请输入用户名"></asp:RequiredFieldValidator>  
                            <asp:TextBox ID="txbUserName" runat="server" class="form-control"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label class="form-control-label">密码</label>
                             &nbsp; &nbsp; &nbsp; 
                            <asp:RequiredFieldValidator ID="rfvtxbPassword" runat="server" ControlToValidate="txbPassword" Display="Dynamic" ErrorMessage="请输入密码"></asp:RequiredFieldValidator>  
                             <asp:TextBox runat="server" ID="txbPassword" CssClass="form-control" TextMode="Password"></asp:TextBox>
                        </div>                      
                    </div>

                    <div class="card-footer">
                        <div class="row">
                          
                            <div class="col-6">
                                <a href="UserRegister.aspx" class="btn btn-link">未有账号？注册></a>
                            </div>
                             <div class="col-6">
                                 <asp:Button ID="Btn_Login" runat="server" Text="登陆" CssClass="btn btn-primary px-5" OnClick="Btn_Login_Click" />
                                
                            </div>
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
