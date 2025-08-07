using UnityEngine;

public class ScriptShaderSky : MonoBehaviour
{
    [SerializeField] Material skybox;

    private void Start()
    {
        if(skybox == null) { RenderSettings.skybox = skybox; }  
    } 
}
