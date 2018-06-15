---@class MainScene :Component
local SUIT = require('lib.suit')
local MainScene = Component:extend()

function MainScene:new()
    self.suit = SUIT:new()
end

function MainScene:draw()
    self:draw()
end

function MainScene:update(dt)
    self.suit:Button("Hello, World!", 100, 100, 300, 30)
end

return MainScene