#ФУНКЦИИ DEF , LAMBDA , RETURN :
#ФУНКЦИИ ИСПОЛЬЗУЮТ ВСЕ ТИПЫ ДАННЫХ

def a(x,o):#DEF-ЭТО СОЗДАЁТ ФУНКЦИЮ,МОЖНО ВСЁ,ЧТО ХОЧЕШЬ ПИСАТЬ И СОЗДАВАТЬ(СЛО-
    return x+o#ВАРИ И Т.Д);RETURN-ВОЗВРАЩАЕТ ЗНАЧЕНИЕ,КОТОРОЕ СТОИТ ПОСЛЕ НЕГО
print(a(23,12))#В СКОБКАХ НУЖНО ПИСАТЬ ЗНАЧЕНИЯ ЗНАЧЕНИЙ A (X,O)
print()

def r(k,j):#СОЗДАЁМ ФУНКЦИЮ С ЗНАЧЕНИЯМИ 
    return k+j#СКЛАДЫВАЕМ ИХ ПРИ ЭТОМ МОЖНО СКЛАДЫВАТЬ ЦЕЛЫЕ СТРОКИ(ПОЛЬЗОВАТЬСЯ
print(r("di","ck"))#ПРАВИЛАМИ ТИПОВ ДАННЫХ
print()

def h(g,b):#СОЗДАЁМ ФУНКЦИЮ
    ru=g+b#МОЖНО ПИСАТЬ ОЧЕНЬ МНОГО РАЗЛИЧНЫХ ОПЕРАЦИЙ
    return ru#ВЫВОДИМ ТО,ЧТО ПОЛУЧИЛОСЬ
print(h("Я"," русский"))
print()

#ФУНКЦИЯ В ФУНКЦИИ :

def pop(f):#ДОБАВЛЯЕМ ФУНКЦИЮ POP С ЗНАЧЕНИЕМ F
    def add(n):#ADD-НОВАЯ ПЕРЕМЕННАЯ ФУНКЦИИ,КОТОРАЯ ДОБАВЛЕНА ДЛЯ ТОГО,ЧТОБЫ НА-
        return n+f#ПИСАТЬ ПОДФУНКЦИЮ
    return add#ВЫВОДИТ ЗНАЧЕНИЕ ФУНЦИИ ADD,КОТОРОЕ РАВНО A+N
test = pop(100)#ЭТО НУЖНО ДЛЯ ДОБАВЛЕНИЯ ЗНАЧЕНИЯ N В ADD    
print(test(200))#TEST РАВНО POP,ТО СЛЕДУЩЕЕ ЗНАЧЕНИЕ(КОТОРОЕ N) РАВНО ЭТОМУ
#TEST ДОБАВЛЯЮТ ПОТОМУ ЧТО ОНА ДАЁТ СЛЕДУЩЕЕ ЗНАЧЕНИЕ ДЛЯ ПЕРЕМЕННОЙ POP,КОТОРОЕ
#НАЗЫВАЕТСЯ В ДАННОМ СЛУЧАЕ N
print()
#ИНАЧЕ ЭТО ВЫГЛЯДИТ ТАК(БЕЗ ПЕРЕМЕННОЙ ADD) :

def POP(F,N):#ДОБАВЛЯЕМ К POP ЗНАЧЕНИЕ N
    return F+N#ПИШЕМ ОСНОВУ ОСНОВ
print(POP(100,200))#ДАЁМ ЗНАЧЕНИЯ F И N
print()

#ЧТО МОГУТ ИСПОЛЬЗОВАТЬ ПРОГРАМИСТЫ:

def B():#СОЗДАЁМ ПУСТОЕ ЗНАЧЕНИЕ,НО ВОПРОС:ДЛЯ ЧЕГО?
    pass#PASS-НЕКОТОРЫЕ ПРОГРАМИСТЫ ТАК ПОМЕЧАЮТ ТО,ЧТО НУЖНО ДОРАБОТАТЬ
