using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour {

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
