#КОРТЕЖИ:
#КОРТЕЖ-ЭТО ТОТ ЖЕ СПИСОК,НО КОТОРЫЙ НЕЛЬЗЯ ИЗМЕНИТЬ;СПОЛЬЗУЕТСЯ ДЛЯ ТОГО,ЧТОБЫ
#ОСВОБОДИТЬ БОЛЬШЕ МЕСТА(ОНИ МЕНЬШЕ ВЕСЯТ)ИЛИ ДРУГИЕ НЕ ИЗМЕНЯЛИ ИХ НАМЕРЕНО;ВСЕ
#ФУНКЦИИ К СПИСКАМ ТАКЖЕ РАБОТАЮТ,НЕ СЧИТАЯ ДОБАВЛЕНИЯ,УДАЛЕНИЯ,ПЕРЕМЕНЫ МЕСТ

l=(34,54.45)#L-КОРТЕЖ
#L[0]=56 - БУДЕТ НЕВЕРНО ИЛИ ОШИБКА,Т.К КОРТЕЖИ НЕ ИЗМЕНЯЮТСЯ(ДЕЛО НЕ В СКОБКАХ)

b=[34,54.45]#B-СПИСОК

print(l.__sizeof__())#SIZEOFF-ОПРЕДЕЛЯЕТ КОЛИЧЕСТВО БАЙТ В СПИСКЕ ИЛИ ДРУГОМ 
print(b.__sizeof__())#ЗНАЧЕНИИ (В БАЙТАХ )

i=tuple('hello world')#TUPLE-КОМАНДА СОЗДАЁТ СПИСОК ИЗ КАЖДОГО СИМВОЛА В СТРОЧКЕ
print(i)#КОТОРЫЕ НЕЛЬЗЯ МЕНЯТЬ
print()

i=('hello world')#ИНАЧЕ ПОЛУЧИТСЯ ТАК,ЧТО БУДЕТ ПИСАТЬСЯ СТРОКА ,КА ПОЛНОЦЕННОЕ
print(i)#ПРЕДЛОЖЕНИЕ(ТАКЖЕ МОЖНО ПИСАТЬ БЕЗ СКОБОК,БУДЕТ ТОЖЕ САМОЕ)

i='hello world',45,'ty',34#ЭТО УЖЕ БУДЕТ КОРТЕЖ,Т.К ТАМ ПРИСУТСТВУЮТ ",",КОТОРЫЕ
print(i)#ДУМАЮТ,ЧТО ТЫ ОПУСТИЛ СКОБКИ И НАПИСАЛ КОРТЁЖ9МОЖНО СО СКОБКАМИ ПИСАТЬ)
