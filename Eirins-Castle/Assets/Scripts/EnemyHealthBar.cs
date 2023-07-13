using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    private float normStatus = 1f;
    private static float maxHits = 2f;
    private float currHits = maxHits;
    private static float maxBarLenght = 0.3f;
    
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
    public void setHealthBar()
    {
        //if enemy takes damage
        if(normStatus > 0)
        {
            this.GetComponent<Transform>().localScale = new Vector3((lossHealth(0.0001f) * maxBarLenght), this.transform.localScale.y, 1.0f);
        }

        //if enemy gains health
        //if(normStatus < 0)
        //{
        //    this.GetComponent<Transform>().localScale = new Vector3((gainHealth(1f) * maxBarLenght), this.transform.localScale.y, 1.0f);
        //}
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        setHealthBar();
    }
}
