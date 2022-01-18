using UniRx;
using UnityEngine;

namespace InterfaceAdapters.Boat
{
    public class BoatMovementViewModel
    {
        public ReactiveCommand<Vector2> Move { get; } = new ReactiveCommand<Vector2>();
        public ReactiveCommand<Vector3> Rotate { get; } = new ReactiveCommand<Vector3>();
        public ReactiveProperty<Vector2> Velocity { get; } = new ReactiveProperty<Vector2>();
        public ReactiveProperty<float> RotationAngle { get; } = new ReactiveProperty<float>();
    }
}