using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public Movement player;
    private Clock clock;
    public Transform move2;
    public Transform move;
    public float range = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        player = FindAnyObjectByType<Movement>();
        clock = FindAnyObjectByType<Clock>();
    }

    // Update is called once per frame
    void Update()
    {
        var distance = Vector3.Distance(transform.position, player.transform.position);
       
        if(distance <= range)
        {
            agent.destination = player.transform.position;
        }
        else if(distance > range)
        {
            StartCoroutine(Wait());
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            clock.ChangeTime(-5);
            Destroy(gameObject);
        }
    }
    IEnumerator Wait()
    {
        var distance2 = Vector3.Distance(transform.position, move2.position);
        var distance3 = Vector3.Distance(transform.position, move.position);
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        if (distance2 < distance3)
        {
            yield return new WaitForSeconds(5);
            agent.SetDestination(move.position);
        }
        else if (distance3 < distance2)
        {
            yield return new WaitForSeconds(5);
            agent.SetDestination(move2.position);
        }
    }
}
