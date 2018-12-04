using System;
using System.Collections;

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
        }
    }
    #region Basic Struct    
    struct Coffee
    {
        public string Name { get; set; }
        public string Bean { get; set; }
        public string CountryOFOrigin { get; set; }
        public int Strength { get; set; }

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

            Console.WriteLine($"Name:{coffee1.Name}");
            Console.WriteLine($"Bean:{coffee1.Bean}");
            Console.WriteLine($"Country of Origin:{coffee1.CountryOFOrigin}");
            Console.WriteLine($"Strength:{coffee1.Strength}");

            var beverageList = ArrayListExamples(coffee1, coffee2, coffee3);
            foreach (Coffee item in beverageList)
            {
                Console.WriteLine($"Name:{item.Name}");
                Console.WriteLine($"Bean:{item.Bean}");
                Console.WriteLine($"Country of Origin:{item.CountryOFOrigin}");
                Console.WriteLine($"Strength:{item.Strength}");
            }
            Console.ReadLine();
        }
        private static ArrayList ArrayListExamples(Coffee coffee1, Coffee coffee2, Coffee coffee3)
        {
            var beverages = new ArrayList
            {
                coffee1,
                coffee2,
                coffee3
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

            foreach (string item in myMenu.beverages)
            {
                Console.WriteLine($"Item:{item}");
            }
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
            for (int i = 0; i < myDays.Length; i++)
            {
                Console.WriteLine($"Day-{i}:{myDays[i]}");
            }
            //=================
        }
    }
    #endregion

}
