
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] Scene2Controller _scene2Controller;
    [SerializeField] StarshipHealth _starshipHealth;
    [SerializeField] TimerFlying _timerFlying;
    [SerializeField] GameObject _canvasGameOver;
    [SerializeField] GameObject _CanvasGameWin;
    [SerializeField] GameObject _CanvasGame;

    private void Update()
    {
        if(_scene2Controller._counsTwoScene >= 10f)
        {
            _CanvasGameWin.SetActive(true);
            _CanvasGame.SetActive(false);
            Time.timeScale = 0f;
            
        }
        if (_starshipHealth.healthSparship <=0f)
        {
            _canvasGameOver.SetActive(true);
            _CanvasGame.SetActive(false);
            Time.timeScale = 0f;
            
        }
        if (_timerFlying._time <= 0)
        {
            _canvasGameOver.SetActive(true);
            _CanvasGame.SetActive(false);
            Time.timeScale = 0f;
        }
    }
}
