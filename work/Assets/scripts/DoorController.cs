using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool DoorOpen = false;
    public GameObject door;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("DoorOpen", DoorOpen);
        //door.SetActive(!DoorOpen); เปิดได้ ไม่มี Animator
    }
}
