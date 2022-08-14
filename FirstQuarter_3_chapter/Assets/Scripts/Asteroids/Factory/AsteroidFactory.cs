using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal sealed class AsteroidFactory : IEnemyFactory
    {
        public Enemy Create(Health hp)
        {
            var enamy = Object.Instantiate(Resources.Load<Asteroid>("Ename/Asteroid"));

            //enamy.DependencyInjectHealth(hp);

            return enamy;
        }
    }
}
