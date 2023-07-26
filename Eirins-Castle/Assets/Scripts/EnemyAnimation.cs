using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimationSet
{
    IDLE,
    JUMP,
    ATTACK,
    MOVERIGHT,
    MOVELEFT,
    HURT,
    DEATH
}

public class EnemyAnimation : MonoBehaviour
{
    public BaseEnemy enemy;
    public Sprite[] idleSprites;
    public Sprite[] jumpSprites;
    public Sprite[] attackSprites;
    public Sprite[] moveRightSprites;
    public Sprite[] moveLeftSprites;
    public Sprite[] hurtSprites;
    public Sprite[] deathSprites;


    public float animationSpeed = 0.1f;

    private SpriteRenderer spriteRenderer;

    [NonSerialized]
    public AnimationSet currentAnimation;
   
    [NonSerialized]
    public bool isAnimating = false;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<BaseEnemy>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private IEnumerator PlayAnimation(Sprite[] animationSprites)
    {
        isAnimating = true;

        for (int i = 0; i < animationSprites.Length; i++)
        {
            spriteRenderer.sprite = animationSprites[i];
            yield return new WaitForSeconds(animationSpeed);
        }

        isAnimating = false;
    }

    // Update is called once per frame
    void Update()
    {  

        if(enemy.isMovingRight)
        {
            currentAnimation = AnimationSet.MOVERIGHT;
        }
        else if(enemy.isMovingLeft)
        {
            currentAnimation = AnimationSet.MOVELEFT;
        }
        else if(enemy.isJumping)
        {
            currentAnimation = AnimationSet.JUMP;
        }
        else if(enemy.isAttacking)
        {
            currentAnimation = AnimationSet.ATTACK;
        }
        else if(enemy.isDying)
        {
            currentAnimation = AnimationSet.DEATH;
        }
        else if (enemy.isHurt)
        {
            currentAnimation = AnimationSet.HURT;
        }
        else
        {
            currentAnimation = AnimationSet.IDLE;
        }

        if(!isAnimating && CheckAnimationChange(currentAnimation))
        {
            StartCoroutine(PlayAnimation(GetAnimationSprites()));
        }


    }

    private Sprite[] GetAnimationSprites()
    {
        switch (currentAnimation)
        {
            case AnimationSet.IDLE:
                return idleSprites;
            case AnimationSet.JUMP:
                return jumpSprites;
            case AnimationSet.ATTACK:
                return attackSprites;
            case AnimationSet.MOVERIGHT:
                return moveRightSprites;
            case AnimationSet.MOVELEFT:
                return moveLeftSprites;
            case AnimationSet.DEATH:
                return deathSprites;
            case AnimationSet.HURT:
                return hurtSprites;
            default:
                return null;
        }

    }

    private bool CheckAnimationChange(AnimationSet animation)
    {
        return currentAnimation == animation;
    }
}
