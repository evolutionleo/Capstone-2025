/// @desc 


init = function() {
	scribble_font_set_default("fDefault")
}


__init = function() {
	static initialized = false
	if (initialized)
		return;
		
	init()
	
	initialized = true
}

__init()
room_goto_next()