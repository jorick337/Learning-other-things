i=5
while i < 15:
    print(i)
    i=i+2
for i in 'hello world':
    print(i*2,end='')
print()    
for i in 'hello world':
    if i=='o':
        continue
    print(i*2,end='')
print()    
for i in 'hello world':
    if i=='0':
        break
    print(i * 2,end='')
print()
for i in 'hello worl':
    if i=='a':
        break
    else:
        print('Буквы a в строке нет')
print('Как ваше имя ?')
name=input()
name.isdigit()
if name.isdigit() :
    print('нельзя вводить цифры')

 
        


    
