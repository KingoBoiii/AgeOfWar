using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace KingoBoiii.AgeOfWarClone
{

    internal enum BaseAge
    {
        Stone,
        Medieval,
        Renaissance,
        Modern,
        Future
    }

    [DisallowMultipleComponent]
    public sealed class Base : MonoBehaviour
    {
        [System.Serializable]
        internal class BaseAgeData
        {
            [field: SerializeField] public BaseAge Age { get; set; }
            [field: SerializeField] public Sprite BaseGfx { get; set; }
        }

        [System.Serializable]
        internal class BaseData
        {
            [field: SerializeField] public UnitMoveDirection UnitMoveDirection { get; set; }
            [field: SerializeField] public BaseAgeData[] Ages { get; set; }
        }


        [SerializeField] private bool _allowAgeWrapAround = true;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] BaseAge _currentAge = BaseAge.Stone;
        [SerializeField] private BaseData _data;

        private IDictionary<BaseAge, BaseAgeData> _baseAgeDataMap;

        private void Start()
        {
#if !UNITY_EDITOR
            _allowAgeWrapAround = false;
#endif

            _baseAgeDataMap = _data.Ages.ToDictionary(k => k.Age);
        }

        public void SpawnUnit()
        {
        }

        public void AgeUp()
        {
            if (!_allowAgeWrapAround && _currentAge == BaseAge.Future)
            {
                return;
            }

            _currentAge++;
            if (_allowAgeWrapAround)
            {
                _currentAge = (BaseAge)(((int)_currentAge) % (int)(BaseAge.Future + 1));
            }

            _spriteRenderer.sprite = _baseAgeDataMap[_currentAge].BaseGfx;
        }
    }

}
