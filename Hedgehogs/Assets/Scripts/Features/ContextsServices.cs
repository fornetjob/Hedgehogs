using Assets.Scripts.Core;
using Assets.Scripts.Features;
using Assets.Scripts.Features.Services;

public partial class Contexts
{
    public ContextsServices services = new ContextsServices();
}

namespace Assets.Scripts.Features
{
    /// <summary>
    /// Сервисы уровня Contexts
    /// </summary>
    public sealed class ContextsServices : ServicesContainer
    {
        /// <summary>
        /// Возвращает сервис работы с камерой
        /// </summary>
        /// <returns></returns>
        public CameraService ProvideCameraService()
        {
            return Provide<CameraService>();
        }
    }
}