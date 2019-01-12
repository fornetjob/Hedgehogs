using Assets.Scripts.Core;
using Assets.Scripts.Features.Input.Services;

public partial class InputContext
{
    public InputServices services = new InputServices();
}

namespace Assets.Scripts.Features.Input.Services
{
    /// <summary>
    /// Сервисы контекста InputContext
    /// </summary>
    public class InputServices:ServicesContainer
    {
        /// <summary>
        /// Возвращает интерфейс сервиса игровых событий
        /// </summary>
        /// <returns></returns>
        public IInputService ProvideInputService()
        {
            return Provide<IInputService>();
        }
    }
}
