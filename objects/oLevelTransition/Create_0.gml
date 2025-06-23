/// @desc 

activate = function() {
	if (trigger_fade) {
		oTransition.start(dest_room)
	}
	else {
		room_goto(dest_room)
	}
}