print(B())#ВЫДАСТ NONE,НА ЧТО СРАЗУ ЖЕ ОТЛИКАЕТСЯ ПРОГРАМИСТ
print()

#ЗНАЧЕНИЕ ПО УМОЛЧАНИЮ:
#ОШИБКА:МОЖЕТ ВОЗНИКНУТЬ В РЕЗУЛЬТАТЕ ВВОДА ПЕРЕМЕННОЙ ВНАЧАЛЕ (В СКОБКАХ)
#РЕШЕНИЕ ОШИБКИ:НУЖНО ПИСАТЬ ЗНАЧЕНИЯ ПЕРЕМЕННЫХ ПО УМОЛЧАНИЮ В КОНЦЕ

def orda(i,q,z=3):#Z=3 - ЭТО ЗНАЧЕНИЕ ПО УМОЛЧАНИЮ,КОТОРОЕ МОЖНО ИЗМЕНЯТЬ 
    jo=i+q#СОЗДАЁМ ДРУГУЮ ПЕРЕМЕННУЮ
    jo**=z#ВОЗВОДИМ В СТЕПЕНЬ (ПО УМОЛЧАНИЮ НА 3)
    return jo#ВЫВОДИМ НОВОЕ ЗНАЧЕНИЕ
print(orda(2,3))#ТУТ МОЖНО МЕНЯТЬ ЗНАЧЕНИЕ Z
print()

#КАК ДОБАВЛЯТЬ МНОГО ЗНАЧЕНИЙ,КОТОРЫЕ БУДУТ ПРЕВРАЩАТЬСЯ В КОРТЕЖ,СЛОВАРЬ:
#ДЛЯ ВСЕХ ФУНКЦИЙ ЭТИ СПОСОБЫ ОДИНАКОВЫ(DIF И  LAMMDA)

def volva(*args):#ФУНКЦИЯ VOLVA В КОТОРОЙ * - ОЗНАЧАЕТ СОЗДАНИЕ КОРТЕЖА
    return args #БУДЕТ ВЫВОДИТЬ КОРТЕЖ
print(volva(8,9,10,"88"))#СЮДА МОЖНО ДОБАВЛЯТЬ МНОГО ЗНАЧЕНИЙ 
print()

def rio(**args):#ФУНКЦИЯ RIO В КОТОРОЙ ** - ОЗНАЧАЕТ СОЗДАНИЕ СЛОВАРЯ,В КОТОРЫЙ 
    return args#МОЖНО ПИСАТЬ МНОГО ЗНАЧЕНИЙ
print(rio(Имя='Вася',Фамилия='Рог',n=56))#В КЛЮЧЕ ПИШУТСЯ ТОЛЬКО БУКВЫ(НЕ ЦИФРЫ)
print()

#ФУНКЦИЯ LAMBDA:
#НЕТ СЛОВА RETURN!!!

uro= lambda x,y:x*y#LAMBDA-ОТЛИЧАЕТСЯ ОТ DEF ТЕМ,ЧТО ЗАПИСЫВАЕТСЯ В ОДНУ СТРОЧКУ
print(uro(2,2))#ПРИНЦИП НАПИСАНИЯ ТОТ ЖЕ
print(uro('ra',5))#ЛЮБЫЕ ФУНКЦИИ МОЖНО ИСПОЛЬЗОВАТЬ НЕСКОЛЬКО РАЗ В РАЗНЫХ ТИПАХ
print()#ДАННЫХ (НО! СМОТРИТЕ НА ТО,ЧТО ДЕЛАЮТ С ПЕРЕМЕНЫМИ ИНАЧЕ ВОЗМОЖНА ОШИБКА)

print((lambda s,w:s+w)(5,6))#ФУНКЦИЮ LAMBDA МОЖНО ЗАПИСЫВАТЬ В PRINT ПРИ ЭТОМ 
print()#ПОСЛЕ ЕЁ СКОБОК ИДУТ СКОБКИ ЕЁ ЗНАЧЕНИЙ 
























