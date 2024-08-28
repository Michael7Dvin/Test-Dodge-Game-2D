using UnityEngine;

namespace _Codebase.Gameplay.Hero
{
    [RequireComponent(typeof(Mover))]
    public class Hero : MonoBehaviour
    {
        public Mover Mover { get; private set; }

        private void Awake()
        {
            Mover = GetComponent<Mover>();
        }
    }
}