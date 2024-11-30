using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowIconScript : MonoBehaviour
{
    [SerializeField] private SpriteRenderer shownIcon;
    [SerializeField] private Combatant combatant;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //shownIcon.sprite = combatant.getChosenCard().GetIcon();
    }
}
