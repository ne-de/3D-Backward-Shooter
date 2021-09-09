﻿using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 startPosition;

    public float moveSpeed;
    public float gravity = 20.0f;

    private Rigidbody _rb;
    private Vector3 _initialDrag;
    private float _movement;

    private void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.autorotateToLandscapeLeft = false;
        Screen.autorotateToLandscapeRight = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Input.mousePosition = 0;
        _rb = GetComponent<Rigidbody>();
        _rb.constraints = RigidbodyConstraints.FreezePositionZ;
        _rb.freezeRotation = true;
        _rb.useGravity = false;
        startPosition = transform.position;
    }

    void Update()
    {
        if (GameManager.GameStarted)
        {
#if UNITY_ANDROID
            #region Touch switch
        if (Input.touchCount > 0)
        {
            Touch actualInput = Input.touches[0];
            switch (actualInput.phase)
            {
                case TouchPhase.Began:
                    _initialDrag = Camera.main.ScreenToViewportPoint(actualInput.position);
                    break;
                case TouchPhase.Moved:
                case TouchPhase.Stationary:
                    Vector3 viewportPos = Camera.main.ScreenToViewportPoint(actualInput.position);
                    _movement = viewportPos.x - _initialDrag.x;
                    transform.Translate(Vector3.right * _movement * moveSpeed * Time.deltaTime);

                    break;
                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    break;
            }
        }
            #endregion
#endif
        }
    }

    void FixedUpdate()
    {
        // We apply gravity manually
        _rb.AddForce(new Vector3(0, -gravity * _rb.mass, 0));
        if (GameManager.GameStarted)
        {

#if UNITY_STANDALONE
            float moveH = Input.GetAxis("Mouse X");
            Vector3 movement = new Vector3(moveH, 0, 0);
            _rb.velocity = movement * moveSpeed * Time.fixedDeltaTime;
#endif
        }
    }
}
