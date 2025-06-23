/// @desc 

alpha = 0
timer = 0
timer_max_in = 60
timer_max_out = 60

surf = undefined

active = false
reversed = false

dest_room = undefined


start = function(_dest_room) {
	if (active)
		return;
	
	active = true
	reversed = false
	
	dest_room = _dest_room
}