using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIcontroller : MonoBehaviour
{
    //ใช้งาน AI ผ่าน NavMesh
    NavMeshAgent agent;
   // เป้าหมาย AI ที่จะเดินผ่าน NavMesh ไปถึง
    public GameObject target;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
             agent.SetDestination(target.transform.position);
        }
       
    }
}
