using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Combatant
{
    override public void startTurn() {
        // Do UI stuff here ...
    }

    override public void endTurn() {
        // Do UI stuff here ...

        base.endTurn();
    }
}
