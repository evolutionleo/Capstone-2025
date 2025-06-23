/// @desc 

if (active) {
	if (!reversed) {
		timer++
		
		alpha = timer / timer_max_in
		
		if (timer >= timer_max_in) {
			reversed = true
			timer = timer_max_out
			
			room_goto(dest_room)
		}
	}
	else {
		timer--
		
		alpha = timer / timer_max_out
		
		if (timer <= 0) {
			active = false
			surf = undefined
		}
	}
}