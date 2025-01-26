using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorMovement : MonoBehaviour
{
    public Movement cmp_mov;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    private Vector2 lastDirection;
    // Start is called before the first frame update
    void Start()
    {
        if (cmp_mov == null && GetComponent<Movement>()) cmp_mov = GetComponent<Movement>();
        if (animator == null && GetComponent<Animator>()) animator = GetComponent<Animator>();
        if (spriteRenderer == null && GetComponent<SpriteRenderer>()) spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cmp_mov && animator)
        {
            animator.SetFloat("spd", Mathf.Abs(Mathf.Abs(cmp_mov.cmp_rb.velocity.x) + Mathf.Abs(cmp_mov.cmp_rb.velocity.y)));
            if(Mathf.Abs(cmp_mov.direction.x) + Mathf.Abs(cmp_mov.direction.y) > 0)
            {
                lastDirection = new Vector2(cmp_mov.direction.x, cmp_mov.direction.y);
            }
            animator.SetFloat("horizontal", lastDirection.x);
            animator.SetFloat("vertical", lastDirection.y);
        }
        if(spriteRenderer)
        {
            if(lastDirection.x < 0)
            {
                spriteRenderer.flipX = true;
            }
            else if(lastDirection.x > 0)
            {
                spriteRenderer.flipX = false;
            }
        }
    }
}
