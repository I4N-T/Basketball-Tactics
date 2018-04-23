using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OpponentScoreScript : MonoBehaviour {

    public Text opponentScoreText;

    void Update()
    {
        opponentScoreText.text = "Away: " + GameManager.opponentScore;
    }
}
