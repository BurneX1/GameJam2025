using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool enable;
    //public bool smooth; //Para cuando toque pulir
    public Vector2 direction;
    //private Vector2 speedDirection; //Para cuando toque pulir x2
    public Rigidbody2D cmp_rb;
    public float spd;
    // Start is called before the first frame update
    void Start()
    {
        if(cmp_rb==null && GetComponent<Rigidbody2D>()) cmp_rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enable && spd > 0 && cmp_rb!=null)
        {
            Move();
        }
    }

    public void Move()
    {
        cmp_rb.velocity = new Vector2(spd * direction.x, spd * direction.y);
    }

}
