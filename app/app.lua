---@class Application: Component
---@protected _ctx
---@protected imgDir string
---@protected fontDir string
---@protected fontDefault string
local Application = Component:extend()
local MainScene = require('app.scene.menu')

function Application:new()
    self.super.new(self)
    local graphics = love.graphics
    self._ctx = {}
    self.runTime = 0;
    self.imgDir = "/image/"
    self.fontDir = "/font/"
    self.fontDefault = graphics.newFont(self.fontDir .. "sh.otf", 13)
    graphics.setFont(self.fontDefault)
    graphics.setColor({ 0, 0, 0 })
    graphics.setBackgroundColor(rgba("#FFFFFF"))
    graphics.setDefaultFilter("nearest", "nearest")
    self:addChild(MainScene());
end

function Application:update(dt)
    self.super.update(self, dt);
    self.runTime = self.runTime + dt;
end

function Application:draw()
    self.super.draw(self);
    love.graphics.print("FPS: " .. love.timer.getFPS())
end

function Application:pressed(x, y, button)
end

function Application:mousePressed(x, y, button)
end

function Application:mouseReleased(x, y, button)
end

function Application:textInput(text)
end

function Application:keyPressed(k, code, isrepeat)
end

function Application:keyReleased(k, code, isrepeat)
end

return Application