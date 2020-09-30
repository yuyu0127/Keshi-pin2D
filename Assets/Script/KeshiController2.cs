using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeshiController2 : MonoBehaviour
{
    float hitForceX;
    float hitForceY;
    Vector2 startPos;
    Vector2 endPos;
    Vector2 direction;
    private Rigidbody2D rigid2D = null;     // 物理剛体
    [SerializeField] private LineRenderer lineRenderer = null;       // 発射方向
    // ドラッグ開始点
    private Vector2 dragStart = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 初期化処理
    public void Awake()
    {
        this.rigid2D = this.GetComponent<Rigidbody2D>();
    }

    // マウス座標を取得
    private Vector2 GetMousePosition()
    {
        var position = Input.mousePosition;
        Debug.Log("input" + position);
        return position;
    }

    // ドラック開始イベントハンドラ
    public void OnMouseDown()
    {
        this.dragStart = Input.mousePosition;

        this.lineRenderer.enabled = true;
        this.lineRenderer.SetPosition(0, this.rigid2D.position);
        this.lineRenderer.SetPosition(1, this.rigid2D.position);
    }

    // ドラッグ中イベントハンドラ
    public void OnMouseDrag()
    {
        this.endPos = Input.mousePosition;
        this.direction = endPos - dragStart;

        this.lineRenderer.SetPosition(0, this.rigid2D.position);
        this.lineRenderer.SetPosition(1, this.rigid2D.position - this.direction * 0.01f);

        //Debug.Log("マウスを離した場所" + endPos);
        //Debug.Log("Direction" + direction);   // ベクトルの方向の確認

        this.hitForceX = direction.x;   // x軸方向のベクトル
        this.hitForceY = direction.y;   // y軸方向のベクトル
    }

    // ドラッグ終了イベントハンドラ
    public void OnMouseUp()
    {
        this.lineRenderer.enabled = false;


        // x軸方向とy軸方向の移動(速度調整数付き?)
        float decrease = 0.98f;
        this.rigid2D.AddForce(new Vector2(this.hitForceX * decrease * -1, this.hitForceY * decrease * -1));
    }
}
