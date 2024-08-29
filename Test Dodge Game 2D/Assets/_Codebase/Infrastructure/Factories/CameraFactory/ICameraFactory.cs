using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Codebase.Infrastructure.Factories.CameraFactory
{
    public interface ICameraFactory
    {
        UniTask WarmUpAsync();
        Camera Create();
    }
}