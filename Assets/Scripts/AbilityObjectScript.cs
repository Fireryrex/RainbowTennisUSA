using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityObjectScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] string[] abilities;
    [SerializeField] AbilityTransferScript abilityRail;
    [SerializeField] string player;
    [SerializeField] string ability;
    void Start()
    {
        abilityRail = this.transform.parent.gameObject.GetComponentInParent<AbilityTransferScript>();
        ability = abilities[Random.Range(0, abilities.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ball") && collision.gameObject.GetComponent<BallBounce>().GetLastPlayerHit() != "")
        {
            player = collision.gameObject.GetComponent<BallBounce>().GetLastPlayerHit();
            print(ability);
            print(player);
            abilityRail.transferAbility(player, ability);
            Destroy(this.gameObject);
        }
    }
}
