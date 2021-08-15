using UnityEngine;

namespace Plugins.DIContainer
{
    public class InjectDI : MonoBehaviour
    {
        private void Awake()
        {
            foreach (var beh in FindObjectsOfType<MonoBehaviour>()) DiServices.MainContainer.InjectSingle(beh);
        }
    }
}