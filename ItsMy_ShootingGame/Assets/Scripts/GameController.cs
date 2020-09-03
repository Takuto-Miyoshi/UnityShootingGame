using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    float timer = 0.0f;

    public enum GameState {
        Playing,
        Cleared,
        Failed,
    }
    GameState State = GameState.Playing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;

        switch (State) {
            case GameState.Playing:
                PlayingProcessing();
                break;
            case GameState.Cleared:
                ClearedProcessing();
                break;
            case GameState.Failed:
                FailedProcessing();
                break;
        }
    }

    void PlayingProcessing() {
    }

    void ClearedProcessing() {
        if (timer >= 5.0f) SceneManager.LoadScene("TitleScene");
    }

    void FailedProcessing() {
        if (timer >= 3.0f) SceneManager.LoadScene("TitleScene");
    }

    public void ChangeState(GameState new_state) {
        State = new_state;
        timer = 0.0f;
    }
}
