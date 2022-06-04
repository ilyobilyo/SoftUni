using System;
using System.Collections.Generic;

namespace Cards
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Card> cards = new List<Card>();

            string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < input.Length; i++)
            {
                string[] cardInfo = input[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string cardFace = cardInfo[0];
                string cardSuit = cardInfo[1];

                try
                {
                    Card card = new Card(cardFace, cardSuit);

                    cards.Add(card);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(String.Join(" ", cards));
        }
    }

    public class Card
    {
        private string face;
        private string suit;

        public Card(string face, string suit)
        {
            Face = face;
            Suit = suit;
        }

        public string Face
        {
            get
            {
                return face;
            }
            set
            {
                if (!IsFaceValid(value))
                {
                    throw new ArgumentException("Invalid card!");
                }

                face = value;
            }
        }
        public string Suit
        {
            get
            {
                return suit;
            }
            set
            {
                if (!IsSuitValid(value))
                {
                    throw new ArgumentException("Invalid card!");
                }

                SetUtfCode(value);
            }
        }

        public override string ToString()
        {
            return $"[{face}{suit}]";
        }

        private void SetUtfCode(string suitValue)
        {
            if (suitValue == "S")
            {
                this.suit = "\u2660";
            }
            else if (suitValue == "D")
            {
                this.suit = "\u2666";
            }
            else if (suitValue == "H")
            {
                this.suit = "\u2665";
            }
            else if (suitValue == "C")
            {
                this.suit = "\u2663";
            }
        }

        private bool IsFaceValid(string face)
        {
            bool isDigitTo9 = char.TryParse(face, out char faceAsChar);

            if ((isDigitTo9 && faceAsChar > 49 && faceAsChar < 58) || faceAsChar == 'J'
                || faceAsChar == 'Q' || faceAsChar == 'K' || faceAsChar == 'A')
            {
                return true;
            }
            else if (face == "10")
            {
                return true;
            }

            return false;
        }


        private bool IsSuitValid(string suit)
          => suit == "S" || suit == "H"
                || suit == "D" || suit == "C";
    }
}
