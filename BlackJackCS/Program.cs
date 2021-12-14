using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJackCS
{
    class Program
    {
        public class Card
        {
            public string Suit { get; set; }
            public string Name { get; set; }
            public int Value { get; set; }

            public Card(string suit, string name, int value)
            {
                Suit = suit;
                Name = name;
                Value = value;
            }

            public override string ToString()
            {
                return $"{Name} of {Suit}";
            }
        }

        public class Deck
        {
            public List<Card> Cards { get; set; } = new List<Card>();

            public Deck()
            {
                Cards = createShuffledDeck();
            }

            public List<Card> shuffleDeck(List<Card> cards)
            {
                Random rnd = new Random();
                List<Card> shuffledCards = cards.OrderBy(a => rnd.Next()).ToList();
                return shuffledCards;
            }

            public List<Card> createShuffledDeck()
            {
                string[] suits = { "hearts", "diamonds", "clubs", "spades" };
                string[] names = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "jack", "queen", "king", "ace" };
                List<Card> newDeck = new List<Card>();
                foreach (string suit in suits)
                {
                    for (int i = 0; i < 13; i++)
                    {
                        Card card;
                        if (names[i].Equals("jack") || names[i].Equals("queen") || names[i].Equals("king"))
                        {
                            card = new Card(suit, names[i], 10);
                        }
                        else if (names[i].Equals("ace"))
                        {
                            card = new Card(suit, names[i], 11);
                        }
                        else
                        {
                            card = new Card(suit, names[i], i + 2);
                        }
                        newDeck.Add(card);
                    }
                    Console.WriteLine(suit);
                }
                List<Card> newShuffledDeck = shuffleDeck(newDeck);
                return newShuffledDeck;
            }
        }

        static void Main(string[] args)
        {
            string again = "y";
            while (again.Equals("y"))
            {
                Program.newGame();
                // There should be an option to play again. This should start a new game with a new full deck of 52 shuffled cards and new empty hands for the dealer and the player.
                Console.WriteLine("Play again? (y/n)");
                again = Console.ReadLine();
            }
        }

        public static void newGame()
        {
            // The game should be played with a standard deck of playing cards (52).
            Deck freshDeck = new Deck();
            List<Card> houseCards = new List<Card>();
            int houseValue = 0;
            List<Card> playerCards = new List<Card>();
            int playerValue = 0;

            int deckIndex = 0;
            Boolean hit = true;
            string input;

            // The house should be dealt two cards, hidden from the player until the house reveals its hand.
            for (int i = 0; i < 2; i++)
            {
                houseCards.Add(freshDeck.Cards[deckIndex]);
                // houseCards.Add(freshDeck.Cards.ElementAt(deckIndex));
                houseValue = houseValue + freshDeck.Cards[deckIndex].Value;
                deckIndex++;
            }
            // The player should be dealt two cards, visible to the player.
            for (int i = 0; i < 2; i++)
            {
                playerCards.Add(freshDeck.Cards[deckIndex]);
                playerValue = playerValue + freshDeck.Cards[deckIndex].Value;
                deckIndex++;
            }
            Console.Write("startings cards are: ");
            foreach (Card card in playerCards)
            {
                Console.Write(card + ", ");
            }
            Console.WriteLine();
            Console.WriteLine("current hand value: " + playerValue);

            // The player should have a chance to hit (i.e. be dealt another card) until they decide to stop or they bust (i.e. their total is over 21). At which point they lose regardless of the dealer's hand.
            Console.WriteLine("hit or stand?: ");
            input = Console.ReadLine();
            if (input == null)
            {
                input = "";
            }

            if (input.Equals("stand"))
            {
                hit = false;
            }
            else if (input.Equals("hit"))
            {
                hit = true;
            }
            else
            {
                Console.WriteLine("Invalid input. Learn how to type. You're getting a card.");
            }
            while (hit)
            {
                playerCards.Add(freshDeck.Cards[deckIndex]);
                playerValue = playerValue + freshDeck.Cards[deckIndex].Value;
                deckIndex++;

                Console.Write("Current cards are: ");
                foreach (Card card in playerCards)
                {
                    Console.Write(card + ", ");
                }

                Console.WriteLine();
                Console.WriteLine("Current hand value: " + playerValue);

                if (playerValue > 21)
                {
                    Console.WriteLine("GET BUSTED BUSTA. YOU LOSE.");
                    string again = "y";
                    while (again.Equals("y"))
                    {
                        Program.newGame();
                        // There should be an option to play again. This should start a new game with a new full deck of 52 shuffled cards and new empty hands for the dealer and the player.
                        Console.WriteLine("Play again? (y/n)");
                        again = Console.ReadLine();
                    }
                }

                Console.Write("hit or stand?: ");
                input = Console.ReadLine();
                if (input == null)
                {
                    input = "";
                }
                if (input.Equals("stand"))
                {
                    hit = false;
                }
                else if (input.Equals(hit))
                {
                    hit = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Learn how to type. You're getting a card.");
                }
            }
            // When the player stands, the house reveals its hand and hits (i.e. draw cards) until they have 17 or more.
            Console.Write("Dealer cards are: ");
            foreach (Card card in houseCards)
            {
                Console.Write(card + ", ");
            }

            Console.WriteLine();
            Console.WriteLine("Dealer hand value: " + houseValue);

            if (houseValue >= 17)
            {
                if (houseValue >= playerValue)
                {
                    Console.WriteLine("DEALER WINS: " + houseValue + " to " + playerValue);
                }
                else
                {
                    Console.WriteLine("PLAYER WINS: " + playerValue + " to " + houseValue);
                }
            }
            else
            {
                while (houseValue < 21 && houseValue <= playerValue)
                {
                    houseCards.Add(freshDeck.Cards[deckIndex]);
                    houseValue = houseValue + freshDeck.Cards[deckIndex].Value;
                    deckIndex++;

                    Console.Write("Dealer cards are: ");
                    foreach (Card card in houseCards)
                    {
                        Console.Write(card + ", ");
                    }

                    Console.WriteLine();
                    Console.WriteLine("Dealer hand value: " + houseValue);

                    if (houseValue > 21)
                    {
                        Console.WriteLine("DEALER GOT BUSTED BUSTA. YOU WIN.");
                        break;
                    }
                }
                Console.WriteLine("PLAYER WINS: " + houseValue + " to " + playerValue);
            }
            // If dealer goes over 21 the dealer loses.
            // The player should have two choices: "Hit" and "Stand."
            // Consider Aces to be worth 11, never one.
            // The app should display the winner. For this mode, the winner is who is closer to a blackjack (21) without going over.
            // Ties go to the DEALER.
        }
    }
}