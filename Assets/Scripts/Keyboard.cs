using UnityEngine;
using UnityEngine.UI;

public class Keyboard : MonoBehaviour
{
    [SerializeField] InputField inputField;
    [SerializeField] InputField[] inputFieldDade;
    [SerializeField] Text _capitalLetters;
    [SerializeField] GameObject _upperObject;
    //[SerializeField] string _name;
    [SerializeField] bool _up;

    private void Start()
    {
        inputFieldDade = GameObject.FindObjectsOfType<InputField>();
        for (int i = 0; i < inputFieldDade.Length; i++)
        {
            if (inputFieldDade[i].name == "InputField (school)")
            {
                inputField = inputFieldDade[i];
            }
        }
        _up = true;
        inputField = GetComponent<InputField>();
    }
    public void SchoolStudent()
    {
        for (int i = 0; i < inputFieldDade.Length; i++)
        {
            if (inputFieldDade[i].name == "InputField (school)")
            {
                inputField = inputFieldDade[i];
            }
        }
    }
    public void NameStudent()
    {
        for (int i = 0; i < inputFieldDade.Length; i++)
        {
            if (inputFieldDade[i].name == "InputField (name)")
            {
                inputField = inputFieldDade[i];
            }
        }
    }
    public void LastNameStudent()
    {
        for (int i = 0; i < inputFieldDade.Length; i++)
        {
            if (inputFieldDade[i].name == "InputField (last name)")
            {
                inputField = inputFieldDade[i];
            }
        }
    }
    public void ClassStudent()
    {
        for (int i = 0; i < inputFieldDade.Length; i++)
        {
            if (inputFieldDade[i].name == "InputField (class)")
            {
                inputField = inputFieldDade[i];
            }
        }
    }
    private void Update()
    {
        if(_up == true)
        {
            _upperObject.SetActive(true);
        }
        else
        {
            _upperObject.SetActive(false);
        }
        if(GameObject.Find("Text (CapitalLetters)"))
        {
            _capitalLetters = GameObject.Find("Text (CapitalLetters)").GetComponent<Text>();
            if(_up == true)
            {
                _capitalLetters.text = "Заглавные";
            }
            else
            {
                _capitalLetters.text = "маленькие";
            }
        }
        //_name = inputField.text;
    }
    private void FixedUpdate()
    {
        if(GameObject.Find("Upper"))
        {
            _upperObject = GameObject.Find("Upper");
        }
    }
    public void BackSpace()
    {
        if (inputField.text.Length > 0)
        {
            inputField.text = inputField.text.Substring(0, inputField.text.Length - 1);
            _up = false;
        }
    }
    public void Clear()
    {
        inputField.text = "";
        _up = true;
    }
    public void SPACE()
    {
        inputField.text += " ";
        _up = false;
    }
    public void Й()
    {
        if(_up == true)
        {
            inputField.text += "й".ToUpper();
            _up = false;
        }
        else
        {
            inputField.text += "й".ToLower();
        }
        
    }

