#include <iostream>

using namespace std;

class pierwsza
{
public:
	int metoda(int a, int b)
	{
		return a + b;
	}
};

class druga
{
public:
	int metoda2(int a, int b)
	{
		return a - b;
	}
};

class trzecia
{
public:
	int metoda3(int a, int b)
	{
		return a / b;
	}
};

class zbiorcza : pierwsza, druga, trzecia
{
public:
	void metoda_all()
	{
		cout << metoda(5, 4);
		cout << metoda2(4, 1);
		cout << metoda3(15, 3);
	}
};

int main()
{
	zbiorcza nowy_obiekt;
	nowy_obiekt.metoda_all();

	cin.get();
	return 0;
}