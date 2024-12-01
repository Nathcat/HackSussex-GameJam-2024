using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class helpMenu : MonoBehaviour


{
    public GameObject help_menu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void help() {
        help_menu.SetActive(true);
    }

    public void rn() {
        help_menu.SetActive(false);
    }
    // Update is called once per frame

}
