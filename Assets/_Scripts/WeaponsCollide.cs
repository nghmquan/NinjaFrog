using System.Collections.Generic;
using UnityEngine;

public class WeaponsCollide : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbodyWeapon;
    [SerializeField] private Animator animatorWeapon;

    private List<string> weaponList = new List<string> {"Ground","NinjaFrog"};

    //Set collision when it collide another object
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Change weapons when they collide ground or ninja frog 
        if (IsWeaponTag(collision.gameObject.tag))
        {
            WeaponsCollided();
        }
    }

    //Check  is obecject weapons're tag
    private bool IsWeaponTag(string tag)
    {
        return weaponList.Contains(tag);
    }

    //When weapons collided another objects
    public void WeaponsCollided()
    {
        //Change body type weapon from dynamic to staic
        rigidbodyWeapon.bodyType = RigidbodyType2D.Static;
        this.enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        animatorWeapon.SetTrigger("isDestroy");
        Destroy(gameObject, 1f);
    }
}
