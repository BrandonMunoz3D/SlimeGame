using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health playerhealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;
   

    private void Start()
    {
        totalhealthBar.fillAmount = playerhealth.currentHealth / 5;
    }

    private void Update()
    {
        currenthealthBar.fillAmount = playerhealth.currentHealth / 5; 
    }
}

