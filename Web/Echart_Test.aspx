<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Echart_Test.aspx.cs" Inherits="UserFB.Web.Echart_Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>图表</title>
       <script src="Echarts/echarts.min.js"></script>
     <script src="../bootstrap/vendor/jquery/jquery.min.js"></script>
    <script src="Echarts/macarons.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
   <div id="main" style="width: 600px;height:400px;"></div>
    <script type="text/javascript">
    var mychart = echarts.init(document.getElementById('main'), 'macarons');
    mychart.setOption({
        title: {
            text: '异步加载数据示例'
        },
        tooltip: {},
        legend: {
            data: ['销量']
        },
        xAxis: {
            data: []
        },
        yAxis: {},
        series: [{
            name: '销量',
            type: 'pie',
            radius: 60,饼图

           //  type: 'line',折线图

           //  type: 'bar',//直方图


            data: []
        }]
    });
    mychart.showLoading();
    var names =[];    //类别数组（实际用来盛放X轴坐标值）
    var nums = [];    //销量数组（实际用来盛放Y坐标值）
 
    $.ajax({
        type: "post",
        async: true,            //异步请求（同步请求将会锁住浏览器，用户其他操作必须等待请求完成才可以执行）
        url: "Echart_Test.aspx?method=getdata",
        //url:"Handler.ashx?method=getdata",
        data: {},
        dataType: "json",        //返回数据形式为json
        success: function (result) {
            //请求成功时执行该函数内容，result即为服务器返回的json对象
            if (result) {

              // var json = $.parseJSON(result);

              // alert(result);注释掉这个可以取消成功还弹出提示框的问题
              
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
                        name: '销量',
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
    </form>
</body>
</html>
