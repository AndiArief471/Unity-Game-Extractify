using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform lookAt;
    public float boundX = 0;
    public float boundY = 0;

    public static CameraController instance;
    public Room currRoom;

    void Awake()
    {
        instance = this;
    }

    void LateUpdate()
    {
        UpdatePosition();
    }

    void UpdatePosition()
    {
        if(currRoom == null)
        {
            return;
        }

        Vector3 targetPos = GetCameraTargetPosition();
        
        Vector3 delta = Vector3.zero;

        float deltaX = lookAt.position.x - transform.position.x;
        if(deltaX > boundX || deltaX < -boundX){
            if(transform.position.x < lookAt.position.x){
                delta.x = deltaX - boundX;
            }
            else{
                delta.x = deltaX + boundX;
            }
        }

        float deltaY = lookAt.position.y - transform.position.y;
        if(deltaY > boundY || deltaY < -boundY){
            if(transform.position.y < lookAt.position.y){
                delta.y = deltaY - boundY;
            }
            else{
                delta.y = deltaY + boundY;
            }
        }

        transform.position += new Vector3(delta.x, delta.y, 0);
    }

    Vector3 GetCameraTargetPosition()
    {
        if(currRoom == null)
        {
            return Vector3.zero;
        }

        Vector3 targetPos = currRoom.GetRoomCentre();

        return targetPos;
    }

    public bool IsSwitchingScene()
    {
        return transform.position.Equals(GetCameraTargetPosition()) == false;
    }
}

