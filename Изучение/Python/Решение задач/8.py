#ДВУМЕРНЫЕ МАССИВЫ

#1.
#МАКСИМУМ
#Найдите индексы первого вхождения максимального элемента. Выведите два числа:
#номер строки и номер столбца, в которых стоит наибольший элемент в двумерном
#массиве. Если таких элементов несколько, то выводится тот, у которого меньше
#номер строки, а если номера строк равны то тот, у которого меньше номер столбца.

n,m=1,1
a=[[int(j) for j in input().split()] for i in range(n)]
b=a[0][0]
for i in range(n):
    for l in range(m):
        if a[i][l]>b:
            b=a[i][l]
            c,d=i,l
        else:c,d=i,l
print(c,d,'\n')

#2.
#Снежинка
#Дано нечетное число n. Создайте двумерный массив из n×n элементов, заполнив
#его символами "." (каждый элемент массива является строкой из одного символа).
#Затем заполните символами "*" среднюю строку массива, средний столбец массива,
#главную диагональ и побочную диагональ. В результате единицы в массиве должны
#образовывать изображение звездочки. Выведите полученный массив на экран,
#разделяя элементы массива пробелами.

n=11
a=[['.']*n for i in range(n)]
for i in range(n):
    a[i][n-i-1]='*'
    a[i][i]='*'
    a[i][int((n-1)/2)]='*'
    a[int((n-1)/2)][i]='*'
for i in a:
        print(' '.join([l for l in i]))
print()

#3.
#Шахматная доска
#Даны два числа n и m. Создайте двумерный массив размером n×m и заполните 
#его символами "." и "*" в шахматном порядке. В левом верхнем углу должна 
#стоять точка.

n,m=6,8
a=[['.']*m for i in range(n)] 
for i in range(n):
    for l in range(1,m,2):
        a[i][l-i]='*'
for i in a:
    print(' '.join([str(l) for l in i]))
print()

#4.
#Диагонали, параллельные главной
#Дано число n. Создайте массив размером n×n и заполните его по следующему 
#правилу. На главной диагонали должны быть записаны числа 0. На двух диагоналях,
#прилегающих к главной, числа 1. На следующих двух диагоналях числа 2, и т.д.

n=4
a=[[abs(i-l) for l in range(n)] for i in range(n)]
for i in a:
    print(' '.join([str(l) for l in i]))
print()

#5.
#ПОБОЧНАЯ ДИАГОНАЛЬ
#Дано число n. Создайте массив размером n×n и заполните его по следующему правилу:
#Числа на диагонали, идущей из правого верхнего в левый нижний угол равны 1.
#Числа, стоящие выше этой диагонали, равны 0.
#Числа, стоящие выше этой диагонали, равны 2.
#Полученный массив выведите на экран. Числа в строке разделяйте одним пробелом.

n=7
a=[0]*n
a=[[0]*(n-1-i)+[1]+[2]*abs((1+(n-1-i))-n) for i in range(n)]
for i in a:
    print(' '.join([str(l) for l in i]))
print()

#6.
#ПОМЕНЯТЬ СТОЛБЦЫ
#Дан двумерный массив и два числа: i и j. Поменяйте в массиве столбцы с
#номерами i и j и выведите результат.
#Программа получает на вход размеры массива n и m, затем элементы массива, 
#затем числа i и j.
#Решение оформите в виде функции swap_columns(a, i, j).

def swamp_columns(a,i,j):
    for k in range(len(a)):
        a[k][i],a[k][j]=a[k][j],a[k][i]
n,m=[int(i) for i in input().split()]
a=[[int(j) for j in input().split()] for i in range(n)]
i,j=[int(i) for i in input().split()]
swamp_columns(a,i,j)
print('\n'.join([' '.join([str(i) for i in row]) for row in a]))
































        
