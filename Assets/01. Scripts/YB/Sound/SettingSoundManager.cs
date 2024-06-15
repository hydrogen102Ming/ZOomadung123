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

        // �����̴��� ����� �� ChangeVolume �޼��带 ȣ���ϵ��� �̺�Ʈ ������ �߰�
        volumeSlider.onValueChanged.AddListener(delegate { ChangeVolume(); });
    }

    public void ChangeVolume()
    {
        // �����̴� ���� ���� ������� ������ ����
        backgroundMusicSource.volume = volumeSlider.value;
        Save();
    }

    private void Load()
    {
        // ����� ���� ���� �ҷ��� �����̴��� ������� ������ ����
        float volume = PlayerPrefs.GetFloat("musicVolume");
        volumeSlider.value = volume;
        backgroundMusicSource.volume = volume;
    }

    private void Save()
    {
        // ���� �����̴� ���� ����
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}
