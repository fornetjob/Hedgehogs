using Assets.Scripts.Core;
using Assets.Scripts.Features.Game;
using Assets.Scripts.Features.Game.Services;

public partial class GameContext
{
    public GameServices services = new GameServices();
}

namespace Assets.Scripts.Features.Game
{
    /// <summary>
    /// Сервисы контекста GameContext
    /// </summary>
    public sealed class GameServices: ServicesContainer
    {
        /// <summary>
        /// Возвращает сервис пулинга контроллеров
        /// </summary>
        /// <returns></returns>
        public ControllerPoolingService ProvideControllerPoolingService()
        {
            return Provide<ControllerPoolingService>();
        }

        /// <summary>
        /// Возвращает интерфейс сервиса игрового времени
        /// </summary>
        /// <returns></returns>
        public IGameTimeService ProvideGameTimeService()
        {
            return Provide<IGameTimeService>();
        }

        /// <summary>
        /// Возвращает сервис конфигурации
        /// </summary>
        /// <returns></returns>
        public ConfigService ProvideConfigService()
        {
            return Provide<ConfigService>();
        }

        /// <summary>
        /// Возвращает сервис случайных чисел
        /// </summary>
        /// <returns></returns>
        public RandomService ProvideRandomService()
        {
            return Provide<RandomService>();
        }
    }
}