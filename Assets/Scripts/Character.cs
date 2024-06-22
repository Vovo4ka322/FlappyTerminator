using UnityEngine;

public class Character : MonoBehaviour
{
    public virtual void Die() 
    {
        Destroy(gameObject);
    }
}
