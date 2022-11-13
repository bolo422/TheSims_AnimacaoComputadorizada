using System;
using UnityEngine;

namespace Scripts
{
    public abstract class Interactable : MonoBehaviour
    {
        public abstract void Interact();

        private void OnTriggerEnter(Collider other)
        {
            PlayerHud.Instance.InteractText.text = "Pressione E para interagir com " + gameObject.name;
            PlayerInteractController.Instance.CurrentInteractable = this;
        }
        
        private void OnTriggerExit(Collider other)
        {
            PlayerHud.Instance.InteractText.text = "";
            PlayerInteractController.Instance.CurrentInteractable = null;
        }
    }
}