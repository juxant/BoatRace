using UniRx;
using UnityEngine;

namespace InterfaceAdapters.Player
{
    public class PlayerMovementViewModel
    {
        public ReactiveCommand<Vector2> Move { get; } = new ReactiveCommand<Vector2>();
        public ReactiveProperty<Vector2> Position { get; } = new ReactiveProperty<Vector2>();
    }
}