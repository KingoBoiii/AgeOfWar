using KingoBoiii.AgeOfWarClone.UI;
using KingoBoiii.AgeOfWarClone.Units;
using UnityEngine;

namespace KingoBoiii.AgeOfWarClone
{

    internal class UnitData : IUnitData
    {
        public string Name => "Caveman";
        public Sprite Sprite => throw new System.NotImplementedException();
    }

    [System.Serializable]
    internal sealed class AgeUnit : IUnitData
    {
        [field: SerializeField] public string Name { get; set; }
        [field: SerializeField] public Sprite Sprite { get; set; }
    }

    [System.Serializable]
    internal sealed class Age
    {
        [field: SerializeField] public int Experience { get; set; }
        [field: SerializeField] public AgeUnit[] Units { get; set; }
    }

    [DisallowMultipleComponent]
    internal sealed class GameManager : MonoBehaviour
    {
        [SerializeField] private UnitBehaviour _unitPrefab;
        [SerializeField] private Transform _unitSpawnpoint;

        [SerializeField] private Age[] _ages;
        private Age _currentAge;

        private void Start()
        {
            _currentAge = _ages[0];

            UIManager.Instance.OnUnitBought += OnUnitBought;
            UIManager.Instance.SetupAgeUI(_currentAge);
        }

        private void OnUnitBought(IUnitData unitData)
        {
            var unit = Instantiate(_unitPrefab, _unitSpawnpoint.position, Quaternion.identity);
            if (unit == default)
            {
                return;
            }

            unit.Initialize(unitData);
        }
    }

}
