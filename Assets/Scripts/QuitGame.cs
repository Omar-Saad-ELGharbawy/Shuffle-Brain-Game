using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    [SerializeField] GameObject quitPanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowQuitPanel();
        }
    }

    public void ShowQuitPanel()
    {
        quitPanel.SetActive(true);
    }

    public void CancelQuit()
    {
        quitPanel.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
