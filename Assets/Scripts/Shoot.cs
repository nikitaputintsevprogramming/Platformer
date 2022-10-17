using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private int fireSpeed;
    [SerializeField] private Transform firePoint;


    public void Shooter(float direction)
    {
        GameObject currentBullet = Instantiate(bullet, firePoint.position, Quaternion.identity);
        Rigidbody2D currentVelocity = currentBullet.GetComponent<Rigidbody2D>();

        if(direction >= 0)
        {
            currentVelocity.velocity = new Vector2(fireSpeed * 1, currentVelocity.velocity.y);
        }
        else
        {
            currentVelocity.velocity = new Vector2(fireSpeed * -1, currentVelocity.velocity.y);
        }
    }
}
