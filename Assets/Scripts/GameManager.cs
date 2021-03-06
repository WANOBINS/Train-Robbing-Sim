﻿using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject Camera;
    public GameObject EnemyObject;
    public Enemy EnemyScript;
    public AudioMixerSnapshot Coin;

    // Use this for initialization
    private void Start()
    {
        if (!Player)
        {
            print("ERROR: No player!");
            Application.Quit();
        }
        EnemyObject = GameObject.FindGameObjectWithTag("Enemy");
        if (EnemyObject)
        {
            EnemyScript = (Enemy)EnemyObject.GetComponent<Enemy>();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (!Player)
        {
            SceneManager.LoadScene("Main_Menu");
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("Main_Menu");
            }
            if (Player.transform.position.x >= 7 &&
                Player.transform.position.y < .75f &&
                Player.transform.position.y > -.75f)
            {
                if (Player.transform.position.x < 13.75f)
                {
                    Camera.transform.position = new Vector3(Camera.transform.position.x + 0.289f, Camera.transform.position.y, Camera.transform.position.z);
                }
                else
                {
                    Camera.transform.position = new Vector3(0, 0, -10f);
                    EnemyScript.SpeedUp();
                }
            }
        }
    }
}