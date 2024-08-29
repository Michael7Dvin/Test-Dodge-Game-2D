using _Codebase.Gameplay.Heroes;
using Cysharp.Threading.Tasks;

namespace _Codebase.Infrastructure.Services.HeroFactory
{
    public interface IHeroFactory
    {
        UniTask WarmUpAsync();
        UniTask<Hero> CreateAsync();
    }
}