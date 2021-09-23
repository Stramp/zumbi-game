using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10f;
    float speed2;
    Vector3 direction;
    void Start()
    {
        speed2 = speed;
    }

    // Update is called once per frame
    void Update(){
        
        if(Input.GetKey(KeyCode.LeftShift)){
            speed = speed2 * 2;
            Debug.Log("Shift>> "+ speed);
        }else{
            Debug.Log("FORA Shift>> "+ speed);
            speed = speed2;
        }
        if(Input.GetKey(KeyCode.S)){
            float teste = (30f/100f * speed2);
            Debug.Log(teste);
           // Debug.Log("S  " +  (speed2 - (30%speed2)));
            speed = speed2 - teste;
        }
    }
    void FixedUpdate()
    {
        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");

        direction = new Vector3(eixoX, 0, eixoZ) * speed * Time.deltaTime;
        transform.Translate(direction);
    }
}
