using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Полноценное сравнение всей колоды карт Туз > Kороль > Дама > Валет > 10 > 9 > 8 > 7 > 6, 
 * но 6 > Туз и в нагрузку бубны - козырная масть. 
 * Полноценный инкремент(увеличение) и 
 * декремент(уменьшение) значения карты Валет++ = Дама до Туза Туз ++ = Туз, 7 —= 6 и 6 —= 6.
   Потом, тогда давайте, объект класса колода, у которой под капотом 52 объектов класса Карта*/

namespace Practice_Coding
{
    internal class BlackJack
    {
        public static Hashtable masCard = new Hashtable() {
            { 6, "Six" },
            { 7, "Seven" },
            { 8, "Eight" },
            { 9, "Nine" },
            { 10, "Ten" },
            { 11, "Jack" },
            { 12, "Queen" },
            { 13, "King" },
            { 14, "Ace" },
       };
        static void Main(string[] args)
        {
            Card card = new Card("Six", 6);
            Console.WriteLine($"{card.Name}-{card.number}");
            //card--;
            Console.WriteLine($"{card.Name}-{card.number}");

            Console.ReadKey();
        }

        public class Card
        {
            public string Name;
            public int number;

            public Card(string _name, int _number)
            {
                Name = _name;
                number = _number;
            }

            public static Card operator ++(Card c1)
            {
                if (c1.number < 14)
                    c1.Name = masCard[++c1.number].ToString();
                return c1;
            }

            public static Card operator --(Card c1)
            {
                if (c1.number == 6)
                {
                    c1.number = 14;
                    c1.Name = masCard[c1.number].ToString();
                }
                else if (c1.number > 6)
                    c1.Name = masCard[--c1.number].ToString();
                return c1;
            }

            //public static Card operator += (Card c1, Card c2)
            //{
            //    if (c1.number == 6)
            //    {
            //        c1.number = 14;
            //        c1.Name = masCard[c1.number].ToString();
            //    }
            //    else if (c1.number > 6)
            //        c1.Name = masCard[--c1.number].ToString();
            //    return c1;
            //}


            //public static bool operator >(Card a, Card b)
            //{
            //    if (a.Name == "Queen" && b.Name == "Jack")
            //    {
            //        return true;
            //    }
            //    return false;
            //}
            //public static bool operator <(Card a, Card b)
            //{
            //    return false;
            //}
        }
    }
}
