using System.Linq;
using UnityEngine;

public class PlayerController : Combatant
{
    [SerializeField] private HandOrganiser handPrefab;

    override public void startTurn() {
        base.startTurn();

        if (getDeck().Length == 0) {
            base.createDeck(fightController.playerCardSet, 7);
        }

        Instantiate(handPrefab).Generate(getDeck().ToList());
    }

    override public void endTurn() {
        // Do UI stuff here ...

        base.endTurn();
    }
}
