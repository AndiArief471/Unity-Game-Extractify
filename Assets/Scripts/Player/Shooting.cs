using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] Camera mainCam;
    private Vector3 abc;

    public GameObject bullet;
    public Transform bulletTransform;

    public bool canFire;
    private float timer;
    public float timeBetweenFiring;

    void Update()
    {
        abc = mainCam.ScreenToWorldPoint(Input.mousePosition);
        abc.z = 0f;
        Vector3 rotation = abc - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0, rotZ);

        Debug.Log(mainCam.ScreenToWorldPoint(Input.mousePosition));

        if(!canFire)
        {
            timer += Time.deltaTime;
            if(timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }

        if(Input.GetMouseButton(0) && canFire)
        {
            canFire = false;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        }
    }
}
