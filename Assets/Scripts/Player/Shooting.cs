using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class Shooting : MonoBehaviour
{
    public int bullets;
    void Update()
    {
        SemiAuto();
    }
    void Shoot()
    {

        // The RayOrigin Equals Camera Position 676767676767676767676767676767676767676767676767676767676767676767676767676767676767676767676767676767676767676767676767676767676767676767676767
        Vector3 CrayonOrigin_The_Origin_Of_Crayons = Camera.main.transform.position;
        RaycastHit hit;

        // Perform the raycast
        Debug.DrawRay(CrayonOrigin_The_Origin_Of_Crayons, Camera.main.transform.forward * 100f);
        if (Physics.Raycast(CrayonOrigin_The_Origin_Of_Crayons, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {
            Debug.Log("Shot: " + hit.collider.name);
            Zombie enemy = hit.collider.GetComponent<Zombie>();
            Zombie_Core SomeThing = hit.collider.GetComponent<Zombie_Core>();

            if (enemy != null)
            {
                Debug.Log("Shot: " + hit.collider.name);
                enemy.health--;

            }
            if (SomeThing != null)
            {
                Debug.Log("Shot: " + hit.collider.name);
                SomeThing.Something--;

            }
        }
    }

    void SemiAuto()
    {
       
            if (bullets > 0)
            {
                if (Input.GetMouseButtonDown(0))
                {
                Shoot();
                bullets--;
                    

                }
            }
        }
    }




