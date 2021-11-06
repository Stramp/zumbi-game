using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZumbiCreator : MonoBehaviour
{
    public GameObject zumbi;
    public int TimeRespawn;
    private float timeCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime;
        if(timeCounter > TimeRespawn)
        {
            Instantiate(zumbi, transform.position, transform.rotation);
            timeCounter = 0;
        }
        //Instantiate(zumbi, transform.position, transform.rotation);
    }
}
