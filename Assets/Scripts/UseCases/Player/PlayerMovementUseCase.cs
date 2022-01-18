using Entities.Player;
using Entities.Services.EventDispatcher;
using Entities.UseCases.Player;
using UnityEngine;

namespace UseCases.Player
{
    public class PlayerMovementUseCase : IPlayerMovementUseCase
    {
        private readonly IEventDispatcherService _eventDispatcherService;
        private readonly PlayerAttributes _playerAttributes = new PlayerAttributes();

        private PlayerInputChange _playerMovement;

        public PlayerMovementUseCase(IEventDispatcherService eventDispatcherService)
        {
            _eventDispatcherService = eventDispatcherService;
        }

        public void SetVerticalMovement(float verticalMovement)
        {
            var newVerticalMovement = _playerMovement.VerticalMovement + verticalMovement;
            newVerticalMovement = Mathf.Clamp(newVerticalMovement, -1f, 1f);
            _playerMovement = new PlayerInputChange(newVerticalMovement, 0f);
            _eventDispatcherService.Dispatch(_playerMovement);
        }

        public void SetForce(float force)
        {
            var newForce = _playerMovement.Force + force;
            newForce = Mathf.Clamp(newForce, -1f, 1f);
            _playerMovement = new PlayerInputChange(0f, newForce);
            _eventDispatcherService.Dispatch(_playerMovement);
        }

        public void Move(Vector2 actualPosition)
        {
            if (_playerMovement.VerticalMovement == 0) return;

            var newPosition = actualPosition + _playerAttributes.Speed * new Vector2(0f, _playerMovement.VerticalMovement);
            _eventDispatcherService.Dispatch(new PlayerMovementChange(newPosition));
        }
    }
}