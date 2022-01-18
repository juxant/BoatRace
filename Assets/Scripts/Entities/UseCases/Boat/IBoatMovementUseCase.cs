using UnityEngine;

namespace Entities.UseCases.Boat
{
    public interface IBoatMovementUseCase
    {
        void Move(Vector2 direction);
        void Rotate(Vector3 actualPosition);
    }
}