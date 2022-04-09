using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusSlider : MonoBehaviour
{
    public Slider sliderval;
    public float slidervalint;
    public Text green;
    public Text red;
    public Text blue;
    public Text big;
    // Start is called before the first frame update
    void Start()
    {
        sliderval.value = PlayerPrefs.GetFloat("bonus_factor");
    }

    // Update is called once per frame
    void Update()
    {
        slidervalint = sliderval.value;
        PlayerPrefs.SetFloat("bonus_factor", slidervalint);
        green.text = ""+(5 * slidervalint);
        red.text = "" + (15 * slidervalint);
        blue.text = "" + (10 * slidervalint);
        big.text = "" + (30 * slidervalint);
    }
}
