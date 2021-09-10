using UnityEngine;

public class Pistol : MonoBehaviour
{
    //PUBLIC
    public Transform muzzle;
    public float rateOfFire;
    public float firePower = 70;

    //PRIVATE
    private float m_timer;

    void FixedUpdate()
    {
        m_timer += Time.deltaTime;

        if (GameManager.GameStarted)
        {
            GameObject _bullet = BulletPooling.SharedInstance.GetPooledObject();
            if (_bullet != null)
            {
                if (m_timer > 1/rateOfFire)
                {
                    var _rb = _bullet.GetComponent<Rigidbody>();
                    _bullet.transform.position = muzzle.transform.position;
                    _bullet.transform.rotation = muzzle.transform.rotation;
                    _bullet.SetActive(true);
                    _rb.velocity = new Vector3(0, 0, -firePower * 8) * Time.fixedDeltaTime;
                    m_timer = 0;
                }
            }
        }
    }
}
