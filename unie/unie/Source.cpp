#include <iostream>

using namespace std;

union nowa
{
	int a;
	double b;
};

int main()
{
	nowa unia;
	unia.a = 25;
	//unia.b = 12.5;
	cout << unia.a << endl;
	cout << unia.b << endl;

	cin.get();
	return 0;
}