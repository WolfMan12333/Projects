#include <iostream>

using namespace std;

class figura
{
protected:
	double podst;
	double wys;

public:
	void przypisz(double a, double h)
	{
		podst = a;
		wys = h;
	}
};

class kwadrat : public figura
{
public:
	double pole()
	{
		return podst * wys;
	}
};

class trojkat : public figura
{
public:
	double pole()
	{
		return (podst * wys) / 2;
	}
};

int main()
{
	kwadrat kw_powierzchnia;
	trojkat tr_powierzchnia;

	kw_powierzchnia.przypisz(8.5, 9);
	tr_powierzchnia.przypisz(4, 3.8);

	cout << kw_powierzchnia.pole() << endl;
	cout << tr_powierzchnia.pole();

	cin.get();
	return 0;
}