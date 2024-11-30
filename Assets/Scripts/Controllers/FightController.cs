using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightController : MonoBehaviour
{
    public Card[] playerCardSet;
    public Card[] enemyCardSet;

    public List<Combatant> combatants;
    public int currentCombatant = 0;

    public GameObject enemyPrefab;
    public Vector3[] enemySpawnPositions;

    public void Start() {
        int enemyCount = Random.Range(1, 3);
        combatants = new List<Combatant>();

        combatants.Add(FindObjectOfType<PlayerController>());

        for (int i = 1; i < enemyCount + 1; i++) {
            combatants.Add(Instantiate(
                enemyPrefab,
                enemySpawnPositions[i - 1],
                new Quaternion()
            ).GetComponent<Combatant>());
        }

        playTurn();
    }

    public void playTurn() {
        combatants[currentCombatant].startTurn();
    }

    public void nextTurn() {
        currentCombatant = (currentCombatant + 1) % combatants.Count; 
        
        playTurn();
    }

    public void endPlayerTurn() {
        combatants[0].endTurn();
    }
}
