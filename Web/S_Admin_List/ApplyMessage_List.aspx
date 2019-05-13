<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplyMessage_List.aspx.cs" Inherits="UserFB.Web.S_Admin_List.ApplyMessage_List" %>

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
                         <h5>权限申请消息</h5>
                     
                        </div>
                            
                     </div>
                </div>
            </div>

            <asp:GridView ID="GridView1" runat="server"  AllowPaging="True" 
            class="tab-content" style="width: 100%;text-align:center;word-break :break-all;word-wrap:break-word " RowStyle-Height="50px" OnPageIndexChanging ="GridView1_PageIndexChanging"
              OnRowDataBound="GridView1_RowCreated" OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating" 
                    AutoGenerateColumns="False"  RowStyle-HorizontalAlign="Center" OnRowCreated="GridView1_RowCreated" DataKeyNames="ApplyID" >

                <Columns>
                    <asp:TemplateField HeaderText="申请人">
                        <EditItemTemplate>
                            <asp:Label ID="LabelName" runat="server" Text='<%# Eval("name") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Labelname" runat="server" Text='<%# Bind("name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="部门">
                        <EditItemTemplate>
                            <asp:Label ID="LabelDepartment" runat="server" Text='<%# Eval("department") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Labeldepartment" runat="server" Text='<%# Bind("department") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="职位">
                        <EditItemTemplate>
                            <asp:Label ID="LabelJob" runat="server" Text='<%# Eval("job") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Labeljob" runat="server" Text='<%# Bind("job") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="申请权限">
                        <EditItemTemplate>
                            <asp:Label ID="LabelPermission" runat="server" Text='<%# Eval("permission") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Labelpermission" runat="server" Text='<%# Bind("permission") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="申请时间">
                        <EditItemTemplate>
                            <asp:Label ID="LabelTime" runat="server" Text='<%# Eval("applyTime") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Labeltime" runat="server" Text='<%# Bind("applyTime") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                  

                      <asp:TemplateField HeaderText="操作">
    <ItemTemplate>
    <asp:Button ID="btnAgree" runat="server" Text="同意" CssClass="btn btn-primary" CausesValidation="false" CommandName=""  OnClick="btnAgree_Click"/> 
         <asp:Button ID="btnRefuse" runat="server" Text="拒绝" CssClass="btn btn-primary" CausesValidation="false" CommandName=""  OnClick="btnRefuse_Click" /> 
    </ItemTemplate>
</asp:TemplateField> 
                    <asp:ButtonField ButtonType="Button" Text="同意"  />
                    <asp:CommandField ShowEditButton="True" EditText="同意" UpdateText="确认同意" ButtonType="Button" />
                </Columns>

<RowStyle Height="50px"></RowStyle>

            </asp:GridView>
            <br />
             <div class="row">
                <div class="col-md-6">
                    <div class="card">
                    
                        <div class="card-header bg-light" style="width:1200px;height:50px;border:none">
                         <h5>历史申请消息</h5>
                     
                        </div>
                            
                     </div>
                </div>
    </div>

            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" class="tab-content" style="width: 100%;text-align:center;word-break :break-all;word-wrap:break-word "  RowStyle-Height="50px" >
                <Columns>
                    <asp:BoundField DataField="name" HeaderText="申请人" />
                    <asp:BoundField DataField="department" HeaderText="部门" />
                    <asp:BoundField DataField="job" HeaderText="职位" />
                    <asp:BoundField DataField="permission" HeaderText="申请权限" />
                    <asp:BoundField DataField="applyTime" HeaderText="审核时间" />
                    <asp:BoundField DataField="applyState" HeaderText="状态" />
                </Columns>

                <RowStyle Height="50px" />

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