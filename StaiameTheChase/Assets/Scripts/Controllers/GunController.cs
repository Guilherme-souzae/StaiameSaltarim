using UnityEngine;
using System.Collections.Generic;

public class GunController : MonoBehaviour
{
    public List<BaseGun> currentGuns;

    private void Awake()
    {
        // Se não foi usada no Inspector ou está vazia, preenche automaticamente
        if (currentGuns == null || currentGuns.Count == 0)
        {
            currentGuns = new List<BaseGun>(GetComponentsInChildren<BaseGun>());
        }
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
    }
}
