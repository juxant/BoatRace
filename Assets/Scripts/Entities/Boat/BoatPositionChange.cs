using UnityEngine;

namespace Entities.Boat
{
    public struct BoatPositionChange
    {
        public Vector2 Velocity { get; }

        public BoatPositionChange(Vector2 velocity)
        {
            Velocity = velocity;
        }
    }
}