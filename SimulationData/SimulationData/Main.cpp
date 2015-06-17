#include <iostream>
#include <fstream>

using namespace std;

void rand_data(int ilosc, int minval, int maxval)
{
	ofstream outfile;
	outfile.open("randdata.txt");
	if (outfile.good() == true)
	{
		for (int i = 0; i < ilosc; ++i)
		{
			double random = (rand() % maxval) + (minval);
			double random2 = (rand() % maxval) + (minval);
			outfile << random << " " << random2 << endl;
			cout << random << " " << random2 << endl;
		}
	}
	else
		cout << "Nie ma dostepu do pliku\n";
}

int main()
{
	cout << "Podaj ilosc danych: " << endl;
	int ilosc;
	cin >> ilosc;

	cout << "Podaj wartosc minimalna: " << endl;
	int minval;
	cin >> minval;

	cout << "Podaj wartosc maksymalna: " << endl;
	int maxval;
	cin >> maxval;

	rand_data(ilosc, minval, maxval);
	system("PAUSE");
}