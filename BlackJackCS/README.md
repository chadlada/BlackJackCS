# BlackJackCS

(P) Problem =
The game should be played with a standard deck of playing cards (52).
The house should be dealt two cards, hidden from the player until the house reveals its hand.
The player should be dealt two cards, visible to the player.
The player should have a chance to hit (i.e. be dealt another card) until they decide to stop or they bust (i.e. their total is over 21). At which point they lose regardless of the dealer's hand.
When the player stands, the house reveals its hand and hits (i.e. draw cards) until they have 17 or more.
If dealer goes over 21 the dealer loses.
The player should have two choices: "Hit" and "Stand."
Consider Aces to be worth 11, never one.
The app should display the winner. For this mode, the winner is who is closer to a blackjack (21) without going over.
Ties go to the DEALER.
There should be an option to play again. This should start a new game with a new full deck of 52 shuffled cards and new empty hands for the dealer and the player.

(E) Example

(D) Data =
Create a class or some way to represent a card
-a deck
-a rank (king , queen , numeric etc)
-a suit
Create a collection for the players cards and the dealers
Create a method to calculate the numeric value of "hand"
Determine if the hand is over 21
Create a method to display the cards in a hand (possibly for the advanced version only)
Create a method to get a new card from the dealer by rolling a random number from 2 to 14 with 11 representing a jack 12 a queen 13 - king and 14 Ace

(A) Algorithm

build a Deck that has all 52 cards of combination of all the ranks and suits
When the game starts we will get 2 new cards for the player and 2 for the dealer
Display the dealers second card to the player
Total the players cards and display them
Ask the Player to type H for hit or S for stay
Accept a uppercase or lower case response
If the player chooses to "hit" another card will be drawn and the loop will continue until the player stays or busts
After the player decides to "stay" the dealer's turn will commence
The dealer will follow Standard black jack rules
When the dealer has served every player
The dealer's face-down card is turned up
If the total is 17 or more, the dealer must stand.
If the total is 16 or under, the dealer must hit.
The dealer must continue to take cards until the total is 17 or more, at which point the dealer must stand.
When the dealer stands, or busts the game is over.
If the dealer busts, the player wins
If the dealer does not bust, the total of the two hands is compared and the person with the highest total wins.
Ask the Player to quit or play again

Explorer Mode (Problem)
General Rules:
The game should be played with a standard deck of playing cards (52).
The house should be dealt two cards, hidden from the player until the house reveals its hand.
The player should be dealt two cards, visible to the player.
The player should have a chance to hit (i.e. be dealt another card) until they decide to stop or they bust (i.e. their total is over 21). At which point they lose regardless of the dealer's hand.
When the player stands, the house reveals its hand and hits (i.e. draw cards) until they have 17 or more.
If dealer goes over 21 the dealer loses.
The player should have two choices: "Hit" and "Stand."
Consider Aces to be worth 11, never one.
The app should display the winner. For this mode, the winner is who is closer to a blackjack (21) without going over.
Ties go to the DEALER.
There should be an option to play again. This should start a new game with a new full deck of 52 shuffled cards and new empty hands for the dealer and the player.
