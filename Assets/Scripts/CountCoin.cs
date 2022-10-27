using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountCoin : MonoBehaviour
{
    [SerializeField] private Text countText;
    public int count = 0;

    void Update()
    {
        countText.text = count.ToString();
    }
}
