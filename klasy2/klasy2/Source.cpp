#include <iostream>
#include <string>

using namespace std;

class dzialanie
{
private:
	int a;
	int b;
	int c;

public:
	int dodaj(int a, int b, int c)
	{
		return a + b + c;
	}

	int mnoz(int a, int b, int c)
	{
		return a * b * c;
	}
};

int main()
{
	int lb[] = { 5, 10, 15 };

	dzialanie dodatnie;
	cout << dodatnie.dodaj(lb[0], lb[1], lb[2]) << endl;
	cout << dodatnie.mnoz(lb[0], lb[1], lb[2]) << endl;

	dzialanie ujemne;
	cout << -1 * (ujemne.dodaj(lb[0], lb[1], lb[2])) << endl;
	cout << -1 * (ujemne.mnoz(lb[0], lb[1], lb[2]));
	cin.get();
	return 0;
}