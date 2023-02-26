using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{

    public float speed;
    private Rigidbody2D rb;
    private Animator animator;
    private float horizontalLeftRight;
    private bool isFacingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalLeftRight = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalLeftRight * speed, rb.velocity.y);
        Flip();
        animator.SetFloat("move", Mathf.Abs(horizontalLeftRight));
    }
    void Flip()
    {
        if(isFacingRight && horizontalLeftRight < 0 || !isFacingRight && horizontalLeftRight > 0)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x = localScale.x * -1;
            transform.localScale = localScale;
        }
    }
}
