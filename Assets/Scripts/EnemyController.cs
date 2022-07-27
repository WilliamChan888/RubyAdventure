using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3;
    private Rigidbody2D rigidbody2d;
    public bool vertical ;
    private int direction = 1;
    public float changeTime = 3;
    private float timer; //计时器

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();
        //animator.SetFloat("MoveX", direction);
        //animator.SetBool("Vertical", vertical);

        //竖直轴向动画控制
        PlayMoveAnimation();

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer<0)
        {
            direction = -direction;
            PlayMoveAnimation();
            timer = changeTime;
        }

        Vector2 position = rigidbody2d.position;

        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed*direction;
        }
        else
        {
            position.x =position.x + Time.deltaTime * speed *direction;

        }
        rigidbody2d.MovePosition(position);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        RubyController rubyController = collision.gameObject.GetComponent<RubyController>();

        if (rubyController!=null)
        {
            rubyController.ChangeHealth(-1);
        }
    }

    private void PlayMoveAnimation()
    {
        if (vertical)
        {
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", direction);
        }
        else
        {
            animator.SetFloat("MoveX", direction);
            animator.SetFloat("MoveY", 0);
        }
    }
}
