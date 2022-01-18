using Entities.Player;
using Entities.Services.EventDispatcher;
using Entities.Utilities;
using System;

namespace InterfaceAdapters.Player
{
    public class PlayerMovementPresenter : DisposableBase
    {
        private readonly IEventDispatcherService _eventDispatcherService;
        private readonly PlayerMovementViewModel _playerMovementViewModel;

        public PlayerMovementPresenter(IEventDispatcherService eventDispatcherService,
                                    PlayerMovementViewModel playerMovementViewModel)
        {
            _eventDispatcherService = eventDispatcherService;
            _playerMovementViewModel = playerMovementViewModel;

            _eventDispatcherService.Subscribe<PlayerMovementChange>(OnPlayerPositionChange);
        }

        public override void Dispose()
        {
            base.Dispose();
            _eventDispatcherService.Unsubscribe<PlayerMovementChange>(OnPlayerPositionChange);
        } 

        private void OnPlayerPositionChange(PlayerMovementChange playerPositionChange)
        {
            _playerMovementViewModel.Position.Value = playerPositionChange.Position;
        }
    }
}