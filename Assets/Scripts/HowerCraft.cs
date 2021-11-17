using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowerCraft : MonoBehaviour
{
    [SerializeField] Transform[] anchors;
    RaycastHit[] hits;
    private Rigidbody howerCraftRb;
    public float speed;
    public float torque;
    public float multiplier;
    public float verticalRotation = 500;
    public float horizontalRotation = 50;
    private float horizontalInput, verticalInput; // movement variables;

    public float gravityForce = 9.81f;
    int layerMask = 1<<7;


    // Start is called before the first frame update
    void Start()
    {
        hits = new RaycastHit[anchors.Length];
        howerCraftRb = GetComponent<Rigidbody>();
        
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //howerCraftRb.AddForceAtPosition(Vector3.up * gravityForce * howerCraftRb.mass, howerCraftRb.centerOfMass);

         for(int i = 0; i<anchors.Length; i++)
         {
             Hower(anchors[i], hits[i]);
         }
         Move();
    }

    void Hower(Transform anchor, RaycastHit hit)
    {
        
        if(Physics.Raycast(anchor.position, -transform.up, out hit,Mathf.Infinity, layerMask))
        {
            float force = 0;
            force = Mathf.Abs(1/(hit.point.y - anchor.position.y));
            howerCraftRb.AddForceAtPosition(transform.up* force* multiplier, anchor.position, ForceMode.Acceleration);
        }

    }

    void Move()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        howerCraftRb.AddForce(transform.forward * verticalInput * speed );
        howerCraftRb.AddTorque(transform.right * verticalInput * verticalRotation);
        howerCraftRb.AddTorque(transform.up * horizontalInput * torque );
        howerCraftRb.AddTorque(-transform.forward* horizontalInput* horizontalRotation);
    }
}
