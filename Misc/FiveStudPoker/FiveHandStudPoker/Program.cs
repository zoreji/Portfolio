/************************************************************
 *  Program:    FiveHandStudPoker
 *  Author:     Ervin Hernandez
 *  Class:      CMPE 1700
 *  Date:       22 March 2015
 ************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveHandStudPoker
{
    // ♥♦♣♠
    /// <CardSuit>
    /// Enum CardSuit
    ///     An Enum thats contains all the suit for
    ///     making a card
    /// </summary>
    enum CardSuit
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }
    /// <CardValue>
    /// Enum CardValue
    ///     An Enum thats contain all the Number Value
    ///     for making a card. Starting with Deuce at 2 to 
    ///     Ace at 14
    /// </summary>
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
    /// <PokerRank>
    /// Enum PokerRank
    ///     An Enum thats contain the ranking of each
    ///     possible poker hand in the game of 
    ///     Five hand Stud Poker
    /// </summary>
    enum PokerRank
    {
        Nothing = 0,
        Pair,
        TwoPairs,
        Three_of_a_kind,
        Straight,
        Flush,
        FullHouse,
        Four_of_a_kind,
        StraightFlush,
        RoyalFlush
    }
    /// <summary>
    /// The Five Hand Stud Poker Program trys to replicate a poker game
    /// with the five hand stud poker rules set with four players. althought the program 
    /// doesn't evalue hands that are tie in similar ranking. also it doesn't 
    /// have a way to evaluate royal flush.
    /// </summary>
    class Program
    {
        public static Random rng = new Random();
        /// <SingleCard>
        /// Struct SingleCard
        ///     obtains the enum of a Cardsuit and CardValue
        ///     and create a card for the deck
        /// </summary>
        struct SingleCard
        {
            public CardSuit s_CardSuit;
            public CardValue s_CardValue;
            public override string ToString()
            {
                return string.Format(s_CardValue + " of " + s_CardSuit);
            }
        }
        /// <summary>
        /// Method:     CreateDeck(Stack<SingleCard> deck)
        /// Purpose:    Create A Stack of Card for a deck
        /// Parameters: Stack<SingleCard> deck - The container to hold
        ///             a stack of card for the deck
        /// Returns:    Nothing
        /// </summary>
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
        /// <summary>
        /// Method:     Shuffle(Stack<SingleCard> Maindeck)
        /// Purpose:    To shuffle the stack of card that have been created
        /// Parameters: Stack<SingleCard> Maindeck - the stack of card that have been created
        /// Returns:    Nothing
        /// </summary>
        static void Shuffle(Stack<SingleCard> Maindeck)
        {
            Stack<SingleCard> tempStack1 = new Stack<SingleCard>();
            Stack<SingleCard> tempStack2 = new Stack<SingleCard>();
            int indexSplit = rng.Next(0, 27);
            for (int i = 0; i < indexSplit; ++i)
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
        /// <summary>
        /// Method:     Deal(Stack<SingleCard> Deck,List<List<SingleCard>> player )
        /// Purpose:    To deal a card to earh player clockwise
        /// Parameters: Stack<SingleCard> Deck - the stack of cards created
        ///             List<List<SingleCard>> player - the list of players in the game
        /// Returns:    Nothing
        /// </summary>
        static void Deal(Stack<SingleCard> Deck,List<List<SingleCard>> player )
        {
            // deal each card in a clockwise to each player
            for (int w = 0; w < 5; ++w)
                for (int i = 0; i < 4; ++i)
                    player[i].Add(Deck.Pop());
        }
        /// <summary>
        /// Method:     ScoreHand(List<SingleCard> Hand, List<PokerRank> Score)
        /// Purpose:    To score the player hand
        /// Parameters: List<SingleCard> Hand - player hand
        ///             List<PokerRank> Score - player score
        /// Returns     Nothing
        /// </summary>
        static void ScoreHand(List<SingleCard> Hand, List<PokerRank> Score)
        {
            if (PairCount(Hand) != 0)
            {
                // a switch case that assign the correct score to the play with the correct amount of pair
                switch(PairCount(Hand))
                {
                    case 6:
                        Score.Add(PokerRank.Four_of_a_kind);
                        break;
                    case 4:
                        Score.Add(PokerRank.FullHouse);
                        break;
                    case 3:
                        Score.Add(PokerRank.Three_of_a_kind);
                        break;
                    case 2:
                        Score.Add(PokerRank.TwoPairs);
                        break;
                    case 1:
                        Score.Add(PokerRank.Pair);
                        break;
                }
            }
            // else there isn't any pair then check for straight and flush
            else if (checkFlush(Hand) && checkStraight(Hand))
            {
                Score.Add(PokerRank.StraightFlush);
            }
            else if (checkFlush(Hand))
            {
                Score.Add(PokerRank.Flush);
            }
            else if (checkStraight(Hand))
            {
                Score.Add(PokerRank.Straight);
            }
            else
            {
                // if there is not straight or/and flush then its nothing
                Score.Add(PokerRank.Nothing);
            }
        }
        /// <summary>
        /// Method:     PairCount(List<SingleCard> Hand)
        /// Purpose:    To count the numbers of pair in the player hand
        /// Parameters: List<SingleCard> Hand - Player hand
        /// Returns:    The number of pair in the hand
        /// </summary>
        static int PairCount(List<SingleCard> Hand)
        {
            int count = 0;
            for (int i = 0; i < 5; ++i)
                for (int w = i + 1; w < 5; ++w)
                {
                    // check for each card if it is a pair and add to the count
                    if (Hand[i].s_CardValue == Hand[w].s_CardValue)
                    {
                        count++;
                    }
                }
            return count;
        }
        /// <summary>
        /// Method:     checkFlush(List<SingleCard> Hand)
        /// Purpose:    to check if there is a flush in player hand
        /// Parameters: List<SingleCard> Hand - player hand
        /// Returns:    if there is a flush in the hand
        /// </summary>
        static bool checkFlush(List<SingleCard> Hand)
        {
            bool check = true;
            for (int i = 0; i < 5; ++i)
                for (int w = i + 1; w < 5; ++w)
                {
                    // this conditional statement check if each card is a suit that match, if one is not then the out result will be false
                    // else all the card must be suit
                    check = (Hand[i].s_CardSuit == Hand[w].s_CardSuit) ? check : false;
                }
            return check;
        }
        /// <summary>
        /// Method:     checkStraight(List<SingleCard> Hand)
        /// Purpose:    Check if there is a Straight in hand
        /// Parameters: List<SingleCard> Hand - player hand
        /// Returns:    if there is a Straight
        /// </summary>
        static bool checkStraight(List<SingleCard> Hand)
        {
            // temp hand to not alter the main hands of the players
            List<SingleCard> temphand = new List<SingleCard>();
            temphand = Hand;
            //Create a temp card for sorting
            SingleCard tempcard = new SingleCard();
            bool check = false;
            do
            {
                check = false;
                //for the first card in the hand
                for (int i = 0; i < 5; ++i)
                    //for the card ahead of the first card
                    for (int w = i + 1; w < 5; ++w)
                    {
                        //check if the hand have been alter
                         check = (temphand[i].s_CardValue > temphand[w].s_CardValue) ? true : check;
                         if(temphand[i].s_CardValue > temphand[w].s_CardValue)
                         {
                             tempcard = temphand[i];
                             temphand[i] = temphand[w];
                             temphand[w] = tempcard;
                         }
                    }
            //check if the hand have been sorted
            } while (check);
            //boolean to check if the total differnce of the hand is 4
            return (temphand[0].s_CardValue - temphand[4].s_CardValue) == 4;

        }

        static int ScorePlayers(List<PokerRank> Score)
        {
            int Winner = 0;
            for (int i = 0; i < 3; ++i)
                Winner = (Score[Winner] <= Score[i + 1]) ? i + 1 : Winner;
            return Winner;
        }
        static void Main(string[] args)
        {
            Stack<SingleCard> Deck = new Stack<SingleCard>();
            List<SingleCard> Hand;
            List<List<SingleCard>> player = new List<List<SingleCard>>();
            List<PokerRank> PlayerScore = new List<PokerRank>();
            
            Console.WriteLine("Phase One");
            Console.WriteLine("Creating Deck");
            CreateDeck(Deck);

            Console.WriteLine("Shuffling Deck");
            int shuffleIndex = rng.Next(50, 9001);
            for (int i = 0; i < shuffleIndex; ++i)
                Shuffle(Deck);

            Console.WriteLine("Seating Players");
            for (int i = 0; i < 4; ++i)
            {
                Hand = new List<SingleCard>();
                player.Add(Hand);
            }

            Console.WriteLine("Deal Cards");
            Deal(Deck, player);
            for (int i = 0; i < 4; ++i)
            {
                Console.WriteLine("\nPlayer{0} Hand:", i + 1);
                Console.WriteLine("----------------");
                foreach (SingleCard cards in player[i])
                    Console.WriteLine(cards.ToString());
            }
            Console.ReadKey();

            Console.WriteLine("\nPhase Two");
            Console.WriteLine("Checking Hands");
            for (int i = 0; i < 4; ++i)
            {
                ScoreHand(player[i], PlayerScore);
            }

            Console.WriteLine("Scoring");
            if (ScorePlayers(PlayerScore) == 0)
                Console.WriteLine("No Winner...");
            else
                Console.WriteLine("Winner is Player {0} with a {1}", ScorePlayers(PlayerScore) + 1,(PokerRank)PlayerScore[ScorePlayers(PlayerScore)]);
            Console.ReadKey();
        }
    }
}
