using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraGridSnapFollow : MonoBehaviour
{
    [SerializeField]
    float GridSnapSpeed;
    [SerializeField]
    GameObject followObj;
    GameObject Cam;

    [SerializeField]
    Vector2 CameraSnappingAmount = new Vector2(6,10); //if player moves out of bounds move camera by these amounts in that direction

    [SerializeField]
    Vector2 playerBounds = new Vector2(3,5); //plus and minus this amount from the centre of the scene


    Vector2 CameraStartPos = new Vector2(0, 0);

    public Vector2 xBound;
    public Vector2 yBound;
    void PlayerBounds()
    {
        //calculate the bounds that we will base the camera position off of.
        xBound = new Vector2(Cam.transform.position.x - playerBounds.x, Cam.transform.position.x + playerBounds.x);
        yBound = new Vector2(Cam.transform.position.y - playerBounds.y, Cam.transform.position.y + playerBounds.y);
        //if player leaves these bounds we will move the camera in that direction and adjust the bounds to match
    }

    void ObjectPositionCheck()
    {
        if (followObj.transform.position.x > xBound.y)
        {
            Cam.transform.position = new Vector3(Cam.transform.position.x + CameraSnappingAmount.x, Cam.transform.position.y, -10);
            PlayerBounds();
        }
        else if(followObj.transform.position.x < xBound.x)
        {
            Cam.transform.position = new Vector3(Cam.transform.position.x - CameraSnappingAmount.x, Cam.transform.position.y, -10);
            PlayerBounds();
        }

        if (followObj.transform.position.y > yBound.y)
        {
            Cam.transform.position = new Vector3(Cam.transform.position.x, Cam.transform.position.y + CameraSnappingAmount.y, -10);
            PlayerBounds();
        }
        else if (followObj.transform.position.y < yBound.x)
        {
            Cam.transform.position = new Vector3(Cam.transform.position.x, Cam.transform.position.y - CameraSnappingAmount.y, -10);
            PlayerBounds();
        }
    }

    void camFollow()
    {
        Cam.transform.position = new Vector3(followObj.transform.position.x, followObj.transform.position.y, -10);
    }

    private void Start()
    {
        Cam = this.gameObject;
        PlayerBounds();
    }
    private void Update()
    {
        ObjectPositionCheck();
        //camFollow();
    }
}
