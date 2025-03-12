using KingoBoiii.AgeOfWarClone.UI;
using UnityEngine;
using UnityEngine.UI;

namespace KingoBoiii.AgeOfWarClone.UI
{

    [DisallowMultipleComponent]
    internal sealed class BuyUnitUI : MonoBehaviour
    {
        [SerializeField] private Transform _parent;

        public event System.Action<IUnitData> OnButtonClicked;
        private BuyUnitButton[] _buttons;

        public void SetUnits(IUnitData[] unitDatas)
        {
            _buttons = new BuyUnitButton[unitDatas.Length];
            for (int i = 0; i < _buttons.Length; i++)
            {
                _buttons[i] = CreateButton(unitDatas[i], _parent);
                _buttons[i].onClick.AddListener(unitData => OnButtonClicked?.Invoke(unitData));
            }
        }

        private BuyUnitButton CreateButton(IUnitData unitData, Transform parent)
        {
            var buttonGameObject = new GameObject($"Button ({unitData.Name})");
            buttonGameObject.transform.parent = parent;

            var image = buttonGameObject.AddComponent<Image>();
            if(image == default)
            {
                return default;
            }

            image.sprite = unitData.Sprite;

            var button = buttonGameObject.AddComponent<BuyUnitButton>();
            if (button == default)
            {
                return default;
            }

            button.UnitData = unitData;

            return button;
        }
    }

}
