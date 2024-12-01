using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowIconScript : MonoBehaviour
{
    [SerializeField] private SpriteRenderer shownIcon;
    [SerializeField] private EnemyController combatant;
    // Update is called once per frame
    


    public void ChangeIcon(Card nextcard)
    {
        shownIcon.sprite = nextcard.GetIcon();
    }

    public void Update(){
        if(combatant.CompareTag("dead")){
            shownIcon.sprite.enabled = false;
        }
    }
}
