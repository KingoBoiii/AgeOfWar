using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace KingoBoiii.AgeOfWarClone.UI
{

    [DisallowMultipleComponent]
    public sealed class BuyUnitButton : Button
    {
        [Serializable]
        public class BuyUnitButtonClickedEvent : UnityEvent<IUnitData> { }

        [SerializeField]
        [FormerlySerializedAs("onClick")]
        private BuyUnitButtonClickedEvent _onClick = new BuyUnitButtonClickedEvent();

        public new BuyUnitButtonClickedEvent onClick
        {
            get { return _onClick; }
            set { _onClick = value; }
        }

        public IUnitData UnitData { get; set; }

        public override void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left)
            {
                return;
            }

            if (UnitData == default)
            {
                return;
            }

            Press();
        }

        private void Press()
        {
            if (!IsActive() || !IsInteractable())
            {
                return;
            }

            UISystemProfilerApi.AddMarker("BuyUnitButton.onBuyUnitButtonClick", this);

            _onClick.Invoke(UnitData);
        }
    }

}
