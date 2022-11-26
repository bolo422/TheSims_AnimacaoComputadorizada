using System;
using System.Collections;
using System.Collections.Generic;
using Scripts;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Dictionary<MotiveType, Motive> _motives;

    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }

    public Dictionary<MotiveType, Motive> Motives
    {
        get => _motives;
        set => _motives = value;
    }

    [SerializeField] private float HungerValue;
    [SerializeField] private float EnergyValue;
    [SerializeField] private float HygieneValue;
    [SerializeField] private float BladderValue;
    
    private bool fastMode;
    public void ToggleFastMode(){fastMode = !fastMode;}


    private void Awake()
    {
        _instance = this;
        _motives = new Dictionary<MotiveType, Motive>();
        _motives.Add(MotiveType.Hunger, new Motive(MotiveType.Hunger));
        _motives.Add(MotiveType.Energy, new Motive(MotiveType.Energy));
        _motives.Add(MotiveType.Hygiene, new Motive(MotiveType.Hygiene));
        _motives.Add(MotiveType.Bladder, new Motive(MotiveType.Bladder));
    }

    void Start()
    {
        //foreach (var motive in _motives) StartCoroutine(AddToMotiveByTime(motive.Value, 1.0f, 0, 10.0f, true));
    }

    private void Update()
    {
        HungerValue = _motives[MotiveType.Hunger].Value;
        EnergyValue = _motives[MotiveType.Energy].Value;
        HygieneValue = _motives[MotiveType.Hygiene].Value;
        BladderValue = _motives[MotiveType.Bladder].Value;
    }

    public void AddToMotiveValueByTime(Motive motive, float totalAmount, float totalTime, bool positive)
    {
        Debug.Log("Started");
        StartCoroutine(AddToMotiveByTime(motive, totalAmount, totalTime, positive ? 1 : -1, 0));
    }
    
    IEnumerator AddToMotiveByTime(Motive motive, float totalAmount, float totalTime, int multiplier, float totalincremented)
    {
        yield return new WaitForSeconds(0.2f);
        float increment = totalAmount / totalTime * 0.2f;
        totalincremented += increment;

        if (motive.AddValue(increment * multiplier * (fastMode ? 3 : 1)))
        {
            yield break;
        }
        if (totalincremented < totalAmount)
        {
            StartCoroutine(AddToMotiveByTime(motive, totalAmount, totalTime, multiplier, totalincremented));
        }
    }
}
