# ССЫЛКА НА ИСТОЧНИК: https://qudata.com/ml/ru/NN_Base_Torch_NN.html

#region ПОСЛЕДОВАТЕЛЬНОСТЬ СЛОЕВ

import torch
import torch.nn as nn
 
nX = 2  # вход
nH = 5  # промежуток(скрытый слой)
nY = 1  # выход

# Squential - контейнер для последовательного комбинирования слоев модели, где 
# каждый слой будет применяться по порядку к данным. Это удобный способ создания модели
modelS = nn.Sequential(
          nn.Linear(nX, nH),    # входной слой
          nn.Sigmoid(),         # активация скрытого слоя
          nn.Linear(nH, nY),    # выходной слой
          nn.Sigmoid() )        # активация выходного слоя
# То есть 2 -> 5 -> 1

#endregion

#region ФУНКЦИОНАЛЬНАЯ АРХИТЕКТУРА

# Более удобным считается создание нейроной сети в функциональном виде, наследуя
# класс nn.Module, где:
# __init__ - определяются переменные сети которые будут использоваться
# forward - тут строиться архитектура сети которая будет использоваться при этом слои
# складываются в вычислительный граф

nX = 2  # вход
nH = 5  # промежуток(скрытый слой)
nY = 1  # выход

class TwoLayersNet(nn.Module):
    def __init__(self, nX, nH, nY):        
        super(TwoLayersNet, self).__init__()     # конструктор предка с этим именем
         
        self.fc1 = nn.Linear(nX, nH)             # создаём параметры модели
        self.fc2 = nn.Linear(nH, nY)             # в полносвязных слоях

    def forward(self, x):                        # задаётся прямой проход
        x = self.fc1(x)                          # выход первого слоя
        x = nn.Sigmoid()(x)                      # активация
        x = self.fc2(x)                          # выход второго слоя
        x = nn.Sigmoid()(x)                      # активация
        return x

model = TwoLayersNet(nX, nH, nY)                    # экземпляр сети

#endregion

#region МОДЕЛЬНЫЕ ДАННЫЕ

# Создадим два класса на 2D плоскости со значениями от 0 до 1:
# X - все случайные значения
# Y - те что находяться в центре
X = torch.tensor([[0.4214, 0.2862],[0.8847, 0.3323],[0.4405, 0.6170],
                  [0.2672, 0.2194],[0.4839, 0.0361],[0.6251, 0.9900]])
# Посчитаем для одного:
# [0.4214, 0.2862] = [(0.4214 -0,5)^2 (0.2862-0,5)^2] = [0,08^2 0,22^2] = 
# [0,0064 0,0484] = [0,0548]
# [0,0548] < 0,1 == true == 1
# [0.8847, 0.3323] = [(0,8847-0,5)^2 (0,33-0,5)^2] = [0,38^2 0,17^2] = 
# [0,1444] [0,0289] = [0,1733]
# [0,1733] < 0,1 == false == 0
# Где 1 то в центре, 0 наоборот
Y = (torch.sum((X - 0.5)**2, axis=1) < 0.1).float().view(-1,1)

# matplotlib.pyplot - библиотека которая поможет нарисовать, чтобы было понятнее
import matplotlib.pyplot as plt                      

plt.figure (figsize=(5, 5))                                  # размеры (квадрат)
plt.scatter(X.numpy()[:,0], X.numpy()[:,1], c=Y.numpy()[:,0], s=30, 
            cmap=plt.cm.Paired, edgecolors='k')        
# plt.show()                                                   # выводим рисунок    

#endregion

#region ОБУЧЕННЫЕ СЕТИ

# Для обучения необходимы: функция ошибки(BSELoss) и оптимизатор(SGD)
model = TwoLayersNet(2, 5, 1)       
 
loss      = nn.BCELoss()
optimizer = torch.optim.SGD(model.parameters(),lr=0.5, momentum=0.8)        

# fit - функция обучающая модель(эпоха обучения), где
# X - тензор с входными значениями
# Y - тензор с истиными значениями
# batch_size - количество примеров
# train - включать ли режим тренировки или просто посмотреть как работает 
# обученная модель
def fit(model, X,Y, batch_size=100, train=True):    
    model.train(train)              # важно для Dropout, BatchNorm
    sumL = 0                        # ошибка
    sumA = 0                        # точность
    # примеры(батчи) - длина X, деленная на количество примеров(получается 
    # целочисленный тип Long)
    numB = int( len(X)/batch_size ) 
    
    for i in range(0, numB*batch_size, batch_size):          
        # Простой выбор нужного примера
        # xb = X[i: i+batch_size]                     # текущий пример
        # yb = Y[i: i+batch_size]                     # и его истина
           
        # Выборка происходит случайно, при этом выбираются только нужные для данного
        # примера значения, НО в обучение могут попасть не все примеры, а иногда даже 
        # одинаковые. Этот метод используется в классе DataLoader(параметр shuffle)
        idx = torch.randint(high = len(X), size = (batch_size,) )
        xb = X[idx]
        yb = Y[idx]
                      
        y = model(xb)                               # прямое распространение
        L = loss(y, yb)                             # вычисляем ошибку

        # Пример вставки своего оптимизатора
        # if train:                                   # в режиме обучения
        #     L.backward()                            # вычисляем градиенты            
        #     with torch.no_grad():                   
        #         for p in model.parameters():        # для каждого параметра модели
        #             p.add_(p.grad, alpha=-0.7)      # p += -0.7*grad
        #             p.grad.zero_()                  # обнуляем градиенты
  
        if train:                                   # в режиме обучения
            optimizer.zero_grad()                   # обнуляем градиенты        
            L.backward()                            # вычисляем градиенты            
            optimizer.step()                        # подправляем параметры
                                     
        sumL += L.item()                            # суммарная ошибка (item из графа)
        # sumA - берут и округляют y, где предсказания и сравнивают с истиной, находя
        # среднее значение точности предсказания значения
        sumA += (y.round() == yb).float().mean()    
         
    return sumL/numB,  sumA/numB                    # средняя ошибка и точность


