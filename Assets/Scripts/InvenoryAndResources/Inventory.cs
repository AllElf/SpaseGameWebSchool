using System;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject _buttonRessourse;
    [SerializeField] GameObject _buttonRessourseClone;
    [SerializeField] Transform _point_RessourseClone;
    [SerializeField] GameObject _container;
    [SerializeField] GameObject _canvasInvenrory;
    [SerializeField] Transform _point_InventoryTrue;
    [SerializeField] Transform _point_InventoryFalse;

    public string _resourceName;
    public Sprite _image;

    private void Start()
    {
        //_buttonRessourse = new GameObject[100];
        _point_RessourseClone = GameObject.Find("ResoursesClonePoint").transform;
        _container = GameObject.Find("PanelContainer");
        _canvasInvenrory = GameObject.Find("Canvas (Inventory)");
        _point_InventoryTrue = GameObject.Find("Point_InventoryTrue").transform;
        _point_InventoryFalse = GameObject.Find("Point_InventoryFalse").transform;
    }
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.P))
        {
            Clone();
        }
    }

    public void PointCanvasInventoryFalse()
    {
       _canvasInvenrory.transform.position = _point_InventoryFalse.position; 
    }
    public void PointCanvasInventoryTrue()
    {
        _canvasInvenrory.transform.position = _point_InventoryTrue.position;
    }
    public void Clone()
    {
        #region comment
        //for(int i = 0;  i < _buttonRessourse.Length; i++) 
        //{
        //    if (_buttonRessourse[i] == null)
        //    {
        //        _buttonRessourse[i] = Instantiate(_buttonRessourseClone, _point_RessourseClone.position, _point_RessourseClone.rotation, _container.transform);
        //        _buttonRessourse[i].GetComponent<Image>().sprite = _image;
        //        _buttonRessourse[i].name = /*"Button (Resource) " + i.ToString();*/ _resourceName;
        //        _buttonRessourse[i].GetComponentInChildren<Text>().text = _resourceName;
        //        _image = null;
        //        _resourceName = null;
        //        break;
        //    }
        //    else if (_buttonRessourse[i] != null && _buttonRessourse[i].name == _resourceName)
        //    {
        //        _buttonRessourse[i].GetComponentInChildren<Text>().text += "x2";
        //    }
        //}
        #endregion
        if (_buttonRessourse == null)
        {
            int i = 1;
            _buttonRessourse = Instantiate(_buttonRessourseClone, _point_RessourseClone.position, _point_RessourseClone.rotation, _container.transform);
            _buttonRessourse.GetComponent<Image>().sprite = _image;
            _buttonRessourse.name = _resourceName;
            _buttonRessourse.GetComponentInChildren<Text>().text = i.ToString();
            _image = null;
            _resourceName = null;
            
        }
        else if (_buttonRessourse != null && _buttonRessourse.name == _resourceName)
        {
            int i;
            i = Convert.ToInt32(_buttonRessourse.GetComponentInChildren<Text>().text);
            i++;
            _buttonRessourse.GetComponentInChildren<Text>().text = i.ToString();
            _image = null;
            _resourceName = null;
        }
        else if(_buttonRessourse != null && _buttonRessourse.name != _resourceName)
        {
            int i = 1;
            _buttonRessourse = Instantiate(_buttonRessourseClone, _point_RessourseClone.position, _point_RessourseClone.rotation, _container.transform);
            _buttonRessourse.GetComponent<Image>().sprite = _image;
            _buttonRessourse.name = _resourceName;
            _buttonRessourse.GetComponentInChildren<Text>().text = i.ToString();
            _image = null;
            _resourceName = null;
        }

    }
}
