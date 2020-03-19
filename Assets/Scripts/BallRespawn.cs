using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BallRespawn : MonoBehaviour
{
    [SerializeField] string winner;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject text;
    float time = 0;
    [SerializeField] int timeToWait = 10;
    bool countdown;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ball")
        {
            text.GetComponent<TextMeshProUGUI>().text = "THE WINNER IS:\n" + winner;
            time = Time.time;
            countdown = true;
        }
    }

    private void Update()
    {
        if(countdown == true)
        {
            Debug.Log(time);    
            if(Time.time - time >= 1)
            {
                time = Time.time;
                timeToWait--;
            }
            if(timeToWait <= 5)
            {
                text.GetComponent<TextMeshProUGUI>().text = "New Game in:\n" + timeToWait;
            }
            if(timeToWait <= 0)
            {
                SceneManager.LoadScene("ColeScene");
            }
        }
    }
}
