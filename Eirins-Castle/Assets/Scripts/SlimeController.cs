using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : BaseEnemy
{

    // Start is called before the first frame update
    void Start()
    {
      
    }

  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            dealDamage(playerController); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Die()
    {

    }
}
