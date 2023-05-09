using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameObject SlimePlayer;
    PlayerHealth playerHealth;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;
    

    private void Awake()
    {
        playerHealth = SlimePlayer.GetComponent<PlayerHealth>();
    }

    private void Start()
    {
        totalHealthBar.fillAmount = 1;
        currentHealthBar.fillAmount = 1;
    }

    private void Update()
    {
        if (SlimePlayer.GetComponent<PlayerHealth>().healthCurrent == 5)
            currentHealthBar.fillAmount = 1;

        if (SlimePlayer.GetComponent<PlayerHealth>().healthCurrent == 4)
            currentHealthBar.fillAmount = .8f;

        if (SlimePlayer.GetComponent<PlayerHealth>().healthCurrent == 3)
            currentHealthBar.fillAmount = .6f;

        if (SlimePlayer.GetComponent<PlayerHealth>().healthCurrent == 2)
            currentHealthBar.fillAmount = .4f;

        if (SlimePlayer.GetComponent<PlayerHealth>().healthCurrent == 1)
            currentHealthBar.fillAmount = .2f;

        if (SlimePlayer.GetComponent<PlayerHealth>().healthCurrent == 0)
            currentHealthBar.fillAmount = 0;
    }
}

