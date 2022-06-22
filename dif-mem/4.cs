/*Представление последовательностей на смежной и связной памяти.
Написать две программы: одну на смежной памяти, другую на связной памяти, в которых можно:
1. Добавлять элементы в дерево
2. Удалять элементы издерева
3. Находить нужный элемент дерева по значению и по индексу и по указателю*/
using System;
using System.Collections.Generic;

namespace ConsoleApp3
{

    class TreeOnLikedMemory
    {

        private List<int> data;

        int cur_num;

        public TreeOnLikedMemory()
        {
            cur_num = -1;
        }
        public void addItem(int value)
        {
            if (cur_num == -1)
            {
                data = new List<int>();
                data.Add(value);
                cur_num = 0;
                return;
            }
            if (data.Count <= cur_num * 2 + 2)
            {
                int cnt = data.Count;
                for (int i = 0; i <= cnt; i++)
                {
                    data.Add(Int32.MaxValue);
                }
            }
            if (data[cur_num * 2 + 1] == Int32.MaxValue)
            {
                data[cur_num * 2 + 1] = value;
                return;
            }
            if (data[cur_num * 2 + 2] == Int32.MaxValue)
            {
                data[cur_num * 2 + 2] = value;
                return;
            }
            Console.WriteLine("Новый узел добвать нельзя. У этого узла уже есть два предка");

        }
        public void UpdateCurrentValue(int newValue)
        {
            if (cur_num == -1)
            {
                Console.WriteLine("Дерево пустое");
                return;
            }
            data[cur_num] = newValue;
            Console.WriteLine("Значение текущего узла изменено");
        }
        public void CurrentValue()
        {
            if (cur_num == -1)
            {
                Console.WriteLine("Дерево пустое");
            }
            else
            {
                Console.WriteLine($"Значение текущего узла: {data[cur_num]}");
            }
        }

        public void ToParent()
        {
            cur_num = (cur_num - 1) / 2;
        }
        public void ToChild(int num = 0)
        {
            if (num != 1 && num != 2)
            {
                Console.WriteLine("Некорректное значение номера узла. У данного дерева не может быть больше двух потомков");
                return;
            }
            if (data.Count <= cur_num * 2 + num || data[cur_num * 2 + num] == Int32.MaxValue)
            {
                Console.WriteLine($"У данного узла нет предка с номером: {num}");
                return;
            }
            cur_num = cur_num * 2 + num;
            Console.WriteLine("Переход к предку успешно выполнен");
        }
        public void CheckChilds()
        {
            if (data.Count <= cur_num * 2 + 2 || (data[cur_num * 2 + 1] == Int32.MaxValue && data[cur_num * 2 + 2] == Int32.MaxValue))
            {
                Console.WriteLine("У текущего узла нет предков");
                return;
            }
            Console.WriteLine("Потомки текущего узла: ");
            if (data[cur_num * 2 + 1] != Int32.MaxValue)
            {
                Console.WriteLine($"1 - {data[cur_num * 2 + 1]}");
            }
            if (data[cur_num * 2 + 2] != Int32.MaxValue)
            {
                Console.WriteLine($"2 - {data[cur_num * 2 + 2]}");
            }

        }
        public void RemoveChild(int num)
        {
            if (num != 1 && num != 2)
            {
                Console.WriteLine("Некорректное значение номера узла. У данного дерева не может быть больше двух потомков");
                return;
            }
            if (data.Count <= cur_num * 2 + num || data[cur_num * 2 + num] == Int32.MaxValue)
            {
                Console.WriteLine($"У данного узла нет предка с номером: {num}");
                return;
            }
            data[cur_num * 2 + num] = Int32.MaxValue;
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            TreeOnLikedMemory tree = new TreeOnLikedMemory();
            Console.WriteLine("Команды: ");
            Console.WriteLine("1 - Посмотреть значение текущего узла");
            Console.WriteLine("2 - изменить значение текущего узла");
            Console.WriteLine("3 - добавить потомка текущему узлу");
            Console.WriteLine("4 - посмотреть список потомков текущего узла");
            Console.WriteLine("5 - перейти к одному из потомков");
            Console.WriteLine("6 - перейти к предку");
            Console.WriteLine("7 - удалить одного из потомков");
            Console.WriteLine("-1 - завершить работу программы");
            int CurrentCommand = 0;
            while (CurrentCommand != -1)
            {
                Console.Write("Введите команду: ");
                CurrentCommand = Convert.ToInt32(Console.ReadLine());

                if (CurrentCommand == -1)
                {
                    Console.Write("Работа программы завершена");
                    break;
                }
                else if (CurrentCommand == 1)
                {
                    tree.CurrentValue();
                }
                else if (CurrentCommand == 2)
                {
                    Console.Write("Введите новое значение текущего узла:");
                    int newCurrValue = Convert.ToInt32(Console.ReadLine());
                    tree.UpdateCurrentValue(newCurrValue);
                }
                else if (CurrentCommand == 3)
                {
                    Console.Write("Введите значение добавляемого узла:");
                    int newChild = Convert.ToInt32(Console.ReadLine());
                    tree.addItem(newChild);
                }
                else if (CurrentCommand == 4)
                {
                    tree.CheckChilds();
                }
                else if (CurrentCommand == 5)
                {
                    Console.Write("Введите номер потомка, в который хотите перейти: ");
                    int childNum = Convert.ToInt32(Console.ReadLine());
                    tree.ToChild(childNum);
                }
                else if (CurrentCommand == 6)
                {
                    tree.ToParent();
                    Console.WriteLine("Выполнен переход к предку");
                }
                else if (CurrentCommand == 7)
                {
                    Console.Write("Введите номер потока, которого вы хотите удалить: ");
                    int ChildToRemove = Convert.ToInt32(Console.ReadLine());
                    tree.RemoveChild(ChildToRemove);
                }
                else
                {
                    Console.WriteLine("Вы ввели неверную команду");
                }

            }

        }
    }
}


//На связной памяти: 

#include <iostream>
using namespace std;

struct Node
{
	int x;
	Node* l, * r;
};


void del(Node*& Tree)
{
	if (Tree != NULL)
	{
		del(Tree->l);
		del(Tree->r);
		delete Tree;
		Tree = NULL;
	}

}

void show(Node*& Tree)
{
	if (Tree != NULL)
	{
		show(Tree->l);
		cout << Tree->x;
		show(Tree->r);
	}
	else
	{
		cout << '\n';
	}
}

void add_node(int x, Node*& MyTree)
{
	if (NULL == MyTree)
	{
		MyTree = new Node;
		MyTree->x = x;
		MyTree->l = MyTree->r = NULL;
	}

	if (x < MyTree->x)
	{
		if (MyTree->l != NULL) add_node(x, MyTree->l);
		else
		{
			MyTree->l = new Node;
			MyTree->l->l = MyTree->l->r = NULL;
			MyTree->l->x = x;
		}
	}

	if (x > MyTree->x)
	{
		if (MyTree->r != NULL) add_node(x, MyTree->r);
		else
		{
			MyTree->r = new Node;
			MyTree->r->l = MyTree->r->r = NULL;
			MyTree->r->x = x;
		}
	}
}


int main()
{
	setlocale(LC_ALL, "Rus");
	Node* Tree = NULL;
	bool k = true;
	while (k) {
		cout << "Введите значение: " << endl;
		int x;
		cin >> x;
		add_node(x, Tree);
		cout << "Хотите продолжить? Введите no, если нет" << endl;;
		string s;
		cin >> s;
		if (s == "no") k = false;
	}
	
	show(Tree);
	cin.get();
}