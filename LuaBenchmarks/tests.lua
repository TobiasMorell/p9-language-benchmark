--Require vector lib "maf"
local maf = require("maf")
local bit32 = require("bit32")


local  tests = {}

-- ######################
-- # Vector 3 tests     #
-- ######################


function tests.scale(input)
    local v = maf.vector()
    local vScaled = v:scale(input)

    return vScaled.x

end

function tests.multiply(input)
    local v = maf.vector() -- Should be zero initialized
    local v2 = maf.vector(input,input,input)
    local vMult = maf.vector(v.x * v2.x, v.y * v2.y, v.z * v2.z)

    return vMult.x
end

function tests.translate(input)
    local v = maf.vector()
    local v2 = maf.vector(input,input,input)
    local vTranslated = v + v2

    return vTranslated.x
end

function tests.subtract(input)
    local v = maf.vector()
    local v2 = maf.vector(input,input,input)
    local vSub = v2 - v

    return vSub.x
end


function tests.length(input)
    local v = maf.vector(input,input,input)
    return v:length()
end


function tests.dot(input)
    local v = maf.vector()
    local v2 = maf.vector(input,input,input)
    local dot = v:dot(v2)

    return dot
end

-- ######################
-- # Vector 2 tests     #
-- ######################

function tests.scale2d(input)
    local v = maf.vector()
    local vScaled = v:scale(input)

    return vScaled.x

end

function tests.multiply2d(input)
    local v = maf.vector()
    local v2 = maf.vector(input,input)
    local vMult = maf.vector(v.x * v2.x, v.y * v2.y)

    return vMult.x
end

function tests.translate2d(input)
    local v = maf.vector()
    local v2 = maf.vector(input,input)
    local vTranslated = v + v2

    return vTranslated.x
end

function tests.subtract2d(input)
    local v = maf.vector()
    local v2 = maf.vector(input,input)
    local vSub = v2 - v

    return vSub.x
end


function tests.length2d(input)
    local v = maf.vector(input,input)
    return v:length()
end


function tests.dot2d(input)
    local v = maf.vector()
    local v2 = maf.vector(input,input)
    local dot = v:dot(v2)

    return dot
end


-- ######################
-- # Math tests         #
-- ######################

function tests.sestoft(input)
    local d = 1.1 * (bit32.band(input , 0xFF))
    return d * d * d * d * d * d * d * d * d * d * d * d * d * d * d * d * d * d * d * d
end

function tests.sestoftPow(input)
    local d = 1.1 * (bit32.band(input , 0xFF))
    return math.pow(d,20)
end

function tests.primes(input)
    local realNumber = 100

    local A = {}

    for i=2,realNumber+1 do
        A[i] = true
    end

    for i=2,math.sqrt(realNumber+1) do
        if(A[i]) then
            local iPow = math.floor(math.pow(i,2)) --No casting to int, so we use floor
            local num = 0

            for j=0, realNumber, iPow + (num*i) do
                A[i] = false
                num = num +1
            end
        end
    end

    local primes = {}
    for i=2, #A do
        if(A[i]) then
            table.insert(A,i)
        end
    end

    return bit32.band(#A, input)
end


function tests.memTest(input)
    local array = {}
    array[100000] = true

    return (#array + input)
end

return tests
