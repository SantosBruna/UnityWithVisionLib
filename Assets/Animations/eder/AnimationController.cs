using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AnimationController : MonoBehaviour
{
    // Referência ao componente Animator
    public Animator animator;
    public Slider slider;

    public void animationSpeed()
    {
        animator.speed = slider.value;
    }


    void Start()
    {
        // Toca a animação "AnimationName"
        animator.Play("AnimationName");
        animationSpeed();
    }
}
