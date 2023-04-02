using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
   public Slider Slider;
   public Gradient gradient;
   public Image fill;
   public AudioClip MiniHeart;

    public void SetMaxHealth(int health)
    {   Slider.maxValue = health;
        Slider.value = health;
        fill.color = gradient.Evaluate(1f);
    
    }
   public void SetHealth(int health)
    { Slider.value = health;
      fill.color = gradient.Evaluate(Slider.normalizedValue);

    }

}
