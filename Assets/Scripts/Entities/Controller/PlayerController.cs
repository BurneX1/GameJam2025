using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public Movement cmp_mov;

    // Start is called before the first frame update
    void Start()
    {
        if(cmp_mov==null && GetComponent<Movement>()) cmp_mov = GetComponent<Movement>();
       
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        MoveKeys();
    }

    public void MoveKeys()
    {
        if (cmp_mov == null) return;

        cmp_mov.direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        cmp_mov.Move();
    }
}
