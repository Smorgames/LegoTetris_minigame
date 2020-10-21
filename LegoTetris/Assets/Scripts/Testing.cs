using UnityEngine;

public class Testing : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameMaster.instance.GameField.DisplayGameFieldWidthAndHeight();
        }
    }
}
