using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAimScript : MonoBehaviour
{
    //this script just points the gun towards whatever the mouse is pointed at.
    Vector3 mousePos;
    Vector3 worldPos;

    [SerializeField]
    float zDepth;
    private void Update()
    {
        mousePos = Input.mousePosition;
        worldPos = new Vector3(mousePos.x, mousePos.y, zDepth);

        this.gameObject.transform.LookAt(worldPos);
    }
}
