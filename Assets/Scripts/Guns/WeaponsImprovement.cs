using UnityEngine;

public class WeaponsImprovement : MonoBehaviour
{
    [SerializeField] GameObject[] weapons;
    [SerializeField] public bool actived;

    private void FixedUpdate()
    {
        actived = AllObjectsActive(weapons);
    }
    public void ActivateNextWeapon()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            if (!weapons[i].activeSelf)
            {
                weapons[i].SetActive(true);
                break; // выходим после активации одного
            }
        }
    }

    public void DeactivateLastWeapon()
    {
        for (int i = weapons.Length - 1; i >= 0; i--)
        {
            if (weapons[i].activeSelf)
            {
                weapons[i].SetActive(false);
                break; // выходим после деактивации одного
            }
        }
    }
    public bool AllObjectsActive(GameObject[] objects)
    {
        foreach (GameObject obj in objects)
        {
            if (!obj.activeSelf)
                return false;
        }
        return true;
    }

}
