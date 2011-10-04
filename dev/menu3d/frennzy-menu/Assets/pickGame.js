
public var matOn:Material;
public var matOff:Material;
public var picked:boolean = false;

public var button1:GameObject;
public var msgIcon:GameObject;


function Update () {
	if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) {
		flash();
		var hitInfo:RaycastHit;
		var r:Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if(Physics.Raycast(r, hitInfo))
		{
		   if(hitInfo.collider == button1.collider)
		   {
		      // rigidbody.AddExplosionForce(forceAmount, transform.position, 25.0f, 1.0f);
		      Debug.Log("hit button1!");
		   }
		}	
	}
}

function flash() {
	msgIcon.renderer.material = matOn;
	yield WaitForSeconds(1);
	msgIcon.renderer.material = matOff;
}



function OnMouseUp() {
	picked = !picked;
	if (picked) {
		renderer.material = matOn;
	} else {
		Application.LoadLevel("marbles");
		Debug.Log("setting matOff");
		renderer.material = matOff;
	}
	Debug.Log("picked:" + picked);
	flash();
}


