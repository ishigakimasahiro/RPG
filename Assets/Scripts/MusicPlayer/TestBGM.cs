using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBGM : MonoBehaviour
{

    void Start()
    {
        SoundManager.Instance.PlayBGM(BGMSoundData.BGM.TITLE);
    }
}
