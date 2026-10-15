using TMPro;
using UnityEngine;

public class goal :MonoBehaviour
{
    //SerializeField →　 privateな変数をInspector上に表示
    [SerializeField]
    TextMeshProUGUI goalText;

    //Istriggerに反応があるか確認
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);

        //Canvasにゴールした情報を送る
        goalText.enabled = true;

    }
}
