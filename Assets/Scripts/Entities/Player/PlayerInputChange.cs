namespace Entities.Player
{
    public struct PlayerInputChange
    {
        public float VerticalMovement { get; }
        public float Force { get; }

        public PlayerInputChange(float verticalMovement, float force)
        {
            VerticalMovement = verticalMovement;
            Force = force;
        }
    }
}