using System.Linq;
using UnityEngine;

public class PlayerController : Combatant
{
    [SerializeField] public HandOrganiser handPrefab;

    override public void startTurn() {
        base.startTurn();

        if (getDeck().Length == 0) {
            base.createDeck(fightController.playerCardSet, 7);
        }

        handPrefab.Generate(getDeck().ToList());
    }

    override public void endTurn() {
        // Do UI stuff here ...

        base.endTurn();
    }
}
