using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookie : MonoBehaviour
{
    private Clock clock;
    [SerializeField] private Movement player;
    // Start is called before the first frame update
    void Start()
    {
        clock = FindAnyObjectByType<Clock>();
        player = FindAnyObjectByType<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            clock.ChangeTime(5);
        }
    }
}
