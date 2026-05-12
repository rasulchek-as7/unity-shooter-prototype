using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Camera fpsCam;
    public float range = 100f;

    public AudioSource gunSound;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        gunSound.Play();

        RaycastHit hit;

        if (Physics.Raycast(
            fpsCam.transform.position,
            fpsCam.transform.forward,
            out hit,
            range))
        {
            if (hit.transform.CompareTag("Target"))
            {
                hit.transform.GetComponent<Target>().DestroyTarget();
            }

            if (hit.transform.CompareTag("Enemy"))
            {
                Destroy(hit.transform.gameObject);
            }
        }
    }
}