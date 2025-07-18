/// @desc 

#region Variables

has_bulb = true
alive_timer_max = 60 * 7 // 5 seconds
alive_timer = alive_timer_max


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

inputs_locked = false


just_teleported = false

#endregion
#region Methods

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

setDefaultInputs = function() {
	kup = false
	kleft = false
	kright = false
	kdown = false
	
	kjump = false
	kjump_hold = false
	
	kinteract = false
	kpickup = false
	
	keject = false
}

die = function() {
	room_restart()
}

ejectBulb = function() {
	if (!has_bulb) {
		return
	}
	
	if (holding) {
		holding.held_by = undefined
		holding = undefined
	}
	
	has_bulb = false
	var bulb = instance_create_layer(x, y - 100, "Instances", oLightBulb)
	holding = bulb
	bulb.held_by = self
	
	alive_timer = alive_timer_max
}

insertBulb = function() {
	if (has_bulb) {
		return
	}
	
	if (!holding) {
		return
	}
	
	if (holding.object_index != oLightBulb) {
		return
	}
	
	
	instance_destroy(holding)
	holding = undefined
	has_bulb = true
}


#endregion
