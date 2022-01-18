using Entities.Services.EventDispatcher;
using Entities.UseCases.Player;
using InterfaceAdapters.Boat;
using InterfaceAdapters.Player;
using UseCases.Boat;
using UseCases.Player;
using Zenject;

namespace Configuration.Installers
{
    public class GlobalInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IEventDispatcherService>()
                .To<EventDispatcherService>()
                .AsSingle();

            InjectPlayer();
            InjectBoat();
        }

        private void InjectPlayer()
        {
            Container.Bind<PlayerInputViewModel>()
                .AsSingle();

            Container.Bind<PlayerMovementViewModel>()
                .AsSingle();

            Container.BindInterfacesAndSelfTo<PlayerMovementUseCase>()
                .AsSingle();

            Container.BindInterfacesAndSelfTo<PlayerMovementController>()
                .AsSingle()
                .NonLazy();

            Container.BindInterfacesAndSelfTo<PlayerMovementPresenter>()
                .AsSingle()
                .NonLazy();
        }

        private void InjectBoat()
        {
            Container.Bind<BoatMovementViewModel>()
                .AsSingle();

            Container.BindInterfacesAndSelfTo<BoatMovementUseCase>()
                .AsSingle();

            Container.BindInterfacesAndSelfTo<BoatMovementController>()
                .AsSingle()
                .NonLazy();

            Container.BindInterfacesAndSelfTo<BoatMovementPresenter>()
                .AsSingle()
                .NonLazy();
        }
    }
}
