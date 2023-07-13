using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BaseEnemy : MonoBehaviour
{
    protected static PlayerController playerController;
   
    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    protected void dealDamage(PlayerController player)
    {
        //find the right most active heart in array
        Heart heart = null;

        for (int i = player.hearts.Length - 1; i >= 0; i--)
        {
            if (!player.hearts[i].isActiveAndEnabled)
            {
                continue;
            }
            else if (player.hearts[i].isActiveAndEnabled && player.hearts[i].getNormStatus() > 0)
            {
                heart = player.hearts[i];
                heart.lossHealth(1);
                break;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

  

  
}
