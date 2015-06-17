// struktury.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>

using namespace std;

struct point
{
	int x, y;
	char nazwa;
};

int _tmain(int argc, _TCHAR* argv[])
{
	point onepkt, secpkt;

	//wype³niam peirwszy punkt danymi
	cout << "Podaj nazwe pierwszego pkt:";
	cin >> onepkt.nazwa;
	cout << "Podaj wpsolrzedna x pkt " << onepkt.nazwa << ": ";
	cin >> onepkt.x;
	cout << "Podaj wspolrzedna y pkt " << onepkt.nazwa << ": ";
	cin >> onepkt.y;

	//wype³niam drugi punkt danymi
	cout << "Podaj nazwe drugiego punktu: ";
	cin >> secpkt.nazwa;
	cout << "Podaj wspolrzedna x punktu " << secpkt.nazwa << ": ";
	cin >> secpkt.x;
	cout << "Podaj wspolrzedna y punktu " << secpkt.nazwa << ": ";
	cin >> secpkt.y;

	char c;
	cin >> c;

	return 0;
}

