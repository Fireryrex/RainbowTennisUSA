using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowBlock : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionExit(Collision other)
    {
        //make sure the collission actually happens with a ball then destroy this block
        if (other.gameObject.tag == "Ball")
        {

            //do soemthing here to reverse the velocity of the pong fall
            Destroy(this.gameObject);
        }
    }
}
