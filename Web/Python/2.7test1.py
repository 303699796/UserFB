#coding=utf-8
import os
import sys
sys.path.append("F:/weijie/UserFB/UserFB/packages/IronPython.2.7.9")


import xlrd
import jieba
import pymysql
import matplotlib.pylab as plt
from wordcloud import WordCloud
from collections import Counter
import numpy as np

def new_report(test_report):
    lists = os.listdir(test_report)                                    #列出目录的下所有文件和文件夹保存到lists
    print(list)
    lists.sort(key=lambda fn:os.path.getmtime(test_report + "\\" + fn))#按时间排序
    file_new = os.path.join(test_report,lists[-1])                     #获取最新的文件保存到file_new
    print(file_new)
    return file_new

def getExcelData(excel,txt):
    readbook = xlrd.open_workbook(excel)
    sheet = readbook.sheet_by_index(1) #取第1个sheet页
    rows = sheet.nrows
    i = 0
    while i < rows:
        txt += sheet.cell(i, 1).value #取第三列的值
        i += 1
    seg_list = jieba.cut(txt)
    c = Counter()
    result = {}
    for x in seg_list:
        if len(x) > 1 and x != '\r\n':
            c[x] += 1
    for (k, v) in c.most_common():
        result[k] = v #放到字典中，用于生成词云的源数据
    return result

    
        #new_report(test_report)
       # return file_new
    
 
 
def makeWordCloud(txt):
    x, y = np.ogrid[:300, :500]

    mask = (x - 150) ** 2 + (y - 150) ** 2 > 150 ** 2
    mask = 255 * mask.astype(int)
    backgroud_Image = plt.imread('C:/Users/Weijie/Desktop/beijing004.jpg')
    wc = WordCloud(background_color="white",
                    max_words=500,
                    #mask=mask,圆形
                   mask = backgroud_Image,
                    repeat=True,
                    width=1000,
                    height=1000,
                    scale=4, #这个数值越大，产生的图片分辨率越高，字迹越清晰
                    font_path="C:\Windows\Fonts\STXINGKA.TTF")
    wc.generate_from_frequencies(txt)
    wc.to_file('C:/Users/Weijie/Desktop/beijing005.png')

    plt.axis("off")
    plt.imshow(wc, interpolation="bilinear")
  #  plt.show()

   # new_report(test_report)
    # return file_new
def result():
    return "Hello，World！"


if __name__ == '__main__':
    test_report="C:/Users/Weijie/Desktop/ceshi1"#目录地址
    #new_report(test_report)
    path_test=new_report(test_report)
    txt = ''
    #makeWordCloud(getExcelData('C:/Users/Weijie/Desktop/ceshi1/1小游戏归类3.14.xlsx', txt))
    makeWordCloud(getExcelData(path_test, txt))
    
 