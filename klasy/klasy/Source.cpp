#include <iostream>
#include <string>

using namespace std;

class muzyka
{
private:
	string nazwa;
	string gatunek;

public:
	void wypisz(string nazwa, string gatunek)
	{
		cout << "Nazwa zespolu: " << nazwa << endl;
		cout << "Gatunek muzyczny: " << gatunek << endl;
	}
};

int main()
{
	cout << "Podaj nazwe ulubionego zespolu: ";
	string nazwa_ulubionego_zespolu;
	cin >> nazwa_ulubionego_zespolu;
	cout << "Podaj ulubiony gatunek muzyczny: ";
	string ulubiony_gatunek_muzyczny;
	cin >> ulubiony_gatunek_muzyczny;

	muzyka pytam;
	pytam.wypisz(nazwa_ulubionego_zespolu, ulubiony_gatunek_muzyczny);

	cin.get();
	cin.get();
	return 0;
}