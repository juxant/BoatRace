using InterfaceAdapters.Player;
using UnityEngine;
using Zenject;

public class PlayerInputService : MonoBehaviour
{
    [Inject] private readonly PlayerInputViewModel _playerInputViewModel;

    private InputManager _inputManager;

    private void Awake()
    {
        _inputManager = new InputManager();
    }

    private void OnEnable()
    {
        _inputManager.Enable();
    }

    private void OnDisable()
    {
        _inputManager.Disable();
    }

    private void Start()
    {
        _inputManager.Player.VerticalMovement.performed += ctx => _playerInputViewModel.SetVerticalMovement.Execute(ctx.ReadValue<float>());
        _inputManager.Player.Force.performed += ctx => _playerInputViewModel.SetForce.Execute(ctx.ReadValue<float>());
    }
}
