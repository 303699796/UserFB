<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="UserFB.Web.S_Admin_List.List"   EnableEventValidation="false"%>
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
       <asp:Label ID="LabelCategory" runat="server"   class="btn btn-info"  Text="问题分类查询"></asp:Label>
                    <%-- <asp:DropDownList ID="DropDownList_Category" class="form-control"  style="width:150px" runat="server" DataSourceID="SqlDataSource_Category" DataTextField="category" DataValueField="category" ></asp:DropDownList>
           <asp:SqlDataSource ID="SqlDataSource_Category" runat="server" ConnectionString="Data Source=.;Initial Catalog=UFB;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [category] FROM [Category]"></asp:SqlDataSource>--%>
            <asp:DropDownList ID="DropDownList_Category" class="form-control"  style="width:150px" runat="server"></asp:DropDownList>
                 &nbsp;&nbsp;
      
            <asp:Button ID="btn_Star" runat="server"  class="btn btn-info"   Text="选择开始时间" OnClick="btn_Star_Click"/>
                  <asp:TextBox ID="txbStar" runat="server"    ></asp:TextBox>
             
                 <asp:Label ID="Label1" runat="server" Text="--"></asp:Label>
                 <asp:Button ID="btn_End" runat="server" class="btn btn-info"  Text="选择结束时间" OnClick="btn_End_Click" />
                 <asp:TextBox ID="txbEnd" runat="server"></asp:TextBox>
                 &nbsp;&nbsp;
                  <asp:TextBox ID="txbSearch" class="form-control"  style="width:200px;float:right"  runat="server"></asp:TextBox>  
                 &nbsp;&nbsp;
                 <asp:Button ID="btn_Search" runat="server" Text="搜索" class="btn btn-info"  OnClick="btn_Search_Click" />
                 &nbsp;&nbsp;
                 <asp:Button ID="btnDownload" runat="server" Text="导出" class="btn btn-info" OnClick="btnDownload_Click" />
</div><br /> 
                
                  <div class="row">

                                       </div>
                              <div class="row">
           <asp:Button ID="btn_Reply"   class="btn btn-rounded btn-info"  data-toggle="modal" data-target="#modal-1" style="width:80px" runat="server" Text="回复" />&nbsp;&nbsp;
             <asp:Button ID="btn_Distribution"   class="btn btn-rounded btn-info"  data-toggle="modal" data-target="#modal-2"  style="width:80px" runat="server" Text="分配" />&nbsp;&nbsp;
              <asp:Button ID="btn_Dealwith"  class="btn btn-rounded btn-info"  runat="server" Text="标记为已处理"  OnClick="btn_Dealwith_Click"/>&nbsp;&nbsp;
              <asp:Button ID="btn_Invalid" class="btn btn-rounded btn-info"  runat="server" Text="标记为无效" OnClick="btn_Invalid_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

         </div>  
            <br />
        &nbsp;&nbsp;&nbsp;
        <asp:Calendar ID="Calendar_Star" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px" Visible="False" OnSelectionChanged="Calendar_Star_SelectionChanged">
                 <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                 <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                 <OtherMonthDayStyle ForeColor="#999999" />
                 <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                 <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                 <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                 <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                 <WeekendDayStyle BackColor="#CCCCFF" />
             </asp:Calendar>
    

             <asp:Calendar ID="Calendar_End" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px" OnSelectionChanged="Calendar_End_SelectionChanged" Visible="False">
                 <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                 <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                 <OtherMonthDayStyle ForeColor="#999999" />
                 <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                 <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                 <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                 <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                 <WeekendDayStyle BackColor="#CCCCFF" />
             </asp:Calendar>
                       
            <br />
      
       
       <asp:GridView ID="GridView1" runat="server" class="tab-content" style="width: 100%;text-align:center;word-break :break-all;word-wrap:break-word " RowStyle-Height="50px" AutoGenerateColumns="False" DataKeyNames="feedbackID" >
           <Columns>
               <asp:TemplateField HeaderText="选择">
                    <ItemTemplate>
                       <asp:CheckBox ID="Modify" runat="server"  />
                    </ItemTemplate>
                </asp:TemplateField>
               <asp:TemplateField HeaderText="反馈用户">
                   <EditItemTemplate>
                       <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Users.userName") %>'></asp:TextBox>
                   </EditItemTemplate>
                   <ItemTemplate>
                       <asp:Label ID="Label1" runat="server" Text='<%# Bind("Users.userName") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:BoundField DataField="feedbackTime" HeaderText="反馈时间" />
               <asp:TemplateField HeaderText="反馈分类">
                   <EditItemTemplate>
                       <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Category.category") %>'></asp:TextBox>
                   </EditItemTemplate>
                   <ItemTemplate>
                       <asp:Label ID="Label2" runat="server" Text='<%# Bind("Category.category") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:BoundField DataField="Info" HeaderText="反馈内容" />
               <asp:BoundField DataField="contact" HeaderText="联系方式" />
               <asp:BoundField DataField="isInvalid" HeaderText="有效状态" />
               <asp:BoundField DataField="solutionState" HeaderText="解决状态" />
               <asp:BoundField DataField="handler" HeaderText="处理人" />
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
