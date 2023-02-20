using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameExit : MonoBehaviour
{

    //ゲーム終了:ボタンから呼び出す
    public void EndGame()
    {
        SoundManager.Instance.PlaySE(SESoundData.SE.BUTTON);
        Application.Quit();//ゲームプレイ終了
    }

}