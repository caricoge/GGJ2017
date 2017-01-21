var speed: float = 15; // speed to follow camera
private var localRot: Quaternion;
private var curRot: Quaternion;

function Start(){
    localRot = transform.localRotation; // save initial local rotation
    curRot = transform.rotation;
}

function Update(){
    // targetRot follows instantly the camera:
    var targetRot = transform.parent.rotation * localRot;
    // curRot follows targetRot with some smoothing delay:
    curRot = Quaternion.Lerp(curRot, targetRot, speed * Time.deltaTime);
    transform.rotation = curRot; // update the actual weapon rotation
}