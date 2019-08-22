using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmer_Spawner : MonoBehaviour
{
    //Cooldown timer
    public float coolDown = 5;
    public float coolDownTimer;

    private bool spawFarmer;

    [SerializeField]
    GameObject farmer;
    private void Start()
    {
        Instantiate(farmer, transform.position, Quaternion.identity);
        Instantiate(farmer, transform.position, Quaternion.identity);
    }

    void Update()
    {
        if (coolDownTimer > 0)
        {
            coolDownTimer -= Time.deltaTime;
        }
        if (coolDownTimer < 0)
        {
            coolDownTimer = 0;
        }
        if (coolDownTimer == 0 && spawFarmer == false)
        {
            spawFarmer = true;

            Instantiate(farmer, transform.position, Quaternion.identity);
            coolDownTimer = coolDown;
            
            spawFarmer = false;
        }
    }
}
