/// @desc 

draw_self()

if (place_meeting(x, y, global.holdable_objects) and holding == undefined) {
	//draw_text(x, bbox_top - 10, "E")
}
else if (place_meeting(x, y, global.interactable_objects) and holding == undefined) {
	//draw_text(x, bbox_top - 10, "F")
}
else if (place_meeting(x, y, oLevelTransition) and !instance_place(x, y, oLevelTransition).passive)
or (place_meeting(x, y, oDoorTeleporter) and instance_place(x, y, oDoorTeleporter).target != noone) {
	draw_sprite_ext(sArrow, 0, x, bbox_top-100, 0.5, 0.5, 0, c_white, 1)
}

if (!has_bulb) {
	draw_set_font(fAliveTimer)
	draw_set_color(c_red)
	
	draw_text(x, bbox_top - 150, string(alive_timer div 60))
	
	draw_set_color(c_white)
	draw_set_font(-1)
}