using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform traget;
    [SerializeField]
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        traget = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = traget.position + offset;
    }
}
