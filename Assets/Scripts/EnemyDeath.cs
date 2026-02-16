using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
   public string hittingTag = "Moveable";

   private void OnCollisionEnter2D(Collision2D collision)
   {
       if (collision.gameObject.CompareTag(hittingTag))
       {
           Destroy(this.gameObject);
       }
   }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(hittingTag))
        {
            Destroy(this.gameObject);
        }
    }

}