using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraKontrol : MonoBehaviour
{
    public Transform topunT;
    [SerializeField]
    GameObject player;
	private void LateUpdate()
    {
        if (topunT.position.y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x,topunT.position.y,
                transform.position.z);
        }
        else if (topunT.position.y < transform.position.y - 20f)
		{
            TopKontrol.isStart = true;
            Destroy(player.gameObject);
		}
    }
}//Class
