/// @desc 

if (instance_exists(target) and place_meeting(x, y, oPlayer) and !oPlayer.just_teleported) {
	if (keyboard_check_pressed(ord("W"))) {
		// teleport to the other door
		oPlayer.x = target.x
		oPlayer.y = target.y + (oPlayer.y - y)
		
		with(oPlayer) {
			// unstuck
			while(place_meeting(x, y, global.solid_objects))
				y--
			
			// get on the ground
			while(!place_meeting(x, y+1, global.solid_objects))
				y++
			
			just_teleported = true
		}
	}
}