using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityScript : MonoBehaviour
{
    private string currentAbility;
    [SerializeField] string[] abilityList;
    [SerializeField] PaddleScript paddle;
    [SerializeField] BallBounce[] balls;
    private bool abilityActive = false;
    private float abilityDuration;

    //Wide Load Variables
    [SerializeField] float widenSize;

    //Catch Variables
    [SerializeField] float[] storedBallSpeed;
    [SerializeField] Vector3[] storedBallDirection;
    [SerializeField] Transform[] storedBallTransform;
    [SerializeField] string playerName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (abilityActive && abilityDuration >= 0)
        {
            abilityDuration -= Time.deltaTime;
        }
        else if (abilityActive && abilityDuration < 0)
        {
            abilityDuration = 0;
            activateAbility();
            abilityActive = false;
            setCurrentAbility("");
        }
    }

    public void setCurrentAbility(string ability)
    {
        currentAbility = ability;
    }

    public void activateAbility()
    {
        if (!abilityActive)
        {
            if (currentAbility == abilityList[1])
            {
                activateWideLoad();
            }
            else if (currentAbility == abilityList[2])
            {
                catchBall();
            }
        }
        else if (abilityActive)
        {
            if (currentAbility == abilityList[1])
            {
                deactivateWideLoad();
            }
            if (currentAbility == abilityList[2])
            {
                releaseBall();
            }
        }
    }

    private void activateWideLoad()
    {
        paddle.widen(widenSize);
    }

    private void deactivateWideLoad()
    {
        paddle.widen(0);
    }

    private void catchBall()
    {
        abilityActive = true;
    }

    private void releaseBall()
    {
        for(int i = 0; i < balls.Length; i++)
        {
            balls[i].SetSpeed(storedBallSpeed[i]);
            balls[i].SetDirection(storedBallDirection[i]);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ball"))
        {
            other.GetComponent<BallBounce>().SetLastPlayerHit(playerName);
            if(abilityActive && currentAbility == abilityList[2])
            {
                for(int i = 0; i < balls.Length; i++)
                {
                    storedBallSpeed[i] = balls[i].GetSpeed();
                    storedBallDirection[i] = balls[i].GetDirection();
                }
            }
        }
    }
}
