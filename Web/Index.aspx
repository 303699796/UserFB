<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="UserFB.Web.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="UTF-8"/>
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0"/>
    <meta http-equiv="X-UA-Compatible" content="ie=edge"/>
    <title>首页</title>
     <link rel="stylesheet" href="../bootstrap/vendor/simple-line-icons/css/simple-line-icons.css"/>
    <link rel="stylesheet" href="../bootstrap/vendor/font-awesome/css/fontawesome-all.min.css"/>
     <link rel="stylesheet" href="../bootstrap/css/styles.css"/>
     <script src="../bootstrap/vendor/jquery/jquery.min.js"></script>
       <script src="Echarts/echarts.min.js"></script>
      <script src="Echarts/macarons.js"></script>
    <style type="text/css">
        .auto-style1 {
            position: relative;
            width: 100%;
            min-height: 1px;
            -webkit-box-flex: 0;
            -ms-flex: 0 0 50%;
            flex: 0 0 50%;
            max-width: 50%;
            left: 9px;
            top: -12px;
            padding-left: 15px;
            padding-right: 15px;
        }
    </style>
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
                                <a href="../Index.aspx" class="nav-link active">
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
            
                      <button type="button" class="btn btn-block btn-info" style="width:100%;height:40px;border:none;font-weight:900;font-size:17px">反馈数量</button>
             <br />
            <div class="container-fluid">
                <div class="row">
                    <div class="col-md-3">
                        <div class="card p-4">
                            <div class="card-body d-flex justify-content-between align-items-center">
                                <div>
                                     <span class="font-weight-light">昨日反馈量</span>
                                    <br /><br />
                                    <asp:Label ID="LabelYdayNum" runat="server" class="h4 d-block font-weight-normal mb-2" ></asp:Label>
                                 
                                   
                                </div>

                                <div class="h2 text-muted">
                                    <i class="icon icon-people"></i>
                                </div>
                            </div>
                        </div>
                    </div>


                    <div class="col-md-3">
                        <div class="card p-4">
                            <div class="card-body d-flex justify-content-between align-items-center">
                                <div>
                                    <span class="font-weight-light">今日反馈量</span><br /><br />
                                    <asp:Label ID="LabelDdayNum" runat="server" class="h4 d-block font-weight-normal mb-2"></asp:Label>
                                    
                                </div>

                                <div class="h2 text-muted">
                                    <i class="icon icon-cloud-download"></i>
                                </div>
                            </div>
                        </div>
                    </div>

                    
                    <div class="col-md-3">
                        <div class="card p-4">
                            <div class="card-body d-flex justify-content-between align-items-center">
                                <div>
                                    <span class="font-weight-light">本周已解决</span>
                                    <br /><br />
                                    <asp:Label ID="LabelWSolve" runat="server" class="h4 d-block font-weight-normal mb-2"  ></asp:Label>

                                    
                                </div>

                                <div class="h2 text-muted">
                                    <i class="icon icon-wallet"></i>
                                </div>
                            </div>
                        </div>
                    </div>


                    <div class="col-md-3">
                        <div class="card p-4">
                            <div class="card-body d-flex justify-content-between align-items-center">
                                <div>
                                    <span class="font-weight-light">待解决</span><br /><br />
                                    <asp:Label ID="LabelNSolve" runat="server" class="h4 d-block font-weight-normal mb-2" ></asp:Label>
                                    
                                </div>

                          
                                <div class="h2 text-muted">
                                    <i class="icon icon-clock"></i>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                    </div>
     <div class="card">
   <div id="main" style="width:100%;height:400px;"></div>
    <script type="text/javascript">
    var mychart = echarts.init(document.getElementById('main'), 'macarons');
    mychart.setOption({
        title: {
            text: '近七日反馈数量',
              x:'center'
        },
        tooltip: {},
        legend: {
            data: ['反馈数量'],
              orient: 'vertical',
              left: 'left'
        },
        xAxis: {
            data: []
        },
        yAxis: {},
        series: [{
            name: '反馈数量',
            type: 'line',
            data: []
        }]
    });
    mychart.showLoading();
    var names =[];    //（实际用来盛放X轴坐标值）
    var nums = [];    //（实际用来盛放Y坐标值）
 
    $.ajax({
        type: "post",
        async: true,            //异步请求（同步请求将会锁住浏览器，用户其他操作必须等待请求完成才可以执行）
        url: "Index.aspx?method=getdata",
    
        data: {},
        dataType: "json",        //返回数据形式为json
        success: function (result) {
            //请求成功时执行该函数内容，result即为服务器返回的json对象
            if (result) {

              // var json = $.parseJSON(result);

             //  alert(result);
              
               for (var i = 0; i < result.length; i++) {

                  // alert(result[i].name);

                   names.push(result[i].names);   
                  
                }
                for (var i = 0; i < result.length; i++) {
                   nums.push(result[i].nums);    
                }
                mychart.hideLoading();    //隐藏加载动画
                mychart.setOption({        //加载数据图表
                    xAxis: {
                        data: names
                    },
                    series: [{
                        // 根据名字对应到相应的系列
                        name: '反馈数量',
                        data: nums
                    }]
                });
 
            }
 
        },
        error: function (errorMsg) {
            //请求失败时执行该函数
            alert("图表请求数据失败!");
            myChart.hideLoading();
        }
        })
    </script>
