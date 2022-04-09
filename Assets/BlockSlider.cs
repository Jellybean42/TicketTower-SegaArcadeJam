using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockSlider : MonoBehaviour
{
    public Slider sliderval;
    public float slidervalint;
    public Text side;
    public Text center;

    // Start is called before the first frame update
    void Start()
    {
        sliderval.value = PlayerPrefs.GetFloat("block_factor");
    }

    // Update is called once per frame
    void Update()
    {
        slidervalint = sliderval.value;
        PlayerPrefs.SetFloat("block_factor", slidervalint);
        side.text = "" + (2 * slidervalint);
        center.text = "" + (1 * slidervalint);
    }
}
