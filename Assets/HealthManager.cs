using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

    public Image healthBar;
    public Image enegyBar;
    public CharacterStats stats;


	// Use this for initialization
	void Start () {
        stats = GetComponent<CharacterStats>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
        float healthPercent = GetStatsPercent(stats.currentHealth, stats.maxHealth);
        healthBar.fillAmount = healthPercent;
	}

    float GetStatsPercent( int currentStat, int maxStat)
    {
        return Mathf.Clamp01(currentStat / (float)maxStat);
    }
}
