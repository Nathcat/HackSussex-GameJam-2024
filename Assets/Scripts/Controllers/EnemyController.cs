using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Combatant
{
    override public void startTurn() {
        base.chosenCard = base.getDeck()[
            Random.Range(0, base.getDeck().Length - 1)
        ];

        // Do stuff here ...
    }

    override public void endTurn() {
        // Do UI stuff here ...

        base.endTurn();
    }
}
