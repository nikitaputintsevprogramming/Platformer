using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public Animator anim;
    private Transform Player; 
    [SerializeField] public float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        anim = gameObject.GetComponent<Animator>();
        Player = GameObject.Find("Player").transform;
    }

    
    void Update()
    {
        if(Vector2.Distance(gameObject.transform.position, Player.position) <= 0.3)
        {
            anim.SetTrigger("Attack");
        }
        else 
        {
            anim.SetBool("Idle", true);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = Vector2.right * speed;        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "EnemyStopper")
        {
            speed = speed * -1; // speed *= -1
            sr.flipX = !sr.flipX;
        }
    }
}
