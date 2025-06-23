/// @desc 

#region Physics variables

walkspd = 6
jumpspd = 11

// walking acceleration/deceleration

// slow/slippery
//acc = 0.7
//decc = 0.4

// robotic?
acc = 1
decc = 0.8

grv = 0.6

movedir = {
	x: 0,
	y: 0
}

spd = {
	x: 0,
	y: 0
}

coyote_time = 0
coyote_time_max = 6

jump_buffer = 0
jump_buffer_max = 6

holding = undefined

#endregion
#region Physics Methods

jump_was_cut = false

jump = function() {
	spd.y = -jumpspd
	jump_was_cut = false
}

jumpCut = function() {
	if (!jump_was_cut) {
		jump_was_cut = true
		spd.y *= 0.5
	}
}


#endregion
