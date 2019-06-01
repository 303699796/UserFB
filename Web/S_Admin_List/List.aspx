<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="UserFB.Web.S_Admin_List.List"   EnableEventValidation="false" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <meta charset="UTF-8"/>
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0"/>
    <meta http-equiv="X-UA-Compatible" content="ie=edge"/>
    <title>反馈列表</title>
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
                        <a href="../S_Admin_List/List.aspx" class="nav-link active">
                            <i class="icon icon-puzzle"></i>反馈列表
                        </a>
                    </li>                                    
                         <li class="nav-item nav-dropdown"> 

                        <a href="#" class="nav-link nav-dropdown-toggle">
                            <i class="icon icon-grid"></i> 反馈分析 <i class="fa fa-caret-left"></i>
                        </a>

                        <ul class="nav-dropdown-items" >
                            <li class="nav-item" >
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
                                    <i class="icon icon-energy"></i>帮助列表
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

      <div class="row">
                  &nbsp;&nbsp;
                 &nbsp;&nbsp &nbsp;&nbsp

 <asp:Button ID="Button3"  class="btn btn-rounded btn-success"  runat="server" OnClick="Button3_Click" Text="多选标记" CausesValidation="False" />&nbsp;&nbsp;
              <asp:Button ID="btn_Dealwith"  class="btn btn-rounded btn-info"  runat="server" Text="标记为已处理"  OnClick="btn_Dealwith_Click" CausesValidation="False"/>&nbsp;&nbsp;
              <asp:Button ID="btn_Invalid" class="btn btn-rounded btn-info"  runat="server" Text="标记为无效" OnClick="btn_Invalid_Click" CausesValidation="False" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
           



       <asp:Label ID="LabelCategory" runat="server"   class="btn btn-info"  Text="问题分类查询"></asp:Label>
                  
            <asp:DropDownList ID="DropDownList_Category" class="form-control"  style="width:180px" runat="server"></asp:DropDownList>
                  <asp:Button ID="Btn_Category" runat="server" Text="搜索" class="btn btn-info"   OnClick="Btn_Category_Click" CausesValidation="False"/>
                
                
                 &nbsp;&nbsp;
                 &nbsp;&nbsp;            
                 &nbsp;&nbsp;
                  <asp:TextBox ID="txbSearch" class="form-control"  style="width:240px;float:right"  runat="server"></asp:TextBox>  
                 <asp:Button ID="btn_KeyWSearch" runat="server" Text="搜索" class="btn btn-info"  OnClick="btn_KeyWSearch_Click" CausesValidation="False" />
                 &nbsp;&nbsp;
                  <asp:Button ID="Btn_All" runat="server" Text="查看全部" class="btn btn-info"   OnClick="Btn_All_Click" CausesValidation="False"  Visible="false"/>

                
                 &nbsp;&nbsp;
                 &nbsp;&nbsp;
                 <asp:Button ID="btnDownload" runat="server" Text="导出Excel" class="btn btn-info" OnClick="btnDownload_Click" OnClientClick="return true" />
