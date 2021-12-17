using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCollider : MonoBehaviour
{

    private Rigidbody playerRB;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Coins")
        {
            Destroy(other.gameObject);
        }

        if (other.tag == "CoinGroup")
        {
            Destroy(other.gameObject);
        }

        //THIS IS FOR THE FUEL WILL CHANGE THIS LATER
        if (other.tag == "Obstacle")
        {
            Destroy(other.gameObject);
        }

        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
    }
}
