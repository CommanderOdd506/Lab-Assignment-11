using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CardGame : MonoBehaviour
{
    private List<string> deck = new List<string>();
    private List<string> hand = new List<string>();

    private int handSize = 4;

    private string[] honorCards = { "K", "Q", "J", "A" };
    private string[] suits = { "\u2660", "\u2663", "\u2665", "\u2666" };

    void Start()
    {
        InitializeDeck();
        InitializeHand();
        SimulateGame();
    }

    void InitializeDeck()
    {
        for (int i = 0; i < suits.Length; i++)
        {
            for (int j = 0; j < honorCards.Length; j++)
            {
                string card = honorCards[j] + suits[i];
                deck.Add(card);
            }
        }
        ShuffleDeck();
        Debug.Log(string.Join(", ", deck));
    }

    bool HasWinningHand()
    {
        var groups = hand.GroupBy(card => card[card.Length - 1]);

        foreach (var group in groups)
        {
            if (group.Count() >= 3)
            {
                return true;
            }
        }

        return false;
    }


    void InitializeHand()
    {
        for (int i = 0;i < handSize;i++)
        {
            hand.Add(deck[0]);
            deck.RemoveAt(0);
        }

        Debug.Log("My Hand: " + string.Join(", ", hand));
    }

    void ShuffleDeck()
    {
        deck = deck.OrderBy(x => Random.value).ToList();
    }

    string CurrentHand()
    {
        return string.Join(", ", hand);
    }

    void SimulateGame()
    {
        bool won = false;
        while (true) 
        { 
            if(HasWinningHand())
            {
                Debug.Log("My hand is: " + CurrentHand() + ". The game is WON.");

                break;
            }

            if (deck.Count <= 0)
            {
                Debug.Log("The deck is empty. The game is LOST");
                break;
            }

            int discardIndex = Random.Range(0, handSize);
            string discardedCard = hand[discardIndex];
            hand.RemoveAt(discardIndex);

            string addedCard = deck[0];
            hand.Add(deck[0]);
            deck.RemoveAt(0);

            if(HasWinningHand())
            {
                Debug.Log($"I discarded {discardedCard} and drew {addedCard}. My hand is: {CurrentHand()}. The game is WON.");
                break;
            }
            else
            {
                Debug.Log($"I discarded {discardedCard} and drew {addedCard}. My hand is: {CurrentHand()}. This is not a winning hand. I will attempt to play another round");
            }
        }

    }
}
