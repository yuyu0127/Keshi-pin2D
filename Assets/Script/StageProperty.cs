using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageProperty : MonoBehaviour
{
    public static int first;
    public static int second;
    GameObject player1;
    GameObject player2;
    
    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Eraser1");
        player2 = GameObject.FindGameObjectWithTag("Eraser2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // 机から出ると負け -> result 画面へ
    void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Eraser1"))
        {
            // ステージから離れたオブジェクトを知りたい
            first = 2;      // 1位は2p
            second = 1;     // 2位は1p
            Destroy(player1);
            Debug.Log("first : " + first + ", second : " + second);
        }
        else if (other.CompareTag("Eraser2"))
        {
            first = 1;      // 1位は1p
            second = 2;     // 2位は2p
            Destroy(player2);
            Debug.Log("first : " + first + ", second : " + second);
        }
        // 1秒後とかにシーン遷移が良い？
        //Invoke("SceneManager.LoadScene", 1.0f);
        SceneManager.LoadScene("ResultScene");
    }
}
