using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowInCanvas : MonoBehaviour
{
    public bool disaableNull;
    public Camera mainCamera;
    public Transform follow;
    public bool screenBorder;
    public float borderValue;
    public float offSet;
    private Vector2 centerDiff;
    private Vector2 cameraFollowPosition;
    private Vector2 cameraCenter;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        cameraCenter = new Vector2(mainCamera.pixelWidth / 2, mainCamera.pixelHeight / 2);
    }

    // Update is called once per frame
    void Update()
    {
        PointObject();
    }

    public void PointObject()
    {
        if (follow == null || follow.gameObject.activeSelf == false)
        {
            if (disaableNull) gameObject.SetActive(false);

            return;
        }

        Follow();
        Rotate();
    }

    public void Follow()     
    {

        float x = -cameraCenter.x + mainCamera.WorldToScreenPoint(follow.position).x;
        float y= -cameraCenter.y + mainCamera.WorldToScreenPoint(follow.position).y;
        cameraFollowPosition = new Vector2(x, y);
        centerDiff = new Vector2(x/Mathf.Abs(x), y / Mathf.Abs(y));


        transform.position = Vector2.Lerp(cameraCenter, mainCamera.WorldToScreenPoint(follow.position), 1f-offSet);//mainCamera.WorldToScreenPoint( follow.position) - new Vector3(offSet*centerDiff.x, offSet * centerDiff.y);
        if(screenBorder)
        {

            if(transform.position.x > mainCamera.pixelWidth - borderValue)
            {
                transform.position = new Vector3(mainCamera.pixelWidth - borderValue, transform.position.y,transform.position.z);
            }
            else if (transform.position.x< borderValue)
            {
                transform.position = new Vector3(borderValue, transform.position.y, transform.position.z);
            }


            if (transform.position.y > mainCamera.pixelHeight - borderValue)
            {
                transform.position = new Vector3(transform.position.x, mainCamera.pixelHeight - borderValue, transform.position.z);
            }
            else if (transform.position.y < borderValue)
            {
                transform.position = new Vector3(transform.position.x, borderValue, transform.position.z);
            }

        }
        
    }
    public void Rotate()
    {
     
        Vector3 target = mainCamera.WorldToScreenPoint(follow.position);

        float angle = Mathf.Atan2(target.y-transform.position.y, target.x-transform.position.x) * Mathf.Rad2Deg;


       

        transform.eulerAngles = new Vector3(0,0, Quaternion.FromToRotation(Vector3.up, target - transform.position).eulerAngles.z);

    }
}
