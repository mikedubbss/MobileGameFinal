using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class loopingBackground : MonoBehaviour
{
    //private Vector2 startPos;
    //private double repeatWidth;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    startPos = transform.position;
    //    repeatWidth = GetComponent<BoxCollider2D>().size.y / 0.78;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (transform.position.y < startPos.y - repeatWidth)
    //    {
    //        transform.position = startPos;
    //    }
    //}

    private car_Move carMoveScript;
    public float speed = 0.5f;
    private Renderer r;

    // Start is called before the first frame update
    void Start()
    {
        carMoveScript = GameObject.Find("newestPlayerAsset").gameObject.GetComponent<car_Move>();
        r = GetComponent<Renderer>(); //r is a reference to the renderer 
    }

    // Update is called once per frame
    void Update()
    {
        if (!carMoveScript.stopScrolling)
        {
            //transform.Translate(Vector2.down * Time.deltaTime * speed);
            //speed = 0;

            Vector2 offset = new Vector2(Time.time * -speed, 0);
            r.material.mainTextureOffset = offset;   //offset material of object
        }
    }
}