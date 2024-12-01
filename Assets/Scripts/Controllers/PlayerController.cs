using System.Linq;
using UnityEngine;

public class PlayerController : Combatant
{
    public HandOrganiser hand;
    [SerializeField] private AudioClip newDeckSound;
    private bool skipping;

    override public void startTurn() {
        base.startTurn();

        if (getDeck().Length == 0) {
            base.createDeck(fightController.playerCardSet, 7);
            AudioSource.PlayClipAtPoint(newDeckSound, transform.position);
        }

        hand.Generate(getDeck().ToList());
        skipping = true;
    }

    public override void playCard(Card card, Combatant target)
    {
        base.playCard(card, target);
        skipping = false;
    }

    override public void endTurn() {
        // Do UI stuff here ...

        if (skipping) updateEnergy(baseEnergy / 2);

        base.endTurn();
    }
}
