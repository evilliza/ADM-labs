# Представление последовательностей на смежной и связной памяти.
# Написать две программы: одну на смежной памяти, другую на связной памяти, в которых можно:
# 1. Добавлять элементы в последовательность
# 2. Удалять элементы из последовательности
# 3. Находить нужный элемент последовательности по значению и по индексу и по указателю
# По выбору преподавателя и по согласованию со студентами реализовать алгоритм сортировки на дереве, например, красно-черное дерево, быстрая сортировка, куча...
class Node:
    def __init__(self, value=0):
        self.next = None
        self.value = value


class List:
    def __init__(self, size=0):  # создает наачальные данные для экземпляра класса
        self.__size = size
        self.__head = None

    def __getitem(self, ind):
        if not isinstance(ind, int):
            raise TypeError
        if self.__size == 0 or not (-self.__size <= ind < self.__size):
            raise IndexError('Index out of range')
        if ind < 0:
            ind = ind + self.__size
        h = self.__head
        while ind:
            h = h.next
            ind -= 1
        return h

    def __getitem__(self, ind):  # выводит определенное значение
        return self.__getitem(ind).value

    def __setitem__(self, ind, value):  # задает определенное значение конкретному значению
        self.__getitem(ind).value = value

    def __iter__(self):  # возвращает объект-итератор
        h = self.__head
        while h:
            yield h.value
            h = h.next

    def __len__(self):  # вывод кол-ва элементов
        return self.__size

    def append(self, value):  # добавление в конец списка переменных
        if self.__size == 0:
            self.__head = Node(value)
        else:
            self.__getitem(-1).next = Node(value)
        self.__size += 1

    def pop(self, ind=None):  # удаляет последний элемент
        if ind is None:
            ind = self.__size - 1
        elif not isinstance(ind, int):
            raise TypeError
        if not (-self.__size <= ind < self.__size):
            raise IndexError('Index out of range')

        if ind == 0:
            self.__head = self.__head and self.__head.next
            self.__size -= 1
            return
        if ind < 0:
            ind = ind + self.__size

        h = self.__getitem(ind - 1)
        h.next = h.next and h.next.next
        self.__size -= 1


if __name__ == '__main__':
    l = List()
    l.append(0)
    l.append(1)
    l.append(2)
    l.append(3)
    l.append(4)
    l.append(5)
    for i in l:
        print(i, end=' ')
    print()
    l.pop(2)
    l.pop(5)
    l.pop(0)
    for i in l:
        print(i, end=' ')
    print()
