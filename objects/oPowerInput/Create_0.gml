/// @desc 

activate = function() {}
deactivate = function() {}

_activate = function() {
	if (!active) {
		active = true
		activate()
	}
}

_deactivate = function() {
	if (active) {
		active = false
		deactivate()
	}
}