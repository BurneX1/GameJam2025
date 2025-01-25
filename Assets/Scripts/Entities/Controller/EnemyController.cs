using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Movement cmp_mov;
    public Vector2 actualDir;
    public DirectionalCast cmp_cast;
    int valueListDirection = 0;


    private void OnEnable()
    {
        if(cmp_cast)
        {
            valueListDirection = Random.Range(0, cmp_cast.directions.Length - 1);
            actualDir = cmp_cast.directions[valueListDirection].direction;
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        if (cmp_mov == null && GetComponent<Movement>()) cmp_mov = GetComponent<Movement>();
        if (cmp_cast == null && GetComponent<DirectionalCast>()) cmp_cast = GetComponent<DirectionalCast>();

        valueListDirection = Random.Range(0, cmp_cast.directions.Length - 1);
        actualDir = cmp_cast.directions[valueListDirection].direction;
        cmp_mov.direction = actualDir;
    }

    private void Update()
    {
        BounceMove();
    }

    public void BounceMove()
    {
        if (cmp_cast.directions[valueListDirection].check == false) return;

        List<int> list = new List<int>();
        for (int i = 0;i< cmp_cast.directions.Length;i++)
        {
            if (cmp_cast.directions[i].check==false) list.Add(i);
        }

        Debug.Log(list.Count + " Count");
        if(list.Count>0)
        {
            valueListDirection = list[Random.Range(0, list.Count)];
            actualDir = cmp_cast.directions[valueListDirection].direction;
            cmp_mov.direction = actualDir;
        }
        
        //cmp_mov.direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void FixedUpdate()
    {
        Move();
        
    }

    public void Move()
    {
        if (cmp_mov == null) return;


        cmp_mov.Move();

    }
}
