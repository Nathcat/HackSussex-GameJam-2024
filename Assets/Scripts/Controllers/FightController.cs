using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightController : MonoBehaviour
{
    public Card[] playerCardSet;
    public Card[] enemyCardSet;

    public Combatant[] combatants;
    public int currentCombatant = 0;

    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public Vector3 playerSpawnPosition;
    public Vector3[] enemySpawnPositions;

    public void Start() {
        int enemyCount = Random.Range(1, 3);
        combatants = new Combatant[enemyCount + 1];

        combatants[0] = Instantiate(
            playerPrefab,
            playerSpawnPosition,
            new Quaternion() 
        ).GetComponent<Combatant>();

        for (int i = 1; i < enemyCount + 1; i++) {
            combatants[i] = Instantiate(
                enemyPrefab,
                enemySpawnPositions[i - 1],
                new Quaternion()
            ).GetComponent<Combatant>();
        }
    }

    public void playTurn() {
        combatants[currentCombatant].startTurn();
    }

    public void nextTurn() {
        currentCombatant = (currentCombatant + 1) % combatants.Length; 
    }
}
