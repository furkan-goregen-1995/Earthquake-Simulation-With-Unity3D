using System.Collections;
using UnityEngine.AI;
using System.Collections.Generic;
using UnityEngine;

public class navmesh : MonoBehaviour {

    public Transform home;
    NavMeshAgent agent;
    float durum;

   
    void Start () {

        
        agent = this.GetComponent<NavMeshAgent>();
        agent.SetDestination(home.position);
       
        
 }

    // Update is called once per frame
    void Update () {
   
        
         durum = islemler.depremsuresi;
        if (Time.timeScale == 1.0f && durum == 27.15f)
        {
            agent.baseOffset = 1.0f;
            agent.speed = 4;
            agent.angularSpeed = 2;
        }
        if (Time.timeScale == 1.0f && durum == 149.03f)
        {
            agent.baseOffset = 1.0f;
            agent.speed = 0;
            agent.angularSpeed = 20;
        }
    }
}
