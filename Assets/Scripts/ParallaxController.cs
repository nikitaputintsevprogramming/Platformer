using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    [SerializeField] Transform[] Layers;

    [SerializeField] float[] koef;

    // Start is called before the first frame update
    void Start()
    {
        Layers = new Transform[5];

        Layers[0] = GameObject.Find("Background").transform;
        Layers[1] = GameObject.Find("Mountain").transform;
        Layers[2] = GameObject.Find("Mountain2").transform;
        Layers[3] = GameObject.Find("Mountain3").transform;
        Layers[4] = GameObject.Find("Trees").transform;

    }

    // Update is called once per frame
    void Update()
    {
        for (int count = 0; count < Layers.Length; count++)
        {
            Layers[count].position = transform.position * koef[count];
        }
        
    }
}
