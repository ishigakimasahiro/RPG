using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameExit : MonoBehaviour
{

    //�Q�[���I��:�{�^������Ăяo��
    public void EndGame()
    {
        SoundManager.Instance.PlaySE(SESoundData.SE.BUTTON);
        Application.Quit();//�Q�[���v���C�I��
    }

}