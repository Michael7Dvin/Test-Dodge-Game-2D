using _Codebase.Gameplay.Heroes;

namespace _Codebase.Infrastructure.Services.HeroProvider
{
    public class HeroProvider : IHeroProvider
    {
        public Hero Hero { get; private set; }
        
        public void SetHero(Hero hero)
        {
            Hero = hero;
        }
    }
}