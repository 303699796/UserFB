<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserRegister.aspx.cs" Inherits="UserFB.Web.Login.UserRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="UTF-8"/>
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0"/>
    <meta http-equiv="X-UA-Compatible" content="ie=edge"/>
    <title>用户注册</title>

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
                       用户注册
                    </div>
                    <div class="card-body py-5">
                        <div class="form-group">
                            <label class="form-control-label">用户名&nbsp;:</label>                   
                           &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 
                         <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="txbUserName" Display="Dynamic" ErrorMessage="请输入用户名"></asp:RequiredFieldValidator>                  
                            <asp:TextBox ID="txbUserName" runat="server" class="form-control"></asp:TextBox>                          
                        </div>
                      
                            <div class="form-group">
                                <label class="form-control-label">出生日期&nbsp;: &nbsp;&nbsp; &nbsp; </label> 
                              
                                <asp:DropDownList ID="DropDownListYear" runat="server" ></asp:DropDownList>
                                <span>&nbsp;年 &nbsp; </span>
                            
                                    <asp:DropDownList ID="DropDownListMonth" runat="server" ></asp:DropDownList>
                               
                                <span>&nbsp;月 &nbsp; </span>
                                
                                <asp:DropDownList ID="DropDownListDay" runat="server"></asp:DropDownList>
                                <span>&nbsp;日 &nbsp;</span>
                             <%-- onchange="setDays()"--%>

                            </div>

                          <div class="form-group">
                            <label class="form-control-label"  style="float:left">性别&nbsp;: &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp;</label> 
                            <asp:DropDownList ID="DropDownList1" runat="server">
                                <asp:ListItem>男</asp:ListItem>
                                <asp:ListItem>女</asp:ListItem>
                            </asp:DropDownList>
                         </div>

                        <div class="form-group">
                            <label class="form-control-label" >密码&nbsp;:</label>  
                              &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 
                         <asp:RequiredFieldValidator ID="rfvtxbPassword1" runat="server" ControlToValidate="txbPassword1" Display="Dynamic" ErrorMessage="请输入密码"></asp:RequiredFieldValidator> 
                             <asp:TextBox runat="server" ID="txbPassword1" CssClass="form-control" TextMode="Password"></asp:TextBox>
                        </div>       
                        <div class="form-group">
                            <label class="form-control-label">确认密码&nbsp;:</label>  
                              &nbsp; &nbsp; &nbsp; 
                            <asp:RequiredFieldValidator ID="rfvtxbPassword2" runat="server" ControlToValidate="txbPassword2" Display="Dynamic" ErrorMessage="请再次输入密码"></asp:RequiredFieldValidator>  
                          <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txbPassword1" ControlToValidate="txbPassword2" Display="Dynamic" ErrorMessage="两次密码不一致"></asp:CompareValidator>
                             <asp:TextBox runat="server" ID="txbPassword2" CssClass="form-control" TextMode="Password"></asp:TextBox>
                           
                        </div>   
                    </div>

                    <div class="card-footer">
                       <div class="row">
                          
                            <div class="col-6">
                                <a href="Login.aspx" class="btn btn-link">已有密码？登陆 ></a>
                            </div>
                             <div class="col-6">
                                 <asp:Button ID="Btn_Register" runat="server" Text="注册" CssClass="btn btn-primary px-5" OnClick="Btn_Register_Click"/>
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