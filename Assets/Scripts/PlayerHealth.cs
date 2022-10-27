using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] private Image[] hearts;
    [SerializeField] private GameObject diePanel;
    [SerializeField] private AudioSource cameraSound;
    [SerializeField] private SpriteRenderer spriteRenderer;

    void Start()
    {
        Time.timeScale = 1;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (i >= 5 || gameObject.transform.position.y <= -1.5f)
        {
            diePanel.SetActive(true);
            cameraSound.Stop();
            spriteRenderer.enabled = false;
            Time.timeScale = 0;
            foreach (var heart in hearts)
            {
                heart.gameObject.SetActive(false);
            }
            print("death");
        }
    }

    private float timer = 0;
    private int i = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Enemy"))
        {
            print(collision.CompareTag("Enemy").ToString());
            if (timer >= 3)
            {
                if (i <= 4)
                {
                    
                    hearts[i + 1].GetComponent<AudioSource>().Play();
                    hearts[i].gameObject.SetActive(false);
                    GetComponent<Animator>().SetTrigger("IsHurt");
                    timer = 0;
                    i++;
                }

                if (i > 4)
                {
                    i++;
                }

            }
            else
            {
                GetComponent<Animator>().SetTrigger("IsIdle");
            }

        }

        if (collision.tag == "Health")
        {
            if (i > 0)
            {
                hearts[i - 1].gameObject.SetActive(true);
                i--;
                Destroy(collision.gameObject);
            }
        }
    }
}
