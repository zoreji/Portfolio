using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardStack
{
    enum CardSuit
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }
    enum CardValue
    {
        Deuce = 2,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }
    class Program
    {
        public static Random rng = new Random();
        struct SingleCard
        {
            public CardSuit s_CardSuit;
            public CardValue s_CardValue;
            public override string ToString()
            {
                return string.Format(s_CardValue + " of " + s_CardSuit);
            }
        }
        static void Main(string[] args)
        {
            Stack<SingleCard> Deck = new Stack<SingleCard>();
            CreateDeck(Deck);
            foreach (SingleCard card in Deck)
            {
                Console.WriteLine(card);
            }
            Console.WriteLine();
            Console.ReadKey();
            int shuffleIndex = rng.Next(50, 9001);
            for (int i = 0; i < shuffleIndex; ++i) 
                Shuffle(Deck);

            foreach (SingleCard card in Deck)
            {
                Console.WriteLine(card);
            }
            Console.ReadKey();
        }
        static void CreateDeck(Stack<SingleCard> deck)
        {
            for (int i = (int)CardSuit.Clubs; i <= (int)CardSuit.Spades; ++i)
            {
                for (int j = (int)CardValue.Deuce; j <= (int)CardValue.Ace; ++j)
                {
                    SingleCard singleCard = new SingleCard();
                    singleCard.s_CardSuit = (CardSuit)i;
                    singleCard.s_CardValue = (CardValue)j;
                    deck.Push(singleCard);
                }
            }
        }
        static void Shuffle(Stack<SingleCard> Maindeck)
        {
            Stack<SingleCard> tempStack1 = new Stack<SingleCard>();
            Stack<SingleCard> tempStack2 = new Stack<SingleCard>();
            int indexSplit = rng.Next(0,27);
            for (int i = 0; i < indexSplit ; ++i)
            {
                tempStack1.Push(Maindeck.Pop());
            }
            do
            {
                if (tempStack1.Count != 0)
                {
                    tempStack2.Push(tempStack1.Pop());
                }
                if (Maindeck.Count != 0)
                {
                    tempStack2.Push(Maindeck.Pop());
                }
            } while (tempStack2.Count != 52);
            for (int i = 0; i < 52; ++i)
            {
                Maindeck.Push(tempStack2.Pop());
            }
        }
    }
}
