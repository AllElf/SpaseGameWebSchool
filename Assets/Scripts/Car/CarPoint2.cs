using UnityEngine;
using System.Collections.Generic;

public class CarPoint2 : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _maxSpeed;
    [SerializeField] float _turnSpeed;
    public float _range;
    public bool _isGround;
    [SerializeField] bool _isWalk;
    [SerializeField] Rigidbody rb;
    Vector3 vec;
    [SerializeField] List<Vector3> vecList = new List<Vector3>();
    [SerializeField] bool useList = true; // ������������� ������

    private void Start()
    {
        _isGround = true;
        _isWalk = false;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            SetTarget();
        }
        if (vecList.Count > 0)
        {
            Move();
        }
    }

    void SetTarget()
    {
        RaycastHit _hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out _hit))
        {
            if (_hit.collider != null && _hit.collider.tag == "Ground")
            {
                vec = new Vector3(_hit.point.x, _hit.point.y, _hit.point.z);
                if (useList)
                {
                    // �������� �� ������������ ��������� ����������� �������
                    if (vecList.Count == 0 || vecList[vecList.Count - 1] != vec)
                    {
                        vecList.Add(vec);
                    }
                }
                else
                {
                    // ������ ������ ����� �������
                    vecList.Clear();
                    vecList.Add(vec);
                }
            }
        }
    }

    void Move()
    {
        if (vecList.Count == 0)
        {
            return;
        }

        Vector3 targetPosition = vecList[0];
        Vector3 direction = (targetPosition - rb.transform.position).normalized;

        // ������� � ����
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        rb.MoveRotation(Quaternion.RotateTowards(rb.rotation, lookRotation, _turnSpeed * Time.deltaTime));

        // �������� ������
        if (rb.linearVelocity.magnitude < _maxSpeed)
        {
            rb.AddForce(transform.forward * _speed);
        }

        // �������� �� ���������� �����
        if (Vector3.Distance(rb.transform.position, targetPosition) < 0.5f)
        {
            vecList.RemoveAt(0);
        }
    }
}