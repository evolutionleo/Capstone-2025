/// @desc 

draw_self()

if (place_meeting(x, y, global.holdable_objects) and holding == undefined) {
	draw_text(x, bbox_top - 10, "E")
}
else if (place_meeting(x, y, global.interactable_objects) and holding == undefined) {
	draw_text(x, bbox_top - 10, "F")
}