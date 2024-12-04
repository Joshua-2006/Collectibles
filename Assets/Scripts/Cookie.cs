using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookie : MonoBehaviour
{
    private Clock clock;
    [SerializeField] private Movement player;
    GameManager gm;
    
    
    // Start is called before the first frame update
    void Start()
    {
        clock = FindAnyObjectByType<Clock>();
        player = FindAnyObjectByType<Movement>();
        gm = FindAnyObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.CompareTag("Player"))
        {
            clock.ChangeTime(5);
            gm.Updates();
            Destroy(gameObject);
        }
    }
}
