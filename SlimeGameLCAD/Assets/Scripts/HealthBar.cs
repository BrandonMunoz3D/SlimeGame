using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    PlayerHealth healthCurrent;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;
   

    private void Start()
    {
        healthCurrent = GetComponent<PlayerHealth>();
        totalHealthBar.fillAmount = 1;
        currentHealthBar.fillAmount = 1;
    }

    private void Update()
    {
        //currenthealthBar.fillAmount = healthCurrent.currentHealth / 5; 
    }
}

