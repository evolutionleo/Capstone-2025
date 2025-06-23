/// @desc 

if (active) {
	// fading in (to black)
	if (!reversed) {
		timer++
		
		alpha = timer / duration_in
		
		
		// finish the fade in
		if (timer >= duration_in) {
			reversed = true
			timer = duration_out
			
			room_goto(dest_room)
		}
	}
	// fading out to the next room
	else {
		timer--
		
		alpha = timer / duration_out
		
		
		// finish the fade out
		if (timer <= 0) {
			active = false
			
			with(oPlayer) {
				inputs_locked = false
			}
		}
	}
}