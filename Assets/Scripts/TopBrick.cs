using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TopBrick : MonoBehaviour
{
    AudioSource aS;
    GameManager gM;
    bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        gM = FindObjectOfType<GameManager>();
        aS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        if(!gameOver)
        {
            aS.Play();

            gM.EndGame();

            gameOver = true;
        }
        
        
    }

        
}
