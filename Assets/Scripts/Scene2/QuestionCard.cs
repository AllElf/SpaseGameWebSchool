using UnityEngine;

public class QuestionCard : MonoBehaviour
{
    [SerializeField] string _findQuestions = "Questions/PanelQuestion1";
    [SerializeField] GameObject _questionPrefab;
    [SerializeField] RectTransform _pointPanelQuestions;
    bool _isMoving;
    [SerializeField] float _speed = 5f;
    CameraLookAtMe _cameraLookAtMe;
    [SerializeField] Animator _animator;
    [SerializeField] CanvasQuestionScript _canvasQuestionScript;
    [SerializeField] GameObject _pref;
    ParticlesChest _particlesChest;

    private void Start()
    {
        _questionPrefab = Resources.Load<GameObject>(_findQuestions);
        _isMoving = false;
        _cameraLookAtMe = GetComponent<CameraLookAtMe>();
        _animator = GetComponent<Animator>();
        _cameraLookAtMe.enabled = false;
        _canvasQuestionScript = GameObject.FindGameObjectWithTag("ScriptManager").GetComponent<CanvasQuestionScript>();
        _particlesChest = GetComponentInParent<ParticlesChest>();
    }
    private void OnMouseDown()
    {
        _isMoving = true;
    }
    private void FixedUpdate()
    {
        if (_isMoving == true)
        {
            _animator.enabled = false;
            _cameraLookAtMe.enabled = true;
            transform.position = Vector3.MoveTowards(transform.position, Camera.main.transform.position, _speed * Time.deltaTime);
            
            if (transform.position == Camera.main.transform.position)
            {
                _canvasQuestionScript._enabledCanvas = true;
                _pref = Instantiate(_questionPrefab, _pointPanelQuestions.position, _pointPanelQuestions.rotation, _pointPanelQuestions);
                _pref.GetComponent<RightAnswer>()._particlesChestAnswer = _particlesChest;
                Destroy(gameObject);
            }
        }
    }
}
