using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class Shooting : MonoBehaviour
{
    public int pistolMagCount;
    private int pistolMag;
    public int pistolMagMax;
    private int pistolAmmo;
    public float pistolReloadSpeed = 0.9f;
    //Reload bools
    public bool rPressed = false;
    public bool isReloading = false;
    public float timer = 0;
    void Start()
    {
        pistolMag = pistolMagMax;
        pistolAmmo = pistolMagMax * pistolMagCount;
       
    }
    void Update()
    {
        SemiAuto();
    }
    void SemiAuto()
    {
        
        if (pistolMag > 0 || pistolAmmo > 0)
        {

            if (Input.GetKey(KeyCode.R))
            {
                rPressed = true;
            }

            if ((pistolMag <= 0 || pistolMag < pistolMagMax && rPressed) && pistolAmmo > 0)
            {
                //Debug.Log(timer); 
                timer += Time.deltaTime;
                if (timer >= pistolReloadSpeed)
                {
                    isReloading = false;
                    rPressed = false;
                    int remainingAmmo = Mathf.Max(0, pistolAmmo - (pistolMagMax - pistolMag));
                    // Debug.Log("Ammo Left " + remainingAmmo);
                    pistolMag = Mathf.Min(pistolAmmo + remainingAmmo, pistolMagMax);
                    //Debug.Log("Pistol Mag " + pistolMag);
                    pistolAmmo = remainingAmmo;
                    timer = 0;
                }
            }

            if (!isReloading && pistolMag > 0)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    pistolMag--;
                    Shoot();

                }
            }
        }
    }

    void Shoot()
    {

        // The RayOrigin Equals Camera Position 676767676767676767676767676767676767676767676767676767676767676767676767676767676767676767676767676767676767676767676767676767676767676767676767
        Vector3 CrayonOrigin_The_Origin_Of_Crayons = Camera.main.transform.position;
        RaycastHit hit;

        // Perform the raycast
        Debug.DrawRay(CrayonOrigin_The_Origin_Of_Crayons, Camera.main.transform.forward * 100f);
        if (Physics.Raycast(CrayonOrigin_The_Origin_Of_Crayons, Camera.main.transform.forward, out hit, 1000f ))
        {
            Debug.Log("Shot: " + hit.collider.name);
            Zombie enemy = hit.collider.GetComponent<Zombie>();
            if (enemy != null)
            {
                Debug.Log("Shot: " + hit.collider.name);
                enemy.health--;

            }
        }
    }

}



