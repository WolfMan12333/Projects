#include <iostream>

using namespace std;

template <class typ>
class mnoznik
{
private:
	int a;
public:
	typ metoda(typ x)
	{
		a = 2;
		return x * 2;
	}
};

int main()
{
	mnoznik<int>obiekcik;
	cout << obiekcik.metoda(5) << endl;
	mnoznik<char>obiekcik1;
	cout << obiekcik1.metoda(2) << endl;

	cin.get();
	return 0;
}