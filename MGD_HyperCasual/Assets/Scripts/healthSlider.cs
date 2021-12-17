using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthSlider : MonoBehaviour
{

    public Slider slider;


    // Start is called before the first frame updat

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealthBar(float health)
    {
        slider.value = health;
    }
}
