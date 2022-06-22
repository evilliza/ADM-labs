#include <iostream>
#include <vector>
#include <cmath>

double Fact(int a) {
	double s = 1;
	if (a == 0)
		return s;
	else
		s = a * Fact(a - 1);
	return s;
}

int SUM = 1;
int ALL = 0;

int main()
{
	std::vector<int> a;
	std::vector<int> b;
	setlocale(LC_ALL, "Russian");
	std::cout << "Введите одну из следующих комбинаторных схем:" << '\n';
	std::cout << "1. Комбинаторная сумма." << '\n';
	std::cout << "2. Прямое произведение." << '\n';
	std::cout << "3. Количество размещений с повторениями." << '\n';
	std::cout << "4. Количество размещений без повторений." << '\n';
	std::cout << "5. Количество сочетаний с повторениями." << '\n';
	std::cout << "6. Количество сочетаний без повторений." << '\n';
	std::cout << "7. Количество перестановок с повторениями." << '\n';
	std::cout << "8. Количество перестановок без повторений." << '\n';
	int inPut = 0;
	int aCount = 0;
	int bCount = 0;
	int n = 0;
	std::cin >> inPut;
	switch (inPut)
	{
	case 1:
		std::cout << "Заполните последовательно множества." << '\n';
		std::cout << "Введите количество элементов множества A: ";
		std::cin >> aCount;
		std::cout << '\n';
		std::cout << "Заполните множество А: ";
		for (int i = 0; i < aCount; ++i) {
			int local;
			std::cin >> local;
			a.push_back(local);
		}
		std::cout << '\n' << "Введите количество элементов множества B: ";
		std::cin >> bCount;
		std::cout << '\n';
		std::cout << "Заполните множество B: ";
		for (int i = 0; i < bCount; ++i) {
			int local;
			std::cin >> local;
			b.push_back(local);
		}
		n = a.size() + b.size();
		std::cout << "По правилу сумм: |A u B|= " << n << '\n';
		break;
	case 2:
		std::cout << "Заполните последовательно множества." << '\n' << "Введите количество элементов множества A: ";
		std::cin >> aCount;
		std::cout << '\n' << "Заполните множество А: ";
		for (int i = 0; i < aCount; ++i) {
			int local;
			std::cin >> local;
			a.push_back(local);
		}
		std::cout << '\n' << "Введите количество элементов множества B: ";
		std::cin >> bCount;
		std::cout << '\n' << "Заполните множество B: ";
		for (int i = 0; i < bCount; ++i) {
			int local;
			std::cin >> local;
			b.push_back(local);
		}
		n = a.size() * b.size();
		std::cout << "По правилу произведения множеств: |A x B| = " << n << '\n';
		break;
	case 3:
		std::cout << "Заполните ваше множество X: " << '\n' << "Введите количество элементов множества X: ";
		std::cin >> aCount;
		std::cout << '\n' << "Заполните множество X: ";
		for (int i = 0; i < aCount; ++i) {
			int local;
			std::cin >> local;
			a.push_back(local);
		}
		std::cout << "Введите значение длины вашего размещения: ";
		std::cin >> n;
		std::cout << "По правилу прямого произведения получаем: |X1 x X2 x ... x Xк| = " << pow(a.size(), n) << "  , где  к - длина размещения." << '\n';
		break;
	case 4:

		std::cout << "Заполните ваше множество X: " << '\n' << "Введите количество элементов множества X: ";
		std::cin >> aCount;
		std::cout << "Введите значение длины вашего размещения: ";
		std::cin >> n;
		std::cout << "По правилу размещения без повторения получаем:  " << Fact(aCount) / Fact(aCount - n) << '\n';
		break;

	case 5:
		std::cout << "Заполните ваше множество X: " << '\n' << "Введите количество элементов множества X: ";
		std::cin >> aCount;
		std::cout << "Введите значение длины вашего сочетания: ";
		std::cin >> n;
		std::cout << "По правилу сочетания c повторений получаем:  " << Fact(aCount + n - 1) / (Fact(n - 1) * Fact(aCount)) << '\n';
		break;
	case 6:
		std::cout << "Заполните ваше множество X: " << '\n' << "Введите количество элементов множества X: ";
		std::cin >> aCount;
		std::cout << "Введите значение длины вашего сочетания: ";
		std::cin >> n;
		std::cout << "По правилу сочетания без повторений получаем:  " << Fact(aCount) / (Fact(n) * Fact(aCount - n)) << '\n';
		break;
	case 7:
		std::cout << "Заполните ваше множество X: " << '\n' << "Введите количество различных элементов множества X: ";
		std::cin >> aCount;
		for (int i = 0; i < aCount; i++) {
			std::cout << "Введите количество " << i + 1 << " элемента:" << '\n';
			std::cin >> n;
			SUM *= Fact(n);
			ALL += n;
		}
		std::cout << "Количество перестановок с повторениями: " << Fact(ALL) / SUM << '\n';
		break;
	case 8:
		std::cout << "Запишите ваше множество X: " << '\n' << "Введите количество элементов множества X : ";
		std::cin >> aCount;
		std::cout << "По правилу перестановки получаем:  " << Fact(aCount) << '\n';
		break;
	default:
		std::cout << "Вы ввели некорректное значение.";
		break;
	}
	return 0;
}
