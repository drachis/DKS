using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float dodgeRange = 1;
    public float speed = 1;
    public GameObject ship;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    private Vector3 controledParentPosition, controlledChildPosition;    
	void Update () {
        //update container object position
        controledParentPosition = new Vector3(
            gameObject.transform.localPosition.x,
            gameObject.transform.localPosition.y + 
                (speed * Time.deltaTime * Input.GetAxis("Vertical")),
            gameObject.transform.localPosition.z);
        gameObject.transform.localPosition = controledParentPosition;
        // update child object position
        controlledChildPosition = new Vector3(
            ship.transform.localPosition.x,
            Input.GetAxis("Vertical") * dodgeRange,
            ship.transform.localPosition.z);
        ship.gameObject.transform.localPosition = controlledChildPosition;
    }
    
}
