using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Mechanics.GameLevel.Stages.ElectroStage
{
    public class InteractWithWirePart : MonoBehaviour
    {
        [SerializeField] private Wires _wires;

        private event Action _backAction;
        
        public void OnInteract()
        {
            _backAction?.Invoke();
            _backAction = (Action)Delegate.RemoveAll(_backAction, _backAction);
        }

        public void OffInteract()
        {
            if(_backAction!=null)
                if(_backAction.GetInvocationList().Length>0)
                    return;
            foreach (var wirePartShell in _wires.WiresList.Where(x=>x.WiresPart.enabled==true))
            {
                wirePartShell.WiresPart.enabled = false;
                _backAction += () => wirePartShell.WiresPart.enabled = true;
            }
        }
    }
}