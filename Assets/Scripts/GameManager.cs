using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Clock clock;
    private bool gameOver;
    private Movement player;
    private int cookies;
    [SerializeField] private Door door;
    [SerializeField] private TextMeshProUGUI collect;
    // Start is called before the first frame update
    void Start()
    {
        clock = FindAnyObjectByType<Clock>();
        player = FindAnyObjectByType<Movement>();
        cookies = FindObjectsOfType<Cookie>().Length;
        collect.text = $"Cookies: {cookies}";
    }

    // Update is called once per frame
    void Update()
    {
        if(clock.time <= 0)
        {
            gameOver = true;
        }
        if (gameOver == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if(cookies <= 0)
        {
            door.open = true;
        }
        cookies = FindObjectsOfType<Cookie>().Length;
        //UpdateCount();
    }
    public void Updates()
    {
        StartCoroutine(UpdateCount());
    }
    IEnumerator UpdateCount()
    {
        yield return new WaitForEndOfFrame();
        collect.text = $"Cookies: {cookies}";
    }
}
