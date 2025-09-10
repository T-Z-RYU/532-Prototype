using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public Entity nearbyEntity;
    public EntityBar entityBar;
    
    private void Update()
    {
        var moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0).normalized;
        transform.Translate(moveSpeed * Time.deltaTime * moveDirection, Space.World);
        
        if(nearbyEntity != null)
        {
            entityBar.AddEntity(nearbyEntity);
            Destroy(nearbyEntity.gameObject);
            nearbyEntity = null;
        }
    }
}