</div>
      
            <br />    
        &nbsp;&nbsp;&nbsp;
                               
          
      
            <asp:Label ID="Labeltest" runat="server" Visible="false" ></asp:Label>
          

          
           
       <asp:GridView ID="GridView1" runat="server" class="tab-content" style="width: 100%;text-align:center;word-break :break-all;word-wrap:break-word "
           RowStyle-Height="50px" AutoGenerateColumns="False" DataKeyNames="feedbackID"  AllowPaging="True" OnRowDataBound="GridView1_RowDataBound" >
           <Columns>
               <asp:TemplateField HeaderText="选择" Visible="False">
                    <ItemTemplate>
                       <asp:CheckBox ID="Modify" runat="server"  />
                    
                         
                   
                    </ItemTemplate>
                </asp:TemplateField>
             
               <asp:TemplateField HeaderText="反馈用户" ItemStyle-Width="90px">
                   <EditItemTemplate>
                       <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Users.userName") %>'></asp:TextBox>
                   </EditItemTemplate>
                   <ItemTemplate>
                       <asp:Label ID="Label1" runat="server" Text='<%# Bind("Users.userName") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:BoundField DataField="feedbackTime" HeaderText="反馈时间"  ItemStyle-Width="135px"/>
               <asp:TemplateField HeaderText="反馈分类" ItemStyle-Width="120px">
                   <EditItemTemplate>
                       <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Category.category") %>'></asp:TextBox>
                   </EditItemTemplate>
                   <ItemTemplate>
                       <asp:Label ID="Label2" runat="server" Text='<%# Bind("Category.category") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:BoundField DataField="Info" HeaderText="反馈内容" ItemStyle-Width="330px"/>
               <asp:BoundField DataField="contact" HeaderText="联系方式" ItemStyle-Width="130px"/>
           <%--    <asp:BoundField DataField="isInvalid" HeaderText="有效状态" />--%>
               <asp:BoundField DataField="solutionState" HeaderText="解决状态" />
               <asp:BoundField DataField="handler" HeaderText="负责人" />
               <asp:TemplateField ShowHeader="False">
                   <ItemTemplate>
                      <asp:Button ID="Button2" runat="server"   CausesValidation="false" CommandName="getID"  Text="选择" CssClass="btn btn-primary"  CommandArgument='<%# Eval("feedbackID") %>' OnClick="Button2_Click"/>
                         
                    
                    
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField Visible="False">
                   <ItemTemplate>
                       <button  id="Btn_Dtr"  class="btn btn-rounded btn-info" type="button"  data-toggle="modal" data-target="#modal-2"   style="width:80px"   >分配</button>
                       <button  id="Btn_Reply" class="btn btn-rounded btn-info"" type="button"  data-toggle="modal" data-target="#modal-1"  style="width:80px"  >回复</button>
                   </ItemTemplate>
               </asp:TemplateField>
           </Columns>

           <HeaderStyle Height="50px" />

