using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FireBullet : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (!GetComponentInParent<SpriteRenderer>().flipX)
        {
            Vector3 vector3 = transform.position + new Vector3(-0.6f, 0.15f, 0);
            GameObject bulletIns = Instantiate(bullet, vector3, Quaternion.Euler(0, -180, 0));
            bulletIns.GetComponent<Rigidbody2D>().velocity = new Vector2(-15, 0);
        }
        else
        {
            Vector3 vector3 = transform.position + new Vector3(0.6f, 0.15f, 0);
            GameObject bulletIns = Instantiate(bullet, vector3, Quaternion.Euler(0,0,0));
            bulletIns.GetComponent<Rigidbody2D>().velocity = new Vector2(15,0);
        }
    }
}
