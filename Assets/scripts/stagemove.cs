using UnityEngine;
using UnityEngine.InputSystem;

public class stagemove : MonoBehaviour
{
    //変数、関数
    //変数→int,strubg 値を格納するための箱
    //データ型(int,string,InputAction)＋変数名(num,name)

    private InputAction moveInput;

    //関数→処理をまとめて実行するための箱
    
    //目的(抽象的課題)：ステージを回転させること
    //手段(具体的課題):ActionMspを使用市プレイヤーの入力を受け取る
    //                受け取った入力をもとにステージのrotarionを変更する



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveInput = InputSystem.actions.FindAction("Move");
    }

    public float threshold = 0.2f;
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(moveInput.ReadValue<Vector2>());
        Vector3 rotation;

        rotation = new Vector3(
        moveInput.ReadValue<Vector2>().y * threshold,
        0,
        moveInput.ReadValue<Vector2>().x * threshold);


        //A += B → A = A + B
        //this,transform.localPosition → このコードがアタッチされているオブジェクトの位置情報
        //moveInout.ReadValue<Vecter2> →(X,Y,Z=0)
        
        rotation = new Vector3(moveInput.ReadValue<Vector2>().y, 0, moveInput.ReadValue<Vector2>().x);

        //this.transform.Rotate(rotation);
        //オイラー角に変換
        Quaternion tilt = Quaternion.Euler(rotation.x,  rotation.z, 0f);
        this.gameObject.GetComponent<Rigidbody>().MoveRotation(this.gameObject.GetComponent<Rigidbody>().transform.rotation * tilt);

    }
}
