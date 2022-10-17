using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Animator anim;
    [SerializeField] private int PlayerHealthCount;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        PlayerHealthCount = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y <= -1.5f || PlayerHealthCount <= 0)
        {
            spriteRenderer.enabled = false;
            print("Player is dead");            
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            anim.SetTrigger("IsHurt");
            PlayerHealthCount--; // PlayerHealthCount = PlayerHealthCount - 1
        }

        if(other.gameObject.tag == "Health")
        {
            PlayerHealthCount++;
            print("Health + 1");
            Destroy(other.gameObject);
        }
    }
}
