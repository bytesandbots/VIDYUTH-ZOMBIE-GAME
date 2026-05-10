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
    bool dead = false;
    public int IDK;
    public GameObject healtho;
    public GameObject ammo_o;

    public NavMeshAgent parasite;
    public Transform player;
    private Animator zzz;

    public BoxCollider MC_Donalds;

    
    void Start()
    {
        MC_Donalds = GetComponent<BoxCollider>();
        IDK = Random.Range(1, 4);
        choice = movement[Random.Range(0, movement.Length)];
        parasite = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        zzz = GetComponent<Animator>();
        if (choice == movement[0]) 
        {
            zzz.SetTrigger(choice);
            parasite.speed = 10;
            health = Random.Range(1, 10);
        }
        if(choice == movement[1])
        {
            zzz.SetTrigger(choice);
            parasite.speed = 3;
            health = Random.Range(1, 10);
        }
        if (choice == movement[2])
        {
            zzz.SetTrigger(choice);
            parasite.speed = 5;
            health = Random.Range(1, 10);
        }

    }
    IEnumerator DeathAnimation() 
    {
        parasite.enabled = false;
        MC_Donalds.enabled = false;
        zzz.SetTrigger("Dying");
        yield return new WaitForSeconds(3.17f);
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        if (dead) return;
        parasite.SetDestination(player.position);

        if(health<=0) 
        {
            dead = true;
            switch (IDK) 
            {
                 case 1:
                    Instantiate(healtho,transform.position + Vector3.up,Quaternion.identity);
                    break;

                case 2:
                    Instantiate(ammo_o, transform.position + Vector3.up, Quaternion.identity);
                    break;

            }
            StartCoroutine(DeathAnimation());

                 
        }
    }
 
    }

