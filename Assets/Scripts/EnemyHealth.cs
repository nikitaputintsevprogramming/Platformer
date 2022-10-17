using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int currentHealth;
    public int maxHealth = 3;
    private EnemyMove enemyMove;

    [SerializeField] Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        enemyMove = GetComponent<EnemyMove>();
        anim = GetComponent<Animator>();
    }

    public void Damage(int damage)
    {
        currentHealth = currentHealth - damage;
        anim.SetTrigger("Damage");
        anim.SetBool("Idle", true);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
            enemyMove.speed = 0;
            anim.SetTrigger("Dead");
            Destroy(gameObject, 0.5f);
        }
    }
}
