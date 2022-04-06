using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TopBrick : MonoBehaviour
{
    public GameObject[] EndUI;
    GameManager gM;
    // Start is called before the first frame update
    void Start()
    {
        gM = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        gM.EndGame();
    }
        
}
