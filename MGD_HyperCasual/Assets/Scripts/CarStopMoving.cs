using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarStopMoving : MonoBehaviour
{

    public road_ScrollDown stopMovingCar;
    private Animator enemyCarAnim;

    // Start is called before the first frame update
    void Start()
    {
        enemyCarAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //enemyCarAnim.SetTrigger("IGotHit");
            Debug.Log("IT WORKS");
        }
    }
}
