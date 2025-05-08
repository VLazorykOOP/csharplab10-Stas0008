using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9_10CharpT
{
    public enum TraderType
    {
        Bull,
        Bear 
    }

    public class Trader
    {
        public string Name { get; }
        public TraderType Type { get; }
        private decimal currentPrice;

        public event PriceChangeEventHandler PriceChanged;

        public Trader(string name, TraderType type, decimal initialPrice)
        {
            Name = name;
            Type = type;
            currentPrice = initialPrice;
        }

        public void ChangePrice(string stockSymbol, decimal newPrice)
        {
            if (newPrice < 0)
            {
                Console.WriteLine($"{Name}: Ціна не може бути від'ємною!");
                return;
            }

            decimal oldPrice = currentPrice;
            currentPrice = newPrice;

            PriceChanged?.Invoke(this, new PriceChangeEventArgs(stockSymbol, oldPrice, newPrice));
        }

        public void OnPriceChanged(object sender, PriceChangeEventArgs args)
        {
            if (sender == this)
                return;

            Console.WriteLine($"{Name} ({Type}) реагує на зміну ціни акції {args.StockSymbol}: {args.OldPrice} -> {args.NewPrice}");

            if (Type == TraderType.Bull)
            {
                if (args.NewPrice > args.OldPrice)
                    Console.WriteLine($"{Name}: Ціна зросла! Бик у виграші!\n");
                else if (args.NewPrice < args.OldPrice)
                    Console.WriteLine($"{Name}: Ціна впала... Бик у програші.\n");
            }
            else // Bear
            {
                if (args.NewPrice < args.OldPrice)
                    Console.WriteLine($"{Name}: Ціна впала! Ведмідь у виграші!\n");
                else if (args.NewPrice > args.OldPrice)
                    Console.WriteLine($"{Name}: Ціна зросла... Ведмідь у програші.\n");
            }
        }
    }

    public class PriceChangeEventArgs : EventArgs
    {
        public string StockSymbol { get; }
        public decimal OldPrice { get; }
        public decimal NewPrice { get; }

        public PriceChangeEventArgs(string stockSymbol, decimal oldPrice, decimal newPrice)
        {
            StockSymbol = stockSymbol;
            OldPrice = oldPrice;
            NewPrice = newPrice;
        }
    }
    public delegate void PriceChangeEventHandler(object sender, PriceChangeEventArgs args);


}
