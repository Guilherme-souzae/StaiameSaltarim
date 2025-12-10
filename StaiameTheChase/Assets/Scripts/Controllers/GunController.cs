using UnityEngine;
using System.Collections.Generic;

public class GunController : MonoBehaviour
{
    public List<BaseGun> currentGuns;

    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            foreach (var gun in currentGuns)
            {
                gun.tryShoot();
            }
        }
    }
}
