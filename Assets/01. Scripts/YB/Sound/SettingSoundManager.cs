using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingSoundManager : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private AudioSource backgroundMusicSource;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
        }
        Load();

        // 슬라이더가 변경될 때 ChangeVolume 메서드를 호출하도록 이벤트 리스너 추가
        volumeSlider.onValueChanged.AddListener(delegate { ChangeVolume(); });
    }

    public void ChangeVolume()
    {
        // 슬라이더 값에 따라 배경음악 볼륨을 조절
        backgroundMusicSource.volume = volumeSlider.value;
        Save();
    }

    private void Load()
    {
        // 저장된 볼륨 값을 불러와 슬라이더와 배경음악 볼륨에 적용
        float volume = PlayerPrefs.GetFloat("musicVolume");
        volumeSlider.value = volume;
        backgroundMusicSource.volume = volume;
    }

    private void Save()
    {
        // 현재 슬라이더 값을 저장
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}
