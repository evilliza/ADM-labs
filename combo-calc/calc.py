print ('Выберите систему счисления для первого числа: ')
a = int (input ())
c=0
b=0
s=0
if (a==2):
    print ('Введите первое число в двоичной системе:')
    x = int (input ())
    while (x>0):
        b= b+ ((x % 10) * (2**c))
        c+=1
        x=x//10
elif (a==4):
    print ('Введите первое число в четверичной системе:')
    x = int (input ())
    while (x>0):
        b= b+ ((x % 10) * (4**c))
        c+=1
        x=x//10
elif (a==8):
    print ('Введите первое число в восьмиричной системе:')
    x = int (input ())
    while (x>0):
        b= b+ ((x % 10) * (8**c))
        c+=1
        x=x//10
elif (a==16):
    print ('Введите первое число в шестнадцатиричной системе:')
    x = input()
    x = x.lower()
    d = [str(i) for i in range(10)] + ['a', 'b', 'c', 'd', 'e', 'f']
    d = {d[i]: i for i in range(len(d))}
    while c != len(x):
        b= b+ (d[x[-(c+1)]] * (16**c))
        c+=1
else:
    print('неверная система счисления, дальнейшее выполнение программы будет работать неверно')
c=0
print ('Выберите систему счисления для второго числа: ')
j = int (input ())
if (j==2):
    print ('Введите второе число в двоичной системе:')
    y = int (input ())
    while (y>0):
        s= s+ ((y % 10) * (2**c))
        c+=1
        y=y//10
elif (j==4):
    print ('Введите второе число в четверичной системе:')
    y = int (input ())
    while (y>0):
        s= s+ ((y % 10) * (4**c))
        c+=1
        y=y//10
elif (j==8):
    print ('Введите второе число в восьмиричной системе:')
    y = int (input ())
    while (y>0):
        s= s+ ((y % 10) * (8**c))
        c+=1
        y=y//10
elif (j==16):
    print ('Введите второе число в Шестнадцатиричной системе:')
    y = input()
    y = y.lower()
    d = [str(i) for i in range(10)] + ['a', 'b', 'c', 'd', 'e', 'f']
    d = {d[i]: i for i in range(len(d))}
    while c != len(y):
        s= s+ (d[y[-(c+1)]] * (16**c))
        c+=1
print ('Выберите операцию (+, -, *, /)')
o = input()
if (o=='+'):
    print (b+s)
if (o=='-'):
    print (b-s)
if (o=='*'):
    print (b*s)
if (o=='/'):
    print (b/s)