X = torch.rand (1200,2)                                         # вход
Y = (torch.sum((X - 0.5)**2, axis=1) < 0.1).float().view(-1,1)  # истина

# режим оценки модели(проверяем до цикла что там):
# print("before:      loss: %.4f accuracy: %.4f" %  fit(model, X,Y, train=False))

# Что за модель ? 
# Мы даем ей на вход 1200 парных значений которые пройдя через нее должны выдать нам
# только те значения которые находяться в центре
epochs = 1000
# for epoch in range(epochs):     # каждая эпоха проходит по всем параметрам
#     # чтобы улучшить обучение можно перемешать данные(в данном случае создается новая
#     # память, что не всегда хорошо, поэтому смотри что в самой функции fit есть 
#     # перемешка)
#     # idx = torch.randperm( len(X) )
#     # X = X[idx]
#     # Y = Y[idx]
    
#     L,A = fit(model, X, Y)      # эпоха выводит среднюю ошибку и точность
    
#     # вывод для удобства через каждые 100 эпох
#     if epoch % 100 == 0 or epoch == epochs-1:                 
#         print(f'epoch: {epoch:5d} loss: {L:.4f} accuracy: {A:.4f}' )   

#endregion

#region ВЫВОД СТРУКТУРЫ СЕТИ

# Один из наиболее простых способов сделать это:
#print(model)

# torchinfo - библиотека с функцией summary - в нее передается размерность правильной 
# формы, на выходе показывает слои, названия и параметры модели
from torchinfo import summary
#summary(model, input_size=(1,2))

# Вывести параметры модели при стопочном способе задания(sequential) можно послойно
# (выглядит очень не удобно):
# for layer in modelS:
#     print("***", layer)
#     for param in layer.parameters():
#         print(param.data.numpy())

# В общем случае параметры выводятся так:
# numel - возвращает общее число элементов в тензоре
# for param in model.parameters():
#     print(param.numel(), param.size(), param.data.numpy())

# Еще один способ вывода параметров модели через state_dict, где записаны основные 
# веса, смещения и т.д.
import numpy as np

# model.state_dict().items() - берет k и v, где k - название, а v - размерность модели
# prod - выводит общее число элементов по размерности
# tot = 0
# for k, v in model.state_dict().items():
#     pars = np.prod(list(v.shape))   # размерность параметра
#     tot += pars                     # сумма размерностей параметров
#     print(f'{k:20s} :{pars:7d}  shape: {tuple(v.shape)} ')
# print(f"{'total':20s} :{tot:7d}")

# Либо можно изобразить модель рисунком при помощи torchviz
import torchviz

# Был создан граф при помощи модели и кинутой в него X, переданы параметры(имена) слоев
# dot = torchviz.make_dot(model(X), params = dict(model.named_parameters()))
# dot.render("dot_model_graph", format="png")

#endregion

#region СОХРАНЕНИЕ И ЗАГРУЗКА

# torch.save - сохраняет в бинарном виде любой словарь да же с состоянием модели и 
# оптимизатором
import datetime
  
state = {'info':      "Это моя сеть",            # описание
         'date':      datetime.datetime.now(),   # дата и время
         'model' :    model.state_dict(),        # параметры модели
         'optimizer': optimizer.state_dict()}    # состояние оптимизатора
 
torch.save(state, 'state.pt')                    # сохраняем файл

# torch.load - загружает сохранненую модель при этом нужно:
# создать модель и оптимизатор и уже после присвоить им загруженную модель
# weight_only - при true загрузит только веса, при false все параметры
state = torch.load('state.pt', weights_only=False)                   
 
# Без разницы, что за параметры, главное инициализация:
m = TwoLayersNet(2, 5, 1)                        
optimizer = torch.optim.SGD(m.parameters(),lr=1)

# Загрузка параметров модели и оптимизатора
m.        load_state_dict(state['model'])
optimizer.load_state_dict(state['optimizer'])

# Эта информация врят ли будет нужна, но все же если необходимо
#print(state['info'], state['date'])

#endregion

#region КЛАСС DATASET

# В PyTorch принято оборачивать обучающие данные в класс, где:
# __len__ - определяет число примеров
# __getitem__ - дает пример по индексу

