
using UnityEngine.InputSystem;

using UnityEngine;
public enum comboKey{up,down,left,right,A,B}
public class PlayerController : MonoBehaviour {
    [SerializeField] ComboManager comboManager;
    
    void AddInQueue(comboKey key){
        comboManager.OnKey(key);
    }
    public void Up(InputAction.CallbackContext context){
        if(context.performed)
        AddInQueue(comboKey.up);
    }
    public void Down(InputAction.CallbackContext context){
        if(context.performed)
        AddInQueue(comboKey.down);
    }
    public void Left(InputAction.CallbackContext context){
        if(context.performed)
        AddInQueue(comboKey.left);
    }
    public void Right(InputAction.CallbackContext context){
        if(context.performed)
        AddInQueue(comboKey.right);
    }
    public void A(InputAction.CallbackContext context){
        if(context.performed)
            AddInQueue(comboKey.A);
    }
    public void B(InputAction.CallbackContext context){
        if(context.performed)
        AddInQueue(comboKey.B);
    }
}
