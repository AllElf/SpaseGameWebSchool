using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtStarship : MonoBehaviour
{
    [SerializeField] string _nameStarship = "Starship";
    [SerializeField] GameObject _starship;

    private void Start()
    {
        _starship = GameObject.Find(_nameStarship);
    }
    private void FixedUpdate()
    {
        transform.LookAt(_starship.transform.position);
    }
}
