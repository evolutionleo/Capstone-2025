using UnityEngine;

public class OffsetAdder : MonoBehaviour
{
    [SerializeField] private Vector2 _offset;

    public void AddOffset()
    {
        transform.position += new Vector3(_offset.x, _offset.y, 0);
    }

    public void SubtractOffset()
    {
        transform.position -= new Vector3(_offset.x, _offset.y, 0);
    }
}
