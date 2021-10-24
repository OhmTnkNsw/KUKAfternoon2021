using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1f;
    public float rotspeed = 10f;
    float newRotY = 0;

    void Update()
    {
        float newx = transform.position.x;
        float newy = transform.position.y;
        float newz = transform.position.z;

        if (Input.GetKey(KeyCode.UpArrow))
            {
                newz = transform.position.z + speed * Time.deltaTime;
            newRotY = 0;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            newz = transform.position.z - speed * Time.deltaTime;
            newRotY = 180;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            newx = transform.position.x + speed * Time.deltaTime;
            newRotY = 90;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            newx = transform.position.x - speed * Time.deltaTime;
            newRotY = -90;
        }
        transform.position = new Vector3(newx, newy, newz);
        transform.rotation = Quaternion.Lerp(Quaternion.Euler(0, newRotY, 0), transform.rotation, rotspeed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
      
             /*if (collision.gameObject.name == "Sphere")
             {
                 transform.localScale = new Vector3(2, 2, 2);
             }

             if (collision.gameObject.name == "Cube")
             {
                 transform.localScale = new Vector3(1, 1, 1);
             }*/
    }
}


