private var startTime;
var textTime : String; //added this member variable here so we can access it through other scripts
 
 
function Awake() {
 
   startTime = Time.time;
 
}
 
function OnGUI () {
 
   var guiTime = Time.time - startTime;
 
   var minutes : int = guiTime / 60;
   var seconds : int = guiTime % 60;
   var fraction : int = (guiTime * 100) % 100;
 
   guiText.text = String.Format ("Timer: " + "{0:00}:{1:00}", minutes, seconds); 
 
}