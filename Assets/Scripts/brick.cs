using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brick : MonoBehaviour
{
    GameManager gM;
    public float value;
    // Start is called before the first frame update
    void Start()
    {
        gM = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, Vector3.zero) > 50)
        {
            Destroy(gameObject);
            Debug.Log("Got a brick");
            gM.IncreaseScore(value);
        }
    }
}
