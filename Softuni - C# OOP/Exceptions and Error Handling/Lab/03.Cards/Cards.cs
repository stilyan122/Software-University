using System;
using System.Collections.Generic ;
using System.Linq;

namespace Cards
{
    public class Cards
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>()
                {
                    "2","3","4","5","6","7","8","9","10","J","Q","K","A"
                };
            List<string> cardsArr = new List<string>();
            List<string[]> cardsList = new List<string[]>();
            string[] cards = Console.ReadLine().Split(", ");
            foreach (var item in cards)
            {
                cardsList.Add(item.Split(" "));
            }
            for (int i = 0; i < cardsList.Count; i++)
            {
                try
                {
                    if (!list.Contains(cardsList[i][0].ToString()))
                    {
                        throw new ArgumentException();
                    }
                    else
                    {
                        Card card = new Card(cardsList[i][0].ToString(), cardsList[i][1].ToString());
                        cardsArr.Add(card.ToString());
                    }
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Invalid card!");
                }
            }
            Console.WriteLine(string.Join(" ", cardsArr));
        }
    }
    public class Card
    {
        private string face;
        private string suit;
        public string Face { get; set; }
        public string Suit { get; set; }
        public Card(string f, string s)
        {
            Face = f;
            Suit = s;
        }
        public override string ToString()
        {
            if (Suit == "S")
            {
                return $"[{Face}{"\u2660"}]".ToString();
            }
            else if (Suit == "H")
            {
                return $"[{Face}{"\u2665"}]".ToString();
            }
            else if (Suit == "D")
            {
                return $"[{Face}{"\u2666"}]".ToString();
            }
            else if (Suit == "C")
            {
                return $"[{Face}{"\u2663"}]".ToString();
            }
            else
            {
                throw new ArgumentException();
            }
        }
    } 
    }
