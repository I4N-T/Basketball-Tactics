using UnityEngine;
using System.Collections;

public class SelectionBorderScript : MonoBehaviour {

    SpriteRenderer sr;

	// Use this for initialization
	void Start ()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (GameManager.selectedAthlete != null)
        {
            sr.enabled = true;
            transform.position = GameManager.selectedAthlete.transform.position;
        }
        else if (GameManager.selectedAthlete == null)
        {
            sr.enabled = false;
        }
	
	}
}
