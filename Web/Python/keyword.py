#获取反馈文本分词和去除停用词、直方图、自定义词典、生成词云
import os
from collections import Counter
import jieba
jieba.load_userdict("D:/Python/jieba-0.39/jieba/dict2.txt")
import pymysql
import matplotlib.pylab as plt
from wordcloud import WordCloud
import numpy as np
import codecs


from pylab import mpl

mpl.rcParams['font.sans-serif'] = ['FangSong']  # 指定默认字体
mpl.rcParams['axes.unicode_minus'] = False  # 解决保存图像是负号'-'显示为方块的问题
plt.rcParams['font.sans-serif'] = ['SimHei']

stopword=[u'。',u',',u'，',u'(',u')',u'"',u':',u';',u'、',u',',u'，',u'”',u'“',u'；',u'：',u'的',u'有',u'也']
word = []
counter = {}




# jieba.load_userdict('userdict.txt')
# 创建停用词list
def stopwordslist(filepath):
    stopwords = [line.strip() for line in open(filepath, 'r',encoding='utf-8').readlines()]
    return stopwords
 
 
# 对句子进行分词
def seg_sentence(sentence):
    sentence_seged = jieba.cut(sentence.strip())
    stopwords = stopwordslist('D:/Python/jieba-0.39/jieba/stopwords.txt')
    # 这里加载停用词的路径
    outstr = ''
    for word in sentence_seged:
        if word not in stopwords:
            if word != '\t':
                outstr += word
                outstr += " "
    return outstr
 

def new_report(test_report):
    lists = os.listdir(test_report)                                    #列出目录的下所有文件和文件夹保存到lists
    print(list)
    lists.sort(key=lambda fn:os.path.getmtime(test_report + "\\" + fn))#按时间排序
    file_new = os.path.join(test_report,lists[-1])                     #获取最新的文件保存到file_new
    print(file_new)
    return file_new

test_report="C:/Users/Weijie/Downloads"#目录地址
path_txt=new_report(test_report)
 
inputs = open(path_txt, 'r',encoding='gb2312') #加载要处理的文件的路径
outputs = open('./001.txt', 'w') #加载处理后的文件路径
for line in inputs:
    line_seg = seg_sentence(line)  # 这里的返回值是字符串
    outputs.write(line_seg)

outputs.close()
inputs.close()


text = open('./001.txt').read()
x, y = np.ogrid[:300, :400]
mask = (x - 150) ** 2 + (y - 150) ** 2 > 150 ** 2
mask = 255 * mask.astype(int)
my_wordcloud = WordCloud(background_color="white",
                         mask=mask,#圆形
                         width=1000,
                         height=860,
                         scale=5,
                         font_path="C:\Windows\Fonts\STXINGKA.TTF").generate(text)
my_wordcloud.to_file('../Images/wordcloud.png')







with codecs.open('./001.txt',encoding='gb2312')as fr:
    for line in fr:
        line = line.strip()
        #print type(line)
        if len(line) == 0:
            continue
        line = jieba.cut(line, cut_all = False)
        for w in line:#.decode('utf-8'):
            if ( w in stopword) or len(w)==1: continue
            if not w in word :
                word.append(w)
            if not w in counter:
                counter[w] = 0
            else:
                counter[w] += 1

counter_list = sorted(counter.items(), key=lambda x: x[1], reverse=True)

print(counter_list[:50])
#for i,j in counter_list[:50]:print i

label = list(map(lambda x: x[0], counter_list[:15]))
value = list(map(lambda y: y[1], counter_list[:15]))

plt.bar(range(len(value)), value, tick_label=label)
plt.savefig('../Images/number_1.png')


