using Entities.UseCases.Boat;
using Entities.Utilities;
using System;
using UniRx;
using UnityEngine;

namespace InterfaceAdapters.Boat
{
    public class BoatMovementController : DisposableBase
    {
        private readonly IBoatMovementUseCase _boatMovementUseCase;
        private readonly BoatMovementViewModel _boatMovementViewModel;

        public BoatMovementController(IBoatMovementUseCase boatMovementUseCase, 
                                    BoatMovementViewModel boatMovementViewModel)
        {
            _boatMovementUseCase = boatMovementUseCase;
            _boatMovementViewModel = boatMovementViewModel;

            _boatMovementViewModel.Move.Subscribe(Move).AddTo(_disposables);
            _boatMovementViewModel.Rotate.Subscribe(Rotate).AddTo(_disposables);
        }

        private void Move(Vector2 direction)
        {
            _boatMovementUseCase.Move(direction);
        }

        private void Rotate(Vector3 actualPosition)
        {
            _boatMovementUseCase.Rotate(actualPosition);
        }
    }
}