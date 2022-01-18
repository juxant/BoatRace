using Entities.UseCases.Player;
using Entities.Utilities;
using System;
using UniRx;
using UnityEngine;

namespace InterfaceAdapters.Player
{
    public class PlayerMovementController : DisposableBase
    {
        private readonly IPlayerMovementUseCase _playerMovementUseCase;
        private readonly PlayerInputViewModel _playerInputViewModel;       
        private readonly PlayerMovementViewModel _playerMovementViewModel;

        public PlayerMovementController(IPlayerMovementUseCase playerMovementUseCase, 
                                    PlayerInputViewModel playerInputViewModel,                           
                                    PlayerMovementViewModel playerMovementViewModel)
        {
            _playerMovementUseCase = playerMovementUseCase;
            _playerInputViewModel = playerInputViewModel;
            _playerMovementViewModel = playerMovementViewModel;

            _playerInputViewModel.SetVerticalMovement.Subscribe(SetVerticalMovement).AddTo(_disposables);
            _playerInputViewModel.SetForce.Subscribe(SetForce).AddTo(_disposables);
            _playerMovementViewModel.Move.Subscribe(Move).AddTo(_disposables);
        }     

        private void SetVerticalMovement(float verticalMovement)
        {
            _playerMovementUseCase.SetVerticalMovement(verticalMovement);
        }

        private void SetForce(float force)
        {
            _playerMovementUseCase.SetForce(force);
        }

        private void Move(Vector2 actualPosition)
        {
            _playerMovementUseCase.Move(actualPosition);
        }
    }
}