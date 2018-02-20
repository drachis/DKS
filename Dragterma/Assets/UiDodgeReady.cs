using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiDodgeReady : MonoBehaviour {
    public PlayerController player;

    private UnityEngine.UI.Text dodgeReadyness;
	// Use this for initialization
	void Start () {
        dodgeReadyness = gameObject.GetComponent<UnityEngine.UI.Text>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(player.dodgeTimeRemaining > 0.05f)
        {
            dodgeReadyness.text = player.dodgeTimeRemaining.ToString();
            dodgeReadyness.color = new Color(1.0f, 0.5f, 0.25f);
        } else {
            dodgeReadyness.color = new Color(0.0f,1.0f,0.0f);
            dodgeReadyness.text = "Ready";
        }
	}
}
