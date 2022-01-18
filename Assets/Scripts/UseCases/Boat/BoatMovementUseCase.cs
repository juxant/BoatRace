using Entities.Boat;
using Entities.Player;
using Entities.Services.EventDispatcher;
using Entities.UseCases.Boat;
using Entities.Utilities;
using System;
using UnityEngine;

namespace UseCases.Boat
{
    public class BoatMovementUseCase : DisposableBase, IBoatMovementUseCase
    {
        private readonly IEventDispatcherService _eventDispatcherService;
        private readonly BoatAttributes _boatAttributes = new BoatAttributes();

        private BoatRotationChange _boatRotationChange;
        private PlayerInputChange _playerMovement;
        private Vector2 _playerPosition;

        public BoatMovementUseCase(IEventDispatcherService eventDispatcherService)
        {
            _eventDispatcherService = eventDispatcherService;

            _eventDispatcherService.Subscribe<PlayerInputChange>(OnPlayerMovementChange);
            _eventDispatcherService.Subscribe<PlayerMovementChange>(OnPlayerPositionChange);
        }
       
        public override void Dispose()
        {
            base.Dispose();
            _eventDispatcherService.Unsubscribe<PlayerInputChange>(OnPlayerMovementChange);
        }

        private void OnPlayerMovementChange(PlayerInputChange playerMovement)
        {
            _playerMovement = playerMovement;
        }

        private void OnPlayerPositionChange(PlayerMovementChange playerPosition)
        {
            _playerPosition = playerPosition.Position;
        }

        public void Move(Vector2 direction)
        {
            var velocity = direction * _boatAttributes.Speed;
            _eventDispatcherService.Dispatch(new BoatPositionChange(velocity));
        }

        public void Rotate(Vector3 actualPosition)
        {            
            if (_playerMovement.Force == 0 || !IsInForceRange(actualPosition)) return;

            var newRotationAngle = _boatRotationChange.RotationAngle + _playerMovement.Force;
            newRotationAngle = Mathf.Clamp(newRotationAngle, -90f, 90f);
            _boatRotationChange = new BoatRotationChange(newRotationAngle);
            _eventDispatcherService.Dispatch(_boatRotationChange);
        }

        private bool IsInForceRange(Vector3 position)
        {
            var minForceRange = _playerPosition.y - _boatAttributes.ForceOffset;
            var maxForceRange = _playerPosition.y + _boatAttributes.ForceOffset;

            return minForceRange <= position.y && maxForceRange >= position.y;
        }
    }
}