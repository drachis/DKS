using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIScore : MonoBehaviour {

	public PlayerController player;
    private Text hits;
	// Use this for initialization
	void Start () {
        hits = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        hits.text = "Hits: " + player.hits.ToString("00");
	}
}
