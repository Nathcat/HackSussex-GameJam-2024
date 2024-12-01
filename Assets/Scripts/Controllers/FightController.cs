using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FightController : MonoBehaviour
{
    public Card[] playerCardSet;
    public Card[] enemyCardSet;

    public List<Combatant> combatants;
    public int currentCombatant = 0;

    public GameObject[] enemyPrefabs;
    public Vector3[] enemySpawnPositions;

    public GameObject handPrefabAsset;
    public GameObject handPrefab;

    public void Start() {
        int enemyCount = 3;
        combatants = new List<Combatant>();

        combatants.Add(FindObjectOfType<PlayerController>());

        for (int i = 1; i < enemyCount + 1; i++) {
            combatants.Add(Instantiate(
                enemyPrefabs[Random.Range(0, enemyPrefabs.Length - 1)],
                enemySpawnPositions[i - 1],
                new Quaternion()
            ).GetComponent<Combatant>());
        }

        handPrefab = Instantiate(handPrefabAsset);

        ((PlayerController)combatants[0]).hand = handPrefab.GetComponent<HandOrganiser>(); ;

        playTurn();
    }

    public void playTurn() {
        combatants[currentCombatant].startTurn();
    }

    public void nextTurn() {
        currentCombatant = (currentCombatant + 1) % combatants.Count;

        if (combatants[currentCombatant].getHealth() == 0) {
            if (currentCombatant == 0) {
                SceneManager.LoadScene("GameOver");
                return;
            }

            combatants.RemoveAt(currentCombatant);
            
            if (combatants.Count == 1) {
                PlayerPrefs.SetInt("AddFuel", Random.Range(3, 7));
                SceneManager.LoadScene("GraphScene");
            }

            if (currentCombatant == combatants.Count) currentCombatant = 0;
        }

        if (currentCombatant == 0) {
            if (combatants[0].getEnergy() == 0) {
                combatants[0].resetEnergy();
                currentCombatant = 1;
            }
        }
        
        playTurn();
    }

    public void endPlayerTurn() {
        combatants[0].endTurn();
    }
}
