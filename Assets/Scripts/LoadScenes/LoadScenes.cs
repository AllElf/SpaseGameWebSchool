using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    [SerializeField] string sceneMobileName;
    [SerializeField] string scenePCName;

    public void MobileVersion()
    {
        SceneManager.LoadScene(sceneMobileName);
    }
    public void PCVersion()
    {
        SceneManager.LoadScene(scenePCName);
    }
}
