/// @desc 

if (active) {
	xscale_prev = image_xscale
	yscale_prev = image_yscale
	
	
	if (expand_direction == "left" or expand_direction == "right")
		image_xscale += expand_speed
	else
		image_yscale += expand_speed
	
	image_xscale = clamp(image_xscale, 0, max_xscale)
	image_yscale = clamp(image_yscale, 0, max_yscale)
	
	
	// bumped into player
	if (place_meeting(x, y, oPlayer)) {
		image_xscale = xscale_prev
		image_yscale = yscale_prev
	}
}