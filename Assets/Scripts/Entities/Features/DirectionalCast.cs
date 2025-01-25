using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalCast : MonoBehaviour
{
    public bool enable;
    public DirectionBool[] directions;

    public LayerMask mask;
    public float distance;
    private BoxCollider2D cmp_coll;

    private void FixedUpdate()
    {
        if (enable)
        {
            for (int i = 0;i<directions.Length;i++)
            {
                directions[i].check = GroundLayerCheck(mask, distance, directions[i]);
            }
        }
    }


    private void Awake()
    {
        cmp_coll = gameObject.GetComponent<BoxCollider2D>();
        Debug.Log(Vector2.down + "down");
        Debug.Log(Vector2.up + "up");
        Debug.Log(Vector2.left + "left");
        Debug.Log(Vector2.right + "right");
    }
    public bool GroundLayerCheck(LayerMask mask, float distance, DirectionBool direction)
    {

        RaycastHit2D hit = Physics2D.BoxCast
            (
            transform.position,
            new Vector2((cmp_coll.size.x) * 0.65f, (cmp_coll.size.x) * 0.65f),
            0,
            direction.direction,
            distance,
            mask
            );
        bool grn = Physics2D.BoxCast
            (
            transform.position,
            new Vector2((cmp_coll.size.x) * 0.65f, (cmp_coll.size.x) * 0.65f),
            0,
            direction.direction,
            distance,
            mask
            );


        if (hit.collider != null)
        {
            direction.actualGround = hit.collider.transform;
        }
        else
        {
            direction.actualGround = null;
        }

        if (grn == true) return true;
        else return false;

    }

}
[System.Serializable]
public class DirectionBool
{
    public Vector2 direction;
    public bool check;
    public Transform actualGround;
}
