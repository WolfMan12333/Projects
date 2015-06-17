#include <iostream>
#include <string>


using namespace std;

class temp
{
public:
	string zmienna;
	temp::temp()
		: zmienna("tajne zdanie")
	{
		cout << zmienna;
	}
	~temp() {};
};

int main()
{
	temp asd;

	cin.get();
	return 0;
}