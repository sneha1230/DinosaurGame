using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public PlayerMovement player;
    public Camera camfollow;
    //public float camOffsetZ;
    //Vector3 camOffset;
    // Start is called before the first frame update
    public GameObject[] blocks;
    public float blockArrowPointer = -10;
    public float safeMargin = 20;
    public float score = 0.0f;
    public Text scoreText;
    void Start()
    {
        print("welcome To Endless Runner Game! \n press space key to jump and escape from obstacles ");
        //camOffset = new Vector3(0, 0, camOffsetZ);

    }

    // Update is called once per frame
    void Update()
    {

        while(player!=null && blockArrowPointer<player.transform.position.x+safeMargin)
        {
            int value = Random.Range(0, blocks.Length);
            if(blockArrowPointer<10)
            {
                value = 0;
            }
            GameObject blocksprefab = Instantiate(blocks[value]);//tested different block sizes
            BlockSize bs = blocksprefab.GetComponent<BlockSize>();
            blocksprefab.transform.position = new Vector3(blockArrowPointer + bs.blockSize / 2, 0, 0);
            //blocksprefab.transform.position = this.transform.position;
            blockArrowPointer += bs.blockSize;

        }
        if (player != null)
        {
            score += Time.deltaTime;
            //score = Mathf.RoundToInt(score);
            scoreText.text= Mathf.RoundToInt(score).ToString() ;
            camfollow.transform.position = new Vector3(player.transform.position.x, camfollow.transform.position.y, camfollow.transform.position.z);
        }
    }
}
