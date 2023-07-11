using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart
{
    private float normStatus = 1f; //starts off as a full heart status represents the normalized status of the heart as a percentage 0 - 1
    private float maxHits = 2f; // the max amount of hits a single heart can take

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
   
}
