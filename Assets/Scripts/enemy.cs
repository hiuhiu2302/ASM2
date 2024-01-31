using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float enemySpeedl;

    Rigidbody2D enemyRB;
    Animator enemyAnim;

    public GameObject enemyGraphic;
    bool facingRight = true;
    float facingTime = 5f;
    float nextFlip = 0f;
    bool canFlip = true;

    private void Awake()
    {
        enemyRB= GetComponent<Rigidbody2D>();
        enemyAnim= GetComponentInChildren<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        enemyAnim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time> nextFlip)
        {
            nextFlip = Time.time+ facingTime;
            flip();
        } 
    }


     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Player")
        {
           if(facingRight&& collision.transform.position.x<transform.position.x) 
            {
                flip();
            }else if(!facingRight&& collision.transform.position.x> transform.position.x)
            {
                flip();
            }
           canFlip = false;
        }
    }

     void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == ("Player"))
        {
            if (!facingRight)
            
                enemyRB.AddForce(new Vector2(-1, 0) * enemySpeedl);
            
            else
            
                enemyRB.AddForce(new Vector2(1, 0) * enemySpeedl);
                enemyAnim.SetBool("run", true);
                enemyAnim.SetBool("idle", false);
            

        }
    }
    void flip()
    {
        if (!canFlip)
            return;
        facingRight =! facingRight;
        Vector3 theScale = enemyGraphic.transform.localScale;
        theScale.x *= -1;
        enemyGraphic.transform.localScale = theScale;
    }
}
