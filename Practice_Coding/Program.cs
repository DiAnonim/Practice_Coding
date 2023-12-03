using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Полноценное сравнение всей колоды карт Туз > Kороль > Дама > Валет > 10 > 9 > 8 > 7 > 6, 
 * но 6 > Туз и в нагрузку бубны - козырная масть. 
 * Полноценный инкремент(увеличение) и 
 * декремент(уменьшение) значения карты Валет++ = Дама до Туза Туз ++ = Туз, 7— = 6 и 6 — = 6.
   Потом, тогда давайте, объект класса колода, у которой под капотом 52 объектов класса Карта*/

namespace Practice_Coding
{
    internal class BlackJack
    {
        static void Main(string[] args)
        {
            Console.WriteLine("a");
            Console.ReadKey();
        }

        struct Card
        {
            public string Name;
            public Card(string _name)
            {
                Name = _name;
            }

            public static bool operator >(Card a, Card b)
            {
                if (a.Name == "Queen" && b.Name == "Jack")
                {
                    return true;
                }
                return false;
            }
            public static bool operator <(Card a, Card b)
            {
                return false;
            }
        }
    }
}
