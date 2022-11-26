using System;
using System.Collections;
using System.Collections.Generic;
using Scripts;
using UnityEngine;
using UnityEngine.UI;

public class MotivesHUD : MonoBehaviour
{
    [SerializeField] private Slider energy;
    [SerializeField] private Slider hunger;
    [SerializeField] private Slider bladder;
    [SerializeField] private Slider hygiene;

    private Dictionary<MotiveType, Motive> _motives;

    private void Start()
    {
        _motives = GameManager.Instance.Motives;
    }

    private void Update()
    {
        energy.value = _motives[MotiveType.Energy].Value;
        hunger.value = _motives[MotiveType.Hunger].Value;
        bladder.value = _motives[MotiveType.Bladder].Value;
        hygiene.value = _motives[MotiveType.Hygiene].Value;
    }
}
