using _Codebase.Gameplay.Heroes;

namespace _Codebase.Gameplay.Services.HeroProvider
{
    public interface IHeroProvider
    {
        Hero Hero { get; }
        void SetHero(Hero hero);
    }
}