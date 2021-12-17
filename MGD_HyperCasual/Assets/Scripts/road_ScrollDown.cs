using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class road_ScrollDown : MonoBehaviour
{
    private car_Move carMoveScript;
    public float speed = 10;
    public float downbound = -15;


    // Start is called before the first frame update
    void Start()
    {
        carMoveScript = GameObject.Find("newestPlayerAsset").gameObject.GetComponent<car_Move>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!carMoveScript.stopScrolling)
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }
    }
}
