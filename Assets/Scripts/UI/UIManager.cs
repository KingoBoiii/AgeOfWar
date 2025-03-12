using UnityEngine;

namespace KingoBoiii.AgeOfWarClone.UI
{

    [DisallowMultipleComponent]
    internal sealed class UIManager : MonoBehaviour
    {
        private static UIManager s_Instance;
        public static UIManager Instance => s_Instance;

        public event System.Action<IUnitData> OnUnitBought;
        [SerializeField] private BuyUnitUI _buyUnitsUI;

        private void Awake()
        {
            s_Instance = this;
        }

        public void SetupAgeUI(Age age)
        {
            _buyUnitsUI.OnButtonClicked += OnUnitBought;
            _buyUnitsUI.SetUnits(age.Units);
        }
    }

}