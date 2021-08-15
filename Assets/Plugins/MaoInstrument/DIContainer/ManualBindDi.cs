using UnityEngine;

namespace Plugins.DIContainer
{
    public abstract class ManualBindDi : MonoBehaviour
    {
        public abstract void Create(DiBox container);

        public abstract void DestroyDi(DiBox container);
    }
}