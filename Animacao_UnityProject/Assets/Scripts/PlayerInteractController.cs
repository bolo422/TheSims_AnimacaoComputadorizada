using System.Collections;
using Interactables;
using UnityEngine;

namespace Scripts
{
    public class PlayerInteractController : MonoBehaviour
    {
        private Interactable _currentInteractable;

        private bool _canMove;
        public bool CanMove => _canMove;
        
        private CharacterController _characterController;
        private Animator _animator;

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
            _canMove = true;
            _characterController = GetComponent<CharacterController>();
            _animator = GetComponent<Animator>();
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (_currentInteractable != null && _canMove)
                {
                    _characterController.enabled = false;
                    transform.position = _currentInteractable.gripPoint.transform.position;
                    transform.rotation = _currentInteractable.gripPoint.transform.rotation;
                    _currentInteractable.Interact();
                    _animator.Play(_currentInteractable.AnimationName);
                    StartCoroutine(cantMoveCoroutine(_currentInteractable.AnimationTime));
                }
            }
        }

        IEnumerator cantMoveCoroutine(float time)
        {
            _canMove = false;
            yield return new WaitForSeconds(time+0.2f);
            _characterController.enabled = true;
            _canMove = true;
        }
    }
}