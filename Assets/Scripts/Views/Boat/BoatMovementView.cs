using InterfaceAdapters.Boat;
using UnityEngine;
using Zenject;
using UniRx;

namespace Views.Boat
{
    public class BoatMovementView : ViewBase
    {
        [Inject] private readonly BoatMovementViewModel _boatMovementViewModel;

        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();

            _boatMovementViewModel
                .RotationAngle
                .Subscribe(_rigidbody.SetRotation)
                .AddTo(_disposables);

            _boatMovementViewModel
                .Velocity
                .Subscribe(velocity => _rigidbody.velocity = velocity)
                .AddTo(_disposables);
        }

        private void FixedUpdate()
        {
            _boatMovementViewModel.Move.Execute(transform.up);
            _boatMovementViewModel.Rotate.Execute(_rigidbody.position);
        }
    }
}