# ССЫЛКА НА ИСТОЧНИК: https://qudata.com/ml/ru/NN_Base_Torch_Graph.html

#region ПРЯМОЙ И ОБРАТНЫЕ ПРОХОДЫ

# Вычислительный граф - последовательность действий(формула) для нахождения
# значений некоторой величины

# В машинном обучении значением этой величины обычно является скалярная функция(гаусс)
# От -бесконечности до +бесконечности, но в 95% это от -1 до 1 и в 5 от -2 до +2

# Пример: функция z = x*x + sin(2y), Ее граф(x=4,y=3.14):
#
#    4                  16
# x  * => 16 !!!!!!!!!! + => z = 16
#    4                  0 
#                       !
# 2  2                  !
#    !                  !
# y  * => 6.28 sin =>!!!!

# После прохода пересчитаем по ОБРАТНОМУ проходу(правила тут:https://mathdf.com/der/ru/)
# Pz,Px,Py - производные; Gz,Gx,Gy - градиенты
# Pz = 1, т.к. Pz = Pz/Pz, поскольку она производная от самой себя(из 16 в 16)
# Px = (x^2)` = (x^2)` * x` = 2x*1 = 2x = Gx
# (x^2)` - внешняя функция, x` - внешняя
# Py = sin(2y)` = sin(2y)` * 2y` = cos(2y) * 2 * 1 = 2cos(2y) = Gy
# sin(2y)` - внешняя функция, а 2y` - внутренняя 
# Gx = 2*4 = 8; Gy = 2cos(2*3.14) = 2

#endregion

#region ПОСТРОЕНИЕ ГРАФА

import torch
from torch import tensor, empty, ones, zeros # чтобы было проще использовать
 
v  = zeros(2)                # [0. 0.]

#print(v.data)                # tensor([0.,0.]) - данные тензора (тоже, что просто v)
# grad - выдает градиент по тензору
#print(v.grad)                # None  
# grad_fn - функция к нему привела
#print(v.grad_fn)             # None
# is_leaf - является ли листом графа
#print(v.is_leaf)             # True
# requires_grad - нужен ли по нему градиент
#print(v.requires_grad)       # False

# Начало построения графа
# requares_grad - определяет будет ли вектор сразу узлом графа
# Можно настроить после построения
x = ones(2, requires_grad=True)         # сразу объявляется узлом
#print(x)                # tensor([ 1. 1. ],, requires_grad=True)
y = empty(2).fill_(3)                   # создание вектора
y.requires_grad = True                  # объявление его узлом
#print(y)                # tensor([3., 3.], requires_grad=True)

# Заразность узлов: если хоты бы один узел requares_grad=true, то 
# другие тоже станут такими
# [3. 3.] * [3. 3.] => [9. 9.].sum() = 18
z = (y*y).sum()                          # 18.

# grad_fn=<SumBackward0> - означает что в обратном проходе используется sum()
#print(z)                                 # tensor(18., grad_fn=<SumBackward0>)
# z не является листом графа, поскольку он корневой граф
#print(y.is_leaf, z.is_leaf)              # True False
# y не имеет функции обратного прохода, т.к. сам y не участвовал в нем(только z)
#print(y.requires_grad, y.grad_fn)        # True None
# z заразилась у y requires_grad = True из-за того что участвовала в операции
#print(z.requires_grad, z.grad_fn)        # True <SumBackward0>

#endregion

#region ВЫЧИСЛЕНИЕ ГРАДИЕНТОВ

y = empty(2).fill_(3)   #[3 3]
y.requires_grad = True
z = (y*y).sum() 

# backward - запускает процедуру вычисления градиентов в листовых(is_leaf) узлах,
# где requires_grad = true
#print(y.grad)       # None
z.backward()
#        [3  3]    [1 1]     1
# [3 3]y    *    => sum =>   z
#        [3  3]
# (y*y).sum()` = (y^2).sum()` = 2y`(x^n = nx^n-1) = 2y` и 2y`(два значения в y)
# 2y 2y = [2*3, 2*3] = [6. 6.] - Gz
#print(z.requires_grad)
# y имеет два значения градиента - это случилось потому, что y = [3 3] и каждая
# его переменная представляется одним узлом(в обратном проходе)
#print(y.grad)       # tensor([6. 6.])

