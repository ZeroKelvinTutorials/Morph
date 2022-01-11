using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetValueFromSlider : MonoBehaviour
{
    Text myText;
    public Slider mySlider;
    void Start()
    {
        myText = this.GetComponent<Text>();
    }
    void Update()
    {
        mySlider.value = mySlider.value + .001f;
        if(mySlider.value >.99f)
        {
            myText.text = mySlider.value.ToString("#");
        }
        else
        myText.text = mySlider.value.ToString("#.00");

        // myText.text = mySlider.value.ToString();
    }
}
