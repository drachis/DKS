using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float baseSpeed = 1;
    public float speedRange, startingPosition, startingPositionVariation, maximumPosition, heightRange;
    public GameObject projectile;
    // Use this for initialization
    private float speed;
    void Start()
    {
        Respawn();
    }

    // Update is called once per frame

    void Update()
    {
        // fly forward
        gameObject.transform.localPosition = new Vector3(
            gameObject.transform.localPosition.x - speed * Time.deltaTime,
            gameObject.transform.localPosition.y,
            gameObject.transform.localPosition.z
            );
        if (gameObject.transform.localPosition.x < maximumPosition)
        {
            Respawn();
        }
        Debug.Log(projectile.GetComponent<Collider>().tag);
        if (projectile.GetComponent<Collider>().tag == "Player") {
            Respawn();
        }
        
    }

    void Respawn()
    {
        // start with a random position inside the screen and with some speed variation
        speed = Random.Range(baseSpeed - speedRange, baseSpeed + speedRange);
        gameObject.transform.localPosition = new Vector3(
            startingPosition + Random.value * startingPositionVariation,
            Random.Range(-heightRange, heightRange),
            gameObject.transform.localPosition.z);
    }
}
