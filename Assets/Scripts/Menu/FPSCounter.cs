using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    public Text fpsText;
    private float timer;
    private int frames;

    void Update()
    {
        frames++;
        timer += Time.unscaledDeltaTime;

        if (timer >= 1f)
        {
            int fps = Mathf.RoundToInt(frames / timer);
            fpsText.text = "FPS: " + fps;
            frames = 0;
            timer = 0f;
        }
    }
}