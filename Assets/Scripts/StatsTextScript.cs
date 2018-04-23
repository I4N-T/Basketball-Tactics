using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatsTextScript : MonoBehaviour {

    public Text nameText;
    public Text speedText;
    public Text threePointerText;
    public Text twoPointerText;
    public Text handlesText;
    public Text blockText;

    public PlayerControl pcScript;

	void Update ()
    {
        if (GameManager.selectedAthlete != null)
        {
            nameText.text = GameManager.selectedAthlete.name;
            speedText.text = "Speed: " + GameManager.selectedAthlete.speed;
            threePointerText.text = "3-Pointers: " + GameManager.selectedAthlete.threePointers;
            twoPointerText.text = "2-Pointers: " + GameManager.selectedAthlete.twoPointers;
            handlesText.text = "Handles: " + GameManager.selectedAthlete.handles;
            blockText.text = "Block: " + GameManager.selectedAthlete.block;
        }
        if (GameManager.selectedAthlete == null)
        {
            //TODO: MAKE THIS STUFF ONLY HAPPEN ONCE INSTEAD OF IN UPDATE
            nameText.gameObject.SetActive(false);
            speedText.gameObject.SetActive(false);
            threePointerText.gameObject.SetActive(false);
            twoPointerText.gameObject.SetActive(false);
            handlesText.gameObject.SetActive(false);
            blockText.gameObject.SetActive(false);
        }
	
	}
}
