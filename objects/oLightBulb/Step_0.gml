/// @desc 

if (output_type == "constant") {
	active = true
	light.alpha = active ? 1 : 0
}
else {
	timer++
	if (timer >= toggle_interval) {
		timer = 0
		active = !active
	}
	
	light.alpha = active ? 1-(timer/toggle_interval) : 0
}




if !instance_exists(held_by) {
	spd.y += grv
}

// collision code
if (place_meeting(x + spd.x, y, global.solid_objects)) {
	while (!place_meeting(x + sign(spd.x), y, global.solid_objects)) {
		x += sign(spd.x)
	}
	spd.x = 0
}
x += spd.x

if (place_meeting(x, y + spd.y, global.solid_objects)) {
	while (!place_meeting(x, y + sign(spd.y), global.solid_objects)) {
		y += sign(spd.y)
	}
	spd.y = 0
}
y += spd.y




light.x = x
light.y = y