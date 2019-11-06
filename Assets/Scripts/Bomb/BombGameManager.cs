﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombGameManager : MonoBehaviour
{
    public static BombGameManager Instance { get; private set; }
    [SerializeField] Text PlayerTeamScore;
    [SerializeField] Text EnemyTeamScore;
    [SerializeField] Text WinGame;
    [SerializeField] private GameObject whoWonCanvas;
    [SerializeField] Text CountDownText;
    [SerializeField] BaseBehaviour enemyBase;
    [SerializeField] BaseBehaviour allyBase;


    private int enemyScore;
    private int playerScore;
    private bool alliedBombPlanted;
    private bool enemyBombPlanted;
    //private float timer = 3f;


    private void Awake()
    {
        if (Instance != null) Destroy(this);
        Instance = this;
    }

    private void Start()
    {
        PlayerTeamScore.text = "PlayerTeamScore: " + playerScore.ToString() + "/3";
        EnemyTeamScore.text = "EnemyTeamScore: " + enemyScore.ToString() + "/3";

        //CountDownText.text = timer.ToString();
        whoWonCanvas.SetActive(false);
    }

    public void PlantBomb(Team team)
    {
        if(team == Team.Ally && !allyBase.Defused)
        {
            allyBase.Planted = true;
            alliedBombPlanted = true;
        }
        if (team == Team.Enemy && !enemyBase.Defused)
        {
            enemyBase.Planted = true;
            enemyBombPlanted = true;
        }

    }

    public void DefuseBomb(Team team)
    {
        if (team == Team.Ally)
        {
            allyBase.Defused = true;
            enemyBombPlanted = false;
        }
        if (team == Team.Enemy)
        {
            enemyBase.Defused = true;
            alliedBombPlanted = false;
        }
    }

    public void ScoreUp(Team team)
    {
        if (team == Team.Enemy)
        {
            enemyScore++;
            EnemyTeamScore.text = "EnemyTeamScore: " + enemyScore.ToString() + "/3";
            if (enemyScore >= 3)
                Win(team);
        }
        else
        {
            playerScore++;
            PlayerTeamScore.text = "PlayerTeamScore: " + playerScore.ToString() + "/3";
            if (playerScore >= 3)
                Win(team);
        }
    }

    public void Win(Team team)
    {
        if (team == Team.Ally)
            WinGame.text = "Ganaron los aliados";
        else
            WinGame.text = "Ganaron los enemigos";
        whoWonCanvas.SetActive(true);
        Time.timeScale = 0;
    }
}
