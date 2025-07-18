/// @desc 



if (is_string(lines)) {
	lines = string_split(lines, "\n")
}

current_line = 0
current_text = ""

in_dialogue = false

typist = scribble_typist(false)
typist.in(1, 0)

triggered = false
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
	
	first_frame = true
}

nextLine = function() {
	current_line++
	if (current_line >= array_length(lines)) {
		endDialogue()
	}
	else
		current_text = lines[current_line]
}


interact = function() {
	if (!first_frame and (!triggered or is_repeatable)) {
		triggered = true
		startDialogue()
	}
}