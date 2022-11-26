using System;
using Scripts;
using UnityEngine;

namespace Interactables
{
    public class Interactable : MonoBehaviour
    {
        public GameObject gripPoint;
        public String name;
        public MotiveType increaseMotive;
        public float increaseAmount;
        public int increaseTime;

        public MotiveType deceraseMotive;
        public float decreaseAmount;
        public int decreaseTime;

        [SerializeField] private float _animationTime;
        public float AnimationTime => _animationTime;

        [SerializeField] private String _animationName;
        public String AnimationName => _animationName;
        
        private void OnTriggerEnter(Collider other)
        {
            PlayerHud.Instance.InteractText = "Pressione E para interagir com " + name;
            PlayerInteractController.Instance.CurrentInteractable = this;
        }
        
        private void OnTriggerExit(Collider other)
        {
            PlayerHud.Instance.InteractText = "";
            PlayerInteractController.Instance.CurrentInteractable = null;
        }

        public void Interact()
        {
            GameManager.Instance.AddToMotiveValueByTime(
                GameManager.Instance.Motives[increaseMotive], 
                increaseAmount, 
                increaseTime, 
                true);
            
            GameManager.Instance.AddToMotiveValueByTime(
                GameManager.Instance.Motives[deceraseMotive], 
                decreaseAmount, 
                decreaseTime, 
                false);

            if (GetComponent<ActivateOtherAnimation>() != null)
            {
                GetComponent<ActivateOtherAnimation>().Activate();
            }
        }
    }
}