<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="G_List.aspx.cs" Inherits="UserFB.Web.G_Admin_List.G_List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <meta charset="UTF-8"/>
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0"/>
    <meta http-equiv="X-UA-Compatible" content="ie=edge"/>
    <title>分配列表</title>
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
                <a href="../S_Admin_List/ApplyMessage_List.aspx">
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
                        <a href="../G_Admin_List/G_List.aspx" class="nav-link active">
                            <i class="icon icon-puzzle"></i>分配列表
                        </a>
                    </li>   

                      <li class="nav-item">
                        <a href="../G_Admin_List/G_Index.aspx" class="nav-link ">
                            <i class="icon icon-grid"></i>反馈分析
                        </a>
                    </li>  
                   
                      <li class="nav-item">
                        <a href="#" class="nav-link ">
                            <i class="icon icon-target"></i>我的消息
                        </a>
                    </li>        
                        </ul>
                      
            </nav>
        </div>


        <div class="content">
<%--            <div class="row">
                <div class="col-md-6">
                    <div class="card">
                    
                        <div class="card-header bg-light" style="width:1200px;height:50px;border:none">
                         <h5>未处理反馈</h5>
                     
                        </div>
                            
                     </div>
                </div>
    </div>--%>

             <button type="button"  class="btn btn-block btn-info" style="width:100%;height:40px;border:none;font-weight:900;font-size:17px">未解决反馈</button>
               <br />        
         

             <asp:Button ID="Btn_Solve"  class="btn btn-primary" runat="server" CausesValidation="false" CommandName="" Text="标记为已解决" OnClick="Btn_Solve_Click" />
            &nbsp;   &nbsp;   &nbsp;
             <asp:Button ID="Btn_Block" class="btn btn-primary" runat="server" CausesValidation="false" CommandName="" Text="标记为阻塞" OnClick="Btn_Block_Click" />
         <br />    
            <br />
            <asp:GridView ID="GridView1" runat="server" class="tab-content" style="width: 100%;text-align:center;word-break :break-all;word-wrap:break-word "
           RowStyle-Height="50px" AutoGenerateColumns="False" DataKeyNames="distributionID">
                <Columns>
                      <asp:TemplateField HeaderText="选择">
                         
                          <ItemTemplate>
                              <asp:CheckBox ID="ModifyThis" runat="server" />
                          </ItemTemplate>
                      </asp:TemplateField>
                    <asp:TemplateField HeaderText="分配时间">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("distributionTime") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("distributionTime") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="负责人">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("adminID") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("adminID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="反馈信息ID">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("feedbackID") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("feedbackID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="任务描述">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("description") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("description") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="分配者">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("assignerID") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("assignerID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="解决状态">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("state") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("state") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                <%--    <asp:TemplateField HeaderText="标记为" ShowHeader="False">
                        <ItemTemplate>
                           
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    
                    <asp:HyperLinkField DataNavigateUrlFields="feedbackID" DataNavigateUrlFormatString="G_List_Details.aspx?feedbackID={0}" HeaderText="详情" Text="详情" />
                    
                </Columns>

<RowStyle Height="50px"></RowStyle>
            </asp:GridView>
  





            <br />
  

            <br />
          <%--   <div class="row">
                <div class="col-md-6">
                    <div class="card">
                    
                        <div class="card-header bg-light" style="width:1200px;height:50px;border:none">
                         <h5>已处理反馈</h5>
                     
                        </div>
                            
                     </div>
                </div>
    </div>--%>

            
             <button type="button"  class="btn btn-block btn-info" style="width:100%;height:40px;border:none;font-weight:900;font-size:17px">已解决反馈</button>
               <br />   

              <asp:GridView ID="GridView2" runat="server" class="tab-content" style="width: 100%;text-align:center;word-break :break-all;word-wrap:break-word "
           RowStyle-Height="50px" AutoGenerateColumns="False" DataKeyNames="distributionID">
                <Columns>
                    <asp:TemplateField HeaderText="分配时间">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("distributionTime") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("distributionTime") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="负责人">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("adminID") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("adminID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="反馈信息ID">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("feedbackID") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("feedbackID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="任务描述">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("description") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("description") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="分配者">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("assignerID") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("assignerID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="解决状态">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("state") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("state") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                   
                    
                    <asp:HyperLinkField DataNavigateUrlFields="feedbackID" DataNavigateUrlFormatString="G_List_Details.aspx?feedbackID={0}" HeaderText="详情" Text="详情" />
                    
                </Columns>

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
