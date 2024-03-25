using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [HideInInspector]
    public float speed;

    [SerializeField]
    private Transform leftPos, rightPos;

    private Rigidbody2D myBody;

    // Start is called before the first frame update
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        myBody.velocity = new Vector2(speed, myBody.velocity.y);

        if (gameObject.transform.position.x < leftPos.position.x)
        {
            Destroy(gameObject);
        }
        else if (gameObject.transform.position.x > rightPos.position.x)
        {
            Destroy(gameObject);
        }
    }
}
