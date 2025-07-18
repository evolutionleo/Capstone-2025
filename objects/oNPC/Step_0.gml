/// @desc 

if (first_frame) {
	first_frame = false
	exit
}

if (in_dialogue) {
	if (keyboard_check_pressed(vk_anykey) or current_text == "") {
		if (typist.get_state() == 1)
			nextLine()
		else
			typist.skip()
	}
}