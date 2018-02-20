using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float dodgeRange = 1;
    public float speed = 1;
    public GameObject ship;
    public float dodgeDurection, dodgeCooldown;

    public float dodgeTimeRemaining { get; private set; }
    public int hits { get; private set; } // how many times has the ship been hit

    private float triggerR,
                triggerL,
                dodgeStart = 0,
                dodgeEnd = 0;
    private Vector3 dogeDirection;
    // Use this for initialization
    void Start()
    {
        hits = 0;
    }

    // Update is called once per frame
    private Vector3 controledParentPosition, controlledChildPosition;
    void Update()
    {
        //update container object position
        controledParentPosition = new Vector3(
            gameObject.transform.localPosition.x,
            gameObject.transform.localPosition.y +
                (speed * Time.deltaTime * Input.GetAxis("Vertical")),
            gameObject.transform.localPosition.z);
        gameObject.transform.localPosition = controledParentPosition;
        // update child object position
        triggerR = Mathf.Max(Input.GetAxis("TriggerR"), 0);
        triggerL = Mathf.Max(Input.GetAxis("TriggerL"), 0);
        if (Time.time > dodgeEnd + dodgeCooldown&&
            (triggerL > 0.5 ||
             triggerR > 0.5)
           )
        {
            Debug.Log("starting a dodge");
            dodgeStart = Time.time;
            dodgeEnd = dodgeStart + dodgeDurection;
            if (triggerL > 0.5)
            {
                controlledChildPosition = new Vector3(
                     ship.transform.localPosition.x,
                     dodgeRange,
                     ship.transform.localPosition.z);
            }
            if (triggerR > 0.5)
            {
                controlledChildPosition = new Vector3(
                      ship.transform.localPosition.x,
                      -dodgeRange,
                      ship.transform.localPosition.z);
            }
            // we can dodge   
        }
        if (Time.time < dodgeEnd)
        {
             float interpolator = (Time.time - dodgeStart) / (dodgeDurection);
            Vector3 lerpOutput;
            if (interpolator<0.5){
                lerpOutput = Vector3.Slerp(Vector3.zero, controlledChildPosition, (interpolator*2));
            } else {
                lerpOutput = Vector3.Slerp(ship.gameObject.transform.localPosition, Vector3.zero, (interpolator * 2)-1);
            }
            Debug.Log("We are dodging: " + lerpOutput +" "+ interpolator);
            ship.gameObject.transform.localPosition = lerpOutput;
            //we are dodging
        }
		dodgeTimeRemaining = dodgeEnd + dodgeCooldown - Time.time;
        //Debug.Log("Triggers : " + triggerL + " " + triggerR)
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("I've been hit!");
        if(collision.collider.tag == "Enemy")
            hits += 1;
    }
}
