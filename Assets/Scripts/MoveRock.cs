using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRock : MonoBehaviour
{
    private Rigidbody rockRb;
    [SerializeField] private float rockSpeed = 10000;

    // Start is called before the first frame update
    void Start()
    {
        rockRb = GetComponent<Rigidbody>();
        rockRb.AddForce(transform.forward * rockSpeed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