    public void Ц()
    {
        if (_up == true)
        {
            inputField.text += "ц".ToUpper();
            _up = false;
        }
        else
        {
            inputField.text += "ц".ToLower();
        }
    }
    public void У()
    {
        if (_up == true)
        {
            inputField.text += "у".ToUpper();
            _up = false;
        }
        else
        {
            inputField.text += "у".ToLower();
        }
    }
    public void К()
    {
        if (_up == true)
        {
            inputField.text += "к".ToUpper();
            _up = false;
        }
        else
        {
            inputField.text += "к".ToLower();
        }
    }
    public void Е()
    {
        if (_up == true)
        {
            inputField.text += "е".ToUpper();
            _up = false;
        }
        else
        {
            inputField.text += "е".ToLower();
        }
    }
    public void Н()
    {
        if (_up == true)
        {
            inputField.text += "н".ToUpper();
            _up = false;
        }
        else
        {
            inputField.text += "н".ToLower();
        }
    }
    public void Г()
    {
        if (_up == true)
        {
            inputField.text += "г".ToUpper();
            _up = false;
        }
        else
        {
            inputField.text += "г".ToLower();
        }
    }
    public void Ш()
    {
        if (_up == true)
        {
            inputField.text += "ш".ToUpper();
            _up = false;
        }
        else
        {
            inputField.text += "ш".ToLower();
        }
    }
    public void Щ()
    {
        if (_up == true)
        {
            inputField.text += "щ".ToUpper();
            _up = false;
        }
        else
        {
            inputField.text += "щ".ToLower();
        }
    }
    public void З()
    {
        if (_up == true)
        {
            inputField.text += "з".ToUpper();
            _up = false;
        }
        else
        {
            inputField.text += "з".ToLower();
        }
    }
    public void Х()
    {
        if (_up == true)
        {
            inputField.text += "х".ToUpper();
            _up = false;
        }
        else
        {
            inputField.text += "х".ToLower();
        }
    }
    public void Ф()
    {
        if (_up == true)
        {
            inputField.text += "ф".ToUpper();
            _up = false;
        }
        else
        {
            inputField.text += "ф".ToLower();
        }
    }
    public void Ы()
    {
        if (_up == true)
        {
            inputField.text += "ы".ToUpper();
            _up = false;
        }
        else
        {
            inputField.text += "ы".ToLower();
        }
    }
    public void В()
    {
        if (_up == true)
        {
            inputField.text += "в".ToUpper();
            _up = false;
        }
        else
        {
            inputField.text += "в".ToLower();
        }
    }
    public void А()
    {
        if (_up == true)
        {
            inputField.text += "а".ToUpper();
            _up = false;
        }
        else
        {
            inputField.text += "а".ToLower();
        }
    }
    public void П()
    {
        if (_up == true)
        {
            inputField.text += "п".ToUpper();
            _up = false;
        }
        else
        {
            inputField.text += "п".ToLower();
        }
    }
    public void Р()
    {
        if (_up == true)
        {
            inputField.text += "р".ToUpper();
            _up = false;
        }
        else
        {
            inputField.text += "р".ToLower();
        }
    }
    public void О()
    {
        if (_up == true)
        {
            inputField.text += "о".ToUpper();
            _up = false;
        }
        else
        {
            inputField.text += "о".ToLower();
        }
    }
    public void Л()
    {
        if (_up == true)
        {
            inputField.text += "л".ToUpper();
            _up = false;
        }
        else
        {
            inputField.text += "л".ToLower();
        }
    }
    public void Д()
    {
        if (_up == true)
        {
            inputField.text += "д".ToUpper();
            _up = false;
        }
        else
        {
            inputField.text += "д".ToLower();
        }
    }
    public void Ж()
    {
        if (_up == true)
        {
            inputField.text += "ж".ToUpper();
            _up = false;
        }
        else
        {
            inputField.text += "ж".ToLower();
        }
    }
    public void Э()
    {
        if (_up == true)
        {
            inputField.text += "э".ToUpper();
            _up = false;
        }
        else
        {
            inputField.text += "э".ToLower();
        }
    }
    public void Я()
    {
        if (_up == true)
        {
            inputField.text += "я".ToUpper();
            _up = false;
        }
        else
        {
            inputField.text += "я".ToLower();
        }
    }
    public void Ч()
    {
        if (_up == true)
        {
            inputField.text += "ч".ToUpper();
            _up = false;
        }
        else
        {
            inputField.text += "ч".ToLower();
        }
    }
    public void С()
    {
        if (_up == true)
        {
            inputField.text += "с".ToUpper();
            _up = false;
        }
        else
        {
            inputField.text += "с".ToLower();
        }
    }
    public void М()
    {
        if (_up == true)
        {
            inputField.text += "м".ToUpper();
            _up = false;
        }
        else
        {
            inputField.text += "м".ToLower();
        }
    }

    public void И()
    {
        if (_up == true)
        {
            inputField.text += "и".ToUpper();
            _up = false;
        }
        else
        {
            inputField.text += "и".ToLower();
        }
    }
    public void Т()
    {
        if (_up == true)
        {
            inputField.text += "т".ToUpper();
            _up = false;
        }
        else
        {
            inputField.text += "т".ToLower();
        }
    }
    public void Ь()
    {
        if (_up == true)
        {
            inputField.text += "ь".ToUpper();
            _up = false;
        }
        else
        {
            inputField.text += "ь".ToLower();
        }
    }
        public void Б()
    {
        if (_up == true)
        {
            inputField.text += "б".ToUpper();
            _up = false;
        }
        else
        {
            inputField.text += "б".ToLower();
        }
    }
    public void Ю()
    {
        if (_up == true)
        {
            inputField.text += "ю".ToUpper();
            _up = false;
        }
        else
        {
            inputField.text += "ю".ToLower();
        }
    }
    public void UP()
    {
        _up = !_up;
    }

    public void Number_1()
    {
        inputField.text += "1";
        _up = false;
    }
    public void Number_2()
    {
        inputField.text += "2";
        _up = false;
    }
    public void Number_3()
    {
        inputField.text += "3";
        _up = false;
    }
    public void Number_4()
    {
        inputField.text += "4";
        _up = false;
    }
    public void Number_5()
    {
        inputField.text += "5";
    }
    public void Number_6()
    {
        inputField.text += "6";
        _up = false;
    }
    public void Number_7()
    {
        inputField.text += "7";
        _up = false;
    }
    public void Number_8()
    {
        inputField.text += "8";
        _up = false;
    }
    public void Number_9()
    {
        inputField.text += "9";
        _up = false;
    }
    public void Number_0()
    {
        inputField.text += "0";
        _up = false;
    }
}