# retain_graph - сохраняет вычислительный граф после вызова backward, 
# если нужно несколько раз вычислить градиенты для одной и той же функции
y2 = empty(2).fill_(3)   #[3 3]
y2.requires_grad = True
z2 = (y2*y2).sum()
z2.backward(retain_graph = True)
z2.backward(retain_graph = True)
#print(y2.grad)

# a - является константой c requires_grad=False по умолчанию,
# поэтому по ней градиент не вычисляется
x = ones(1, requires_grad=True)
a = tensor(-4.)                 # tensor([-4.], requires_grad=False)
z = 8*x + a
#
#     <=8 <=1 <=1
# 1 x=> *=> +=> 2
#       !   !
#       8   a
#          -4
#
# 8*x` + a` = 8*x` (a` - константа) = 8*1 (x=1) = 8 - Gx
z.backward()
#print(x, x.grad)         # tensor([1.], requires_grad=True), tensor([8.])
#print(a, a.grad)         # tensor([-4.]), None
# grad_fn=<AddBackward0> - функция связанная со сложением(+)
#print(z)                 # tensor([4.], grad_fn=<AddBackward0>)

#endregion

#region ГРАДИЕНТ В ПРОМЕЖУТОЧНЫХ УЗЛАХ

# retain_grid - заставляет хранить в себе прошедшие через него градиенты
# y в данном случае является промежуточной

x = tensor(2., requires_grad=True)

y  = x**2;    y.retain_grad()   # 2^2 = 4       
z  = 2*y;     z.retain_grad()   # 2*4 = 8    

# Gz = 1 - т.к. производная от самой себя
# Gy = 2*y` = 2 (x` = 1) - промежуточная
# Gx = 2*x^2` = 2*2x (x^n` = nx^n-1) = 2*2*2 = 8 - полная функция
z.backward()

#print(z.item(),     y.item(),     x.item())      # 8.0 4.0 2.0
#print(z.grad.item(),y.grad.item(),x.grad.item()) # 1.0 2.0 8.0

#endregion

#region ПРИОСТАНОВКА ПОСТРОЕНИЯ ГРАФА

# В цикле граф будет строиться заново при повторно вычислении градиентов
for i in range(1,3):
    x = empty(2).fill_(i).requires_grad_(True)  # [1 1] и [2 2]
     
    z = x.dot(x) # [1 1] @ [1 1] = [1 1]; [2 2] @ [2 2] = [4 4]
    
    # Для первого случая: 
    # Gz = 1
    # Gx = 1^2` + 1^2` (x^n` = nx^n-1) = 2*1+2*1 = [2 2]
    # Для второго случая:
    # Gz = 1
    # Gx = 2^2` + 2^2` = 2*2 + 2*2 = [4 4]
    z.backward()
    
    #print(z.item(), x.grad)
    
# no_grad - помогает изменить значение тензора не меняя графа
# x определяется только один раз(в случае с большими тензорами это очень важно)
# Иначе будет долго определять память в цикле и это не хорошо
x = empty(2).requires_grad_(True)          # [v v]

for i in range(1,3):
    with torch.no_grad():                  # отключение grad
        x.fill_(i)                         # изменение без графа
         
    z = x.dot(x)
    z.backward()                          
    
    # numpy - показывает тензор как в Numpy
    #print(z.item(), x.grad.numpy())    
    
    # zero_ - обнуляет градиенты(делаем чтобы дальше работать с x и z)
    x.grad.zero_()

# data - если изменять напрямую из нее то граф также не будет изменяться
x = empty(2).requires_grad_(True)          # [v v]

for i in range(1,3):
    x.data.fill_(i)                         # изменение без графа
         
    z = x.dot(x)
    z.backward()                          
    
    # numpy - показывает тензор как в Numpy
    #print(z.item(), x.grad.numpy())    
    
    # zero_ - обнуляет градиенты(делаем чтобы дальше работать с x и z)
    x.grad.zero_()

# enable_grad - включает изменение графа
x = ones(1, requires_grad=True)             # true
with torch.no_grad():                       # отключаем построение графа
    z1 = 2 * x                              # false
    with torch.enable_grad():               # включаем  построение графа 
        z2 = 2 * x                          # true
#print(x.requires_grad, z1.requires_grad, z2.requires_grad)  # True False True

#endregion

#region ОТСОЕДИНЕНИЕ УЗЛА ОТ ГРАФА

# detach - на выходе выводит тензор графа, который будет иметь на него ссылку
x = tensor([1.,2.], requires_grad=True)     # tensor([1., 2.], requires_grad=True)
y = x.detach()                              # tensor([1., 2.])           
         
