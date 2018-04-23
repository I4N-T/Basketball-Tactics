using UnityEngine;
using System.Collections;

public class HoopScript : MonoBehaviour {

    GameManager gmScript;
    public GameObject gameManagerObject;
    PlayerControl pcScript;  //use to hold player controller script of each athlete
    public GameObject endTurnObject;
    public EndTurnButtonScript endTurnScript;


    private void Start()
    {
        gmScript = gameManagerObject.GetComponent<GameManager>();
        endTurnScript = endTurnObject.GetComponent<EndTurnButtonScript>();
    }
    private void OnMouseDown()
    {
        pcScript = GameManager.selectedAthlete.gameObject.GetComponent<PlayerControl>();
        if (GameManager.selectedAthlete != null && GameManager.selectedAthlete.hasPossesion && !pcScript.hasMoved)
        {
            /*float distance = Vector3.Distance(GameManager.selectedAthlete.transform.position, new Vector3(transform.position.x, transform.position.y, -1));
            print("distance: " + distance);*/

            shoot();
            print("made it to this");
            pcScript.hasMoved = true;

            //remove ball possession from the shooter
            GameManager.selectedAthlete.isPossessionChange = true;

            //reset positions
            foreach (Athlete athlete in gmScript.athleteList)
            {
                athlete.startPositionSet();
                if (athlete.name == "PointGuard")
                {
                    athlete.isPossessionChange = true;  //give ball to pointguard
                }
            }

            //end turn
            endTurnScript.EndTurnBtnAction();
            
        }

        
    }

    private void shoot()
    {
        int shotSkill = GameManager.selectedAthlete.twoPointers;
        int rand = Random.Range(0, 10);

        if (shotSkill > rand)
        {
            GameManager.playerScore += 2;
        }
        else if (shotSkill <= rand)
        {
            GameManager.opponentScore += 2;
        }

    }
}
