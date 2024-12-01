using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Represents a combatant in a fight.
/// May be the player, or an enemy, see EnemyController and PlayerController.
/// </summary>
public class Combatant : MonoBehaviour
{
    private List<Card> deck = new List<Card>();
    [SerializeField] private int health;
    [SerializeField] private int energy;
    [SerializeField] private int defence;
    [HideInInspector] public Card chosenCard;
    [HideInInspector] public FightController fightController;

    public void Awake() {
        fightController = FindObjectOfType<FightController>();
    }

    virtual public void Start() {}

    /// <summary>
    /// Create a new deck for this combatant, erasing the old deck if one existed
    /// </summary>
    virtual public void createDeck(Card[] set, int count) {
        deck = new List<Card>();
        
        for (int i = 0; i < count; i++) {

            deck.Add(
                set[UnityEngine.Random.Range(0, set.Length)]
            );
        }
    }

    /// <summary>
    /// Get the deck of this combatant
    /// </summary>
    /// <returns>An array of cards representing this combatant's deck</returns>
    public Card[] getDeck() { return deck.ToArray(); }

    public Card getChosenCard() { return chosenCard; }

    public int getHealth() { return health < 0 ? 0 : health; }

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
        card.Play(target);
        deck.Remove(card);
    }

    virtual public void startTurn() {
        defence = 0;

        Debug.Log(name + " has started their turn!");
    }

    virtual public void endTurn() {
        Debug.Log(name + " has ended their turn!");

        if (getHealth() == 0) {
            fightController.combatants.RemoveAt(fightController.currentCombatant);
            gameObject.tag = null;
            Debug.Log(name + " is dead!");

            if (fightController.currentCombatant == 0) {
                SceneManager.LoadScene("GameOver");
            }
            else {
                if (fightController.combatants.Count == 1 && fightController.combatants[0].getHealth() != 0) {
                    SceneManager.LoadScene("GraphScene");
                }
                else {
                    SceneManager.LoadScene("GameOver");
                }
            }
        }
        
        chosenCard = null;
        fightController.nextTurn();
    }
}
