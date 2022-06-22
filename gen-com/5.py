#По выбору преподавателя написать программу на один из следующих алгоритмов
#Перестановка без повторений
def flag(a, sk, k):
    yes = True
    i = 0
    while i < k and yes:
        if a[i] == sk:
            yes = False
        i += 1
    return yes


n = 4
a = [0] * n
s = [0] * n

s[0] = 1

k = 0
m = 0

while k >= 0:
    while s[k] <= n:
        a[k] = s[k]
        s[k] += 1
        while s[k] <= n and not flag(a, s[k], k):
            s[k] += 1
        if k == n - 1:
            m += 1
            print(*a, sep=' ')
        else:
            k += 1
            s[k] = 1
            while s[k] <= n and not flag(a, s[k], k):
                s[k] += 1
    k -= 1

