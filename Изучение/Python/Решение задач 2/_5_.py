#МОЖНО ИСПОЛЬЗОВАТЬ РАЗНЫЕ КОМАНДЫ ПО ИЗМЕНЕНИЮ ЗНАЧЕНИЯ!!

i = 0  #вводим переменную
while i < 10 :#while(пока)-если значение верно,то выполнить:
    print(i) #напечатает множество i , пока i<10
    i +=2 #каждое значение изменяет (кроме 1)
print()

i =1000  #вводим переменную
while i > 100 :#while(пока)-если значение верно,то выполнить:
    print(i) #напечатает множество i , пока i>100
    i /=2 #каждое значение изменяет (кроме 1)
print()
#FOR(ДЛЯ)-ВЫПОЛНЯЕТ ДЕЙСТВИЕ ДЛЯ ПЕРЕМЕННОЙ    

for g in 'MINECRAFT': #in - говорит в каком выражении g ( что значит переменная)
    print(g * 2 , end = '') #g*2-умножает каждую букву на 2
print()    
print() #пишем 2 пропуска строки,т.к 1 print не действует

#end='' - без неё каждая умноженная буква будет в своей строке :

for g in 'MINECRAFT':
    print(g * 2)
print()

#можно делать вывиски :
for g in 'MINECRAFT':
    print(g * 1)
print()

#ОПЕРАТОРА В ЦИКЛАХ  :
    
#FOR (continue) :
    
for g in 'MINECRAFT':#МОЖНО ИСПОЛЬЗОВАТЬ IF,G=='I'-ЗНАЧИТ БУДЕТ ИСПОЛЬЗОВАТЬ 
    if g=='I':#ТОЛЬКО ЭТОТ СИМВОЛ(С КАПСОМ ИЛИ БЕЗ) УЧИТЫВАЕТСЯ
        continue #continue-пропускает значение и действует дальше
    print(g * 2 , end = '') #будет использованы все буквы,кроме 'I'
print()
print()

#while(continue)- не написал,т.к оно бесконечное (мешает следующим примерам):

#y=1000 #ввод y
#while y>100: #пока y>100 -> y/5
#    if y==200 : #если y=200,то дальше не выполнять
#        continue #continue-пропускает значение и действует дальше
#    print(y) #будет бесконечно писать,что не вызовет строки писания в основе
#    y /=5 #дествие для значения
print()

#FOR (break) :

for g in 'MINECRAFT':
    if g=='I':#ТОЛЬКО ЭТОТ СИМВОЛ(С КАПСОМ ИЛИ БЕЗ) УЧИТЫВАЕТСЯ
        break #break-выходит из цыкла,когда находит значение
    print(g * 2 , end = '') #после значения 'I' это не будет выполняться 
print()
print()

#while(break) :

h=1000           #ввод переменой
while h>1000:    #пока h>1000,то выполнить действие
      if h==200:#если h=200 ,то цикл прекращается
        break  #break-выходит из цыкла,когда находит значение
      print(h)   #выводит значение h
      h /=5      #действует только когда h>1000 и когда h>200
print()

#else - можно употреблять после if в начале строки

for n in 'MINECRAFT\n':
    if n == 'w': #ТОЛЬКО ЭТОТ СИМВОЛ(С КАПСОМ ИЛИ БЕЗ) УЧИТЫВАЕТСЯ
        break #break-выходит из цыкла,когда находит значение
    print(n * 2 , end = '')
else: #else - выводиться когда не выполняется break или любая другая команда
       print('НИЧЕГО НЕ НАЙДЕНО') #print выводит текст сразу после 'MINECRAFT' 
















