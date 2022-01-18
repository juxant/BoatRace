using Entities.Boat;
using Entities.Services.EventDispatcher;
using Entities.Utilities;
using System;

namespace InterfaceAdapters.Boat
{
    public class BoatMovementPresenter : DisposableBase
    {
        private readonly IEventDispatcherService _eventDispatcherService;
        private readonly BoatMovementViewModel _boatMovementViewModel;

        public BoatMovementPresenter(IEventDispatcherService eventDispatcherService,
                                    BoatMovementViewModel boatMovementViewModel)
        {
            _eventDispatcherService = eventDispatcherService;
            _boatMovementViewModel = boatMovementViewModel;

            _eventDispatcherService.Subscribe<BoatRotationChange>(OnBoatRotationChange);
            _eventDispatcherService.Subscribe<BoatPositionChange>(OnBoatPositionChange);
        }

        public override void Dispose()
        {
            base.Dispose();
            _eventDispatcherService.Unsubscribe<BoatRotationChange>(OnBoatRotationChange);
        }

        private void OnBoatRotationChange(BoatRotationChange boatRotationChange)
        {
            _boatMovementViewModel.RotationAngle.Value = boatRotationChange.RotationAngle;
        }

        private void OnBoatPositionChange(BoatPositionChange boatPositionChange)
        {
            _boatMovementViewModel.Velocity.Value = boatPositionChange.Velocity;
        }
    }
}