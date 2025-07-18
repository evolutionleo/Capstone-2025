/// @desc 

if (active) {
	xscale_prev = image_xscale
	yscale_prev = image_yscale
	
	
	reverse_factor = is_reversed ? -1 : 1
	
	if (expand_direction == "left" or expand_direction == "right")
		image_xscale += expand_speed * reverse_factor
	else
		image_yscale += expand_speed * reverse_factor
	
	image_xscale = clamp(image_xscale, 0.1, max_xscale)
	image_yscale = clamp(image_yscale, 0.1, max_yscale)
	
	
	// bumped into player
	if (place_meeting(x, y, oPlayer)) {
		image_xscale = xscale_prev
		image_yscale = yscale_prev
	}
	
	occluder.xscale = image_xscale
	occluder.yscale = image_yscale
}