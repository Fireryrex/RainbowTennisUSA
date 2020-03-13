using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSound : MonoBehaviour
{
    [SerializeField] AudioClip BounceNoiseWall;
    [SerializeField] AudioClip BounceNoiseBlock;
    [SerializeField] string BlockTag = "Block";
    AudioSource src;
    // Start is called before the first frame update
    void Start()
    {
        if (this.GetComponent<AudioSource>() != null)
            src = this.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (BounceNoiseBlock != null && collision.transform.gameObject.tag == BlockTag)
        {
            src.PlayOneShot(BounceNoiseBlock);
        }else if(BounceNoiseWall != null)
        {
            src.PlayOneShot(BounceNoiseWall);
        }
    }
}
