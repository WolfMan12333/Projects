#include <iostream>

using namespace std;

namespace company_1
{
	int licz(int a, int b)
	{
		return a + b;
	}
}

namespace company_2
{
	int licz(int a, int b)
	{
		return double(a) / double(b);
	}
}

int main()
{
	int lb1, lb2, choice;

	cout << "Podaj pierwsza liczbe: ";
	cin >> lb1;

	cout << "Podaj druga liczbe: ";
	cin >> lb2;

	cout << "Wybierz numer operacji: \n";
	cout << "1. DOdawanie\n";
	cout << "2. Dzielenie\n";
	cin >> choice;

	if (choice != 1 && choice != 2)
	{
		exit;
	}
	else if (choice == 1)
	{
		cout << company_1::licz(lb1, lb2);
	}
	else if (choice == 1)
	{
		cout << company_2::licz(lb1, lb2);
	}

	cin.get();
	cin.get();
	return 0;
}