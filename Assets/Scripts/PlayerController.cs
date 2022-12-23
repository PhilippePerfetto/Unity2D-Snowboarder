using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField] private float torqueAmount = 4.5f;
    //[SerializeField] private float boostSpeed = 60f;
    [SerializeField] private float baseSpeed = 30f;
    SurfaceEffector2D surfaceEffector2D;
    private bool canMove = true;

    [SerializeField] Component background2D;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start...");
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
/*
        var all = GetComponents<Type>();
        foreach(var e in all) {
            {
                Debug.Log("e : " + e.ToString());
            }
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            RotatePlayer();

            RespondToBoost();
        }
    }

    public void DisableControls()
    {
        canMove = false;
    }

    private void RespondToBoost()
    {
        float added = Time.deltaTime * 10f;

        background2D.transform.position = new Vector3(background2D.transform.position.x - added / 5.0f, background2D.transform.position.y, background2D.transform.position.z);
        //surfaceEffector2DFar.transform.position = new Vector3(surfaceEffector2DFar.transform.position.x - added / 10.0f, surfaceEffector2DFar.transform.position.y, surfaceEffector2DFar.transform.position.z);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed += added;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            surfaceEffector2D.speed -= added;
        }
        else if (surfaceEffector2D.speed > baseSpeed) {
            surfaceEffector2D.speed -=added;
        }
        else if (surfaceEffector2D.speed < baseSpeed) {
            surfaceEffector2D.speed +=added;
        }
    }

    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount, 0.0f);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount, 0.0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("enter2d");
    }
}
