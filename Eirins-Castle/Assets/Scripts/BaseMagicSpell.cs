using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public interface IMagicSpell
//{
//    BaseMagicSpell spellMovement();
//    void fire();
//    void resetSpell();
//} 

public abstract class BaseMagicSpell : MonoBehaviour//, IMagicSpell
{
    [SerializeField]
    protected float velocity = 1.2f;
    [SerializeField]
    protected float acceleration = 0f;
    [SerializeField]
    protected float spellSizeRadius = 0.3f;
    [SerializeField]
    protected float spellCastTime = 0.33f;
    [SerializeField]
    protected float spellRange = 1f;
    [SerializeField]
    protected float blastRadius = 0.2f;
    [SerializeField]
    protected float blastDuration = 0.1f;
    protected bool isPlayerSpell = true;
    [SerializeField]
    protected float hitDamage = 1f;
    
    public bool isLive = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void shoot()
    {

    }

    public virtual BaseMagicSpell spellMovement()
    {
        return null;
    }

    //resets Spell position and preps for reuse
    public void resetSpell()
    {
        this.transform.position = Vector3.zero;
    }
}
