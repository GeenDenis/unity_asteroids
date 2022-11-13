using System;

namespace Asteroids.Scripts
{
    public interface IDestroyable
    {
        event Action OnDestroy;
        
        void Destroy();
    }
}