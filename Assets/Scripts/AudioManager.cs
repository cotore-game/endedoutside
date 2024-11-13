using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    [SerializeField] public AudioSource as_bgm;
    [SerializeField] public AudioSource as_se;

    [Header("内部的なボリューム 0-1")]
    [SerializeField, Range(0f, 1.0f)] private float vol_bgm = 1f;
    [SerializeField, Range(0f, 1.0f)] private float vol_se = 1f;

    [Header("共通のフェードアウトの長さ")]
    [SerializeField] private float commonFadeTime = 1.5f;

    //フェード処理関係
    private bool isFadeOut = false;
    private float f_time = 0;
    private float f_deltaTime = 0;
    private float f_startVol;

    private bool isSwitch = false;
    private AudioClip nextAc;

    private void Update()
    {
        if (isFadeOut) FadeOut();
    }

    public void PlaySE(AudioClip ac)//どっちのAudioSourceかわからなくなるから作った
    {
        as_se.PlayOneShot(ac);
    }

    /*
    public void SetVolume()
    {
        float vol_master = GameManager.instance.vol_master;
        as_bgm.volume = vol_master * GameManager.instance.vol_bgm * vol_bgm;
        as_se.volume = vol_master * GameManager.instance.vol_se * vol_se;
    }
    */

    public void PlayBGM(AudioClip ac)
    {
        if (as_bgm.isPlaying)
        {
            isSwitch = true;
            nextAc = ac;
            StartFadeOut(commonFadeTime);
        }
        else
        {
            as_bgm.clip = ac;
            as_bgm.Play();
        }
    }
    public void PauseBGM(float fadeTime = 100)
    {
        if (fadeTime == 100) fadeTime = commonFadeTime;
        if (as_bgm.isPlaying) StartFadeOut(fadeTime);
    }

    private void StartFadeOut(float fadeTime)
    {
        f_time = fadeTime;
        isFadeOut = true;
    }
    private void FadeOut()//Updateで毎フレーム読み込む
    {
        if (f_deltaTime == 0) f_startVol = as_bgm.volume;

        as_bgm.volume = (f_time - f_deltaTime) * f_startVol / f_time;
        f_deltaTime += Time.deltaTime;

        if (f_deltaTime > f_time)
        {
            isFadeOut = false;
            as_bgm.Pause();
            as_bgm.volume = f_startVol;
            f_deltaTime = 0;

            if (isSwitch)
            {
                as_bgm.clip = nextAc;
                as_bgm.Play();
                isSwitch = false;
            }
        }
    }

}