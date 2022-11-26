using UnityEngine;

namespace Scripts
{
    public class Motive
    {
        private MotiveType _motiveType;
        private float _value;
        private int _minValue = 0;
        private int _maxValue = 100;

        public Motive(MotiveType motiveType)
        {
            _motiveType = motiveType;
            _value = _maxValue;
        }
        
        public MotiveType MotiveType
        {
            get => _motiveType;
            set => _motiveType = value;
        }

        public float Value
        {
            get => _value;
        }
        
        
        public bool AddValue(float value)
        {
            _value += value;
            if (_value > _maxValue)
            {
                _value = _maxValue;
                return true;
            }
            if(_value < _minValue)
            {
                _value = _minValue;
                return true;
            }
            return false;
        }

        public int MinValue => _minValue;

        public int MaxValue => _maxValue;
    }
}