y[0]=5          # значени присваиваеться x и y
#print(y,x)      # tensor([5., 2.]) и tensor([5., 2.], requires_grad=True)

# По сути при помощи detach можно изменять значения тензора графа без изменения графа
x  = empty(2).requires_grad_(True)
xd = x.detach()
  
for i in range(1,3):
    xd.fill_(i)
          
    z = x.dot(x)                   # начинаем строить граф
    z.backward()                   # вычислительный граф
      
    #print(z.item(), x.grad)
      
    x.grad.zero_()                 # обнуляем градиенты

#endregion

#region ПРИМЕРЫ

# clone - создает независимую копию без ссылки

x  = tensor(3.).requires_grad_(True)   #   x.grad y.grad  y.requires_grad
y  = tensor(3.).requires_grad_(True)   # A:  1    6       True  
#y = x                                 # B:  7    7       True  
#y = tensor(1.)                        # C:  1    None    False 
#y = x.detach().clone()                # D:  1    None    False
y = x.clone()                         # E:  7    None    True, grad_fn=<CloneBackward>

z = x + y*y                            # z = 12

# Gz = 1 во всех случаях
# Первый пример: x = [3.] y = [3.]
# Gx = x` = 0 - т.к. константа, не влияющая на y
# Gy = x` + y^2` = 0 + 2y = 2*3 = 6
# Второй пример(Если x=y, то это создает между ними зависимость друг от друга):
# Gx = x` + x^2` = 1 + 2x = 1+2*3 = 7
# Gy = y` + y^2` = 1 + 2y = 7
# Третий пример:
# Gx = 1
# Gy - нет т.к. requires_grad не был определен
# Четвертый пример:
# Gx = 1
# Gy  - нет т.к. detach выбрал тензор с requires_grad=false и после его клонировал
# Пятый пример:
# Gx = x`+ y^2` = 1 + 2y = 7
# Gy - нет т.к. y - константа из-за x.clone(), которые передал тензор 
z.backward() 
#print(x.grad, y.grad, y.requires_grad)

# clone - клонирует тензор с requires_grad клонируемого тензора, 
# иногда это может мешать, как тут:
# <CloneBackward> - указывает на обратную функцию clone()
x = torch.ones(1, requires_grad=True)
                               # y.requires_grad:  y.grad_fn:
with torch.no_grad():          
    y = x.clone()              # False             None
y = x.detach().clone()         # False             None
y = x.clone()                  # True              <CloneBackward>

#print(y)

#endregion

#region ЧТО НЕЛЬЗЯ ДЕЛАТЬ С ПЕРЕМЕННЫМИ ТЕНЗОРА

# Все методы с _ не создают новые переменные,
# а работают с той памятью, которая выделена
# Ограничением для графов является использхование in-place методов (когда
# значение перезаписывается на ту же память)
x = ones(1);    #print(x, id(x))   # tensor([1.]) 2769629314008
 
x += 1;         #print(x, id(x))   # tensor([2.]) 2769629314008   in-place
x.add_(1);      #print(x, id(x))   # tensor([3.]) 2769629314008   in-place
x = x + 1;      #print(x, id(x))   # tensor([4.]) 2769629311928   non in-place

# Следующий код вызовет ошибку, т.к. использовалась in-place операция
x = tensor(1., requires_grad=True)
#x += 1                             # a leaf Variable...

# То же самое будет если передавать ссылки между значениями с requires_grad=True
# т.к. они его передают
x = tensor(1.,requires_grad=True)
#print(x,id(x))      # tensor(1.,requires_grad=True) ...95208
y = x
#print(y,id(y))      # tensor(1.,requires_grad=True) ...95208
#y *= 1              # Ошибка

# НО если y не листовый узел(функция) то in-place можно:
x = tensor(1.,requires_grad=True)   # x.grad = tensor(0.5)
y = 2*x                             # tensor(2.,     grad_fn=<MulBackward0>)
y += 2                              # tensor(4.,     grad_fn=<AddBackward0>)
y.log_()                            # tensor(1.3863, grad_fn=<LogBackward> )

# Gy = 1
# Gx = log(2*x+2)` = 1/(2*x+2)`*ln(1)` = 1/(2x+2)*1 = 1/2+2 = 1/4
y.backward()                        # y = log(2*x+2); y'=1/(x+1)
print(x.grad)

#endregion

#region



#endregion

#region



#endregion