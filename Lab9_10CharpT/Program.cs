//  За бажанням студента для задач можна створювати консольний проект або WinForm
// Бажано для задач лаб. робіт створити окремі класи
// Виконання  виконати в стилі багатозаданості :
//   Lab9T2  lab9task2 = new Lab9T2; lab9task2.Run();
// При бажанні можна створити багатозадачний режим виконання задач.

using Lab9_10CharpT;

Console.OutputEncoding = System.Text.Encoding.Unicode;
Console.InputEncoding = System.Text.Encoding.Unicode;

Trader bull1 = new Trader("Бик Джон", TraderType.Bull, 100.0m);
Trader bull2 = new Trader("Бик Боб", TraderType.Bull, 100.0m);
Trader bear1 = new Trader("Ведмідь Іван", TraderType.Bear, 100.0m);
Trader bear2 = new Trader("Ведмідь Віктор", TraderType.Bear, 100.0m);

bull1.PriceChanged += bull2.OnPriceChanged;
bull1.PriceChanged += bear1.OnPriceChanged;
bull1.PriceChanged += bear2.OnPriceChanged;

bull2.PriceChanged += bull1.OnPriceChanged;
bull2.PriceChanged += bear1.OnPriceChanged;
bull2.PriceChanged += bear2.OnPriceChanged;

bear1.PriceChanged += bull1.OnPriceChanged;
bear1.PriceChanged += bull2.OnPriceChanged;
bear1.PriceChanged += bear2.OnPriceChanged;

bear2.PriceChanged += bull1.OnPriceChanged;
bear2.PriceChanged += bull2.OnPriceChanged;
bear2.PriceChanged += bear1.OnPriceChanged;

Console.WriteLine("Симуляція зміни ціни акції:");

Console.WriteLine("First.");
bull1.ChangePrice("AnimalCoin", 110.0m);
Console.WriteLine();

Console.WriteLine("Second.");
bear1.ChangePrice("AnimalCoin", 90.0m);
Console.WriteLine();
