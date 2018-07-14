---@class Application: Base
---@field protected  _ctx table
---@field protected imgDir string
---@field protected fontDir string
---@field protected fontDefault Font
local Application = Base:extend()
local MenuScene = require('app.scene.menu')
local Gamestate = require "lib.hump.gamestate"
local deep = require('lib.deep')

function Application:new()
    local graphics = love.graphics
    graphics.setDefaultFilter("nearest", "nearest")
    self._ctx = {}
    self.runTime = 0;
    self.imgDir = "/image/"
    self.fontDir = "/font/"
    self.fontDefaultPath = self.fontDir .. "sh.otf"
    self.fontDefault = graphics.newFont(self.fontDefaultPath, 14)
    graphics.setFont(self.fontDefault)
    graphics.setColor({ 0, 0, 0 })
    graphics.setBackgroundColor(rgba("#FFFFFF"))
    self:registerEvents()
    --self:addChild(MainScene());
end

function Application:start()
    Gamestate.switch(MenuScene())
end

---@param scene Component
function Application:switch(scene)
    Gamestate.switch(scene)
end

function Application:registerEvents()
    local all_callbacks = { 'draw', 'update' }
    for k in pairs(love.handlers) do
        all_callbacks[#all_callbacks + 1] = k
    end
    --print(unpack(all_callbacks))
    for _, f in ipairs(all_callbacks) do
        if not self[f] then
            self[f] = function(self, ...)
            end
        end
        print('register event:', f)
        love[f] = function(...)
            Gamestate[f](...)
            return self[f](self, ...)
        end
    end
end

function Application:update(dt)
    --self.super.update(self, dt);
    self.runTime = self.runTime + dt;
end

function Application:draw()
    deep.execute()
    --self.super.draw(self);
    love.graphics.print("FPS: " .. love.timer.getFPS())
    local state = love.graphics.getStats()
    love.graphics.print("draw call: " .. state.drawcalls, 0, 20)
    --love.graphics.print("draw call: " .. state.canvasswitches, 0, 20)
end

return Application