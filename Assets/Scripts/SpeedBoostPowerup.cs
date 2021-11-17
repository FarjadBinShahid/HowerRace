using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostPowerup : PowerupBase
{
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(SpeedBoostTimer());
        }
    }

    IEnumerator SpeedBoostTimer()
    {
        player.GetComponent<HowerCraft>().speed *= 2;
        yield return new WaitForSeconds(3);
        player.GetComponent<HowerCraft>().speed /= 2;
    }
}
