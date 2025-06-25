/// @desc 

if (first_frame) {
	first_frame = false
	exit
}

if (in_dialogue) {
	if (keyboard_check_pressed(vk_anykey)) {
		nextLine()
	}
}