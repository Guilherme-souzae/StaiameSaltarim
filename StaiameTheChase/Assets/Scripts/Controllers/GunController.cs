using UnityEngine;
using System.Collections.Generic;

public class GunController : MonoBehaviour
{
    public List<BaseGun> normalGuns = new List<BaseGun>();
    public List<BaseGun> grazeGuns = new List<BaseGun>();

    private List<BaseGun> currentGuns = new List<BaseGun>();

    public void Start()
    {
        currentGuns = normalGuns;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            foreach (var gun in currentGuns)
            {
                if (gun != null)
                    gun.tryShoot();
                else
                    Debug.LogError("GunController encontrou um gun NULL dentro de currentGuns!");
            }
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentGuns = grazeGuns;
        }
        else
        {
            currentGuns = normalGuns;
        }
    }
}
