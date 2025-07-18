/// @desc 

event_inherited()

if (place_meeting(x, y, oPlayer) and !triggered) {
	startDialogue()
	triggered = true
}