# *args - собирает все доп. позиционные аргументы в кортеж
# **kwargs - собирает все доп. именованые аргументы в словарь
class MyDataset(torch.utils.data.Dataset):
 
    def __init__(self, N = 10, *args, **kwargs):
        super().__init__(*args,**kwargs)
         
        self.x = torch.rand(N,1)             
    
    # Длина x равна количеству примеров
    def __len__(self):     
        return len(self.x)                      
    
    # Получить idx-тый пример, где
    # input - сам x[idx]
    # target - сам x[idx] * 2
    def __getitem__(self, idx):                 
        return {'input' : self.x[idx], 'target' : 2*self.x[idx]}

data = MyDataset()
 
# Выведет случайные значения в input и их умноженные на два значения в target
#for sample in data:
#    print(sample)

# Dataset можно передать DataLoader - который автоматически позволяет обучать 
# свою нейросеть на числе примеров(batch_size)
# shuffle - нужно ли перемешать данные
# Сам по себе по сути выполняет ровно то что описано в ОБУЧЕННЫЕ СЕТИ(только 
# здесь он это делает сам)
train_loader = torch.utils.data.DataLoader(dataset=data, batch_size=12, shuffle=False)

# for batch in train_loader:                       # получаем батчи для тренировки
#     print(batch['input'], batch['target'])

#endregion

#region ВЫЧИСЛЕНИЯ НА GPU

# В сравнении с GPU CPU сосет по скорости, поскольку GPU имеет больше 
# вычислительной скорости(из-за особенностей видеокарт)
# Тем не менее с маленькими вычислениями лучше справляется CPU, а GPU может замедлить
gpu = torch.device("cuda:0" if torch.cuda.is_available() else "cpu")
cpu = torch.device("cpu")
# У меня не поддерживается
#print(gpu)  # Проверка что работает именно то, что надо

# Модель нейро-сети можно отправить на GPU
model = TwoLayersNet(2, 5, 1)           # экземпляр сети        
model.to(gpu)                           # отправляем его на GPU

# То же самое можно сделать с обучающими данными(если позволяет память GPU)
X =  X.to(gpu)
Y =  Y.to(gpu)

#endregion

#region СОБСТВЕННЫЕ СЛОИ

# Все слои являются наследниками класса nn.Module(по сути нейросеть и слой создаются 
# из одного класса), пример(линейный слой):

# Parameter - класс параметра модели nn.Module
import math
from torch.nn.parameter import Parameter

class My_Linear(nn.Module):
    
    def __init__(self, in_F, out_F):
        super(My_Linear, self).__init__()
        self.weight = Parameter(torch.Tensor(out_F, in_F))  # Весы
        self.bias   = Parameter(torch.Tensor(out_F))        # Смещение
        # Ининциализация параметров иначе случайные будут
        self.reset_parameters()     
 
    # Инициализация происходит с учетом размера входных данных, что важно для 
    # нейро-сетей(помогает контролировать значения выхода)
    def reset_parameters(self):
        for p in self.parameters():
            stdv =  1.0 / math.sqrt(p.shape[0]) # Стандартное отклонение от параметра
            p.data.uniform_(-stdv, stdv)        # Равномерное распределение
 
    # Считает по формуле MYLinear = x@W(t) + B равной формуле Linear, где
    # x - само значение; W(t) - весы; B - смещение;
    def forward(self, x):
        return  x @ self.weight.t() + self.bias 

# Пример использования:
nX = 2
nH = 5
nY = 1
modelS = nn.Sequential(My_Linear(nX, nH), My_Linear(nH, nY))

#summary(modelS, input_size=(1,2))

#endregion

#region СОБСТВЕННЫЙ ОПТИМИЗАТОР

# Копия простого SGD-оптимизатора
class SGD(torch.optim.Optimizer):
     
    def __init__(self, params, lr=0.1, momentum=0):
        defaults = dict(lr=lr, momentum=momentum)
        super(SGD, self).__init__(params, defaults)
 
    @torch.no_grad()        # Шаг без построения градиента
    def step(self):                
        for group in self.param_groups:
            momentum = group['momentum']
            lr       = group['lr']
 
            for p in group['params']:
                if p.grad is None:
                    continue
                     
                grad = p.grad
                 
                if momentum != 0:
                    p_state = self.state[p]
                    if 'momentum_buf' not in p_state:
                        buf = p_state['momentum_buf'] =  torch.clone(grad)
                    else:
                        buf = p_state['momentum_buf']
                        buf.mul_(momentum).add_( grad )                       
                    grad = buf
                     
                p.add_(grad, alpha = -lr)
 
 
optimizer = SGD(model.parameters(), lr=0.1, momentum=0.9)       

# Параметры можно так же менять в процессе обучения
def adjust_optim(optimizer, epoch):
    if epoch == 1000:
        # Смена коэффициента момента B1(смотри оптимизатор ADAM в 4)
        optimizer.param_groups[0]['betas'] = (0.3, optimizer.param_groups[0]['betas'][1])
    if epoch > 1000:
        optimizer.param_groups[0]['lr'] *= 0.9999

#endregion