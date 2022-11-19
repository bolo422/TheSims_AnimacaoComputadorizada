using Interactables;
using UnityEngine;

namespace Scripts
{
    public class PlayerInteractController : MonoBehaviour
    {
        private Interactable _currentInteractable;

        public Interactable CurrentInteractable
        {
            get => _currentInteractable;
            set => _currentInteractable = value;
        }
        
        private static PlayerInteractController _instance;
        public static PlayerInteractController Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<PlayerInteractController>();
                }
                return _instance;
            }
        }

        private void Awake()
        {
            _instance = this;
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (_currentInteractable != null)
                {
                    _currentInteractable.Interact();
                }
            }
        }
    }
}