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


light.x = x
light.y = y