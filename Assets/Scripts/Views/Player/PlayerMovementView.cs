using InterfaceAdapters.Player;
using UnityEngine;
using Zenject;
using UniRx;

namespace Views.Player
{
    public class PlayerMovementView : ViewBase
    {
        [Inject] private readonly PlayerMovementViewModel _playerMovementViewModel;

        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();

            _playerMovementViewModel
                .Position
                .Subscribe(_rigidbody.MovePosition)
                .AddTo(_disposables);
        }

        private void FixedUpdate()
        {
            _playerMovementViewModel.Move.Execute(_rigidbody.position);
        }      
    }
}