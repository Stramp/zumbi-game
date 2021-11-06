using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerUI : MonoBehaviour
{
    private PlayerController playerScript;
    public Slider HealthBar;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        HealthBar.maxValue = playerScript.maxHealth;
        HealthBar.value = playerScript.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void UpdateHealth(float health)
    {
        HealthBar.value = health;
    }
}
