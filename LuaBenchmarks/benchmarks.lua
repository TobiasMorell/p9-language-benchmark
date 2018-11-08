-- Requirements:
-- LuaSocket-dev    (for time with better precision)
-- lua5.1-bit32-dev (backport of lua5.2 bit32 lib)

-- No int32.max in lua so we just use the raw number from C#
local int32_max = 2147483647

-- Reference to test functions
local testLib = require("tests")
local timerboi = require("timer")
timerboi:New()

local function sToNs(seconds)
    return seconds * 1000000000
end


local function Mark8(message, fun, iterations, minTime)
    local count = 1
    local totalCount = 0
    local dummy = 0.0
    local runningTime = 0.0
    local deltaTime = 0.0
    local deltaTimeSquared = 0.0

    --do..while
    while true do
        count = count * 2
        deltaTime = 0.0
        deltaTimeSquared = 0.0

        for j=0, iterations - 1 do
            --print(j)
            timerboi:Play()

            for i=0, count-1 do
                --print("i: ", i)
                dummy = dummy + fun(i)
            end

            runningTime = timerboi:Check()
            local time = runningTime / count
            deltaTime = deltaTime + time
            deltaTimeSquared = deltaTimeSquared + (time * time)
            totalCount = totalCount + count
        end


        if(runningTime > minTime or count > (int32_max/2)) then
            break
        end
    end

    local mean = deltaTime / iterations
    local standardDeviation = math.sqrt((deltaTimeSquared - mean * mean * iterations) / (iterations -1))

    print(string.format("%s,%.3f,%.3f,%d", message, sToNs(mean), sToNs(standardDeviation), count))

end

print("Beginning Native Lua tests")
print("Test,Mean,Deviation,Count")

Mark8("V2 Scale", testLib.scale2d, 5, 0.250)
Mark8("V3 Scale", testLib.scale, 5, 0.250 )
Mark8("V2 Multi", testLib.multiply2d, 5, 0.250)
Mark8("V3 Multi", testLib.multiply, 5, 0.250 )
Mark8("V2 Trans", testLib.translate2d, 5, 0.250)
Mark8("V3 Trans", testLib.translate, 5, 0.250)
Mark8("V2 Subtr", testLib.subtract2d, 5, 0.250)
Mark8("V3 Subtr", testLib.subtract, 5, 0.250)
Mark8("V2 Lengt", testLib.length2d, 5, 0.250)
Mark8("V3 Lengt", testLib.length, 5, 0.250)
Mark8("V2 Dot  ", testLib.dot2d, 5, 0.250)
Mark8("V3 Dot  ", testLib.dot, 5, 0.250)
Mark8("M memTes", testLib.memTest, 5, 0.250)
Mark8("M primes", testLib.primes, 5, 0.250)
Mark8("M sestof", testLib.sestoft, 5, 0.250)
Mark8("M sesPow", testLib.sestoftPow, 5, 0.250)

print("Tests done")
