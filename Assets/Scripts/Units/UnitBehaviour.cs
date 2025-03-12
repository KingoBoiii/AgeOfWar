using UnityEngine;

namespace KingoBoiii.AgeOfWarClone.Units
{

    [DisallowMultipleComponent]
    internal sealed class UnitBehaviour : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private IUnitData _unitData;
        private UnitMovement _movement;

        internal void Initialize(IUnitData unitData)
        {
            _unitData = unitData;

        }

        private void Start()
        {
            gameObject.name = $"Unit ({_unitData.Name})";
            _spriteRenderer.sprite = _unitData.Sprite;

            Debug.Assert(TryGetComponent(out _movement));
            _movement.Initialize(UnitMoveDirection.Right);
        }
    }

}
