using UnityEngine;

public class PlatformWall : MonoBehaviour
{
    //EVENTS
    public delegate void OnWallContactDelegate();
    public static event OnWallContactDelegate OnWallContact;

    public delegate void OnWallClearDelegate();
    public static event OnWallClearDelegate OnWallClear;

    //PUBLIC
    public float wallSpeedDamp = 2;

    //PRIVATE
    private GroundGenerator m_groundGen;

    private void Start()
    {
        m_groundGen = GetComponentInParent<Transform>().GetComponentInParent<GroundGenerator>();
    }


    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            //if (m_groundGen.tilingSpeed != m_groundGen.tilingReferenceSpeed)
            //    return;
            //else m_groundGen.tilingSpeed -= m_groundGen.tilingSpeed / wallSpeedDamp;

            OnWallContact();
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            //m_groundGen.tilingSpeed = m_groundGen.tilingReferenceSpeed;

            OnWallClear();
        }
    }
}
