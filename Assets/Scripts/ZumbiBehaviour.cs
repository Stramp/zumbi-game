using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZumbiBehaviour : MonoBehaviour
{
    public float Speed = 5f;
    private int damage;
    private int fullLife;
    private int atualLife;
    private Vector3 direction;
    private float distaceForAttack;
    public GameObject target;

    private int[] damageArray = { 4,6,8,10,12 };

    private PlayerController targetScripts;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        targetScripts = target.GetComponent<PlayerController>();
        damage = damageArray[Random.Range(1, 5)];
        int random = Random.Range(1, 28);
        transform.localScale = new Vector3((float)damage /8f, (float)damage /8f, (float)damage /8f); 
        transform.GetChild(random).gameObject.SetActive(true);
        fullLife = Random.Range(8, 25);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        direction = (target.transform.position - transform.position).normalized * Speed * Time.deltaTime;
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
        targetScripts.TakeDamage(Random.Range(1, damage+1));
    }
}
