-- Requires 'LuaSocket' Library
socket = require("socket")

local M = {}

M.start = 0

function M:New()
    M:Play()
end

function M:Play()
    self.start = socket.gettime()
end

function M:Check()
    return (socket.gettime() - self.start)
end


return M
