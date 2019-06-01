<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplyMessage_List.aspx.cs" Inherits="UserFB.Web.S_Admin_List.ApplyMessage_List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <meta charset="UTF-8"/>
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0"/>
    <meta http-equiv="X-UA-Compatible" content="ie=edge"/>
    <title>申请审批信息</title>
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
                                <a href="../S_Admin_List/ApplyMessage_List.aspx" class="nav-link active">
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
         
             
            <button type="button"  class="btn btn-block btn-info" style="width:100%;height:40px;border:none;font-weight:900;font-size:17px">权限申请消息</button>
               <br />


            <div style="width:200%">
                            <div class="col-md-6 mb-4"  style="width:300%">
                    <ul class="nav nav-tabs" role="tablist">
                        <li class="nav-item">
                            <a class="nav-link active" data-toggle="tab" href="#home" role="tab" aria-controls="home" style="width:100%;font-size:16px;font-weight:700;text-align:center">未审批消息</a>
                        </li>

                        <li class="nav-item">
                            <a class="nav-link" data-toggle="tab" href="#profile" role="tab" aria-controls="profile" style="width:100%;font-size:16px;font-weight:700;text-align:center">已审批消息</a>
                        </li>

                        
                    </ul>

                    <div class="tab-content">
                        <div class="tab-pane active" id="home" role="tabpanel">
                           

<div class="row">
                 &nbsp; &nbsp; &nbsp;
                 <asp:Button ID="Btn_Agree" runat="server" class="btn btn-info" Text="同意申请" OnClick="Btn_Agree_Click" />
                 &nbsp; &nbsp; &nbsp;
                 <asp:Button ID="Btn_Refuse" runat="server" class="btn btn-info" Text="拒绝申请" OnClick ="Btn_Refuse_Click" />
               
                 </div>
              <br /> 

            <asp:GridView ID="GridView1" runat="server"  AllowPaging="True" 
            class="tab-content" style="width: 100%;text-align:center;word-break :break-all;word-wrap:break-word " RowStyle-Height="50px" OnPageIndexChanging ="GridView1_PageIndexChanging"
              OnRowDataBound="GridView1_RowCreated" OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating" 
                    AutoGenerateColumns="False"  RowStyle-HorizontalAlign="Center" OnRowCreated="GridView1_RowCreated" DataKeyNames="ApplyID" >

                <Columns>
                  

                      <asp:TemplateField HeaderText="选择">
                         
                          <ItemTemplate>
                              <asp:CheckBox ID="ModifyThis" runat="server" />
                          </ItemTemplate>
                      </asp:TemplateField>
                  

                      <asp:TemplateField HeaderText="申请人ID" Visible="False">
                          <EditItemTemplate>
                              <asp:Label ID="LabelApplicantID" runat="server" Text='<%# Eval("applicantID") %>'></asp:Label>
                          </EditItemTemplate>
    <ItemTemplate>
        <asp:Label ID="LabelID" runat="server" Text='<%# Bind("applicantID") %>'></asp:Label>
    </ItemTemplate>
</asp:TemplateField> 
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
                  

                    <%--<asp:CommandField ShowEditButton="True" EditText="同意" UpdateText="确认同意" ButtonType="Button" />
                    <asp:CommandField ButtonType="Button" EditText="拒绝" ShowEditButton="True" UpdateText="确认拒绝" />--%>
                    <asp:TemplateField HeaderText="审批人" Visible="False">
                        <EditItemTemplate>
                            <asp:Label ID="LabelApproverID" runat="server" Text='<%# Eval("approverID") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="LabelapproverID" runat="server" Text='<%# Bind("approverID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                    <HeaderStyle Height="50px" />

<RowStyle Height="50px"></RowStyle>

            </asp:GridView>
            <br />



                        </div>

                        <div class="tab-pane" id="profile" role="tabpanel">
                          <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" class="tab-content" style="width: 100%;text-align:center;word-break :break-all;word-wrap:break-word "  RowStyle-Height="50px" OnRowDataBound="GridView2_RowDataBound" >
                <Columns>
                    <asp:BoundField DataField="name" HeaderText="申请人" />
                    <asp:BoundField DataField="department" HeaderText="部门" />
                    <asp:BoundField DataField="job" HeaderText="职位" />
                    <asp:BoundField DataField="permission" HeaderText="申请权限" />
                    <asp:BoundField DataField="applyTime" HeaderText="审核时间" />
                    <asp:BoundField DataField="applyState" HeaderText="状态(1为同意，2为拒绝)" />
                </Columns>
                <HeaderStyle Height="50px" />
                <RowStyle Height="50px" />

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