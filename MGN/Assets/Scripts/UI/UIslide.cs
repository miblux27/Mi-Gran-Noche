using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIslide : MonoBehaviour
{
    public Slider sliderTime;
    public Image ImageSlide;
    [Range (0,0.5f)] public float gama = 45f;
    private const float invertir = 1f;

    private void Update()
    {
        if (CharacterController2D.time < CharacterController2D.cooldownTime)
        {
            sliderTime.value = invertir - (float)CharacterController2D.time / CharacterController2D.cooldownTime;
            if (ImageSlide.color != Color.red)
            {
                Color colorFinal = Color.red;
                colorFinal.a = gama;
                ImageSlide.color = colorFinal;
            } 
        }
        else
        {
            sliderTime.value = invertir;
            if (ImageSlide.color != Color.white)
            {
                Color colorFinal = Color.white;
                colorFinal.a = gama;
                ImageSlide.color = colorFinal;
            }
        }
    }

}
