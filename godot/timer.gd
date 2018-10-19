var _start_time

func start():
	self._start_time = OS.get_ticks_msec()

func elapsed_time():
	return (OS.get_ticks_msec() - self._start_time)