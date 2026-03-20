using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalUI : MonoBehaviour
{
    public Animal animal;

    public List<Image> hearts;

    public Sprite fullHeartSprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      

    }

    // Update is called once per frame
    void Update()
    {
        
        if (animal.happiness > 0 && animal.happiness <= 5)
        {
            hearts[animal.happiness - 1].sprite = fullHeartSprite;
        }
    }
}
