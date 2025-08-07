using UnityEngine.UI;
using UnityEngine;

public class HealthIndicator : MonoBehaviour
{
    [SerializeField] Image _imageHalth;
    [SerializeField] EnamyRotation _enamyBomb;
    [SerializeField] EnamySpider _enamySpider;
    [SerializeField] TheFlyingEnemy _theFlyingEnemy;
    [SerializeField] Canvas _halth;
    [SerializeField] float _divider;
    [SerializeField] string _healthIndicator;
    private void Start()
    {
        Identification();
        ChaildCount();
        
    }
    private void FixedUpdate()
    {
        FindComponent();
        
    }
    void Identification()
    {
        if (transform.GetComponent<EnamyRotation>())
        {
            _enamyBomb = transform.GetComponent<EnamyRotation>();
            _divider = _enamyBomb._heath;
        }
        else if (transform.GetComponent<EnamySpider>())
        {
            _enamySpider = transform.GetComponent<EnamySpider>();
            _divider = _enamySpider._heath;
        }
        else if (transform.GetComponent<TheFlyingEnemy>())
        {
            _theFlyingEnemy = transform.GetComponent<TheFlyingEnemy>();
            _divider = _theFlyingEnemy._heath;
        }
    }
    void FindComponent()
    {
        if(_enamyBomb != null)
        {
            _imageHalth.fillAmount = _enamyBomb._heath / _divider;
            _healthIndicator = _imageHalth.fillAmount.ToString();
            if(_enamyBomb._betweenDistance > _enamyBomb._distance)
            {
                _halth.enabled = false;
            }
            else
            {
                _halth.enabled = true;
            }
        }
        else if (_enamySpider != null)
        {
            _imageHalth.fillAmount = _enamySpider._heath / _divider;
            _healthIndicator = _imageHalth.fillAmount.ToString();
            if (_enamySpider._betweenDistance > _enamySpider._distance)
            {
                _halth.enabled = false;
            }
            else
            {
                _halth.enabled = true;
            }
        }
        else if (_theFlyingEnemy != null)
        {
            _imageHalth.fillAmount = _theFlyingEnemy._heath / _divider;
            _healthIndicator = _imageHalth.fillAmount.ToString();
            if (_theFlyingEnemy._betweenDistance > _theFlyingEnemy._distance)
            {
                _halth.enabled = false;
            }
            else
            {
                _halth.enabled = true;
            }
        }
    }
    void ChaildCount()
    {
        int i = transform.childCount;
        for (int j = 0; j < i; j++)
        {
            if (transform.GetChild(j).name == "HealthImage")
            {
                _halth = GetComponentInChildren<Canvas>();
                _imageHalth = GetComponentInChildren<Image>();  
            }
        }
    }
   
}
