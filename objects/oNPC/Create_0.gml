/// @desc 

lines = []
current_line = 0
current_text = ""

in_dialogue = false


first_frame = false

startDialogue = function() {
	oPlayer.inputs_locked = true
	in_dialogue = true
	current_line = 0
	current_text = lines[0]
	
	first_frame = true
}

endDialogue = function() {
	oPlayer.inputs_locked = false
	in_dialogue = false
}

nextLine = function() {
	current_line++
	if (current_line >= array_length(lines)) {
		endDialogue()
	}
	else
		current_text = lines[current_line]
}


interact = startDialogue