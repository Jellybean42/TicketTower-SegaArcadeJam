using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMScript : MonoBehaviour
{
    AudioSource aS;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        aS = GetComponent<AudioSource>();

        if( GameObject.FindGameObjectsWithTag("music").Length > 1)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(aS.volume < 0.5)
        {
            aS.volume += Time.deltaTime / 3;
        }
        
    }
}
