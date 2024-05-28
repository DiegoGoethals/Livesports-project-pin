using Pin.LiveSports.Core.Entities;
using Pin.LiveSports.Core.Interfaces;

class Program
{
	static void Main(string[] args)
	{
		Console.WriteLine("Hello World!");
	}
}

// Primary constructors example
public class ExampleService(IFakeDataBase _fakeDataBase) // On creating services it's usefull to use the primary constructor for easier dependency injection
{
	// Normally you have fields here which take up lines of code again but by using the primary constructor you can remove them and have easier to read code
	public Game GetGame(int id)
	{
		return _fakeDataBase.GetGame(id);
	}
}

// Collection expressions (met spread operator)
public class CopyListService()
{
	int[] list = [1, 2, 3, 4, 5, 6, 7, 8];

	public int[] CopyList()
	{
		/* Sometimes you want to return a changed list but you don't want to change the original list, 
			this is where the spread operator comes in handy. It makes a copy of the list and you can change the copy 
			without changing the original list
		*/
		int[] copy = [.. list, 9, 10];
		return copy;
	}
}

// Default lambda parameters
public class LambdaService
{
	public int Add(int a, int b = 2) // You can set default values for parameters in a lambda
	{
		return a + b;
	}
}