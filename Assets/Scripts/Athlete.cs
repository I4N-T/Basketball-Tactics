using UnityEngine;
using System.Collections;

public class Athlete : MonoBehaviour {

    //stats
    public float speed;
    public int threePointers;
    public int twoPointers;
    public int handles;
    public int block;

    //does this athlete possess the ball?
    public bool hasPossesion;
    public bool isPossessionChange;
    
    //other
    private SpriteRenderer sr;
    public Vector3 startPosition;

    public enum AthleteTypes
    {
        pointGuard,
        shootingGuard,
        smallForward,
        powerForward,
        center
    }

    public AthleteTypes mainState;  //set athlete type in inspector

    private void StatAllocation()
    {
        switch (mainState)
        {
            case AthleteTypes.pointGuard:
                speed = 3.5f;
                threePointers = 5;
                twoPointers = 4;
                handles = 8;
                //block = 2;
                break;

            case AthleteTypes.shootingGuard:
                speed = 2.5f;
                threePointers = 7;
                twoPointers = 7;
                handles = 6;
                //block = 4;
                break;

            case AthleteTypes.smallForward:
                speed = 2.5f;
                threePointers = 6;
                twoPointers = 7;
                handles = 6;
                //block = 5;
                break;

            case AthleteTypes.powerForward:
                speed = 2.5f;
                threePointers = 5;
                twoPointers = 7;
                handles = 5;
                //block = 6;
                break;

            case AthleteTypes.center:
                speed = 2;
                threePointers = 2;
                twoPointers = 8;
                handles = 3;
                //block = 7;
                break;
        }
    }

    private void Awake()
    {
        sr = this.GetComponent<SpriteRenderer>();
        StatAllocation();
        //set in start position
        startPositionSet();
    }

    private void Update()
    {
        //change color if char has possession
        if (isPossessionChange)
        {
            if (hasPossesion)
            {
                sr.color = new Color(sr.color.r + 0.4f, sr.color.g + 0.4f, sr.color.b + 0.4f);
                hasPossesion = false;
            }
            else if (!hasPossesion)
            {
                sr.color = new Color(sr.color.r - 0.4f, sr.color.g - 0.4f, sr.color.b - 0.4f);
                hasPossesion = true;
            }
            isPossessionChange = false;
        }
    }

    public void startPositionSet()
    {
        transform.position = startPosition;
    }
}
