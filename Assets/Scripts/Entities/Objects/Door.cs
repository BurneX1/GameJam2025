using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject[] open;
    public GameObject[] close;

    public Animator animator;

    private void OnEnable()
    {
        CloseDoor();
    }

    public void OpenDoor()
    {
        foreach(GameObject obj in open) obj.SetActive(true);
        foreach (GameObject obj in close) obj.SetActive(false);

        //OpenTrigerAnim
    }

    public void CloseDoor()
    {
        foreach (GameObject obj in open) obj.SetActive(false);
        foreach (GameObject obj in close) obj.SetActive(true);

        //OpenCloseAnim
    }
}
