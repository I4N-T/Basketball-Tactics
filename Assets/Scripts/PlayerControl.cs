using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    public bool isSelected;
    public bool hasMoved;

    public Vector2 position;
    public GameObject gameManagerObject;

    private Athlete athleteScript;
    private StatsTextScript statsTextScript;
    

	
	void Start ()
    {
        statsTextScript = gameManagerObject.GetComponent<StatsTextScript>();
        athleteScript = gameObject.GetComponent<Athlete>();
        if (gameObject.name == "PointGuard")
        {
            athleteScript.isPossessionChange = true;  //start point guard off with the ball
        }
        position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
	}
	

	void Update ()
    {
        if (isSelected)
        {
            
        }
	
	}

    private void OnMouseDown()
    {
        if (!isSelected)
        {
            if (!GameManager.isPassMode)
            {
                isSelected = true;
                GameManager.selectedAthlete = gameObject.GetComponent<Athlete>();  //set this as selected athlete in GameManager script
                //set all other athletes to not selected
                GameManager gmScript = gameManagerObject.GetComponent<GameManager>();  //get gameManagerScript
                PlayerControl pcScript;  //use to hold player controller script of each athlete
                foreach (Athlete athlete in gmScript.athleteList)
                {
                    if (athlete.gameObject != gameObject)
                    {
                        pcScript = athlete.gameObject.GetComponent<PlayerControl>();
                        pcScript.isSelected = false;
                    }
                }

                //activate stats texts
                statsTextScript.nameText.gameObject.SetActive(true);
                statsTextScript.speedText.gameObject.SetActive(true);
                statsTextScript.threePointerText.gameObject.SetActive(true);
                statsTextScript.twoPointerText.gameObject.SetActive(true);
                statsTextScript.handlesText.gameObject.SetActive(true);
                statsTextScript.blockText.gameObject.SetActive(true);
            }
            else if (GameManager.isPassMode)
            {
                if (!GameManager.selectedAthlete.gameObject.GetComponent<PlayerControl>().hasMoved)
                {
                    GameManager.selectedAthlete.isPossessionChange = true;
                    athleteScript.isPossessionChange = true;
                    GameManager.isPassMode = false;
                    GameManager.selectedAthlete.gameObject.GetComponent<PlayerControl>().hasMoved = true;
                }              
            }        
        }
    }
}
