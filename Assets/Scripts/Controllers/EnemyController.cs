using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Combatant
{    
    public Card nextCard;

    public void Start() {
        createDeck(fightController.enemyCardSet, 7);
        nextCard = base.getDeck()[
            Random.Range(0, base.getDeck().Length - 1)
        ];
        GetComponentInChildren<ShowIconScript>().ChangeIcon(nextCard);
    }

    override public void startTurn() {
        base.startTurn();

        if (base.getDeck().Length == 0) {
            createDeck(fightController.enemyCardSet, 7);
        }

        base.chosenCard = nextCard;
        nextCard = base.getDeck()[
            Random.Range(0, base.getDeck().Length - 1)
        ];
        if (base.chosenCard.IsSelf())
        {
            base.playCard(base.chosenCard, this);
        }
        else
        {
            base.playCard(base.chosenCard, fightController.combatants[0]);
        }

        // Show the chosen card here?
        GetComponentInChildren<ShowIconScript>().ChangeIcon(nextCard);

        endTurn();
    }

    override public void endTurn() {
        // Do UI stuff here ...

        base.endTurn();
    }
}