</div>
<div>
    
                    <div class="card" style="text-align:center">
                        <div class="card-header bg-light">
                            反馈数量明细
                        </div>

                        <div class="card-body">
                            <div class="table-responsive" >
                                <table class="table table-striped" >
                                    <thead>
                                    <tr>
                                        <th>日期</th>
                                        <th>反馈数量</th>
                                        
                                    </tr>
                                    </thead>
                                    <tbody>
                                    <tr>
                                        <td>
                                            <asp:Label ID="LabelDay1" runat="server" ></asp:Label>
                                        </td>
                                        <td class="text-nowrap"> 
                                            <asp:Label ID="LabelNum1" runat="server"></asp:Label>
                                        </td>
                                        
                                    </tr>
                                    <tr>
                                        <td>
                                             <asp:Label ID="LabelDay2" runat="server" ></asp:Label>
                                        </td>
                                        <td class="text-nowrap">
                                            <asp:Label ID="LabelNum2" runat="server"></asp:Label>
                                        </td>
                                        
                                    </tr>
                                    <tr>
                                        <td>
                                               <asp:Label ID="LabelDay3" runat="server" ></asp:Label>
                                        </td>
                                        <td class="text-nowrap">
                                            <asp:Label ID="LabelNum3" runat="server"></asp:Label>
                                        </td>
                                       
                                    </tr>
                                    <tr>
                                        <td>
                                             <asp:Label ID="LabelDay4" runat="server" ></asp:Label>
                                        </td>
                                        <td class="text-nowrap">
                                            <asp:Label ID="LabelNum4" runat="server"></asp:Label>
                                        </td>
                                        
                                    </tr>
                                    <tr>
                                        <td>
                                             <asp:Label ID="LabelDay5" runat="server" ></asp:Label>
                                        </td>
                                        <td class="text-nowrap">
                                            <asp:Label ID="LabelNum5" runat="server"></asp:Label>

                                        </td>
                                        
                                    </tr>
                                          <tr>
                                        <td>
                                             <asp:Label ID="LabelDay6" runat="server" ></asp:Label>
                                        </td>
                                        <td class="text-nowrap">
                                            <asp:Label ID="LabelNum6" runat="server"></asp:Label>
                                        </td>
                                        
                                    </tr>
                                          <tr>
                                        <td>
                                             <asp:Label ID="LabelDay7" runat="server" ></asp:Label>
                                        </td>
                                        <td class="text-nowrap">
                                            <asp:Label ID="LabelNum7" runat="server"></asp:Label>
                                        </td>
                                        
                                    </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
</div>

                </div>
           </div>  



   </form>  

<%-- <script src="../bootstrap/vendor/jquery/jquery.min.js"></script>--%>
<script src="../bootstrap/vendor/popper.js/popper.min.js"></script>
<script src="../bootstrap/vendor/bootstrap/js/bootstrap.min.js"></script>
<script src="../bootstrap/vendor/chart.js/chart.min.js"></script>
<script src="../bootstrap/js/carbon.js"></script>
<script src="../bootstrap/js/demo.js"></script>
</body>
</html>
