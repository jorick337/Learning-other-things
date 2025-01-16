#КОНСТРУКТОР-ЭТО,КОГДА ПРИ СОЗДАНИИ ОБЬЕКТА МЫ ЗАДАЁМ ЕМУ ХАРАКТЕРИСТИКИ:
#ОБЬЕКТ В KLASS-ЭТО НЕПОСРЕДСТВЕННО САМО ЗНАЧЕНИЕ НОВОЙ ПЕРЕМЕННОЙ(KOSTY,JORA)
#ПОЛЕ-ОДНА ИЗ ХАРАКТЕРИСТИК ОБЬЕКТА

class Person:#СОЗДАЁМ КЛАСС PERSON
    name="Иван"#ДОБАВЛЯЕМ ПОЛЕ NAME
    age=12#ДОБАВЛЯЕМ ПОЛЕ AGE
    
    def __init__(self,name,age):#__INIT__ - КОМАНДА,КОТОРАЯ ДАЁТ ВОЗМОЖНОСТЬ НА 
        self.name=name#ДОБАВЛЕНИЯ ЗНАЧЕНИЯ ПОЛЯ В ДОБАВЛЕНИИ НОВОГО ЗНАЧЕНИЯ В 
        self.age=age#ОБЬЕКТЕ:

kosty=Person("Костя",16)#ЗАПИСАЛИИ БЫСТРО ЗНАЧЕНИЯ НОВОГО ПАРАМЕТРА
print(kosty.name+" "+str(kosty.age))#НАПИСАЛИ НА ЭКРАН,ТО ЧТО ДОБАВИЛИ(ПРОВЕРКА)
print()

#ПЕРЕОПРЕДЕЛЕНИЕ МЕТОДОВ-ЭТО КОГДА ПРИ ДОБАВЛЕНИИ КЛАССА В ДРУГОЙ КЛАСС МОЖНО
#ЧЕРЕЗ SET БЫСТРО НАПИСАТЬ ВСЕ ЗНАЧЕНИЯ ИЗ ДВУХ КЛАССОВ,НО:

class game:#СОЗДАЁМ КЛАСС 
    strateg="cicilisation 6 "#СОЗДАЁМ ПОЛЕ
    strelalka="cs:go"#СОЗДАЁМ ПОЛЕ
    def set(self,strateg,strelalka):#ФУНКЦИЯ С SET ДЛЯ УПРОЩЕНИЯ РАБОТЫ С КЛАС0М
        self.strateg=strateg
        self.strelalka=strelalka

kosty=game()#ДОБАВЛЯЕМ ОБЬЕКТ В КЛАСС
kosty.set("minecraft","doom")#ПИШЕМ ЕМУ ЗНАЧЕНИЯ
print(kosty.strateg+" "+kosty.strelalka)#ВЫВОДИМ ЕГО ЗНАЧЕНИЯ
print()

class minut(game):#СОЗДАЁМ НОВЫЙ КЛАСС,В КОТОРОМ РАБОТАЮТ ТЕЖЕ ФУНКЦИИ,ЧТО И В
    logic=45#GAME;ДОБАВЛЯЕМ НОВОЕ ПОЛЕ
    shuter=67#ДОБАВЛЯЕМ НОВОЕ ПОЛЕ
    def set(self,strateg,strelalka,logic,shuter):#В SET ЗАПИСЫВАЕМ НОВЫЕ ЗНАЧЕНИЯ
        self.strateg=strateg
        self.strelalka=strelalka
        self.logic=logic#ЗАПИСЫВАЕМ ТАКЖЕ НОВЫЕ ПОЛЯ ДЛЯ ЗАПОЛНЕНИЯ,КОТОРЫЕ МО- 
        self.shuter=shuter#ЖЕМ ЗАПИСЫВАТЬ В УДОБНОМ РЕЖИМЕ

jorj=minut()#ДАННЫЙ ОБЬЕКТ ТЕПЕРЬ МОЖЕТ ИСПОЛЬЗОВАТЬ SET,КОТОРЫЙ МОЖЕТ ДОБАВЛЯТЬ
jorj.set("wow","fortnite",45,56)#ЗНАЧЕНИЯ ИЗ ДРУГОГО КЛАССА
print(jorj.strateg+" "+str(jorj.logic)+" "+jorj.strelalka+" "+str(jorj.shuter))




















        

