using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerrigidbody : MonoBehaviour
{
    public float speed = 2f; 
    public float rotspeed = 10f;
    float newRotY = 0;
    public GameObject prefabBullet;
    Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void fixUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        { 
         rb.AddForce(0, 0, speed,ForceMode.VelocityChange);
            newRotY = 0;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(0, 0, -speed, ForceMode.VelocityChange);
            newRotY = 180;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(-speed , 0, 0, ForceMode.VelocityChange);
            newRotY = -90;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(speed, 0, 0, ForceMode.VelocityChange);
            newRotY = 90;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Instantiate(prefabBullet);
        }
        
             transform.rotation = Quaternion.Lerp(Quaternion.Euler(0, newRotY, 0), transform.rotation, rotspeed* Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);

        if (collision.gameObject.tag == "collectable") 
        {
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "collectable")
        {
            Destroy(other.gameObject);
        }
    }
  

}
