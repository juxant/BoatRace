using UniRx;

namespace InterfaceAdapters.Player
{
    public class PlayerInputViewModel
    {
        public ReactiveCommand<float> SetVerticalMovement { get; } = new ReactiveCommand<float>();
        public ReactiveCommand<float> SetForce { get; } = new ReactiveCommand<float>();        
    }
}