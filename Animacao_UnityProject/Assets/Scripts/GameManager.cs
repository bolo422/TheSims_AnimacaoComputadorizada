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

    public int hyperMode;


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

    /*public void AddToMotiveValueByTime(Motive motive, float increment, float totalAmount, int multiplier, float incrementSplatter, bool infinite)
    {
        increment /= incrementSplatter;   
        Debug.Log("Started");
        StartCoroutine(AddToMotiveByTime(motive, increment, totalAmount, 0, infinite, multiplier));
    }*/

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

        if (motive.AddValue(increment * multiplier * hyperMode))
        {
            yield break;
        }
        
        if (totalincremented < totalAmount)
        {
            StartCoroutine(AddToMotiveByTime(motive, totalAmount, totalTime, multiplier, totalincremented));
        }
        else
        {
            Debug.Log("Finished");
        }
    }

    // tempo = (totalAmount / increment ) * 0.2f
    // x = (20 / 0,375) * 0.2f
    // 10,6 = (20 / x) * 0.2f
    // x = (20 / 10,6) * 0.2f
    
    /*private IEnumerator AddToMotiveByTime(Motive motive, float increment, float totalAmount, float totalIncremented, bool infinite, int multiplier) {
        yield return new WaitForSeconds(0.2f);
        totalIncremented+=increment;
        motive.Value += increment * multiplier;
        if (infinite || totalIncremented < totalAmount)
        {
            //Debug.Log("totalIncremented: " + totalIncremented);
            StartCoroutine(AddToMotiveByTime(motive, increment, totalAmount, totalIncremented, infinite, multiplier));
        }
        else
        {
        }
    }*/

    // public void AddToMotiveValue(Motive motive, int value)
    // {
    //     motive.Value += value;
    // }
}
