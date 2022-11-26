using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOtherAnimation : MonoBehaviour
{
    [SerializeField] private Animator otherObjectAnimator;
    [SerializeField] private string animationName;

    public void Activate()
    {
        otherObjectAnimator.Play(animationName);
    }
}
