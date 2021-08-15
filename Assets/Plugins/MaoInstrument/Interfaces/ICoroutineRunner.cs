using System.Collections;
using UnityEngine;

namespace Plugins.Interfaces
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator curtaint);
    }
}