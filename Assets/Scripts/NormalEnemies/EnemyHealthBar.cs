using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider slider;
    public Color low;
    public Color high;
    public Vector3 offset;

    void Start(){
        slider.gameObject.SetActive(false);
    }

    public void SetHealth(float health, float maxHealth)
    {
        if(health < maxHealth)
        {
            slider.gameObject.SetActive(true);

        }
        
        slider.value = health;
        slider.maxValue = maxHealth;

        slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, slider.normalizedValue);
    }
    
    void Update()
    {
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
    }
}
