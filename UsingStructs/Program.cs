using System;
using System.Collections;
using System.Linq;
namespace UsingStructs
{
    class Program
    {
        static void Main()
        {
            //Basic Struct 
            Program0.Main0();
            //Indexer
            Program1.Main1();
            //Indexer with days example
            Program2.Main2();
            // Query Collection
            Program3.Main3();
        }
    }
    #region Basic Struct    
    struct Coffee :IComparable
    {
        public string Name { get; set; }
        public string Bean { get; set; }
        public string CountryOFOrigin { get; set; }
        public int Strength { get; set; }

        // Implement I Comparable only if you use .Sort in your collection
        public int CompareTo(object obj)
        {
            var coffe2 =  (Coffee)obj;
            return String.Compare(this.Name, coffe2.Name);
        }

    
    }

    static class Program0
    {
        static public void Main0()
        {
            var coffee1 = new Coffee
            {
                Name = "Fourth Coffee Quencher",
                Bean = "Arabica",
                CountryOFOrigin = "Indonesia",
                Strength = 3
            };
            var coffee2 = new Coffee
            {
                Name = "Machiato",
                Bean = "Robusta",
                CountryOFOrigin = "Colombia",
                Strength = 4
            };

            var coffee3 = new Coffee
            {
                Name = "Late Expresso",
                Bean = "Arabica",
                CountryOFOrigin = "Costa Rica",
                Strength = 3
            };


            var coffee4 = new Coffee
            {
                Name = "Capuchino",
                Bean = "Arabica",
                CountryOFOrigin = "Mexico",
                Strength = 3
            };

            Console.WriteLine($"Name:{coffee1.Name}");
            Console.WriteLine($"Bean:{coffee1.Bean}");
            Console.WriteLine($"Country of Origin:{coffee1.CountryOFOrigin}");
            Console.WriteLine($"Strength:{coffee1.Strength}");
            Console.WriteLine(new string('=', 30));
            var beverageList = ArrayListExamples(coffee1, coffee2, coffee3,coffee4);
            beverageList.Sort(); // Ordena el array list
            foreach (Coffee item in beverageList)
            {
                Console.WriteLine($"Name:{item.Name}");
                Console.WriteLine($"Bean:{item.Bean}");
                Console.WriteLine($"Country of Origin:{item.CountryOFOrigin}");
                Console.WriteLine($"Strength:{item.Strength}");
                Console.WriteLine(new string('=', 30));
            }
            Console.ReadLine();
        }
        private static ArrayList ArrayListExamples(Coffee coffee1, Coffee coffee2, Coffee coffee3,Coffee coffee4)
        {
            var beverages = new ArrayList
            {
                coffee1,
                coffee2,
                coffee3,
                coffee4
            };
            return beverages;
        }
    }
    #endregion
    #region Indexer
    struct Menu
    {
        public string[] beverages;
        public Menu(byte No)
        {
            No = 0;
            beverages = new string[] { "Americano", "Café aut lait", "Cafe Machiato", "Capuchino", "Expresso" };
        }
    }
    static class Program1
    {
        public static void Main1()
        {
            //============
            Menu myMenu = new Menu(0);
            var firstDrink = myMenu.beverages[0];
            Console.WriteLine($"Beverages:{firstDrink}");
            Console.WriteLine($"Beverages1:{myMenu.beverages[1]}");
            Console.WriteLine(new string('=', 30));
            foreach (string item in myMenu.beverages)
            {
                Console.WriteLine($"Item:{item}");
            }
            Console.WriteLine(new string('=', 30));
        }
    }
    #endregion
    #region Indexer with days
    struct Days // Example of Indexer
    {
        private readonly string[] days;

        public string this[int index]
        {
            get { return days[index]; }
        }
        public int Length
        {
            get { return days.Length; }
        }
        public Days(byte No)
        {
            No = 0;
            days = new string[] { "Sun", "Mon", "Tues", "Wed", "Thurs", "Fri", "Sat" };
        }
    }
    static class Program2
    {
        public static void Main2()
        {
            //=================
            //using and indexer 
            var myDays = new Days(0);
            Console.WriteLine(new string('=', 30));
            for (int i = 0; i < myDays.Length; i++)
            {
                Console.WriteLine($"Day-{i}:{myDays[i]}");
            }
            Console.WriteLine(new string('=', 30));
            //=================
        }
    }
    #endregion
    #region Hashtable Collection example
    static class Program3
    {
        public static void Main3()
        {
            var prices = new Hashtable
            {
                { "Cafè au Lait", 1.99M },
                { "Caffe Americano", 1.89M },
                { "Cafè Mocha", 2.99M },
                { "Capchino", 2.98M },
                { "Expresso", 1.49M },
                { "Expresso Romano", 1.59M },
                { "English Tea", 1.69M },
                { "Juice", 2.89M }
            };

            // Iterate of Hashtable collection
            foreach (DictionaryEntry de in prices)
            {
                Console.WriteLine($"Key:{de.Key} - Value:{de.Value}");
            }

            //Select all the drinks hat cost less than 2.00, and other them by cost.
            var bargains =
                from string drinks in prices.Keys
                where (Decimal)prices[drinks] < 2.0M
                orderby prices[drinks] ascending
                select drinks;
            foreach (string bargain in bargains)
            {
                Console.WriteLine(bargain);
                Console.WriteLine(new string('=', 30));
            }
            // Select all drinks orderder by keys
            var bargains1 =
                from string drinks in prices.Keys
                orderby prices[drinks] ascending
                select drinks;
            Console.WriteLine(new string('=', 30));
            Console.WriteLine($"The cheapest drink is: {bargains1.FirstOrDefault()}");
            Console.WriteLine($"The most expansive drink is:{bargains1.Last()}");
            Console.WriteLine($"The maximun is:{bargains1.Max()}");
            Console.WriteLine($"The minimun is:{bargains1.Min()}");

            Console.ReadLine();
        }
    }
    #endregion
}
