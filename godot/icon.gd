extends Sprite

# class member variables go here, for example:
# var a = 2
# var b = "textvar"

var timer
const INT_MAX = 2000000


func benchmark(test_name, test_func, test_duration_ms):
	var count = 1
	var total_count = 0
	var func_return = 0
	var st = 0.0
	var sst = 0.0
	var running_time = 0.0
	
	var n = 5
	
	while(true):
		count *= 2
		st = 0.0
		sst = 0.0
		
		for j in range(0,n):
			self.timer.start()
			for i in range(0,count):
				func_return += test_func.call_func(count)
				
			running_time = float(self.timer.elapsed_time())
			var time = running_time / count
			st += time
			sst += (time * time)
			total_count += count
		
		if(running_time >= test_duration_ms or count >= self.INT_MAX):
			break
	
	var mean = st / n
	var standard_deviation = sqrt((sst - mean * mean * n) / (n - 1))
	print(test_name + "\tmean: " + str(mean) + 
		"\tstandard_deviation: " + str(standard_deviation))
	return func_return / total_count

func math_one(input):
	var x = float(input & 0xFF)
	return x * x * x * x * x * x * x * x * x * x * x * x * x * x * x * x * x * x * x * x * x * x * x * x

func math_two(input):
	var x = float(input & 0xFF)
	return pow(x, 20)

func vector2_scale(input):
	var vector = Vector2(input,input) * input
	return vector.x
	
func vector2_mult(input):
	var vector = Vector2(input,input)
	return (vector * vector).x
	
func vector2_translate(input):
	var vector = Vector2(input,input)
	return (vector + vector).x
	
func vector2_subtract(input):
	var vector = Vector2(input,input)
	return (vector - vector).x
	
func vector2_combine(input):
	var vector = Vector2(input,input)
	return vector.length()
	
func vector2_dot(input):
	var vector = Vector2(input,input)
	return vector.dot(vector)
	
func vector3_scale(input):
	var vector = Vector3(input,input,input) * input
	return vector.x
	
func vector3_mult(input):
	var vector = Vector3(input,input,input)
	return (vector * vector).x
	
func vector3_translate(input):
	var vector = Vector3(input,input,input)
	return (vector + vector).x
	
func vector3_subtract(input):
	var vector = Vector3(input,input,input)
	return (vector - vector).x
	
func vector3_combine(input):
	var vector = Vector3(input,input,input)
	return vector.length()
	
func vector3_dot(input):
	var vector = Vector3(input,input,input)
	return vector.dot(vector)

func allocate(input):
	var array = Array()
	array.resize(100000)
	index = char(input)
	return array[input]

func _ready():
	self.timer = load("res://timer.gd").new() 
	self.timer.start()

func _process(delta):
	if(Input.is_key_pressed(KEY_SPACE)):
		print("Starting test")
		benchmark("Math_1", funcref(self, "math_one"), 250)
		
		benchmark("vector_scale", funcref(self, "vector_scale"), 250)
		benchmark("vector_mult", funcref(self, "vector_mult"), 250)
		benchmark("vector_translate", funcref(self, "vector_translate"), 250)
		benchmark("vector_subtract", funcref(self, "vector_subtract"), 250)
		