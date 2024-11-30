using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Combatant
{
    /// <summary>
    /// Choose a card randomly from the deck
    /// </summary>
    /// <returns>A randomly chosen card from the deck</returns>
    /// <exception cref="DeckIsEmptyException">Thrown when the deck is empty</exception>
    override public void chooseCard() {
        if (base.getDeck().Length == 0) {
            throw new DeckIsEmptyException();
        }
        
        base.chosenCard = base.getDeck()[
            Random.Range(0, base.getDeck().Length - 1)
        ];
    }
}
