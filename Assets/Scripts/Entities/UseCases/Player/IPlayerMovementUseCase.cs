using UnityEngine;

namespace Entities.UseCases.Player
{
    public interface IPlayerMovementUseCase
    {
        void SetVerticalMovement(float verticalMovement);
        void SetForce(float force);
        void Move(Vector2 actualPosition);
    }
}