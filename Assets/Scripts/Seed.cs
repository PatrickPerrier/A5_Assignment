using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    //Cooldown timer
    public float coolDown = 10;
    public float coolDownTimer;

    private bool hasGrown;
    private bool doOnce;

    [SerializeField]
    GameObject child;

    private void Awake()
    {
        child.transform.gameObject.SetActive(false);
        print("seed was planted");
        Invoke("Grow", 10);
    }
    void Grow ()
    {

        child.transform.gameObject.SetActive(true);
    }
}