<RowStyle Height="50px"></RowStyle>
             </asp:GridView>

           
                     
                       <%--     <button type="button"  class="btn btn-block btn-info" style="width:100%;height:40px;border:none;font-weight:900;font-size:17px">已分配反馈</button>
                      <br /> 
                --%>
           <%-- <asp:Button ID="Btn_title2" runat="server" Text="已分配反馈"  class="btn btn-block btn-success" style="width:100%;height:40px;border:none;font-weight:900;font-size:17px;background-color:rgba(108, 187, 244, 0.74)" />                   
           --%> 
            <br />  
         
             
               <asp:GridView ID="GridView2" runat="server" class="tab-content" style="width: 100%;text-align:center;word-break :break-all;word-wrap:break-word "
           RowStyle-Height="50px" AutoGenerateColumns="False" DataKeyNames="feedbackID"  AllowPaging="True" OnRowDataBound="GridView1_RowDataBound" >
           <Columns>
               <asp:TemplateField HeaderText="选择" Visible="False">
                    <ItemTemplate>
                       <asp:CheckBox ID="Modify" runat="server"  />
                    
                         
                   
                    </ItemTemplate>
                </asp:TemplateField>
             
               <asp:TemplateField HeaderText="反馈用户" ItemStyle-Width="90px">
                   <EditItemTemplate>
                       <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Users.userName") %>'></asp:TextBox>
                   </EditItemTemplate>
                   <ItemTemplate>
                       <asp:Label ID="Label1" runat="server" Text='<%# Bind("Users.userName") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:BoundField DataField="feedbackTime" HeaderText="反馈时间" ItemStyle-Width="135px" />
               <asp:TemplateField HeaderText="反馈分类" ItemStyle-Width="120px">
                   <EditItemTemplate>
                       <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Category.category") %>'></asp:TextBox>
                   </EditItemTemplate>
                   <ItemTemplate>
                       <asp:Label ID="Label2" runat="server" Text='<%# Bind("Category.category") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:BoundField DataField="Info" HeaderText="反馈内容" ItemStyle-Width="330px" />
               <asp:BoundField DataField="contact" HeaderText="联系方式" ItemStyle-Width="130px"/>
           <%--    <asp:BoundField DataField="isInvalid" HeaderText="有效状态" />--%>
               <asp:BoundField DataField="solutionState" HeaderText="解决状态" />
               <asp:BoundField DataField="handler" HeaderText="负责人" />
               <asp:TemplateField ShowHeader="False">
                   <ItemTemplate>
                      <asp:Button ID="Btn_Choose" runat="server"   CausesValidation="false" CommandName="getID"  Text="选择" CssClass="btn btn-primary"  CommandArgument='<%# Eval("feedbackID") %>' OnClick ="Btn_Choos_Click"/>
                         
                    
                    
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField Visible="False">
                   <ItemTemplate>
                     
                       <button  id="Btn_Reply" class="btn btn-rounded btn-info"" type="button"  data-toggle="modal" data-target="#modal-1"  style="width:80px"  >回复</button>
                   </ItemTemplate>
               </asp:TemplateField>
           </Columns>

           <HeaderStyle Height="50px" />

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
              <%--  <asp:Label ID="LabelReceive" runat="server" Text="回复给："></asp:Label>--%>
                <asp:Label ID="LabelName" runat="server"  Visible="false" ></asp:Label>

                 <asp:Label ID="LabelReply" runat="server" Text="请输入回复信息:"></asp:Label>
                 <asp:RequiredFieldValidator ID="rfvtxbReply" runat="server" ControlToValidate="txtReply" Display="Dynamic" ErrorMessage="回复消息不可为空"></asp:RequiredFieldValidator>     
                <br />     <br /> 
                      
                <asp:TextBox ID="txtReply" runat="server" TextMode="MultiLine" Width="450px" Height="100px"></asp:TextBox>
                 
            </div>

            <div class="modal-footer" >
                <button type="button" class="btn btn-link"  data-dismiss="modal">取消</button>   
                <asp:Button ID="BntReply" type="button" runat="server"  class="btn btn-primary" OnClick="BntReply_Click"  Text="回复" OnClientClick="return true" />
            </div>
        </div>
    </div>
</div>



              <div class="modal fade" id="modal-2" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title">问题分配</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>

            <div class="modal-body">
                <div class="row">
                  &nbsp;&nbsp;&nbsp; <asp:Label ID="Label4" runat="server" Text="分配给："></asp:Label>  &nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="DropDownList_Distribution" class="form-control" Width="380px" runat="server"></asp:DropDownList>
                 <%--   <asp:Label ID="LabelDropDownList" runat="server" Text = "必填" ForeColor="Red" Visible ="false"></asp:Label>--%>
                   <asp:RequiredFieldValidator ID="RFVDropDownList" runat="server" ControlToValidate="DropDownList_Distribution" Display="Dynamic" ErrorMessage="必填"></asp:RequiredFieldValidator>     
               
                    </div>
                <br /><br />
                <div class="row">
                 &nbsp;&nbsp;&nbsp;  <asp:Label ID="Label3" runat="server"  Text="分配描述:"></asp:Label>
                &nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtDistribution" runat="server" TextMode="MultiLine" class="form-control" Width="380px" Height="100px"></asp:TextBox>
                 <%--   <asp:Label ID="LabelDistribution" runat="server" Text = "必填"  Visible ="false"></asp:Label>--%>
            <asp:RequiredFieldValidator ID="RFVtxtDistribution" runat="server" ControlToValidate="txtDistribution" Display="Dynamic" ErrorMessage="必填"></asp:RequiredFieldValidator>  
                </div>
            </div>

            <div class="modal-footer" >
                <button type="button" class="btn btn-link"  data-dismiss="modal">取消</button>   
                <asp:Button ID="Btn_Distribution" type="button" runat="server"  class="btn btn-primary" OnClick="Btn_Distribution_Click"  Text="确认分配" OnClientClick="return true" />
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
