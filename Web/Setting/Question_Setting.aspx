<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Question_Setting.aspx.cs" Inherits="UserFB.Web.Setting.Question_Setting" %>

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
    <script language="javascript" src="/js/CheckBox.js" type="text/javascript"></script>
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
                        <a href="../S_Admin_List/List.aspx" class="nav-link active">
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
                                    <i class="icon icon-energy"></i> 常见问题
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
          <button type="button"  class="btn btn-block btn-info" style="width:100%;height:40px;border:none;font-weight:900;font-size:17px">常见问题设置</button>
               <br />  
           <button class="btn btn-primary px-5" type="button" data-toggle="modal" data-target="#modal-1" style="float:left">新增问题</button>
           &nbsp; &nbsp; &nbsp; &nbsp;
          <asp:Button ID="btnDelete" class="btn btn-primary px-5" runat="server" Text="删除" OnClick="btnDelete_Click"/>    


            <br /><br />
           <%--  <div class="row">
                <div class="col-md-6">
                    <div class="card">
                    
                        <div class="card-header bg-light" style="width:1200px;height:50px;border:none">
                         <h5>管理员设置</h5>
                     
                        </div>
                            
                     </div>
                </div>
            </div>--%>

         <div class="modal fade" id="modal-1" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title">新增问题</h5> 
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>

            <div class="modal-body">
                <div class="row">
                <asp:Label ID="LabelCategory" runat="server" Text="   &nbsp;&nbsp;&nbsp; 请选择新增问题分类 ："></asp:Label>
                      &nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="DropDownList_Category"  Width="270px" runat="server"></asp:DropDownList>
                    </div>
                <br /><br />
                <div class="row">
                 <asp:Label ID="LabelQuestion" runat="server" Text="  &nbsp;&nbsp;&nbsp;  请输入新增问题描述 ："></asp:Label>
                &nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtQuestion" runat="server" TextMode="MultiLine" Width="270px" Height="100px"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="rfvtxtQuestion" runat="server" ControlToValidate="txtQuestion" Display="Dynamic" ErrorMessage="必填"></asp:RequiredFieldValidator>     
            
                </div> 
                 <br /><br />
                <div class="row">
               
                <asp:Label ID="LabelSolution" runat="server" Text="  &nbsp;&nbsp;&nbsp;  请输入解决方案描述 ："></asp:Label>
                &nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtSolution" runat="server" TextMode="MultiLine" Width="270px" Height="100px"></asp:TextBox>
                
                      <asp:RequiredFieldValidator ID="rfvtxtSolution" runat="server" ControlToValidate="txtSolution" Display="Dynamic" ErrorMessage="必填"></asp:RequiredFieldValidator>     
            </div>

        </div>
            <div class="modal-footer" >
                <button type="button" class="btn btn-link"  data-dismiss="modal">取消</button>
               <%-- <button  type="button" class="btn btn-primary" onclick=""  >保存</button>--%>
                <asp:Button ID="BntSave" type="button" runat="server"  class="btn btn-primary" OnClick="BntSave_Click"  Text="保存" />
            </div>
        </div>
    </div>
</div>


               <div class="card" style="width:100%;height:500px">

        <asp:GridView ID="gridView" runat="server" AllowPaging="True" 
            class="tab-content" style="width: 100%;text-align:center;word-break :break-all;word-wrap:break-word " RowStyle-Height="50px" OnPageIndexChanging ="gridView_PageIndexChanging"
                    BorderWidth="1px" DataKeyNames="questionID" OnRowDataBound="gridView_RowDataBound"
            OnRowEditing="gridView_RowEditing" OnRowCancelingEdit="gridView_RowCancelingEdit" OnRowUpdating="gridView_RowUpdating" 
                    AutoGenerateColumns="False"  RowStyle-HorizontalAlign="Center" OnRowCreated="gridView_RowCreated">
                    <Columns>
                    <asp:TemplateField ControlStyle-Width="30" HeaderText="选择"    >
                                <ItemTemplate>
                                    <asp:CheckBox ID="DeleteThis" onclick="javascript:CCA(this);" runat="server" />
                                </ItemTemplate>

<ControlStyle Width="30px"></ControlStyle>
                            </asp:TemplateField> 
                            
		                <asp:TemplateField HeaderText="问题所属分类" SortExpression="categoryID">
                            <EditItemTemplate>
                                <asp:Label ID="txtCcategory" runat="server" Text='<%# Bind("categoryID") %>'></asp:Label>
                               <%-- <asp:DropDownList ID="ddl_category" runat="server"></asp:DropDownList>
                                <asp:HiddenField ID="hf_Category" runat="server" Text='<%# Bind("categoryID") %>' />--%>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("categoryID") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="问题描述" SortExpression="question">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtQuestion" runat="server" Text='<%# Bind("question") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("question") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="解决方案" SortExpression="solution">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtSolution" runat="server" Text='<%# Bind("solution") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("solution") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                            
		                <asp:TemplateField HeaderText="更新时间" SortExpression="time">
                            <EditItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("time") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("time") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:CommandField HeaderText="编辑" ShowEditButton="True" />
                            
                        </Columns>
                <HeaderStyle Height="50px" />
<RowStyle HorizontalAlign="Center" Height="50px"></RowStyle>
                </asp:GridView>
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
