using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Mechanics.GameLevel.Stages
{
    public class Spark : MonoBehaviour, IDragHandler, IEndDragHandler
    {
        public void OnDrag(PointerEventData eventData)
        {
            Vector3 newPosition =Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPosition.z = 0;
            transform.position = newPosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            var list = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, list);
            ShadowSpark shadow = null;
            foreach (var l in list)
                if(l.gameObject.TryGetComponent<ShadowSpark>(out shadow))
                    break;
            if(shadow && shadow.ApplaySpark(this))
                return;
            else
                transform.localPosition = Vector3.zero;
        }
    }
}