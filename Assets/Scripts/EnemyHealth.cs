using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private AudioSource DeathSound;
    [SerializeField] Animator anim;
    [SerializeField] int currentHealth;
    public int maxHealth = 3;
    private EnemyMove enemyMove;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        enemyMove = GetComponent<EnemyMove>();
        anim = GetComponent<Animator>();
        DeathSound = GetComponent<AudioSource>();
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
            DeathSound.Play();
            anim.SetTrigger("Dead");
            Destroy(gameObject, 0.5f);

        }
    }
}
