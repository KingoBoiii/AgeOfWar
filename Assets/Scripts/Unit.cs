using UnityEngine;

namespace KingoBoiii.AgeOfWarClone
{

    public interface IUnitData
    {
        string Name { get; }
        Sprite Sprite { get; }
    }

    [DisallowMultipleComponent]
    internal sealed class Unit : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private IUnitData UnitData { get; set; }

        public void Initialize(IUnitData unitData)
        {
            UnitData = unitData;

            gameObject.name = $"Unit ({UnitData.Name})";
            // _spriteRenderer.sprite = UnitData.Sprite;
        }
    }

}
