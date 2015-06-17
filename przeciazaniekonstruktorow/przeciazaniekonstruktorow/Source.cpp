#include <iostream>
#include <string>

using namespace std;

class settings
{
public:
	settings::settings(string lvl)
	{
		cout << "Wybrales poziom trudnosci " << lvl << endl;
	}

	settings::settings(string lvl, bool cheats)
	{
		cout << "Wybrales pziom trudnosci " << lvl;
		if (cheats != 1)
		{
			cout << "i nieaktywowales kodow!" << endl;
		}
		else
		{
			cout << " i aktywowales kody!" << endl;
		}
	}
	~settings() {};
};

int main()
{
	settings("1");
	settings("Easy", 1);

	cin.get();
	return 0;
}