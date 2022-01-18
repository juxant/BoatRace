using UnityEngine;

namespace Entities.Player
{
    public struct PlayerMovementChange
    {
        public Vector2 Position { get; }

        public PlayerMovementChange(Vector2 position)
        {
            Position = position;
        }
    }
}
