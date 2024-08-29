using _Codebase.Gameplay.Heroes;

namespace _Codebase.Infrastructure.Services.HeroProvider
{
    public interface IHeroProvider
    {
        Hero Hero { get; }
        void SetHero(Hero hero);
    }
}