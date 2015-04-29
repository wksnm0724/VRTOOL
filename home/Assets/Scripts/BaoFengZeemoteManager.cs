using UnityEngine;
using System.Collections;

public class BaoFengZeemoteManager : MonoBehaviour {
    
	public static BaoFengZeemoteManager Instance;


	private string state="手柄未连接";
	SelectItem selectItem;
	void Awake(){
		Instance = this;
		GameObject obj = GameObject.Find ("CardboardMain");
		if (obj != null) {

			Component com=obj.GetComponent("SelectItem");
			if(com!=null)
			{
				selectItem=com as SelectItem;
			}
		}
	}

    void OnGUI() {

		GUILayout.Label(state);
    }

    public void ZeemoteDownBtn(string currentBtn)
    {


		state = currentBtn;
        switch(currentBtn){
		case "OK":
			state="OK";
			Application.LoadLevel("launcher");
			break;
		case "BACK":
			state="BACK";
			break;
		case "MENU":
			state="MENU";

//			GameObject obj=GameObject.Find("CardboardMain");
//			if(obj!=null)
//			{
//				Cardboard head=obj.GetComponent("Cardboard") as Cardboard;
//				if(head!=null)
//				{
					Application.LoadLevel("2");
					state="I hava zhi xing le";
//				}
//			}
			break;
		case "LEFT_BUTTON":
			state="LEFT_BUTTON";
			selectItem.ItemMove(0);
			break;
		case "RIGHT_BUTTON":
			state="RIGHT_BUTTON";
			selectItem.ItemMove(1);
			break;
		case "UP_BUTTON":
			state="UP_BUTTON";
			break;
		case "DOWN_BUTTON":
			state="DOWN_BUTTON";
			break;
		case "CENTER_POSITION":
			state="CENTER_POSITION";
                
                break;
			//以下为老遥控器（一代遥控器）特有按键;
			case "A":
				
				break;
			case "B":

				break;
			case "C":
				
				break;
			case "D":
				
				break;
		}
        
       
    }


    
  

   

   


    public void ZeemoteStatus(string currentStatus)
    {
		//state = currentStatus;
        switch(currentStatus){
            case "CONNECT_SUCCED":
                
                break;
            case "CONNECT_FAILED":
                
                break;
            case "BLUETOOTH_OPEN_FAILED":
                
                break;
           
        }
    }
   
}
