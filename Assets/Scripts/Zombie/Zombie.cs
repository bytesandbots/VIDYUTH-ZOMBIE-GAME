using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class Zombie : MonoBehaviour
{
    public NavMeshAgent parasite;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        parasite = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        parasite.SetDestination(player.position);
    }
}
