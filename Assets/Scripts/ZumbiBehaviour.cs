using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZumbiBehaviour : MonoBehaviour
{
    public float speed = 5f;
    Vector3 direction;
    float distaceForAttack;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        direction = (target.transform.position - transform.position).normalized * speed * Time.deltaTime;
        distaceForAttack = Vector3.Distance(target.transform.position, transform.position);
        Quaternion rotation = Quaternion.LookRotation(target.transform.position - transform.position);
        GetComponent<Rigidbody>().MoveRotation(rotation);
        if (distaceForAttack > 2.5f){
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + direction);    
            GetComponent<Animator>().SetBool("Attacking", false);
            return;
        }
        GetComponent<Animator>().SetBool("Attacking", true);
    }

    void AttackHit(){
        Time.timeScale = 0;
        target.GetComponent<PlayerController>().TakeDamage(1);
    }
}
