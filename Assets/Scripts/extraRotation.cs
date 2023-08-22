using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class extraRotation : MonoBehaviour
{
    [SerializeField] private float x = 0;
    [SerializeField] private float y = 0;
    [SerializeField] private float z = 0;

    // Update is called once per frame
    void Start()
    {
        transform.Rotate(x, y, z);
    }
}
