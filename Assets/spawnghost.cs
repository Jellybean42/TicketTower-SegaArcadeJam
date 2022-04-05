using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnghost : MonoBehaviour
{
    public Sprite[] gSprites;
    public GameObject ghost;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnGhost(int family)
    {
        GameObject newGhost = Instantiate(ghost, Vector3.up, Quaternion.identity, Camera.main.transform);
        newGhost.GetComponent<SpriteRenderer>().sprite = gSprites[Random.Range(0, 6)];
    }
}
