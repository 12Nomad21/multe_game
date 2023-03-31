using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroPlaySounds : MonoBehaviour
{
    [SerializeField] private AudioSource GetDamageSound;
    [SerializeField] private AudioSource DeathSound;
    [SerializeField] private GameObject Player;
    void Update()
    {
        if (HeroHpSystem.IsGettingDamage == true && HeroHpSystem.Amount_Hero_Hp > 0)
        {

            GetDamageSound.pitch = Random.Range(0.9f, 1.1f);
            GetDamageSound.Play();
        } else if (HeroHpSystem.Amount_Hero_Hp == 0)
        {
            DeathSound.pitch = Random.Range(0.9f, 1.1f);
            DeathSound.Play();
        }
    }
}
