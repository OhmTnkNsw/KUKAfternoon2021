using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rigibody : MonoBehaviour
{
    public float speed = 2f;
    public float rotspeed = 10f;
    float newRotY = 0;
    public GameObject prefabBullet;
    public Transform Gunposition;
    public float gunPower = 15f;
    public float gunCooldown = 2f;
    public float gunCooldowncount = 0;
    public bool hasgun = false;
    public int bulletCount = 0;

    public int coinCount = 0;
    PlaygroungScenemanager manager;
    public AudioSource audioCoin;
    public AudioSource audioFire;
  
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        manager = FindObjectOfType<PlaygroungScenemanager>();
        if(manager == null)
        {
            print("Manager not found!");
        }
        if (PlayerPrefs.HasKey("CoinCount"))
        { 
            coinCount =   PlayerPrefs.GetInt("CoinCount");
        }
        manager.SetTextCoin(coinCount);
    }

    // Update is called once per frame
     void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal") * speed;
        float vertical = Input.GetAxis("Vertical") * speed;
        if (horizontal > 0)
        {
            newRotY = 90;
        }
        else if (horizontal < 0)
        {
            newRotY = -90;
        }
        if (vertical > 0)
        {
            newRotY = 0;
        }
        else if (vertical < 0)
        {
            newRotY = 180;
        }

        rb.AddForce(horizontal, 0, vertical, ForceMode.VelocityChange);
        transform.rotation = Quaternion.Lerp(Quaternion.Euler(0, newRotY, 0), transform.rotation, rotspeed * Time.deltaTime);
        
       
       
       
    }

    private void Update()
    {
        gunCooldowncount += Time.deltaTime;
        //ยิงปืน
        if (Input.GetButtonDown("Fire1") && (bulletCount > 0) && (gunCooldowncount >= gunCooldown))
        {
            gunCooldowncount = 0;
            GameObject bullet = Instantiate(prefabBullet, Gunposition.position, Gunposition.rotation);
            //bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 15f, ForceMode.Impulse);
            Rigidbody bRb = bullet.GetComponent<Rigidbody>();
            bRb.AddForce(transform.forward * gunPower, ForceMode.Impulse);
            Destroy(bullet, 2f);
            
            bulletCount--;
            // หรือ bulletCount = bulletCount - 1;
            manager.SetTextBullet(bulletCount);
            audioFire.Play();
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
       // print(collision.gameObject.name);

        if (collision.gameObject.tag == "collectable")
        {
            Destroy(collision.gameObject);
        }
    }
    //เก็บเหรียญ
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "collectable")
        {
            Destroy(other.gameObject);
            coinCount++;
            manager.SetTextCoin(coinCount);
            audioCoin.Play();
            PlayerPrefs.SetInt("CoinCount", coinCount);
        }

        if (other.gameObject.name == "Gun")
        {
            print("Yea!!! I have a Gun");
            Destroy(other.gameObject);
            hasgun = true;
            //bulletCount = bulletCount + 10;
            bulletCount += 10;
            manager.SetTextBullet(bulletCount);
        }
    }
}
