#coding=utf-8


import os

import xlrd
import jieba
import pymysql
import matplotlib.pylab as plt
from wordcloud import WordCloud
from collections import Counter
import numpy as np
import collections


import sys #这里只是一个对sys的引用，只能reload才能进行重新加载
stdi,stdo,stde=sys.stdin,sys.stdout,sys.stderr 
reload(sys) #通过import引用进来时,setdefaultencoding函数在被系统调用后被删除了，所以必须reload一次
sys.stdin,sys.stdout,sys.stderr=stdi,stdo,stde 
sys.setdefaultencoding('utf-8')

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

    seg_list = " ".join(jieba.cut(txt)) #seg_list为str类型

    #seg_list = jieba.cut(txt)
    document_after_segment = open('C:/Users/Weijie/Desktop/分词结果.txt'.decode('utf-8'), 'w+')
    document_after_segment.write(seg_list)
    document_after_segment.close()

    return seg_list
   


   

 


   # new_report(test_report)
    # return file_new
    

if __name__ == '__main__':
    test_report="C:/Users/Weijie/Desktop/ceshi1"#目录地址
    #new_report(test_report)
    path_test=new_report(test_report)
    txt = ''
    segment_list = getExcelData(path_test,txt)
    #makeWordCloud(getExcelData('C:/Users/Weijie/Desktop/ceshi1/1小游戏归类3.14.xlsx', txt))
    
    

