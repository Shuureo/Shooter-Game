using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour {

    // This script is used to manage the many scenes we have easily, so we dont need 100000000000 diffrient scripts to do so XD

    public void SingleplayerScene() {


    }

    public void MultiplayerScene() {

        SceneManager.LoadSceneAsync("Lobby");
    }

    public void SettingsScene() {


    }

    public void MainMenuScene() {

        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void Exit() {

        Application.Quit();
    }

}
