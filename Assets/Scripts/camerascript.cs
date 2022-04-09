using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerascript : MonoBehaviour
{
    GameManager gM;
    float rotSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        gM = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.Rotate(Vector3.up, (Mathf.RoundToInt(gM.scoreTotal/100) + 0.75f));

        transform.Rotate(Vector3.up, rotSpeed);
        if(gM.bricksRemoved == 5 && rotSpeed == 1f)
        {
            rotSpeed = 2f;
        }
        if (gM.bricksRemoved == 10 && rotSpeed == 2f)
        {
            rotSpeed = 3f;
        }
        if (gM.bricksRemoved == 15 && rotSpeed == 3.5f)
        {
            rotSpeed = 4f;
        }
    }
}
