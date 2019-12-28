using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameResultGui : MonoBehaviour
{
    public GameRuleCtrl GameRuleCtrl;
    public Texture GameClearTexture;
    public Texture GameOverTexture;
    public RawImage GameResultRawImage;

    void Start()
    {
        //GetComponent<RectTransform>().position = new Vector3(100.0f, 0.0f, 0.0f);
        //gameObject.transform.position = new Vector3(100.0f, 0.0f, 0.0f);
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
            GetComponent<RawImage>().texture = GameOverTexture;
        }

        if (GameRuleCtrl.gameClear || GameRuleCtrl.gameOver)
        {
            GetComponent<RectTransform>().anchoredPosition = new Vector3(100.0f, 0.0f, 0.0f);
            //GetComponent<RectTransform>().SetPositionAndRotation(new Vector3(100.0f, 0.0f, 0.0f), Quaternion.identity);
        }
    }
}
