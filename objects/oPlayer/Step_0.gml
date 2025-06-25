/// @desc 

// inputs
if (!inputs_locked) {
	kup = keyboard_check(ord("W"))
	kleft = keyboard_check(ord("A"))
	kdown = keyboard_check(ord("S"))
	kright = keyboard_check(ord("D"))

	kjump = keyboard_check_pressed(vk_space)
	kjump_hold = keyboard_check(vk_space)

	kinteract = keyboard_check_pressed(ord("E"))
	kpickup = keyboard_check_pressed(ord("F"))
}
else {
	setDefaultInputs()
}

movedir.x = kright - kleft
movedir.y = kdown - kup

#region Physics

// fix slightly early or late jump inputs
if (place_meeting(x, y+1, oWall))
	coyote_time = coyote_time_max
else
	coyote_time--
on_ground = coyote_time > 0

if (kjump)
	jump_buffer = jump_buffer_max
else
	jump_buffer--
kjump = jump_buffer > 0


// turn around
if (movedir.x != 0)
	image_xscale = abs(image_xscale) * sign(movedir.x)


// deceleration
if (sign(movedir.x) != sign(spd.x)) {
	spd.x -= sign(spd.x) * decc
	if (abs(spd.x) <= decc)
		spd.x = 0
}
// acceleration
if (sign(movedir.x) != sign(spd.x) || abs(spd.x) < walkspd)
	spd.x += movedir.x * acc


spd.x = clamp(spd.x, -walkspd, walkspd)
spd.y += grv

// jumping
if (jump_buffer >= 0 and coyote_time >= 0) {
	jump()
}

// variable jump height
if (spd.y < -1 and !kjump_hold) {
	jumpCut()
}



// unstuck
while(place_meeting(x, y, oWall)) {
	y--
}


// collision code
if (place_meeting(x + spd.x, y, oWall)) {
	while (!place_meeting(x + sign(spd.x), y, oWall)) {
		x += sign(spd.x)
	}
	spd.x = 0
}
x += spd.x

if (place_meeting(x, y + spd.y, oWall)) {
	while (!place_meeting(x, y + sign(spd.y), oWall)) {
		y += sign(spd.y)
	}
	spd.y = 0
}
y += spd.y

#endregion
#region Picking up items

if (kpickup) {
	if (holding == undefined) {
		with(instance_place(x, y, global.holdable_objects)) {
			if (!is_undefined(held_by)) {
				held_by = other
				other.holding = id
			}
			else if (held_by == other) {
				held_by = undefined
				other.holding = undefined
			}
		}
	}
}

if (instance_exists(holding)) {
	holding.x = x
	holding.y = y - 100
}

#endregion