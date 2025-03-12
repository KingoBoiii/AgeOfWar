using UnityEngine;

namespace KingoBoiii.AgeOfWarClone.Units
{

    [DisallowMultipleComponent]
    internal sealed class UnitMovement : MonoBehaviour
    {
        private UnitMoveDirection _direction;

        internal void Initialize(UnitMoveDirection direction)
        {
            _direction = direction;
        }

        private void Update()
        {
            if (UnitMoveDirection.Unknown.Equals(_direction))
            {
                return;
            }

            var position = transform.position;
            position.x += (float)_direction * Time.deltaTime;
            transform.position = position;
        }
    }

}
