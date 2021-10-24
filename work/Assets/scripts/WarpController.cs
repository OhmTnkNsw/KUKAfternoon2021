using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //โหลด scene

public class WarpController : MonoBehaviour
{
    public string sceneName;
    public AudioSource WarpSound;
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player") ;//เช็คว่าคนเหยียบเป็น Play หรือป่าว
        {
            Invoke("LoadNextScene", 0.6f);
               if (WarpSound != null)
            { 
                WarpSound.Play();
            }
               
;        }
    }
    void LoadNextScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
