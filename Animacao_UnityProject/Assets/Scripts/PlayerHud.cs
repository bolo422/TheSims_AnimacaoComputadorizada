using System;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts
{
    public class PlayerHud : MonoBehaviour
    {
        private static PlayerHud _instance;
        public static PlayerHud Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<PlayerHud>();
                }
                return _instance;
            }
        }
        
        [SerializeField] private GameObject _interactText;

        public String InteractText
        {
            get => _interactText.GetComponentInChildren<Text>().text;
            set
            {
                _interactText.GetComponentInChildren<Text>().text = value;
                if(value != "")
                {
                    _interactText.SetActive(true);
                }
                else
                {
                    _interactText.SetActive(false);
                }
            }
        }

        private void Awake()
        {
            _instance = this;
        }

        private void Start()
        {
            InteractText = "";
            
            float hungerValue = GameManager.Instance.Motives[MotiveType.Hunger].Value;
            
        }
    }
}