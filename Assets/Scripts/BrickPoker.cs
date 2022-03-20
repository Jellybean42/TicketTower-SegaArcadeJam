using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickPoker : MonoBehaviour
{

    RaycastHit hit;
    float reloadTime = 0;
    public float timeToReload = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.localPosition += new Vector3(Input.GetAxis("Horizontal")/2, Input.GetAxis("Vertical")/2, 0);

        
    }

    private void Update()
    {
        reloadTime -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && reloadTime < 0)
        {
            reloadTime = timeToReload;
            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
            {
                if(hit.transform.tag != "TopBrick")
                {
                    hit.rigidbody.AddForce(transform.forward * 1000, ForceMode.Impulse);
                }
                
            }
            //Debug.DrawRay(transform.position, new Vector3(0, transform.position.y, 0) - transform.position, Color.magenta, 10f);
        }

        if (transform.localPosition.x > 1.25f)
        {
            transform.localPosition = new Vector3(1.25f, transform.localPosition.y, -3);
        }
        if (transform.localPosition.x < -1.25f)
        {
            transform.localPosition = new Vector3(-1.25f, transform.localPosition.y, -3);
        }

        if (transform.localPosition.y > 12f)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, 12, -3);
        }
        if (transform.localPosition.y < 0.5f)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, 0.5f, -3);
        }
    }
}
