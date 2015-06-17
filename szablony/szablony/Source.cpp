#include <iostream>
#include <string>

using namespace std;

template <class typ>
typ funkcja(typ x, typ y)
{
	return x + y;
}

int main()
{
	cout << funkcja(3, 5) << endl;
	cout << funkcja(34.2344, -3.432) << endl;
	cout << funkcja<string>("Moje zda", "nie :)") << endl;

	cin.get();
	return 0;
}