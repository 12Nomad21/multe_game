using System.Collections;
using UnityEngine;

public class HeroHpSystem : MonoBehaviour
{
    [SerializeField] static public int Amount_Hero_Hp = 3;
    [SerializeField] static private int TrapDamage = 1;
    [SerializeField] static private float GetDamageCooldown = 5f;
    [SerializeField] static private GameObject Hero;
    static private bool CanGetDamage = true;
    static private SpriteRenderer hero_colour;
    static private Color32 current_collor;
    public static bool IsGettingDamage; 
    void Start()
    {
        hero_colour = gameObject.transform.Find("Sprite").gameObject.GetComponent<SpriteRenderer>();
        current_collor = hero_colour.color;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap" && CanGetDamage)
        {
            StartCoroutine(GettingDamage());
        }
    }
    static public IEnumerator GettingDamage()
    {
        CanGetDamage = false;
        if (Amount_Hero_Hp != 0)
        {
            hero_colour.color = new Color32(210,60,57,255);
            Amount_Hero_Hp -= TrapDamage;
            IsGettingDamage = true;
            yield return new WaitForEndOfFrame();
            IsGettingDamage = false;
            yield return new WaitForSeconds(GetDamageCooldown);
        }
        else Hero.SetActive(false);
        hero_colour.color = current_collor;
        CanGetDamage = true;
    }
}
