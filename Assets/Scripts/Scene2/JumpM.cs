using UnityEngine;

public class JumpM : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] MovePoints _movePoints;
    [SerializeField] bool _touchGround;
    [SerializeField] float _jump = 30;
    void Start()
    {
        _movePoints = GameObject.FindObjectOfType<MovePoints>();
        _touchGround = _movePoints._isGround;
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        _touchGround = _movePoints._isGround;
    }
    private void OnMouseDown()
    { 
        if (_touchGround == true)
        {
            JumpMobile();
            
        }
        else if (_touchGround == false)
        {
            Debug.Log("Не косается поверхности");
        }
    }
    public void JumpMobile()
    {
        Vector3 vec = new Vector3(0, 10f * _jump, 0);
        rb.AddForce(vec);
    }
    
}
