﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Category_Analysis.aspx.cs" Inherits="UserFB.Web.Chart_Analysis.Category_Analysis" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="UTF-8"/>
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0"/>
    <meta http-equiv="X-UA-Compatible" content="ie=edge"/>
    <title>分类分析</title>
     <link rel="stylesheet" href="../bootstrap/vendor/simple-line-icons/css/simple-line-icons.css"/>
    <link rel="stylesheet" href="../bootstrap/vendor/font-awesome/css/fontawesome-all.min.css"/>
     <link rel="stylesheet" href="../bootstrap/css/styles.css"/>

     <script src="../bootstrap/vendor/jquery/jquery.min.js"></script>
       <script src="../Echarts/echarts.min.js"></script>
      <script src="../Echarts/macarons.js"></script>

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
                            <i class="icon icon-puzzle"></i> 反馈列表
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
                                    <i class="icon icon-energy"></i> 帮助列表
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
              <div class="col-md-6">
                    <div class="card">                    
                        <div class="card-header bg-light" style="width:1200px;height:50px;border:none">
                         <h5>用户画像</h5>                     
                        </div>    
                     </div>
                </div>




             <div class ="row">

             <asp:Label ID="LabelTime" runat="server"  Text="请选择时间范围："></asp:Label>&nbsp;&nbsp;
             <%--<asp:Button ID="Btn_Time" runat="server" BorderWidth="0px" Text="请选择时间范围：" />--%>
             <asp:Button ID="Btn_Today" runat="server" class="btn btn-rounded btn-info"  Text="今日" OnClick="Btn_Today_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:Button ID="Btn_Yesterday" runat="server" class="btn btn-rounded btn-info"  Text="近七天" OnClick="Btn_Yesterday_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:Button ID="Btn_7days" runat="server" class="btn btn-rounded btn-info"  Text="近一个月" OnClick="Btn_7days_Click"/>&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:Button ID="Btn_Month" runat="server" class="btn btn-rounded btn-info"  Text="全部" OnClick="Btn_Month_Click" />     
                 <asp:Label ID="Label1" runat="server" Text="女"></asp:Label>
                 <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
                 </div>

         
             <asp:GridView ID="GridView1" runat="server"></asp:GridView>
  
             
              <div id="main" style="width:100%;height:400px;"></div>
    <script type="text/javascript">
    var mychart = echarts.init(document.getElementById('main'), 'macarons');
    mychart.setOption({
        title: {
            text: '反馈用户性别比例',
            x:'center'
           
            
        },
        tooltip: {},
       legend: {
        orient: 'vertical',
        left: 'left',
        data: ['男','女']
    },
        xAxis: {
            data: []
        },
        yAxis: {},
        series: [{
            name: '反馈类型分析',
           //type: 'pie',
           //radius: 100,
            type: 'bar',//直方图
            data: []
            
        }]
    });
    mychart.showLoading();
    var names =[];    //类别数组（实际用来盛放X轴坐标值）
    var nums = [];    //销量数组（实际用来盛放Y坐标值）
 
    $.ajax({
        type: "post",
        async: true,            //异步请求（同步请求将会锁住浏览器，用户其他操作必须等待请求完成才可以执行）
        url: "Category_Analysis.aspx?method=getdata",
        //url:"Handler.ashx?method=getdata",
        data: {},
        dataType: "json",        //返回数据形式为json
        success: function (result) {
            //请求成功时执行该函数内容，result即为服务器返回的json对象
            if (result) {

              // var json = $.parseJSON(result);

             //  alert(result);
              
               for (var i = 0; i < result.length; i++) {

                  // alert(result[i].name);

                   names.push(result[i].names);    //挨个取出类别并填入类别数组
                  
                }
                for (var i = 0; i < result.length; i++) {
                   nums.push(result[i].nums);    //挨个取出销量并填入销量数组
                }
                mychart.hideLoading();    //隐藏加载动画
                mychart.setOption({        //加载数据图表
                    xAxis: {
                       data: names
                    },
                    series: [{
                        // 根据名字对应到相应的系列
                        name: '反馈类型',

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