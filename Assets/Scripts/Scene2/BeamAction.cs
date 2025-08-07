using System.Linq;
using UnityEngine;

public class BeamAction : MonoBehaviour
{
    private Ray _ray;
    private RaycastHit _hit;
    [SerializeField] private float _maxDistanceRay;
    [SerializeField] LineRenderer _lineRenderer;
    Vector3[] vec = new Vector3[2];
    [SerializeField] MovePoints _movePoints;
    public string _aim;
    [SerializeField] GameObject _hitPoint;
    [SerializeField] Vector3 _hitPosition;

    private void Start()
    {
        _movePoints = GameObject.FindGameObjectWithTag("Player").GetComponent<MovePoints>();
        LinerSearch();
    }

    void LinerSearch()
    {
        if (gameObject.GetComponent<LineRenderer>() != null)
        {
            _lineRenderer = GetComponent<LineRenderer>();
        }
        else
        {
            Debug.Log("Нет такого компонента");
        }
    }
    private void FixedUpdate()
    {
        Ray();
        DrawRay();
        Target();
    }
    private void Ray()
    {
        _maxDistanceRay = _movePoints._range;
        _ray = new Ray(transform.position, transform.forward * _maxDistanceRay);
        Debug.DrawRay(transform.position, transform.forward * _maxDistanceRay, Color.red);
        Vector3 vec1 = new Vector3(0, 0, _maxDistanceRay);
        vec.Append<Vector3>(vec1);
        vec[0] = new Vector3(0, 0, 0.1f);
        vec[1] = new Vector3(0, 0, _maxDistanceRay);
        _lineRenderer.SetPositions(vec);
    }
    private void DrawRay() // Метод для отрисовки луча (Можно и без него обойтись)
    {
        if (Physics.Raycast(_ray, out _hit, _maxDistanceRay)) // Physics.Raycast этот метод определяет столкнулся ли луч и внутрь записываем ( луч, то с чем столкнулся луч, на каком расстоянии ,будет проверка)
        {
            Debug.DrawRay(_ray.origin, _ray.direction * _maxDistanceRay, Color.blue); // Debug.DrawRay - отрисовка луча(Debug - метод проверки на ошибки) _ray.origin - откуда точка появляется _rey.direction - направление,  _rey.direction * _maxDistanceRay - определили дистанцию луча, луча Color.blue - цвет луча
            if (_hit.collider.CompareTag("Enamy") || _hit.collider.CompareTag("EnamyTrigger"))
            {
                _hitPoint.transform.position = _hit.point - _hitPosition;
                _hitPoint.transform.rotation = _hit.transform.rotation;
                _aim = "Враг на прицеле";
            }
            else
            {
                _aim = "Враг не прицеле"; 
            }
        }

        if (_hit.transform == null) // если наш луч не столкнулся не с одним из объектов из раздела transform то он становится красным
        {
            
            Debug.DrawRay(_ray.origin, _ray.direction * _maxDistanceRay, Color.red);
            _aim = "";
        }
    }
    void Target()
    {
        if (_aim == "Враг на прицеле")
        {
            //_hitPoint.GetComponent<MeshRenderer>().enabled = true;
            _hitPoint.SetActive(true);
            
        }
        else if (_aim == "Враг не прицеле")
        {
            //_hitPoint.GetComponent<MeshRenderer>().enabled = false;
            _hitPoint.SetActive(false);
        }
        else if (_aim == "")
        {
            _hitPoint.SetActive(false);
        }
    }
}
