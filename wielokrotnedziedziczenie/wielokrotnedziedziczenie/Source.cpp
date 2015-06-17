#include <iostream>

using namespace std;

class pierwsza
{
public:
	void metoda1()
	{
		cout << "Klasa pierwsza dziedziczona!\n";
	}
};

class druga
{
public:
	void metoda2()
	{
		cout << "Klasa druga dziedziczona!\n";
	}
};

class trzecia
{
public:
	void metoda3()
	{
		cout << "Klasa trzecia dziedziczona!";
	}
};

class zbiorcza : pierwsza, druga, trzecia
{
public:
	void metoda_all()
	{
		metoda1();
		metoda2();
		metoda3();
	}
};

int main()
{
	zbiorcza nowy_obiekt;
	nowy_obiekt.metoda_all();

	cin.get();
	return 0;
}