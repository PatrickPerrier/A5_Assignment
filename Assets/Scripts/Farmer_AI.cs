using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Farmer_AI : MonoBehaviour
{

    [SerializeField]
    GameObject field;
    [SerializeField]
    GameObject seedPrefab;
    [SerializeField]
    ParticleSystem sleepParticles;

    public Vector3 center;
    public Vector3 size;

    public GameObject bed;
    public GameObject seedStock;
    Vector3 pos;

    NavMeshAgent agent;
    
    bool sleep;
    bool getSeed;
    bool plantSeed;
    
    void Awake()
    {  
        agent = GetComponent<NavMeshAgent>();
        bed = GameObject.Find("Bed_Position");
        seedStock = GameObject.Find("Seed_Location");
        GetSeed();
    }

    private void Update()
    {
        if (agent.remainingDistance <= 0.5f)
        {
            if (sleep == true && getSeed == false && plantSeed == false)
            {
                Sleep();
            }
            else if (sleep == false && getSeed == true && plantSeed == false)
            {
                GetSeed();
            }
            else if (sleep == false && getSeed == false && plantSeed == true)
            {
                PlantSeed();
            }
        }
        
    }
    
    private void Sleep ()
    {
        Vector3 fPosition = new Vector3(transform.position.x, 0, transform.position.z );
        Instantiate(seedPrefab, fPosition, Quaternion.identity);
        transform.Find("fSeed").gameObject.SetActive(false);
        agent.SetDestination(bed.transform.position);

        sleep = false;
        getSeed = true;
        plantSeed = false;
    }
    private void GetSeed ()
    {
        StartCoroutine(Delay());
    }
    private void PlantSeed()
    {
        transform.Find("fSeed").gameObject.SetActive(true);
        agent.SetDestination(SetSeedLocation());
        
        
        sleep = true;
        getSeed = false;
        plantSeed = false;
    }

    public Vector3 SetSeedLocation()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
        return pos;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }
    IEnumerator Delay ()
    {
        if (agent.hasPath == true)
        {
            sleepParticles.gameObject.SetActive(true);
            agent.isStopped = true;
            yield return new WaitForSeconds(5);
            agent.isStopped = false;
            sleepParticles.gameObject.SetActive(false);
        }
        
        agent.SetDestination(seedStock.transform.position);

        sleep = false;
        getSeed = false;
        plantSeed = true;

    }



}
