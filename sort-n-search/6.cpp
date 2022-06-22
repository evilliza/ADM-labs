/*Практическая работа на тему "Сортировка и поиск"
Сортировка слиянием
По выбору преподавателя и по согласованию со студентами реализовать алгоритм сортировки на дереве, например, красно-черное дерево, быстрая сортировка, куча...
Работаем командами по 2 человека*/

#include <iostream>
#include <vector>

using namespace std;

vector<int> a;

void msort(int l, int r)
{
    if (l + 1 >= r) //   0
        return;
    int m = (l + r) / 2; //
    msort(l, m);
    msort(m, r);
    vector<int> tmp(r - l); //
    int q = l;
    int y = m;
    int t = 0;
    while ((q < m) && (y < r))
    {
        if (a[q] <= a[y])
        {
            tmp[t] = a[q];
            ++q;
            ++t;
        }
        else
        {
            tmp[t] = a[y];
            ++y;
            ++t;
        }
    }
    if ((q == m) && (y != r))
        for (y; y < r; ++y)
        {
            tmp[t] = a[y];
            ++t;
        }
    if ((q != m) && (y == r))
        for (q; q < m; ++q)
        {
            tmp[t] = a[q];
            ++t;
        }
    for (int i = 0; i < r - l; ++i)
        a[l + i] = tmp[i];
    return;
}

int main()
{
    // merge sort
    setlocale(LC_ALL, "Rus");
    int n;
    cout << "Введите количество элементов: ";
    cin >> n;
    a.assign(n, 0); //заполнение 
    for (int i = 0; i < n; ++i)
    {
        cout << "Введите элемент " << i + 1 << ": ";
        cin >> a[i];
    }
    msort(0, n);
    cout << "Вывод: ";
    for (int i = 0; i < n; ++i)
    {
        cout << a[i] << " ";
    }
}