using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentation : MonoBehaviour
{
    public Animator animator;
    public GameObject cam;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        animator.SetFloat("InputMagnitudeZ", vertical);
        animator.SetFloat("InputMagnitudeX", horizontal);

        if(Input.GetMouseButton(1)){
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, cam.transform.eulerAngles.y, 0), Time.deltaTime * 100);
            //animator.SetBool("isAiming", true);
            cam.GetComponent<Camera>().fieldOfView = Mathf.Lerp(cam.GetComponent<Camera>().fieldOfView, 30f, Time.deltaTime * 10f);
        }else{
            transform.rotation=Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, cam.transform.eulerAngles.y, 0), Time.deltaTime * 50);
            //animator.SetBool("isAiming", true);
            cam.GetComponent<Camera>().fieldOfView = Mathf.Lerp(cam.GetComponent<Camera>().fieldOfView, 60f,  Time.deltaTime * 5f);
        }
    }
}
