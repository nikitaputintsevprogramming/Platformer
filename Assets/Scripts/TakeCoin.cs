using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeCoin : MonoBehaviour
{
    [SerializeField] private int coins;
    [SerializeField] private ParticleSystem burst;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            burst.Play();
            coins++;
            print("Coins " + coins);
            Destroy(gameObject, 0.3f);
        }
    }
}
