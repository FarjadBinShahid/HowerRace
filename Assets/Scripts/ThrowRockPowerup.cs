using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowRockPowerup : PowerupBase
{

    [SerializeField] private GameObject rockPrefab;
    private bool isThrowRockEnabled;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isThrowRockEnabled)
        {
            ThrowRock();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isThrowRockEnabled = true;
            //gameObject.SetActive(false);
        }
    }

    void ThrowRock()
    {
        Instantiate(rockPrefab, player.transform.position + new Vector3(0,2,0),player.transform.rotation);
        isThrowRockEnabled = false;
    }


}
