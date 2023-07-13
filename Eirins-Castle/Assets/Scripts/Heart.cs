using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    public Sprite[] heartStatus = new Sprite[3];

    private float normStatus = 1f; //starts off as a full heart status represents the normalized status of the heart as a percentage 0 - 1
    private static float maxHits = 2f; // the max amount of hits a single heart can take
    private float currHits = maxHits;
    public Heart() { }

    public Heart(float _normStatus, float _maxHits)
    {
        normStatus = _normStatus;
        maxHits = _maxHits;
    }

    //min value is 0 since the lowest value a heart can have is 0, curr is the current value that the heart has and max is the maxHits a heart can take.
    public void calculateNormilzedStatus(float curr)
    {
        //normilzed value formula = Z[i] = (X[i] - min) / (max - min)
        normStatus = (curr - 0) / (maxHits - 0);
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

    //lose half a heart for every hit
    public void lossHealth(float num)
    {
        currHits = currHits - num;
        calculateNormilzedStatus(currHits);
    }

    public void gainHealth(float num)
    {
        currHits = currHits + num;
        calculateNormilzedStatus(currHits);
    }

    private void SetHeartImage()
    {
        if(normStatus == 1)
        {
            //set full heart
            this.GetComponent<Image>().sprite = heartStatus[0];
        }
        else if(normStatus == 0.5f)
        {
            //set half heart
            this.GetComponent <Image>().sprite = heartStatus[1];
        }
        else
        {
            //set empty heart
            this.GetComponent<Image>().sprite= heartStatus[2];
        }
    }

    private void Start()
    {
        this.GetComponent<Image>().sprite = heartStatus[0]; 
    }

    private void LateUpdate()
    {
        SetHeartImage();
    }

}
