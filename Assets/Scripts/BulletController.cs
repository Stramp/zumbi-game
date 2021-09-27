using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public int speed = 100;
    void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.forward * speed * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Inimigo")Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
