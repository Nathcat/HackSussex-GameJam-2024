using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Combatant
{    
    override public void startTurn() {
        base.startTurn();

        if (base.getDeck().Length == 0) {
            createDeck(fightController.enemyCardSet, 7);
        }

        base.chosenCard = base.getDeck()[
            Random.Range(0, base.getDeck().Length - 1)
        ];

        base.chosenCard.Play(
            fightController.combatants[0]
        );

        // Show the chosen card here?

        endTurn();
    }

    override public void endTurn() {
        // Do UI stuff here ...

        base.endTurn();
    }
}
