using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Trash : MonoBehaviour, IDropHandler
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnDrop(PointerEventData data)
    {
        var originalObj = data.pointerDrag;
        if (originalObj == null)
            return;
        var drag = originalObj.GetComponent<draggable>();
        if (drag == null)
            return;
        drag.clear();
    }
}
