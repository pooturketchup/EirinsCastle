using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBullet : BaseMagicSpell
{
    private Vector2 currPos;

    private void Update()
    {
        if(isLive)
        {
            spellMovement();
        }
        else
        {
            resetSpell();
        }
    }

    public override BaseMagicSpell spellMovement()
    {
        //float x = this.transform.position.x;
        //float y = this.transform.position.y;
        //Vector2 PointOfOrigin = this.transform.position;
        //Vector2 dir = this.transform.forward;

        //currPos = PointOfOrigin;

        //this.transform.position = currPos;

        

        return this;
    }
}
