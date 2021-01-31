using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartMenu : MonoBehaviour
{
    [SerializeField] GameObject startMenu;
    [SerializeField] GameObject optionsMenu;
    public void StartGame(int _scenIndex)
    {
        SceneManager.LoadScene(_scenIndex);
    }
    public void OptionsActive(bool activity)
    {
        startMenu.SetActive(!activity);
        optionsMenu.SetActive(activity);
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
