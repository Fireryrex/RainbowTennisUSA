using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityTransferScript : MonoBehaviour
{
    [SerializeField] GameObject paddleOne;
    [SerializeField] GameObject paddleTwo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void transferAbility(string paddleNumber, string abilityName)
    {
        //print("ability name is: " + abilityName);
        if(paddleNumber == "paddle1")
        {
            paddleOne.GetComponentInChildren<AbilityScript>().setCurrentAbility(abilityName);
        }
        else if(paddleNumber == "paddle2")
        {
            paddleTwo.GetComponentInChildren<AbilityScript>().setCurrentAbility(abilityName);
        }
    }
}
