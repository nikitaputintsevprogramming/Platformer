using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeCoin : MonoBehaviour
{
    [SerializeField] private CountCoin countCoin;
    [SerializeField] private ParticleSystem burst;

    private void Start()
    {
        countCoin = FindObjectOfType<CountCoin>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            burst.Play();
            countCoin.count++;          
            Destroy(gameObject, 0.3f);
        }
    }
}
