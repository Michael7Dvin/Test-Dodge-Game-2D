using _Codebase.Gameplay.Heroes;

namespace _Codebase.Gameplay.Services.HeroProvider
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