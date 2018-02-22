using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class boilZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{

    public draggable.Slot typeOfItem = draggable.Slot.Boil;

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("OnPointerEnter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
       // Debug.Log("OnPointerExit");
    }

    public void OnDrop(PointerEventData eventData)
    {

        draggable d = eventData.pointerDrag.GetComponent<draggable>();
        if (d != null)
        {
            if (typeOfItem == d.typeOfItem)
            {
            //d.parentToReturnTo = this.transform;
            d.newObj.AddComponent<draggable>();
            d.newObj.transform.SetParent(this.transform, false);
            }
        }
    }
}
