using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public GameObject cam;
    public float speed = 10f;
    public float slowTax = 0.3f;
    public GameObject bullet;
    public GameObject aim;
    float speed2;
    Vector3 direction;
    float eixoX ;
    float eixoZ ;
    void Start()
    {
        speed2 = speed;
    }

    // Update is called once per frame
    void Update(){
        
        if(Input.GetKey(KeyCode.LeftShift)){
            speed = speed2 * 2;
        }else{
            speed = speed2;
        }
        if(Input.GetKey(KeyCode.S)){
            speed = speed2 - (slowTax * speed2);
        }
        if(Input.GetButtonDown("Fire1") && Input.GetMouseButton(1)){
                this.shooter();
            }
        
    }
    void FixedUpdate()
    {
        

        this.lookDirection();
        this.moveTo();

        
    }
    void lookDirection(){
        if(Input.GetMouseButton(1)){
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, cam.transform.eulerAngles.y, 0), Time.deltaTime * 100);
            speed = speed2 - (slowTax * speed2);
            animator.SetLayerWeight(1,((Mathf.Lerp(cam.GetComponent<Camera>().fieldOfView, 30f, Time.deltaTime * 10f)/ 30f)));
            cam.GetComponent<Camera>().fieldOfView = Mathf.Lerp(cam.GetComponent<Camera>().fieldOfView, 30f, Time.deltaTime * 10f);
            
        }else{
            transform.rotation=Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, cam.transform.eulerAngles.y, 0), Time.deltaTime * 50);
            animator.SetLayerWeight(1,((Mathf.Lerp(cam.GetComponent<Camera>().fieldOfView, 60f,  Time.deltaTime * 5f) / 30f)-2f)*-1);
            cam.GetComponent<Camera>().fieldOfView = Mathf.Lerp(cam.GetComponent<Camera>().fieldOfView, 60f,  Time.deltaTime * 5f);
        }
    }
    void moveTo(){
        eixoX = Input.GetAxis("Horizontal");
        eixoZ = Input.GetAxis("Vertical");
        direction = new Vector3(eixoX, 0, eixoZ) * speed * Time.deltaTime;
        transform.Translate(direction);
        animator.SetFloat("InputMagnitudeZ", eixoZ);
        animator.SetFloat("InputMagnitudeX", eixoX);
    }
    void shooter(){
        Instantiate(bullet, aim.transform.position, aim.transform.rotation);
    }
}
