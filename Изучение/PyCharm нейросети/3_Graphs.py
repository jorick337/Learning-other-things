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
#print(v.grad)                # None            - градиент по тензору (пока его нет)
#print(v.grad_fn)             # None            - функция к нему привела (пока нет графа)
#print(v.is_leaf)             # True            - является листом графа (да)
#print(v.requires_grad)       # False           - по нему нужен градиент (пока не нужен)

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
  
print(z)                                 # tensor(18., grad_fn=<SumBackward0>)
print(y.is_leaf, z.is_leaf)              # True False
print(y.requires_grad, y.grad_fn)        # True None
print(z.requires_grad, z.grad_fn)        # True <SumBackward0>


#endregion

#region



#endregion

#region



#endregion