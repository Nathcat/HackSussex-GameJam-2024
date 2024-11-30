using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a combatant in a fight.
/// May be the player, or an enemy, see EnemyController and PlayerController.
/// </summary>
public class Combatant : MonoBehaviour
{
    private Card[] deck;
    private int health;
    private int energy;
    private int defence;
    public Card chosenCard;

    /// <summary>
    /// Create a new deck for this combatant, erasing the old deck if one existed
    /// </summary>
    public void createDeck() {
        Debug.LogError("Not implemented!");
    }

    /// <summary>
    /// Get the deck of this combatant
    /// </summary>
    /// <returns>An array of cards representing this combatant's deck</returns>
    public Card[] getDeck() { return deck; }

    public int getHealth() { return health; }

    /// <summary>
    /// Change the value of health by delta
    /// </summary>
    /// <param name="delta">The value to change this combatant's health by, can be +ve or -ve</param>
    public void updateHealth(int delta) { 
        if (delta < 0) {
            defence += delta;
            
            if (defence < 0) {
                health += defence;
                defence = 0;
            }
        }
        else {
            health += delta;
        }
    }

    public int getDefence() { return defence; }
    public void updateDefence(int delta) { defence += delta; }

    public int getEnergy() { return energy; }

    /// <summary>
    /// Change the value of energy by delta
    /// </summary>
    /// <param name="delta">The value to change this combatant's health by, can be +ve or -ve</param>
    public void updateEnergy(int delta) { energy += delta; }

    /// <summary>
    /// Use the specified card on the target combatant
    /// </summary>
    /// <param name="card">The card to play</param>
    /// <param name="target">Who to target with the card</param>
    public void playCard(Card card, Combatant target) {
        Debug.LogError("Not implemented!");
    }

    virtual public void startTurn() {
        throw new NotImplementedException();
    }

    virtual public void endTurn() {
        FightController c = GameObject.Find("FightController").GetComponent<FightController>();
        c.nextTurn();
    }
}
