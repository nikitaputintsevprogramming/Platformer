using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private int damage;
    
    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= -100)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHealth>().Damage(damage);
            Destroy(gameObject);
        }
    }
}
