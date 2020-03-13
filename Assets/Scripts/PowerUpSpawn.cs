using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawn : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float verticalRange = 2f;
    [SerializeField] PowerUpSpawnManager spawnManager;


    private float maxHeight;
    private  float minHeight;

    private bool goingUp;
    private bool goingDown;

    // Start is called before the first frame update
    void Start()
    {
        goingUp = true;
        goingDown = false;

        maxHeight = transform.position.y + verticalRange;
        minHeight = transform.position.y - verticalRange;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
         Vector3 currentPos = transform.position;
         if (goingUp)
         {
             transform.position = Vector3.MoveTowards(transform.position, new Vector3(0,maxHeight,0), speed * Time.fixedDeltaTime);
            if(transform.position.y >= maxHeight)
            {
                goingUp = false;
                goingDown = true;
            }
         }

        if (goingDown)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, minHeight, 0), speed * Time.fixedDeltaTime);
            if (transform.position.y <= minHeight)
            {
                goingUp = true;
                goingDown = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        spawnManager.makeNextTime();
    }
}
