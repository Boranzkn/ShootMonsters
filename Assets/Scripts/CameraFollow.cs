using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private float minX, maxX;

    private Transform player;

    private Vector3 tempPos;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!player)
            return;

        tempPos = new Vector3(player.position.x, transform.position.y, transform.position.z);

        if (tempPos.x < minX)
            tempPos.x = minX;
        else if (tempPos.x > maxX)
            tempPos.x = maxX;

        transform.position = tempPos;
    }
}
