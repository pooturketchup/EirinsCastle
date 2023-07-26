using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    private float normStatus = 1f;
    private static float maxHits = 2f;
    private float currHits = maxHits;
    private static float maxBarLenght = 1f;
    public bool isDamaged = false;
    public bool isHealed = false;
    public bool isDead = false;
    
    public EnemyHealthBar() { }

    public EnemyHealthBar(float _normStatus, float _maxHits)
    {
        normStatus = _normStatus;
        maxHits = _maxHits;
    }

    public float calculateNormilzedStatus(float curr)
    {
        //normilzed value formula = Z[i] = (X[i] - min) / (max - min)
        return normStatus = (curr - 0) / (maxHits - 0);
    }

   
    public float getNormStatus()
    {
        return normStatus;
    }

    public void setNormStatus(float num)
    {
        normStatus = num;
    }
    public float getMaxHits()
    {
        return maxHits;
    }

    public void setMaxHits(float hits)
    {
        maxHits = hits;
    }

    public float lossHealth(float num)
    {
        currHits = currHits - num;
        return calculateNormilzedStatus(currHits);
    }

    public float gainHealth(float num)
    {
        currHits = currHits + num;
        return calculateNormilzedStatus(currHits);
    }

    //adjust the length of the health bar
    public void setHealthBar(float num)
    {
        //if health goes below 0 set to die
        if(normStatus <= 0)
        {
            normStatus=0;
            this.GetComponent<Transform>().localScale = new Vector3(0, this.transform.localScale.y, 1.0f);
            isDead = true;
        }

        //if enemy takes damage
        if(normStatus > 0 && isDamaged == true)
        {
            this.GetComponent<Transform>().localScale = new Vector3((lossHealth(num) * maxBarLenght), this.transform.localScale.y, 1.0f);
        }

        //if enemy gains health
        if (normStatus <= 1 && isHealed == true)
        {
            this.GetComponent<Transform>().localScale = new Vector3((gainHealth(num) * maxBarLenght), this.transform.localScale.y, 1.0f);
        }

        //make sure health does not exceed 100%
        if(normStatus > 1)
        {
            normStatus = 1;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //setHealthBar(0.002f);
    }
}
