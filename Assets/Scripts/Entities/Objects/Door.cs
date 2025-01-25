using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject open;
    public GameObject close;

    public Animator animator;

    private void OnEnable()
    {
        CloseDoor();
    }

    public void OpenDoor()
    {
        open.SetActive(true);
        close.SetActive(false);

        //OpenTrigerAnim
    }

    public void CloseDoor()
    {
        open.SetActive(false);
        close.SetActive(true);

        //OpenCloseAnim
    }
}
