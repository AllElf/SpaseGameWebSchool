using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManagerMenu : MonoBehaviour
{
    [Header("Настройки сцены")]
    [SerializeField] string nameScene = "Flying2.0";

    [Header("Таймер")]
    public float _time = 300f;
    [SerializeField] Text _text;
    public bool stopTime;

    [Header("UI и Аудио")]
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject gamePause;
    [SerializeField] AudioSource audioSource;

    [Header("Камера (3D)")]
    [SerializeField] Camera targetCamera;
    [SerializeField] float portraitFOV = 70f;
    [SerializeField] float landscapeFOV = 60f;

    [Header("Внутренние состояния")]
    bool lastIsPortrait;
    bool lastGamePauseState;
    bool lastGameOverState;

    Coroutine currentTimerCoroutine;

    private void Start()
    {
        lastIsPortrait = Screen.height > Screen.width;
        ApplyCameraFOV(lastIsPortrait);
        PrintOrientation(lastIsPortrait);

        // Стартуем таймер
        if (_text != null && _time > 0)
        {
            currentTimerCoroutine = StartCoroutine(TimerLevel());
        }

        UpdateTimeScale();
    }

    private void Update()
    {
        CheckOrientation();
        UpdateTimeScale();
    }

    public void Pause()
    {
        if (gamePause == null) return;

        gamePause.SetActive(!gamePause.activeSelf);

        // Таймер остановится автоматически через stopTime в UpdateTimeScale
    }

    public void RestartGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(nameScene);
    }

    void UpdateTimeScale()
    {
        bool isGameOver = gameOver != null && gameOver.activeSelf;
        bool isPaused = gamePause != null && gamePause.activeSelf;

        bool shouldPause = isGameOver || isPaused;

        // Всегда обновляем stopTime
        stopTime = shouldPause;

        // Только если изменилось состояние паузы/окна game over
        if (isGameOver != lastGameOverState || isPaused != lastGamePauseState)
        {
            Time.timeScale = shouldPause ? 0f : 1f;

            if (audioSource != null)
            {
                if (shouldPause) audioSource.Pause();
                else audioSource.Play();
            }

            lastGameOverState = isGameOver;
            lastGamePauseState = isPaused;
        }
    }

    void CheckOrientation()
    {
        bool isPortrait = Screen.height > Screen.width;

        if (isPortrait != lastIsPortrait)
        {
            ApplyCameraFOV(isPortrait);
            PrintOrientation(isPortrait);
            lastIsPortrait = isPortrait;
        }
    }

    void ApplyCameraFOV(bool isPortrait)
    {
        if (targetCamera != null)
        {
            targetCamera.fieldOfView = isPortrait ? portraitFOV : landscapeFOV;
            Debug.Log($"[Камера] Ориентация: {(isPortrait ? "Портрет" : "Альбом")} → FOV: {targetCamera.fieldOfView}");
        }
    }

    void PrintOrientation(bool isPortrait)
    {
        Debug.Log("Ориентация: " + (isPortrait ? "Портрет" : "Альбомная"));
    }

    IEnumerator TimerLevel()
    {
        while (_time > 0)
        {
            if (!stopTime)
            {
                _time--;
                if (_text != null)
                    _text.text = "Timer: " + _time.ToString("F0") + " second";

                if (_time <= 0)
                {
                    Debug.Log("Таймер завершён.");
                    yield break;
                }
            }

            yield return new WaitForSecondsRealtime(1f);
        }
    }
}
