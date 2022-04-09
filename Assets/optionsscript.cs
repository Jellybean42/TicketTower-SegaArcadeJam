using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class optionsscript : MonoBehaviour
{
    bool page = true;
    public GameObject options;
    public GameObject data;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextPageClick()
    {
        page = !page;
        options.SetActive(page);
        data.SetActive(!page);
    }
}
