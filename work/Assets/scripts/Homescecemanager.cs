using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Homescecemanager : MonoBehaviour
{
    public void GoToplaygroung()
    {
        SceneManager.LoadScene("SampleScene");
     }
    public void ExitGame()
    {
        Application.Quit();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
