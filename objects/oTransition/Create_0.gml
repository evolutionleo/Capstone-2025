/// @desc 

alpha = 0
timer = 0
duration_in = 60
duration_out = 60

active = false
reversed = false

dest_room = undefined


start = function(_dest_room) {
	if (active)
		return;
	
	active = true
	reversed = false
	
	with(oPlayer) {
		inputs_locked = true
	}
	
	dest_room = _dest_room
}