using UnityEngine;

public class CameraFollowView : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] float _smoothSpeed;
    [SerializeField] Vector3 _offset;

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, _target.position + _offset, _smoothSpeed);
    }
}
