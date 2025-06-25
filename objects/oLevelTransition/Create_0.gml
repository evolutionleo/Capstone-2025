/// @desc 

if (dest_room == noone)
	dest_room = room_next(room)


activate = function() {
	if (trigger_fade) {
		oTransition.start(dest_room)
	}
	else {
		room_goto(dest_room)
	}
}