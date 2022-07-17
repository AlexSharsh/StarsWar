using UnityEngine;

namespace StarsWar
{
    internal sealed class GameObjectPhysicsBuilder : GameObjectBuilder
    {
        public GameObjectPhysicsBuilder(GameObject gameObject) : base(gameObject)
        { }
        public GameObjectPhysicsBuilder BoxCollider()
        {
            GetOrAddComponent<BoxCollider>();
            return this;
        }

        public GameObjectPhysicsBuilder Rigidbody(float mass)
        {
            var component = GetOrAddComponent<Rigidbody>();
            component.mass = mass;
            return this;
        }
        private T GetOrAddComponent<T>() where T : Component
        {
            var result = _gameObject.GetComponent<T>();
            if (!result)
            {
                result = _gameObject.AddComponent<T>();
            }
            return result;
        }
    }
}


