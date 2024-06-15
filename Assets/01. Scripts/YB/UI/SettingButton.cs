using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingButton : MonoBehaviour
{
    public GameObject Settingpanel;

    void Update()
    {
        // ESC 키 입력을 감지합니다.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleSettingPanel();
        }
    }

    public void SettingButtonClick()
    {
        ToggleSettingPanel();
    }

    private void ToggleSettingPanel()
    {
        // 패널의 활성화 상태를 토글합니다.
        bool isActive = !Settingpanel.activeSelf;
        Settingpanel.SetActive(isActive);

        // 패널이 활성화되어 있을 때 시간 정지를 하고, 비활성화되어 있을 때 시간 흐름을 정상화합니다.
        Time.timeScale = isActive ? 0f : 1f;
    }

    public void Resume()
    {
        Settingpanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Home()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("TitleScene");
    }

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
