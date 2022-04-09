using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brick : MonoBehaviour
{
    GameManager gM;
    public int value;
    Material mat;
    public int family;
    spawnghost ghostSpawner;
    AudioSource aS;
    public AudioClip[] ghostnoises;
    // Start is called before the first frame update
    void Start()
    {
        gM = FindObjectOfType<GameManager>();
        mat = GetComponent<Material>();
        ghostSpawner = FindObjectOfType<spawnghost>();
        aS = GetComponentInParent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z), Vector3.zero) > 10)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position*2, 2f * Time.deltaTime);
        }
        if (Vector3.Distance(transform.position, Vector3.zero) > 50)
        {
            Destroy(gameObject);
            ghostSpawner.SpawnGhost(family);
            Debug.Log("Got a brick");
            gM.IncreaseScore(value, family);
            aS.clip = ghostnoises[Random.Range(0, ghostnoises.Length)];
            aS.Play();
        }
    }
}
