using UnityEngine;

namespace _Codebase.Infrastructure.Providers.CameraProvider
{
    public interface ICameraProvider
    {
        Camera Camera { get; }
        void SetCamera(Camera camera);
    }
}