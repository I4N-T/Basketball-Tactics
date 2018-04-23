using UnityEngine;
using System.Collections;

public class TileScript : MonoBehaviour {

    PlayerControl pcScript;  //use to hold player controller script of each athlete
    

    private void OnMouseDown()
    {
        
        if (GameManager.selectedAthlete != null)
        {
            pcScript = GameManager.selectedAthlete.gameObject.GetComponent<PlayerControl>();
            if (!pcScript.hasMoved)
            {
                float distance = Vector3.Distance(GameManager.selectedAthlete.transform.position, new Vector3(transform.position.x, transform.position.y, -1));
                print("distance: " + distance);

                if (distance <= GameManager.selectedAthlete.speed)
                {
                    GameManager.selectedAthlete.transform.position = new Vector3(transform.position.x, transform.position.y, -1);  //perform the move
                    pcScript.hasMoved = true;  //set this athlete to hasMoved = true so it can't move again until the next turn
                }
            }

            
        }
    }
}
