/// @desc 

with(oDoorTeleporter) {
	if (self.door_id == other.door_id and other != self) {
		other.target = self
	}
}