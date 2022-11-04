using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeCoin : MonoBehaviour
{
    [SerializeField] private int coins;
    [SerializeField] private ParticleSystem burst;

    // Когда игрока касается чего либо проверяем объект на тег Coin
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Coin")
        {            
            burst.Play();
            coins++;
            print("Coins " + coins);
            Destroy(other.gameObject, 0.3f);
        }
    }
}
