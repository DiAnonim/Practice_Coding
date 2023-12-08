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
            { 0, "0" },
            { 1, "Ace" },
            { 2, "Two" },
            { 3, "Three" },
            { 4, "Four" },
            { 5, "Five" },
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
            Card card = new Card("Ten", 10, "a");
            Card card2 = new Card("Seven", 7, "a");
            //Console.WriteLine($"{card.name}-{card.number}");
            //card--;
            //Console.WriteLine($"{card.name}-{card.number}");

            //Console.WriteLine($"{card.name}-{card.number}-{card.suit}");
            //Console.WriteLine($"{card2.name}-{card2.number}-{card2.suit}");

            //Console.WriteLine(card < card2);

            Card c3 = card2 + card;
            Console.WriteLine($"{c3.name}-{c3.number}-{c3.suit}");

            Console.ReadKey();
        }

        public class Card
        {
            public string name;
            public int number;
            public string suit;


            public Card(string _name, int _number, string _suit)
            {
                name = _name;
                number = _number;
                suit = _suit;
            }

            public static Card operator ++(Card c1)
            {
                if (c1.number < 14)
                    c1.name = masCard[++c1.number].ToString();
                return c1;
            }

            public static Card operator --(Card c1)
            {
                //if (c1.number == 6)
                //{
                //    c1.number = 14;
                //    c1.Name = masCard[c1.number].ToString();
                //}
                //else if (c1.number > 6)
                c1.name = masCard[--c1.number].ToString();
                return c1;
            }

            public static Card operator -(Card c1, Card c2)
            {
                if (c1.suit == c2.suit)
                {
                    int temp = c1.number - c2.number;
                    if (temp > 0)
                        return new Card(masCard[temp].ToString(), temp, c1.suit);
                    else
                        return new Card(masCard[0].ToString(), 0, "Число карты стало меньше 0");
                }
                else return new Card(masCard[0].ToString(), 0, "Не совпадают масти");
            }

            public static Card operator +(Card c1, Card c2)
            {
                if (c1.suit == c2.suit)
                {
                    int temp = c1.number + c2.number;
                    if (temp <= 14) 
                        return new Card(masCard[temp].ToString(), temp, c1.suit);
                    else
                        return new Card(masCard[0].ToString(), 0, "Число карты стало превышать 14");
                }
                else return new Card(masCard[0].ToString(), 0, "Не совпадают масти");
            }

            public static bool operator >(Card c1, Card c2)
            {
                string trump = "diamonds";
                if (c1.number > c2.number && c1.suit == c2.suit)
                    return true;
                else if (c1.number < c2.number && c1.suit == trump && c2.suit != trump)
                    return true;
                else if (c1.number > c2.number && c1.suit != c2.suit && c2.suit != trump)
                    return true;
                return false;
            }

            public static bool operator <(Card c1, Card c2)
            {
                string trump = "diamonds";
                if (c1.number < c2.number && c1.suit == c2.suit)
                    return true;
                else if (c1.number > c2.number && c1.suit != trump && c2.suit == trump)
                    return true;
                else if (c1.number < c2.number && c1.suit != c2.suit)
                    return true;
                return false;
            }

        }
    }
}
