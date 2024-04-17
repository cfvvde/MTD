using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public Transform bullet;
    public int BulletForce = 5000;
    public GameObject spawn;
    

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Transform BulletInstance = (Transform)Instantiate(bullet, spawn.transform.position, Quaternion.identity);
            BulletInstance.GetComponent<Rigidbody>().AddForce(transform.forward * BulletForce);

        }
    }
}
