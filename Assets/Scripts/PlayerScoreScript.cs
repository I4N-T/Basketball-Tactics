using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScoreScript : MonoBehaviour {

    public Text playerScoreText;

	void Update ()
    {
        playerScoreText.text = "Player: " + GameManager.playerScore;
	}
}
