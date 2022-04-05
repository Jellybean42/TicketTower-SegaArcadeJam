using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost : MonoBehaviour
{
    Vector2 targ;

    // Start is called before the first frame update
    void Start()
    {
        targ = Random.insideUnitCircle.normalized * 100;
        while(targ.y < 0)
        {
            targ = Random.insideUnitCircle.normalized * 100;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.up = targ;
        transform.localPosition += transform.up * 5 * Time.deltaTime;
    }
}
