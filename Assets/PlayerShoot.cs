using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Camera fpsCam;
    public float range = 100f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            if (hit.transform.CompareTag("Target"))
            {
                hit.transform.GetComponent<Target>().DestroyTarget();
            }
        }
    }
}