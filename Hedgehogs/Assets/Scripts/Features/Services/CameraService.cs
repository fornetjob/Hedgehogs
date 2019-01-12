using Assets.Scripts.Core;
using UnityEngine;

namespace Assets.Scripts.Features.Services
{
    /// <summary>
    /// Сервис работы с камерой
    /// </summary>
    public class CameraService:IService
    {
        #region Fields

        /// <summary>
        /// Данные для расчёта выхода за экран
        /// </summary>
        private readonly Plane[]
            _planes;

        /// <summary>
        /// Камера
        /// </summary>
        private Camera
            _mainCamera;

        #endregion

        #region ctor

        public CameraService()
        {
            _mainCamera = Camera.main;

            _planes = GeometryUtility.CalculateFrustumPlanes(_mainCamera);
        }

        #endregion

        /// <summary>
        /// Коллайдер входит в фруструм камеры
        /// </summary>
        /// <param name="collider">Коллайдер для проверки</param>
        /// <returns></returns>
        public bool IsColliderInFrustum(Collider2D collider)
        {
            return GeometryUtility.TestPlanesAABB(_planes, collider.bounds);
        }

        /// <summary>
        /// Конвертирует позицию экрана в мировые координаты
        /// </summary>
        /// <param name="pos">Позиция экрана</param>
        /// <returns></returns>
        public Vector2 ScreenToWorldPoint(Vector2 screenPos)
        {
            Vector3 pos = screenPos;

            pos[2] = 10;

            return _mainCamera.ScreenToWorldPoint(pos);
        }
    }
}
