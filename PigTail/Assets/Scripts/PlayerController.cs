
using UnityEngine.InputSystem;

using UnityEngine;
public enum comboKey{up,down,left,right,A,B}
public class PlayerController : MonoBehaviour {
    [SerializeField] ComboManager comboManager;
    
    void AddInQueue(comboKey key){
        comboManager.OnKey(key);
    }
    public void Up(InputAction.CallbackContext context){
        AddInQueue(comboKey.up);
    }
    public void Down(InputAction.CallbackContext context){
        AddInQueue(comboKey.down);
    }
    public void Left(InputAction.CallbackContext context){
        AddInQueue(comboKey.left);
    }
    public void Right(InputAction.CallbackContext context){
        AddInQueue(comboKey.right);
    }
    public void A(InputAction.CallbackContext context){
        AddInQueue(comboKey.A);
    }
    public void B(InputAction.CallbackContext context){
        AddInQueue(comboKey.B);
    }
}
