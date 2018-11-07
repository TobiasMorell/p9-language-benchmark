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
	print(test_name + "\t" + str(mean) + 
		"\t" + str(standard_deviation) + "\t" + str(count))
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
	
func vector2_length(input):
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
	
func vector3_length(input):
	var vector = Vector3(input,input,input)
	return vector.length()
	
func vector3_dot(input):
	var vector = Vector3(input,input,input)
	return vector.dot(vector)

func allocate(input):
	var array = Array()
	array.resize(100000)
	var index = char(input)
	return len(array) + input
	
func primes(number):
	var realNumber = 100
    
	var A = Array()
	A.resize(realNumber + 1)
	for i in range(2, realNumber + 1):
		A[i] = true

	for i in range(2, sqrt(realNumber)):
		if(A[i]):
			var iPow = int(pow(i, 2))
			var num = 0
			
			var j = 0
			while(j < realNumber):
				j = iPow + num * i
				A[i] = false
				num += 1
				
	var primes = Array ()
	for i in range(2, len(A)):
		if (A[i]):
			primes.append(i);

	return len(primes) & number;

func _ready():
	self.timer = load("res://timer.gd").new() 
	self.timer.start()

func ms_to_ns(ms):
	return ms * 1000000

func _process(delta):
	if(Input.is_key_pressed(KEY_SPACE)):
		print("Starting test")
		
		benchmark("ScaleVector2D", funcref(self, "vector2_scale"), ms_to_ns(250))
		benchmark("ScaleVector3D", funcref(self, "vector3_scale"), ms_to_ns(250))
		benchmark("MultiplyVector2D", funcref(self, "vector2_mult"), ms_to_ns(250))
		benchmark("MultiplyVector3D", funcref(self, "vector3_mult"), ms_to_ns(250))
		benchmark("TranslateVector2D", funcref(self, "vector2_translate"), ms_to_ns(250))
		benchmark("TranslateVector3D", funcref(self, "vector3_translate"), ms_to_ns(250))
		benchmark("SubstractVector2D", funcref(self, "vector2_subtract"), ms_to_ns(250))
		benchmark("SubstractVector3D", funcref(self, "vector3_subtract"), ms_to_ns(250))
		benchmark("LengthVector2D", funcref(self, "vector2_length"), ms_to_ns(250))
		benchmark("LengthVector3D", funcref(self, "vector3_length"), ms_to_ns(250))
		benchmark("DotProduct2D", funcref(self, "vector2_dot"), ms_to_ns(250))
		benchmark("DotProduct3D", funcref(self, "vector3_dot"), ms_to_ns(250))
		benchmark("MemTest", funcref(self, "allocate"), ms_to_ns(250))
		benchmark("Primes", funcref(self, "primes"), ms_to_ns(250))
		
		
		benchmark("Sestoft", funcref(self, "math_one"), ms_to_ns(250))
		benchmark("Sestoft", funcref(self, "math_two"), ms_to_ns(250))