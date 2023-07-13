using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMagicSpell
{
    BaseMagicSpell spellMovement();
} 

public class BaseMagicSpell : MonoBehaviour, IMagicSpell
{
    protected float velocity = 1.2f;
    protected float acceleration = 0f;
    protected float spellSizeRadius = 0.3f;
    protected float spellCastTime = 0.33f;
    protected float blastRadius = 0.2f;
    protected float blastDuration = 0.1f;
    protected bool isPlayerSpell = true;
    protected float hitDamage = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void fire()
    {

    }

    BaseMagicSpell IMagicSpell.spellMovement()
    {
        return null;
    }
}
