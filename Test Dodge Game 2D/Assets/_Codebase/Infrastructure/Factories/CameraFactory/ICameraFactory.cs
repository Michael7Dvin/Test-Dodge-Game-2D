using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Codebase.Infrastructure.Factories.CameraFactory
{
    public interface ICameraFactory
    {
        UniTask WarmUpAsync();
        UniTask<Camera> CreateAsync();
    }
}