using System;
using System.Collections.Generic;

namespace Lab4
{
    class Lab4
    {
        static void Main(string[] args)
        {
            List<GardenTree> garden = new List<GardenTree>()
            {
                new AppleTree(34,80,7),
                new CherryTree(10,90,4),
                new AppleTree(100,40,15),
                new PearTree(40,70,10),
            };
            foreach (var item in garden)
            {
                item.GetInfo();
                Console.WriteLine(new string('-', 10));
            }

            GardenTree.Transfer(garden);
            Console.WriteLine("\n\nAFTER TRANSFER\n\n");

            foreach (var item in garden)
            {
                item.GetInfo();
                Console.WriteLine();
                item.FruitInfo();
                Console.WriteLine(new string('-', 10));
            }
            Console.ReadKey();
        }
    }
    abstract class GardenTree : IFruit
    {
        public abstract String Name { get; set; }
        public abstract String Color { get; set; }
        public abstract String Taste { get; set; }
        public abstract void FruitInfo();

        static Int32 num = 1;
        public Int32 Number { get; protected set; }
        Int32 high;
        public Int32 High
        {
            get
            {
                return high;
            }
            protected set
            {
                if (value < 0)
                {
                    high = 0;
                }
                else
                {
                    high = value;
                }
            }
        }
        Int32 age;
        public Int32 Age
        {
            get
            {
                return age;
            }
            protected set
            {
                if (value < 0)
                {
                    age = 0;
                }
                else
                {
                    age = value;
                }
            }
        }
        Int32 fruitfulness;
        public Int32 Fruitfulness
        {
            get
            {
                return fruitfulness;
            }
            protected set
            {
                if (value > 100)
                {
                    fruitfulness = 100;
                }
                else if (value < 0)
                {
                    fruitfulness = 0;
                }
                else
                {
                    fruitfulness = value;
                }
            }
        }
        public String Type { get; protected set; }
        public GardenTree(Int32 age, Int32 fruitfulness, Int32 high)
        {
            Fruitfulness = fruitfulness;
            Age = age;
            High = high;
            Number = num;
            num++;
        }
        public GardenTree(Int32 age, Int32 fruitfulness, Int32 high, Int32 _num)
        {
            Fruitfulness = fruitfulness;
            Age = age;
            High = high;
            Number = _num;
            num++;
        }
        public abstract bool IsSatisfy();
        public void GetInfo()
        {
            Console.WriteLine($"Type: {Type}\nAge: {Age}\nHigh: {High}\nFruiting: {Fruitfulness}");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Number: {Number}");
            Console.ResetColor();
        }
        public static void Transfer(List<GardenTree> garden)
        {
            for (int i = 0; i < garden.Count; i++)
            {
                if (garden[i].IsSatisfy() == false)
                {
                    Int32 num = garden[i].Number;
                    garden.Remove(garden[i]);
                    i--;
                    garden.Add(new AppleTree(50, 60, 10, num));
                }
            }
        }

    }
    interface IFruit
    {
        String Name { get; set; }
        String Color { get; set; }
        String Taste { get; set; }
        void FruitInfo();

    }
    class AppleTree : GardenTree
    {
        public override void FruitInfo()
        {
            Console.WriteLine($"Fruit: {Name}\nColor: {Color}\nTaste: {Taste}");
        }
        public override String Name { get; set; } = "Apple";
        public override String Color { get; set; } = "Yellow";
        public override String Taste { get; set; } = "Sweet-Acidic";

        public override bool IsSatisfy()
        {
            if (this.Age > 60 && this.Fruitfulness < 50 || this.Age < 6)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public AppleTree(Int32 age, Int32 fruitfulness, Int32 high) : base(age, fruitfulness, high)
        {
            Type = "AppleTree";
        }
        public AppleTree(Int32 age, Int32 fruitfulness, Int32 high, Int32 num) : base(age, fruitfulness, high, num)
        {
            Type = "AppleTree";
        }
    }
    class CherryTree : GardenTree
    {
        public override void FruitInfo()
        {
            Console.WriteLine($"Fruit: {Name}\nColor: {Color}\nTaste: {Taste}");
        }
        public override String Name { get; set; } = "Cherry";
        public override String Color { get; set; } = "Red";
        public override String Taste { get; set; } = "Acidic";
        public override bool IsSatisfy()
        {
            if (this.Age > 25 && this.Fruitfulness < 50)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public CherryTree(Int32 age, Int32 fruitfulness, Int32 high) : base(age, fruitfulness, high)
        {
            Type = "CherryTree";
        }
        public CherryTree(Int32 age, Int32 fruitfulness, Int32 high, Int32 num) : base(age, fruitfulness, high, num)
        {
            Type = "CherryTree";
        }
    }
    class PearTree : GardenTree
    {
        public override void FruitInfo()
        {
            Console.WriteLine($"Fruit: {Name}\nColor: {Color}\nTaste: {Taste}");
        }
        public override String Name { get; set; } = "Pear";
        public override String Color { get; set; } = "Green";
        public override String Taste { get; set; } = "Sweet";
        public override bool IsSatisfy()
        {
            if (this.Age > 100 && this.Fruitfulness < 50 && this.Age < 8)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public PearTree(Int32 age, Int32 fruitfulness, Int32 high) : base(age, fruitfulness, high)
        {
            Type = "PearTree";
        }
        public PearTree(Int32 age, Int32 fruitfulness, Int32 high, Int32 num) : base(age, fruitfulness, high, num)
        {
            Type = "PearTree";
        }
    }
}
