using UnityEngine;

namespace Scripts
{
    public class Motive
    {
        private MotiveType _motiveType;
        private float _value;
        private int _minValue;
        private int _maxValue;

        public Motive(MotiveType motiveType)
        {
            _motiveType = motiveType;
            _value = 100;
        }
        
        public MotiveType MotiveType
        {
            get => _motiveType;
            set => _motiveType = value;
        }

        public float Value
        {
            get => _value;
            set => this._value = value; //Mathf.Clamp(value, _minValue, _maxValue);
        }
    }
}