using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject cred;
    // Start is called before the first frame update
    void Start()
    {
        cred.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void play() 
    {
        SceneManager.LoadScene("GraphScene");
    }

    public void settings() 
    {
        cred.SetActive(true);
    }

    public void exit() 
    {
        Application.Quit();
    }
    public void back() { cred.SetActive(false); }
}
