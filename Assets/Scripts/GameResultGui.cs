using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameResultGui : MonoBehaviour
{
    public GameRuleCtrl GameRuleCtrl;
    public Texture GameClearTexture;
    public Texture GameOverRawImage;
    public RawImage GameResultRawImage;

    void Start()
    {
        GameResultRawImage.enabled = false;
    }

    void Update()
    {
        if (GameRuleCtrl.gameClear)
        {
            GameResultRawImage.enabled = true;
            GetComponent<RawImage>().texture = GameClearTexture;
        }
        else if (GameRuleCtrl.gameOver)
        {
            GameResultRawImage.enabled = true;
            GetComponent<RawImage>().texture = GameOverRawImage;
        }
    }
}
