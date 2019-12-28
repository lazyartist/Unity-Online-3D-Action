using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour {
    public AudioClip itemSeClip;
    public enum ItemKind
    {
        Attack,
        Heal,
    };

    public ItemKind kind;

    private void Start()
    {
        Vector3 velocity = Random.insideUnitSphere * 2.0f + Vector3.up * 8.0f;
        GetComponent<Rigidbody>().velocity = velocity;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Player인지 판정
        if(other.tag == "Player")
        {
            //아이템 획득
            CharacterStatus aStatus = other.GetComponent<CharacterStatus>();
            aStatus.GetItem(kind);
            //획득한 아잍템을 지운다.
            Destroy(gameObject);
            //오디오 재생
            AudioSource.PlayClipAtPoint(itemSeClip, transform.position);
        }
    }
}
