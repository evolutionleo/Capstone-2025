using UnityEngine;

public class OffsetAdder : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector2 _offset;
    
    private Transform _transform => _target ? _target : transform;
    
    public void AddOffset()
    {
        _transform.position += new Vector3(_offset.x, _offset.y, 0);
    }

    public void SubtractOffset()
    {
        _transform.position -= new Vector3(_offset.x, _offset.y, 0);
    }
}
