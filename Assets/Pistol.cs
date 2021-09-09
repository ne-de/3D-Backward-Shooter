using UnityEngine;

public class Pistol : MonoBehaviour
{
    public Transform muzzle;
    public float rateOfFire;
    public float firePower = 100;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (GameManager.GameStarted)
        {
            GameObject _bullet = BulletPooling.SharedInstance.GetPooledObject();
            if (_bullet != null)
            {
                if (timer > 1/rateOfFire)
                {
                    var _rb = _bullet.GetComponent<Rigidbody>();
                    _bullet.transform.position = muzzle.transform.position;
                    _bullet.transform.rotation = muzzle.transform.rotation;
                    _bullet.SetActive(true);
                    _rb.velocity = new Vector3(0, 0, -firePower);
                    timer = 0;
                }
            }
        }
    }
}
