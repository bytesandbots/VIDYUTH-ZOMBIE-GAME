using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class Zombie : MonoBehaviour
{
    public string[] attack = new string[4];
    public string[] movement = new string[3];
    public string die;
    private string choice;
    public int health;

    public NavMeshAgent parasite;
    public Transform player;
    private Animator zzz;

    
    // Start is called before the first frame update
    void Start()
    {
        choice = movement[Random.Range(0, movement.Length)];
        parasite = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        zzz = GetComponent<Animator>();
        if (choice == movement[0]) 
        {
            zzz.SetTrigger(choice);
            parasite.speed = 40;
        }
        if(choice == movement[1])
        {
            zzz.SetTrigger(choice);
            parasite.speed = 10;
        }
        if (choice == movement[2])
        {
            zzz.SetTrigger(choice);
            parasite.speed = 20;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
        parasite.SetDestination(player.position);

        if(health<=0) 
        {
            Destroy(gameObject);
        }
    }
 
    }

