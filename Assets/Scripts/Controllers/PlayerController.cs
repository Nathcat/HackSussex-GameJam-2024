using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Combatant
{
    override public void startTurn() {
        base.startTurn();

        if (base.getDeck().Length == 0) {
            base.createDeck(fightController.playerCardSet, 7);
        }

        // Do UI stuff here ...
    }

    override public void endTurn() {
        // Do UI stuff here ...

        base.endTurn();
    }
}
