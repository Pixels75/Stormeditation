using UnityEngine;

public class Circle : MonoBehaviour
{
    [Header("Circle Attributes")]
    [SerializeField][Range( 0f, 20f)] private float speed;
    [SerializeField] private float minSpeed;
    [Header("References")]
    [SerializeField] private Transform rightEnd;
    [SerializeField] private Transform leftEnd;
    
    private Vector3 _direction = Vector3.right;

    private void Update()
    {
        transform.Translate( speed * Time.deltaTime * _direction );
        UpdateDirection();
    }

    private void UpdateDirection()
    {
        if ( transform.position.x >= rightEnd.position.x )
        {
            _direction = Vector3.left;
        }
        else if ( transform.position.x <= leftEnd.position.x )
        {
            _direction = Vector3.right;
        }
    }

    public void Accelerate( float value )
    {
        if ( value < 0f && speed <= minSpeed ) return;
        speed += value;
    }
}
