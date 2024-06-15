using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingButton : MonoBehaviour
{
    public GameObject Settingpanel;

    void Update()
    {
        // ESC Ű �Է��� �����մϴ�.
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
        // �г��� Ȱ��ȭ ���¸� ����մϴ�.
        bool isActive = !Settingpanel.activeSelf;
        Settingpanel.SetActive(isActive);

        // �г��� Ȱ��ȭ�Ǿ� ���� �� �ð� ������ �ϰ�, ��Ȱ��ȭ�Ǿ� ���� �� �ð� �帧�� ����ȭ�մϴ�.
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
