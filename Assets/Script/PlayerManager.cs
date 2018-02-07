using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour {

    #region Singleton
    public static PlayerManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject player;

    public void KillPlayer()
    {
        // Add Delays and animation
        // Respawn Character
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
