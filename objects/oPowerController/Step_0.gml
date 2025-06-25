/// @desc 

for(var i = 0; i < max_channels; i++) {
	channels[$ i] = true
}

with(oPowerOutput) {
	if (!active) {
		other.channels[$ output_channel] = false
	}
	else if (is_undefined(other.channels[$ output_channel])) {
		other.channels[$ output_channel] = true
	}
}

with(oPowerInput) {
	if (other.channels[$ input_channel])
		_activate()
	else
		_deactivate()
}