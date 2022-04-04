using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getBrickFace : MonoBehaviour
{
    brick parent;

    public Sprite[] faces;

    SpriteRenderer sR;

    // Start is called before the first frame update
    void Start()
    {
        sR = GetComponent<SpriteRenderer>();
        parent = GetComponentInParent<brick>();
        if (parent.family >= 0)
        {
            sR.sprite = faces[parent.family];
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
