using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Полноценное сравнение всей колоды карт Туз > Kороль > Дама > Валет > 10 > 9 > 8 > 7 > 6, 
 * но 6 > Туз и в нагрузку бубны - козырная масть. 
 * Полноценный инкремент(увеличение) и 
 * декремент(уменьшение) значения карты Валет++ = Дама до Туза Туз ++ = Туз, 7 —= 6 и 6 —= 6.
   Потом, тогда давайте, объект класса колода, у которой под капотом 52 объектов класса Карта*/

/*Пишем основную механику игры "тысяча", карты есть, создаем объект класса колода,
 * в колоде 52 карты 4 масти * 13 видов, после создания колоды ее можно перемешать, 
 * из нее можно достать Н карт. Каждый раунд достаем из колоды 2 карты и сравниваем между собой*/

namespace Practice_Coding
{
    internal class BlackJack
    {
        public static Hashtable hashCard = new Hashtable() {
            { 2, "2" },
            { 3, "3" },
            { 4, "4" },
            { 5, "5" },
            { 6, "6" },
            { 7, "7" },
            { 8, "8" },
            { 9, "9" },
            { 10, "10" },
            { 11, "Jack" },
            { 12, "Queen" },
            { 13, "King" },
            { 14, "Ace" },
       };

        public static string[] masSuit = new string[] { "spades", " clubs", "diamonds", "hearts" };

        static void Main(string[] args)
        {

            List<Card> cardArray = Deck.CreateDeck();

            Card card = Deck.Take_Out_Two_Cards(ref cardArray);
            Card card2 = Deck.Take_Out_Two_Cards(ref cardArray);

            Console.WriteLine($"{card.name}-{card.number} - {card.suit}");
            Console.WriteLine($"{card2.name}-{card2.number} - {card2.suit}");

            Console.WriteLine(card < card2);

            /*foreach(Card i  in cardArray)
            {
                Console.WriteLine($"{i.name}-{i.number} - {i.suit}");
            }*/

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

            //public static Card operator ++(Card c1)
            //{
            //    if (c1.number < 14)
            //        c1.name = masCard[++c1.number].ToString();
            //    return c1;
            //}

            //public static Card operator --(Card c1)
            //{
            //    c1.name = masCard[--c1.number].ToString();
            //    return c1;
            //}

            //public static Card operator -(Card c1, Card c2)
            //{
            //    if (c1.suit == c2.suit)
            //    {
            //        int temp = c1.number - c2.number;
            //        if (temp > 0)
            //            return new Card(masCard[temp].ToString(), temp, c1.suit);
            //        else
            //            return new Card(masCard[0].ToString(), 0, "Число карты стало меньше 0");
            //    }
            //    else return new Card(masCard[0].ToString(), 0, "Не совпадают масти");
            //}

            //public static Card operator +(Card c1, Card c2)
            //{
            //    if (c1.suit == c2.suit)
            //    {
            //        int temp = c1.number + c2.number;
            //        if (temp <= 14) 
            //            return new Card(masCard[temp].ToString(), temp, c1.suit);
            //        else
            //            return new Card(masCard[0].ToString(), 0, "Число карты стало превышать 14");
            //    }
            //    else return new Card(masCard[0].ToString(), 0, "Не совпадают масти");
            //}

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

        public static class Deck
        {
            static Random rand = new Random();
            public static List<Card> CreateDeck()
            {
                List<Card> cardArray = new List<Card>();
                Card temp;
                foreach (string s in masSuit)
                {
                    foreach (int i in hashCard.Keys)
                    {
                        temp = new Card(hashCard[i].ToString(), i, s);
                        cardArray.Add(temp);
                    }
                }
               return cardArray;
            }

            public static Card Take_Out_Two_Cards(ref List<Card> list)
            {
                int i = rand.Next(0, list.Count - 1);
                Card temp = list[i];
                list.Remove(list[i]);
                return temp;
            }
        }
    }
}
