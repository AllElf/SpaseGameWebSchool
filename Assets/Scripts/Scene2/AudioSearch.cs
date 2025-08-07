using UnityEngine;

public class AudioSearch : MonoBehaviour
{
    [SerializeField] AudioSource[] _audioSource;
    [SerializeField] MovePoints _movePoints;

    private void Start()
    {
        _audioSource = FindObjectsOfType<AudioSource>();
        _movePoints = GameObject.FindObjectOfType<MovePoints>();
    }

    private void FixedUpdate()
    {
        OverAudio();
    }
    void OverAudio()
    {
        if(_movePoints._heathPlayer == 0)
        {
            for (int i = 0; i < _audioSource.Length; i++)
            {
                _audioSource[i].Stop();
            }
        }
    }
}
