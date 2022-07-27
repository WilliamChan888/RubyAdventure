using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;
    public int maxHealth = 5;
    private int currentHealth;
    public int Health { get { return currentHealth; } }
    public int speed = 3;

    //ruby无敌时间
    public float timeInvincible = 2.0f;
    //是否处于无敌状态
    private bool isInvincible;
    //计时器
    public float invincibleTimer;

    private Vector2 lookDirection = new Vector2(1, 0);
    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        //当前玩家输入轴向值不为0
        if (!Mathf.Approximately(move.x,0)||!Mathf.Approximately(move.y,0))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
                                    //取模
        animator.SetFloat("Speed", move.magnitude);

        Vector2 position = transform.position;

        
        //position.x += speed*horizontal * Time.deltaTime;
        //position.y += speed*vertical * Time.deltaTime;


        position = position + speed * move * Time.deltaTime;
        //transform.position = position;
        rigidbody2d.MovePosition(position);

        if (isInvincible)
        {
            invincibleTimer = invincibleTimer - Time.deltaTime;
            if (invincibleTimer<0)
            {
                isInvincible = false;
            }
        }
    }

    public void ChangeHealth(int amount)
    {
        if (amount<0)
        {
            if (isInvincible)
            {
                return;
            }
            //受到伤害
            isInvincible = true;
            invincibleTimer = timeInvincible;
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
    }
}
